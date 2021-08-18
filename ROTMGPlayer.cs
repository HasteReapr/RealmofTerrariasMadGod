using ROTMG_Items.Buffs;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using ROTMG_Items;

namespace ROTMG_Items
{
	// ModPlayer classes provide a way to attach data to Players and act on that data. ExamplePlayer has a lot of functionality related to 
	// several effects and items in ExampleMod. See SimpleModPlayer for a very simple example of how ModPlayer classes work.
	public class ROTMGPlayer : ModPlayer
	{
		public bool Lost_Halls;
		public bool moonded;

		public bool t15Breastplate;
		public bool t15Leggings;
		public bool t15Helmet;
		public bool t15SetBonus;
		public bool WarriorBuff;
		public bool DexIncrease;
		public bool AdminCrown;
		public bool SpookyPet;
		public float PermIncrease;
		public float GPermIncrease;
		public bool examplePersonGiftReceived;
		public bool Unstable = false;
		
		public const int maxLifePot = 20;
		public int LifePot;
		public const int maxManaPot = 5;
		public int ManaPot;
		public const int maxDexPot = 5;
		public int DexPot;
		public const int maxDefPot = 10;
		public int DefPot;
		public const int maxAttPot = 10;
		public int AttPot;
		public const int maxSpdPot = 10;
		public int SpdPot;
		public const int maxVitPot = 10;
		public int VitPot;
		public const int maxWisPot = 10;
		public int WisPot;

		public const int maxGLifePot = 20;
		public int GLifePot;
		public const int maxGManaPot = 5;
		public int GManaPot;
		public const int maxGDexPot = 5;
		public int GDexPot;
		public const int maxGDefPot = 10;
		public int GDefPot;
		public const int maxGAttPot = 10;
		public int GAttPot;
		public const int maxGSpdPot = 10;
		public int GSpdPot;
		public const int maxGVitPot = 10;
		public int GVitPot;
		public const int maxGWisPot = 10;
		public int GWisPot;

		public bool ZoneExample;

		public override float UseTimeMultiplier(Item item)
		{
			if (DexIncrease == true) 
			{ 
				return DexIncrease ? 1.75f : 1f;
			}
			if (AdminCrown == true)
			{
				return AdminCrown ? 9000f : 1f;
			}
			if (t15SetBonus == true)
            {
				return t15SetBonus ? 1.8f : 1f;
            }
			if (WarriorBuff == true)
            {
				return WarriorBuff ? 1.75f : 1f;
            }
			if (t15Breastplate == true)
            {
				return t15Breastplate ? 1.1f : 1f;
            }
			if (t15Leggings == true)
            {
				return t15Leggings ? 1.1f : 1f;
            }
			if (t15Helmet == true)
            {
				return t15Helmet ? 1.1f : 1f;
            }
			if (GDexPot > 1)
            {
				return 1f + GDexPot * 0.05f;
            }
			if (DexPot > 1)
			{
				return 1f + DexPot * 0.05f;
				// GPermIncrease += GDexPot * 0.05f;
				// return GPermIncrease;
			}
			return DexIncrease ? 1f : 1f;
		}
		public override void ResetEffects()
		{
			player.statLifeMax2 += LifePot * 20;
			AbilityPowerRegenRate = 1f + WisPot * 0.75f;
			player.statDefense += DefPot * 1;
			player.lifeRegen += VitPot * 1;
			player.moveSpeed += SpdPot * 0.05f;
			player.allDamage += AttPot * 0.05f;
			player.statLifeMax2 += GLifePot * 20;
			AbilityPowerMax = 100 + (GManaPot * 20) + (ManaPot * 20);
			AbilityPowerRegenRate = 1f + GWisPot * 0.75f;
			player.statDefense += GDefPot * 1;
			player.lifeRegen += GVitPot * 1;
			player.moveSpeed += GSpdPot * 0.05f;
			player.allDamage += GAttPot * 0.05f;
			
			AdminCrown = false;
			Unstable = false;
			DexIncrease = false;
			WarriorBuff = false;
			SpookyPet = false;
			t15Breastplate = false;
			t15Helmet = false;
			t15Leggings = false;
			t15SetBonus = false;
		}
		public override void clientClone(ModPlayer clientClone)
		{
			ROTMGPlayer clone = clientClone as ROTMGPlayer;
			// Here we would make a backup clone of values that are only correct on the local players Player instance.
			// Some examples would be RPG stats from a GUI, Hotkey states, and Extra Item Slots
			clone.player.statLifeMax2 += LifePot * 20;
			clone.player.statDefense += DefPot * 1;
			clone.player.lifeRegen += VitPot * 1;
			clone.AbilityPowerRegenRate = 1 + WisPot * 0.65f;
			clone.player.moveSpeed += SpdPot * 0.05f;
			clone.player.allDamage += AttPot * 0.05f;
			clone.player.statLifeMax2 += GLifePot * 20;
			clone.AbilityPowerMax = 100 + (GManaPot * 20) + (ManaPot * 20);
			clone.player.statDefense += GDefPot * 1;
			clone.player.lifeRegen += GVitPot * 1;
			clone.AbilityPowerRegenRate = 1 + GWisPot * 0.65f;
			clone.player.moveSpeed += GSpdPot * 0.05f;
			clone.player.allDamage += GAttPot * 0.05f;
		}
		public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
		{
			ModPacket packet = mod.GetPacket();
			packet.Write((byte)ROTMGModMessageType.ROTMGPlayerSyncPlayer);
			packet.Write((byte)SyncPlayerMessage.Potions);
			packet.Write((byte)player.whoAmI);
			packet.Write(LifePot);
			packet.Write(ManaPot);
			packet.Write(DefPot);
			packet.Write(AttPot);
			packet.Write(DexPot);
			packet.Write(SpdPot);
			packet.Write(VitPot);
			packet.Write(WisPot);
			packet.Write(GLifePot);
			packet.Write(GManaPot);
			packet.Write(GDefPot);
			packet.Write(GAttPot);
			packet.Write(GDexPot);
			packet.Write(GSpdPot);
			packet.Write(GVitPot);
			packet.Write(GWisPot);
			packet.Write(AbilityPowerCurrent);
			packet.Write(AbilityPowerMax);
			packet.Write(AbilityPowerRegen);
			packet.Write(AbilityPowerRegenTimer);
			packet.Write(AbilityPowerRegenRate);
			packet.Write(moonded);
			packet.Send(toWho, fromWho);
		}
		public override void SendClientChanges(ModPlayer clientPlayer)
		{
			// Here we would sync something like an RPG stat whenever the player changes it.
			ROTMGPlayer clone = clientPlayer as ROTMGPlayer;
		}

        /*public override bool ModifyNurseHeal(NPC nurse, ref int health, ref bool removeDebuffs, ref string chatText)
		{
			AbilityPowerCurrent = AbilityDefaultMax;
			return base.ModifyNurseHeal(nurse, ref health, ref removeDebuffs, ref chatText);
		}*/
        public override void UpdateBiomes()
        {
			Lost_Halls = TheWorld.Lost_Blocks >= 50;
        }

        public override bool CustomBiomesMatch(Player other)
        {
			ROTMGPlayer modOther = other.GetModPlayer<ROTMGPlayer>();
			return Lost_Halls = modOther.Lost_Halls;
        }

        public override void CopyCustomBiomesTo(Player other)
        {
			ROTMGPlayer modOther = other.GetModPlayer<ROTMGPlayer>();
			modOther.Lost_Halls = Lost_Halls;
		}

        public override void ReceiveCustomBiomes(BinaryReader reader)
        {
			BitsByte flags = reader.ReadByte();
			Lost_Halls = flags[0];
		}
        public override Texture2D GetMapBackgroundImage()
        {
			if (Lost_Halls == true)
			{
				return mod.GetTexture("Backgrounds/Lost_Background");
			}
			else return null;
        }

		public override TagCompound Save()
		{
			// Read https://github.com/tModLoader/tModLoader/wiki/Saving-and-loading-using-TagCompound to better understand Saving and Loading data.
			return new TagCompound {
				// {"somethingelse", somethingelse}, // To save more data, add additional lines
				{"LifePot", LifePot},
				{"ManaPot", ManaPot},
				{"VitPot", VitPot},
				{"WisPot", WisPot},
				{"SpdPot", SpdPot},
				{"DefPot", DefPot},
				{"DexPot", DexPot},
				{"AttPot", AttPot},
				{"GLifePot", GLifePot},
				{"GManaPot", GManaPot},
				{"GVitPot", GVitPot},
				{"GWisPot", GWisPot},
				{"GSpdPot", GSpdPot},
				{"GDefPot", GDefPot},
				{"GDexPot", GDexPot},
				{"GAttPot", GAttPot},
				{"AbilityPowerMax", AbilityPowerMax},
				{"AbilityPowerCurrent", AbilityPowerCurrent},
				{"AbilityPowerRegen", AbilityPowerRegen},
				{"AbilityPowerRegenTimer", AbilityPowerRegenTimer},
				{"AbilityPowerRegenRate", AbilityPowerRegenRate},
				{"moonded", moonded},
			};
		}
		public override void Load(TagCompound tag)
		{
			LifePot = tag.GetInt("LifePot");
			ManaPot = tag.GetInt("ManaPot");
			VitPot = tag.GetInt("VitPot");
			WisPot = tag.GetInt("WisPot");
			SpdPot = tag.GetInt("SpdPot");
			DefPot = tag.GetInt("DefPot");
			DexPot = tag.GetInt("DexPot");
			AttPot = tag.GetInt("AttPot");
			GLifePot = tag.GetInt("GLifePot");
			GManaPot = tag.GetInt("GManaPot");
			GVitPot = tag.GetInt("GVitPot");
			GWisPot = tag.GetInt("GWisPot");
			GSpdPot = tag.GetInt("GSpdPot");
			GDefPot = tag.GetInt("GDefPot");
			GDexPot = tag.GetInt("GDexPot");
			GAttPot = tag.GetInt("GAttPot");
			AbilityPowerMax = tag.GetInt("AbilityPowerMax");
			AbilityPowerRegen = tag.GetFloat("AbilityPowerRegen");
			AbilityPowerCurrent = tag.GetInt("AbilityPowerCurrent");
			AbilityPowerRegenTimer = tag.GetFloat("AbilityPowerRegenTimer");
			AbilityPowerRegenRate = tag.GetFloat("AbilityPowerRegenRate");
			moonded = tag.GetBool("moonded");
		}
		public float Unstabled = Main.rand.Next(100) + 1f;
        public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Unstable == true)
            {
				speedX = Main.rand.Next(-100, 100) +1;
				speedY = Main.rand.Next(-100, 100) +1;
			}
            return base.Shoot(item, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        internal enum SyncPlayerMessage : byte
		{
			Potions,
		}
		internal enum ROTMGModMessageType : byte
		{
			ROTMGPlayerSyncPlayer,
			SyncPlayerMessage,
			NonStopPartyChanged,
			AbilityPowerMax,
			AbilityPowerMax2,
			AbilityPowerRegen,
			AbilityPowerRegenTimer,
			AbilityPowerRegenRate,
		}
		// Ability power code. Don't fuck this up.
		public int AbilityPowerCurrent;
		public const int AbilityDefaultMax = 100;
		public int AbilityPowerMax;
		public float AbilityPowerRegen = 180;
		internal float AbilityPowerRegenTimer = 0;
		public float AbilityPowerRegenRate = 1f;
		public static readonly Color HealAbilityPower = new Color(255, 128, 0);
		// Add this to SendClientChanges and ClientClone too, Add the packet data too
		// DONT FORGET THIS IT WILL CAUSE IMMENSE LAG!!!
		// Add Save/Load for increasing the max.
		// Add a replinishment item so you can recover it mid fight.
		// Lets do all our logic for the custom resource here, such as limiting it, increasing it and so on.

		public override void PostUpdate()
		{
			HandleAP();
		}
		private void HandleAP()
		{
			//The recharge timer is how many regen timers fit inside of it, so if the recharge timer is 60,
			//and regen timer is 1, you regen 1 per second. If recharge timer is 60, and regen timer is 1.2, you regenerate 1.2 per second
			AbilityPowerRegenTimer += AbilityPowerRegenRate; // this a float that defaults to 1. Increasing to 1.2 will increase regen by 20%
			if (AbilityPowerRegenTimer >= AbilityPowerRegen)
			{
				AbilityPowerRegenTimer = 0;
				if (AbilityPowerCurrent < AbilityPowerMax)
				{
					AbilityPowerCurrent += 3;
				}
			}
			if (AbilityPowerCurrent > AbilityPowerMax)
			{
				AbilityPowerCurrent = AbilityPowerMax;
			}
		}
		public override void Initialize()
		{
			AbilityPowerCurrent = AbilityDefaultMax;
			AbilityPowerMax = AbilityDefaultMax;
		}

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
			if (player.HasBuff(ModContent.BuffType<Invulnerable>()))
            {
				return false;
            }
			return true;
		}

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
			if(player.HasBuff(ModContent.BuffType<VoidSickness>()))
            {
				damageSource = PlayerDeathReason.ByCustomReason($"{nameof(player)} was consumed by the void.");
				return base.PreKill(damage, hitDirection, pvp, ref playSound, ref genGore, ref damageSource);
			}
            else
            {
				return base.PreKill(damage, hitDirection, pvp, ref playSound, ref genGore, ref damageSource);
			}
        }
    }
}
