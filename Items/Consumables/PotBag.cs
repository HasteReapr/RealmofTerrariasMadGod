using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace ROTMG_Items.Items.Consumables
{
	public class PotBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pot Bag");
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
			if (randomPot == 1){
				player.QuickSpawnItem(ModContent.ItemType<WisPot>());
			}
			if (randomPot == 2){
				player.QuickSpawnItem(ModContent.ItemType<VitPot>());
			}
			if (randomPot == 3){
				player.QuickSpawnItem(ModContent.ItemType<DexPot>());
			}
			if (randomPot == 4){
				player.QuickSpawnItem(ModContent.ItemType<AttPot>());
			}
			if (randomPot == 5){
				player.QuickSpawnItem(ModContent.ItemType<DefPot>());
			}
			if (randomPot == 6){
				player.QuickSpawnItem(ModContent.ItemType<SpdPot>());
			}
			if (randomPot == 7){
				RarePot = Main.rand.Next(0, 2);
				if (RarePot == 0)
				{
					player.QuickSpawnItem(ModContent.ItemType<ManaPot>());
				}else if (RarePot == 1)
                {
					player.QuickSpawnItem(ModContent.ItemType<LifePot>());
				}
			}
			/* int randomPot = new WeightedRandom<int>(
			Tuple.Create(ModContent.ItemType<WisPot>(), 1.25),
			Tuple.Create(ModContent.ItemType<VitPot>(), 1.25),
			Tuple.Create(ModContent.ItemType<DexPot>(), 1.25),
			Tuple.Create(ModContent.ItemType<DefPot>(), 1.25),
			Tuple.Create(ModContent.ItemType<SpdPot>(), 1.25),
			Tuple.Create(ModContent.ItemType<AttPot>(), 1.25),
			Tuple.Create(ModContent.ItemType<LifePot>(), 0.5),
			Tuple.Create(ModContent.ItemType<ManaPot>(), 1.0)
			);
			if (randomPot > 0)
			{
				Item.NewItem(player.getRect(), randomPot);
			} */
		}
	}

}