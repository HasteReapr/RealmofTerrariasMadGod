using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using ROTMG_Items.Items;
using Terraria.Utilities;
using ROTMG_Items.Items.Abilities;
using System;
using ROTMG_Items.Items.Consumables;
using ROTMG_Items.Items.Weapons;
using ROTMG_Items.Items.Weapons.Projectiles;

namespace ROTMG_Items.NPCs.Friendly
{
	// [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class Guill : ModNPC
	{
		public override string Texture => "ROTMG_Items/NPCs/Friendly/Guill";

		public override string[] AltTextures => new[] { "ROTMG_Items/NPCs/Friendly/Guill_Default_Party" };

		public override bool Autoload(ref string name)
		{
			name = "Guill";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
			// DisplayName.SetDefault("Example Person");
			Main.npcFrameCount[npc.type] = 23;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Mechanic;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, DustID.CorruptionThorns);
			}
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (!player.active)
				{
					continue;
				}
			}
			return false;
		}

		public override string TownNPCName()
		{
			return "";
		}

		public override void FindFrame(int frameHeight)
		{
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}



		// Consider using this alternate approach to choosing a random thing. Very useful for a variety of use cases.
		// The WeightedRandom class needs "using Terraria.Utilities;" to use
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();
			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4))
			{
				chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?");
			}
			chat.Add("You want to hear my Oryx impression?");
			chat.Add("Wait, you know you can do that in the Nexus, right?");
			chat.Add("You have 8 stats! Life, mana, attack, defense, speed, dexterity, wisdom and vitality.");
			//chat.Add("This message has a weight of 5, meaning it appears 5 times more often.", 5.0);
			chat.Add("Hm, a random class? What about… wait what are classes?", 0.1);
			return chat; // chat is implicitly cast to a string. You can also do "return chat.Get();" if that makes you feel better
		}


		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				// We want 3 different functionalities for chat buttons, so we use HasItem to change button 1 between a shop and upgrade action.
				shop = true;
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			if (Main.LocalPlayer.HasItem(ModContent.ItemType<GPotBag>())){
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<GDexPot>());
				shop.item[nextSlot].shopCustomPrice = 10000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<GAttPot>());
				shop.item[nextSlot].shopCustomPrice = 10000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<GSpdPot>());
				shop.item[nextSlot].shopCustomPrice = 10000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<GDefPot>());
				shop.item[nextSlot].shopCustomPrice = 10000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<GVitPot>());
				shop.item[nextSlot].shopCustomPrice = 10000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<GWisPot>());
				shop.item[nextSlot].shopCustomPrice = 10000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<GManaPot>());
				shop.item[nextSlot].shopCustomPrice = 100000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<GLifePot>());
				shop.item[nextSlot].shopCustomPrice = 100000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;
			}
			else 
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<DexPot>());
				shop.item[nextSlot].shopCustomPrice = 1000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<AttPot>());
				shop.item[nextSlot].shopCustomPrice = 1000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<SpdPot>());
				shop.item[nextSlot].shopCustomPrice = 1000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<DefPot>());
				shop.item[nextSlot].shopCustomPrice = 1000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<VitPot>());
				shop.item[nextSlot].shopCustomPrice = 1000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<WisPot>());
				shop.item[nextSlot].shopCustomPrice = 1000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ManaPot>());
				shop.item[nextSlot].shopCustomPrice = 10000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<LifePot>());
				shop.item[nextSlot].shopCustomPrice = 10000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;
			}
			if (Main.LocalPlayer.HasBuff(ModContent.BuffType<Buffs.Healing>()))
			{
				shop.item[nextSlot].SetDefaults(ItemID.GreaterHealingPotion);
				nextSlot++;
            }
            else
            {
				shop.item[nextSlot].SetDefaults(ItemID.LesserHealingPotion);
				nextSlot++;
			}
			/*if (Main.moonPhase < 2)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleSword>());
				nextSlot++;
			}
			else if (Main.moonPhase < 4)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleGun>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.ExampleBullet>());
				nextSlot++;
			}
			else if (Main.moonPhase < 6)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ExampleStaff>());
				nextSlot++;
			}
			else
			{
			}*/
			// Here is an example of how your npc can sell items from other mods.
			var modSummonersAssociation = ModLoader.GetMod("SummonersAssociation");
			if (modSummonersAssociation != null)
			{
				shop.item[nextSlot].SetDefaults(modSummonersAssociation.ItemType("BloodTalisman"));
				nextSlot++;
			}
		}

		public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), ModContent.ItemType<ColoSus>());
		}

		// Make this Town NPC teleport to the King and/or Queen statue when triggered.
		public override bool CanGoToStatue(bool toKingStatue)
		{
			return true;
		}

		// Make something happen when the npc teleports to a statue. Since this method only runs server side, any visual effects like dusts or gores have to be synced across all clients manually.
		public override void OnGoToStatue(bool toKingStatue)
		{
			if (Main.netMode == NetmodeID.Server)
			{
				ModPacket packet = mod.GetPacket();
				packet.Write((byte)npc.whoAmI);
				packet.Send();
			}
			else
			{
				StatueTeleport();
			}
		}

		// Create a square of pixels around the NPC on teleport.
		public void StatueTeleport()
		{
			for (int i = 0; i < 30; i++)
			{
				Vector2 position = Main.rand.NextVector2Square(-20, 21);
				if (Math.Abs(position.X) > Math.Abs(position.Y))
				{
					position.X = Math.Sign(position.X) * 20;
				}
				else
				{
					position.Y = Math.Sign(position.Y) * 20;
				}
				Dust.NewDustPerfect(npc.Center + position, DustID.CorruptionThorns, Vector2.Zero).noGravity = true;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 40;
			knockback = 8f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ModContent.ProjectileType<Majesty_Shot>();
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 0.5f;
		}
	}
}