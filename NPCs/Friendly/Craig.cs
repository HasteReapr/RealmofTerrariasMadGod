using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using ROTMG_Items.Items;
using Terraria.Utilities;
using ROTMG_Items.Items.Abilities;
using System;
using System.Linq;
using System.Collections.Generic;
using ROTMG_Items.Items.Consumables;
using ROTMG_Items.Items.Weapons.Projectiles;

namespace ROTMG_Items.NPCs.Friendly
{
	// [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class Craig : ModNPC
	{
		public const double despawnTime = 48600.0;

		public static double spawnTime = double.MaxValue;

		public static List<Item> shopItems = new List<Item>();

		public static NPC FindNPC(int npcType) => Main.npc.FirstOrDefault(npc => npc.type == npcType && npc.active);

		public override string Texture => "ROTMG_Items/NPCs/Friendly/Craig";

		public override string[] AltTextures => new[] { "ROTMG_Items/NPCs/Friendly/Craig_Default_Party" };

		public override bool Autoload(ref string name)
		{
			name = "Craig";
			return mod.Properties.Autoload;
		}
		public static void UpdateTravelingMerchant()
		{
			NPC traveler = FindNPC(ModContent.NPCType<Craig>()); // Find an Explorer if there's one spawned in the world
			if (traveler != null && (!Main.dayTime || Main.time >= despawnTime) && !IsNpcOnscreen(traveler.Center)) // If it's past the despawn time and the NPC isn't onscreen
			{
				// Here we despawn the NPC and send a message stating that the NPC has despawned
				if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText(traveler.FullName + " has departed!", 50, 125, 255);
				else NetMessage.BroadcastChatMessage(NetworkText.FromLiteral(traveler.FullName + " has departed!"), new Color(50, 125, 255));
				traveler.active = false;
				traveler.netSkip = -1;
				traveler.life = 0;
				traveler = null;
			}

			// Main.time is set to 0 each morning, and only for one update. Sundialling will never skip past time 0 so this is the place for 'on new day' code
			if (Main.dayTime && Main.time == 0)
			{
				// insert code here to change the spawn chance based on other conditions (say, npcs which have arrived, or milestones the player has passed)
				// You can also add a day counter here to prevent the merchant from possibly spawning multiple days in a row.

				// NPC won't spawn today if it stayed all night
				if (traveler == null && Main.rand.NextBool(4))
				{ // 4 = 25% Chance
				  // Here we can make it so the NPC doesnt spawn at the EXACT same time every time it does spawn
					spawnTime = GetRandomSpawnTime(5400, 8100); // minTime = 6:00am, maxTime = 7:30am
				}
				else
				{
					spawnTime = double.MaxValue; // no spawn today
				}
			}

			// Spawn the traveler if the spawn conditions are met (time of day, no events, no sundial)
			if (traveler == null && CanSpawnNow())
			{
				int newTraveler = NPC.NewNPC(Main.spawnTileX * 16, Main.spawnTileY * 16, ModContent.NPCType<Craig>(), 1); // Spawning at the world spawn
				traveler = Main.npc[newTraveler];
				traveler.homeless = true;
				traveler.direction = Main.spawnTileX >= WorldGen.bestX ? -1 : 1;
				traveler.netUpdate = true;

				// Prevents the traveler from spawning again the same day
				spawnTime = double.MaxValue;

				// Annouce that the traveler has spawned in!
				if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText(Language.GetTextValue("Announcement.HasArrived", traveler.FullName), 50, 125, 255);
				else NetMessage.BroadcastChatMessage(NetworkText.FromKey("Announcement.HasArrived", traveler.GetFullNetName()), new Color(50, 125, 255));
			}
		}

		private static bool CanSpawnNow()
		{
			// can't spawn if any events are running
			if (Main.eclipse || Main.invasionType > 0 && Main.invasionDelay == 0 && Main.invasionSize > 0)
				return false;

			// can't spawn if the sundial is active
			if (Main.fastForwardTime)
				return false;

			// can spawn if daytime, and between the spawn and despawn times
			return Main.dayTime && Main.time >= spawnTime && Main.time < despawnTime;
		}

		private static bool IsNpcOnscreen(Vector2 center)
		{
			int w = NPC.sWidth + NPC.safeRangeX * 2;
			int h = NPC.sHeight + NPC.safeRangeY * 2;
			Rectangle npcScreenRect = new Rectangle((int)center.X - w / 2, (int)center.Y - h / 2, w, h);
			foreach (Player player in Main.player)
			{
				// If any player is close enough to the traveling merchant, it will prevent the npc from despawning
				if (player.active && player.getRect().Intersects(npcScreenRect)) return true;
			}
			return false;
		}

		public static double GetRandomSpawnTime(double minTime, double maxTime)
		{
			// A simple formula to get a random time between two chosen times
			return (maxTime - minTime) * Main.rand.NextDouble() + minTime;
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

		// Example Person needs a house built out of ExampleMod tiles. You can delete this whole method in your townNPC for the regular house conditions.

		public override string TownNPCName()
		{
			return "";
		}

		// Consider using this alternate approach to choosing a random thing. Very useful for a variety of use cases.
		// The WeightedRandom class needs "using Terraria.Utilities;" to use
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();
			chat.Add("I sometimes get lost in my portals and end up in places like this!");
			chat.Add("Wait, you know Oryx?");
			chat.Add("...", 0.01);
			//chat.Add("This message has a weight of 5, meaning it appears 5 times more often.", 5.0);
			chat.Add("Have you tried nexusing?");
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
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<GDexPot>());
				shop.item[nextSlot].shopCustomPrice = 1000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<GAttPot>());
				shop.item[nextSlot].shopCustomPrice = 1000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<GSpdPot>());
				shop.item[nextSlot].shopCustomPrice = 1000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<GDefPot>());
				shop.item[nextSlot].shopCustomPrice = 1000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<GVitPot>());
				shop.item[nextSlot].shopCustomPrice = 1000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<GWisPot>());
				shop.item[nextSlot].shopCustomPrice = 1000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<GManaPot>());
				shop.item[nextSlot].shopCustomPrice = 10000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<GLifePot>());
				shop.item[nextSlot].shopCustomPrice = 10000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<DexPot>());
				shop.item[nextSlot].shopCustomPrice = 100;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<AttPot>());
				shop.item[nextSlot].shopCustomPrice = 100;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<SpdPot>());
				shop.item[nextSlot].shopCustomPrice = 100;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<DefPot>());
				shop.item[nextSlot].shopCustomPrice = 100;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<VitPot>());
				shop.item[nextSlot].shopCustomPrice = 100;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<WisPot>());
				shop.item[nextSlot].shopCustomPrice = 100;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ManaPot>());
				shop.item[nextSlot].shopCustomPrice = 1000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<LifePot>());
				shop.item[nextSlot].shopCustomPrice = 1000;
				shop.item[nextSlot].shopSpecialCurrency = ROTMG_Items.FaceCustomCurrencyId;
				nextSlot++;
			if (Main.LocalPlayer.HasBuff(ModContent.BuffType<Buffs.Healing>()))
			{
				shop.item[nextSlot].SetDefaults(ItemID.SuperHealingPotion);
				nextSlot++;
			}
			else
			{
				shop.item[nextSlot].SetDefaults(ItemID.GreaterHealingPotion);
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

		public static TagCompound Save()
		{
			return new TagCompound
			{
				["spawnTime"] = spawnTime,
				["shopItems"] = shopItems
			};
		}

		public static void Load(TagCompound tag)
		{
			spawnTime = tag.GetDouble("spawnTime");
			shopItems = tag.Get<List<Item>>("shopItems");
		}


		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			return false; // This should always be false, because we spawn in the Travleing Merchant manually
		}

        public override void AI()
        {
			npc.homeless = true;	
        }
    }
}