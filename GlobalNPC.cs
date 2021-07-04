using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using ROTMG_Items.Items;

namespace ROTMG_Items
{
	public class ROTMG_NPCs : GlobalNPC
	{
		public override bool InstancePerEntity => true;

		public override void NPCLoot(NPC npc)
		{
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
			if (NPC.downedMoonlord)
            {
				int majesty = Main.rand.Next(500) + 1;
				if(majesty == 1)
                {
					Item.NewItem(npc.getRect(), ModContent.ItemType<Majesty>(), 1);
                }
            }*/
			int SUSSWORD = Main.rand.Next(599);
			if (SUSSWORD == 1)
            {
				Item.NewItem(npc.getRect(), ModContent.ItemType<ColoSus>(), 1);
            }
			int PotBag = Main.rand.Next(99);
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