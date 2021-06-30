using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items
{
	public class GDefPot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Potion of Greater Defense");
			Tooltip.SetDefault("Permanetly increases defense by 1.");
		}

		public override void SetDefaults()
		{
			item.width = 10;
			item.height = 13;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useTurn = true;
			item.UseSound = SoundID.Item3;
			item.maxStack = 16;
			item.consumable = true;
			item.rare = ItemRarityID.Orange;
			item.value = Item.buyPrice(gold: 1);
		}
		public override bool CanUseItem(Player player) => player.GetModPlayer<ROTMGPlayer>().GDefPot <= 9;
		public override bool UseItem(Player player)
		{
			player.statDefense += 1;
			if (Main.myPlayer == player.whoAmI)
				// This is very important. This is what makes it permanent.
				player.GetModPlayer<ROTMGPlayer>().GDefPot += 1;
			return true;
		}
	}
}