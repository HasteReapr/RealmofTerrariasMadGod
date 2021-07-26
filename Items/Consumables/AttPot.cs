using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Items.Currency;

namespace ROTMG_Items.Items.Consumables
{
	public class AttPot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Potion of Attack");
			Tooltip.SetDefault("Permanetly increases attack by 5%.");
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
		public override bool CanUseItem(Player player) => player.GetModPlayer<ROTMGPlayer>().AttPot <= 9;
		public override bool UseItem(Player player)
		{
			player.allDamage += 0.05f;
			if (Main.myPlayer == player.whoAmI)
			// This is very important. This is what makes it permanent.
			player.GetModPlayer<ROTMGPlayer>().AttPot += 1;
			return true;
		}
	}
}