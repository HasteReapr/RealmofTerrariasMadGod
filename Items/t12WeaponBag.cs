using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace ROTMG_Items.Items
{
	public class t12WeaponBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("T12 Weapon Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}" + "This can drop any tier 12 weapon.");
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

		public override void RightClick(Player player)
		{
			int randomPot = new WeightedRandom<int>(
			Tuple.Create(ModContent.ItemType<Acclaim>(), 0.16),
			//Tuple.Create(ModContent.ItemType<Foul>(), 0.16),
			Tuple.Create(ModContent.ItemType<CWhole>(), 0.16),
			Tuple.Create(ModContent.ItemType<Recomp>(), 0.16),
			//Tuple.Create(ModContent.ItemType<Masa>(), 0.16),
			Tuple.Create(ModContent.ItemType<Covert>(), 0.16)
);
			if (randomPot > 0)
			{
				Item.NewItem(player.getRect(), randomPot);
			}
		}
	}

}