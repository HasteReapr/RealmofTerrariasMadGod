using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using ROTMG_Items.Items;
using System.Collections.Generic;
using ROTMG_Items.Items.Consumables;
using ROTMG_Items.Items.Weapons;

namespace ROTMG_Items
{
	public class ROTMG_NPCs : GlobalNPC
	{
		public override bool InstancePerEntity => true;

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if(player.GetModPlayer<ROTMGPlayer>().Lost_Halls == true)
            {
				if (player.GetModPlayer<ROTMGPlayer>().moonded == false)
				{
					spawnRate += 40;
					maxSpawns = 20;
				}
				else if(player.GetModPlayer<ROTMGPlayer>().moonded == true)
				{
					spawnRate += 5;
					maxSpawns = 50;
				}
            }
			if(player.GetModPlayer<ROTMGPlayer>().SpriteWorld == true)
            {
				spawnRate *= 2;
				maxSpawns = 100;
            }
        }
        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
			if (spawnInfo.player.GetModPlayer<ROTMGPlayer>().Lost_Halls == true && spawnInfo.player.GetModPlayer<ROTMGPlayer>().moonded == false)
            {
				pool.Clear();
				pool.Add(ModContent.NPCType<NPCs.SpookyBoi>(), 1f);
            }else if(spawnInfo.player.GetModPlayer<ROTMGPlayer>().Lost_Halls == true && spawnInfo.player.GetModPlayer<ROTMGPlayer>().moonded == true)
            {
				pool.Clear();
            }
			if(spawnInfo.player.GetModPlayer<ROTMGPlayer>().SpriteWorld == true)
            {
				pool.Clear();
				pool.Add(ModContent.NPCType<NPCs.Hostile.Sprites.SpriteKnight>(), 0.5f);
				pool.Add(ModContent.NPCType<NPCs.Hostile.Sprites.SpriteSpearer>(), 0.5f);
			}
		}
        public override void NPCLoot(NPC npc)
		{
			if(npc.type == NPCID.SkeletronHead)
            {
				Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Materials.GreaterEssence>(), 1);
			}
			if(npc.type == NPCID.WallofFlesh)
            {
				Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Materials.UnholyEssence>(), 1);
			}
			if(npc.type == NPCID.SkeletronPrime || npc.type == NPCID.Spazmatism || npc.type == NPCID.Retinazer || npc.type == NPCID.TheDestroyer)
            {
				Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Materials.MechanicalEssence>(), 1);
			}
			if(npc.type == NPCID.Plantera)
            {
				Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Materials.HerbalEssence>(), 1);
			}
			if(npc.type == NPCID.MoonLordCore)
            {
				Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Materials.LunarEssence>(), 1);
			}

			if(npc.type == NPCID.CultistBoss)
            {
                if (Main.expertMode)
                {
					if (Main.rand.NextBool(100))
					{
						Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Abilities.Oreo>(), 1);
					}
				}
				else if (Main.rand.NextBool(200))
                {
					Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Abilities.Oreo>(), 1);
                }
            }

			Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Currency.XPDrop>(), 1);

			if(NPC.downedPlantBoss == true)
            {
				int acclaim = Main.rand.Next(300) + 1;
				if(acclaim == 1)
                {
					Item.NewItem(npc.getRect(), ModContent.ItemType<t12WeaponBag>(), 1);
                }
            }
            /*if (NPC.downedGolemBoss)
            {
				int splendor = Main.rand.Next(400) + 1;
				if(splendor == 1)
                {
					Item.NewItem(npc.getRect(), ModContent.ItemType<Splendor>(), 1);
                }
            }
			if (NPC.downedMoonlord) // do some sort of t13 and t14 weapon bag eventually.
            {
				int majesty = Main.rand.Next(500) + 1;
				if(majesty == 1)
                {
					Item.NewItem(npc.getRect(), ModContent.ItemType<Majesty>(), 1);
                }
            }*/
			int SUSSWORD = Main.rand.Next(1999);
			if (SUSSWORD == 1)
            {
				Item.NewItem(npc.getRect(), ModContent.ItemType<ColoSus>(), 1);
            }
			int PotBag = Main.rand.Next(299);
			if (PotBag == 1)
			{
				Item.NewItem(npc.getRect(), ModContent.ItemType<PotBag>(), 1);
			}
			else return;
			if (Main.hardMode)
			{
				int GPotBag = Main.rand.Next(199);
				if (GPotBag == 1)
				{
					Item.NewItem(npc.getRect(), ModContent.ItemType<GPotBag>(), 1);
				}
				else return;
			}
			if (Main.LocalPlayer.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent < Main.LocalPlayer.GetModPlayer<ROTMGPlayer>().AbilityPowerMax)
            {
				int star;
				star = Main.rand.Next(5);
				if(star == 2)
                {
					Item.NewItem(npc.getRect(), ModContent.ItemType<AbilityRegenStar>(), 1);
                }
				
            }
		}
	}
}