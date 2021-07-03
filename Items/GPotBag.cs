using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace ROTMG_Items.Items
{
	public class GPotBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Greater Pot Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = ItemRarityID.Purple;
		}
		public override bool CanRightClick()
		{
			return true;
		}
		public float randomPot = Main.rand.Next(1, 8);
		public float RarePot;
		public override void RightClick(Player player)
		{
			randomPot = Main.rand.Next(1, 8);
			if (randomPot == 1)
			{
				player.QuickSpawnItem(ModContent.ItemType<GWisPot>());
			}
			if (randomPot == 2)
			{
				player.QuickSpawnItem(ModContent.ItemType<GVitPot>());
			}
			if (randomPot == 3)
			{
				player.QuickSpawnItem(ModContent.ItemType<GDexPot>());
			}
			if (randomPot == 4)
			{
				player.QuickSpawnItem(ModContent.ItemType<GAttPot>());
			}
			if (randomPot == 5)
			{
				player.QuickSpawnItem(ModContent.ItemType<GDefPot>());
			}
			if (randomPot == 6)
			{
				player.QuickSpawnItem(ModContent.ItemType<GSpdPot>());
			}
			if (randomPot == 7)
			{
				RarePot = Main.rand.Next(0, 2);
				if (RarePot == 0)
				{
					player.QuickSpawnItem(ModContent.ItemType<GManaPot>());
				}
				else if (RarePot == 1)
				{
					player.QuickSpawnItem(ModContent.ItemType<GLifePot>());
				}
			}
			/*int randomGPot = new WeightedRandom<int>(
			Tuple.Create(ModContent.ItemType<GWisPot>(), 1.25),
			Tuple.Create(ModContent.ItemType<GVitPot>(), 1.25),
			Tuple.Create(ModContent.ItemType<GDexPot>(), 1.25),
			Tuple.Create(ModContent.ItemType<GDefPot>(), 1.25),
			Tuple.Create(ModContent.ItemType<GSpdPot>(), 1.25),
			Tuple.Create(ModContent.ItemType<GAttPot>(), 1.25),
			Tuple.Create(ModContent.ItemType<GLifePot>(), 0.5),
			Tuple.Create(ModContent.ItemType<GManaPot>(), 1.0)
);
			if (randomGPot > 0)
			{
				Item.NewItem(player.getRect(), randomGPot);
			}*/
		}
	}

}