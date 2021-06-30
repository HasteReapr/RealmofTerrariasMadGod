using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items
{
	public class GDexPot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Potion of Greater Dexterity");
			Tooltip.SetDefault("Permanetly increases attack speed by 5%.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 26;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.useAnimation = 17;
			item.useTime = 17;
			item.useTurn = true;
			item.UseSound = SoundID.Item3;
			item.maxStack = 16;
			item.consumable = true;
			item.rare = ItemRarityID.Orange;
			item.value = Item.buyPrice(gold: 1);
		}
		public override bool CanUseItem(Player player) => player.GetModPlayer<ROTMGPlayer>().GDexPot <= 4;
		public override bool UseItem(Player player)
		{
			if (Main.myPlayer == player.whoAmI)
				// This is very important. This is what makes it permanent.
				player.GetModPlayer<ROTMGPlayer>().GDexPot += 1;
			return true;
		}
	}
}