using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Consumables
{
	public class PotionReset : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Potion of Absolute Zero");
			Tooltip.SetDefault("Permanetly sets all of your consumed potions to zero.");
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
		public override bool UseItem(Player player)
		{
			player.manaRegen += 5;
			if (Main.myPlayer == player.whoAmI)
				// This is very important. This is what makes it permanent.
				player.GetModPlayer<ROTMGPlayer>().WisPot = 0;
				player.GetModPlayer<ROTMGPlayer>().VitPot = 0;
				player.GetModPlayer<ROTMGPlayer>().DexPot = 0;
				player.GetModPlayer<ROTMGPlayer>().AttPot = 0;
				player.GetModPlayer<ROTMGPlayer>().DefPot = 0;
				player.GetModPlayer<ROTMGPlayer>().SpdPot = 0;
				player.GetModPlayer<ROTMGPlayer>().ManaPot = 0;
				player.GetModPlayer<ROTMGPlayer>().LifePot = 0;

				player.GetModPlayer<ROTMGPlayer>().GWisPot = 0;
				player.GetModPlayer<ROTMGPlayer>().GVitPot = 0;
				player.GetModPlayer<ROTMGPlayer>().GDexPot = 0;
				player.GetModPlayer<ROTMGPlayer>().GAttPot = 0;
				player.GetModPlayer<ROTMGPlayer>().GDefPot = 0;
				player.GetModPlayer<ROTMGPlayer>().GSpdPot = 0;
				player.GetModPlayer<ROTMGPlayer>().GManaPot = 0;
				player.GetModPlayer<ROTMGPlayer>().GLifePot = 0;
			return true;
		}
	}
}