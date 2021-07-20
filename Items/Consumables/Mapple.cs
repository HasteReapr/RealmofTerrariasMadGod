using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Consumables
{
	public class Mapple : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Potion of Maxing");
			Tooltip.SetDefault("Permanetly maxes all of your stats.");
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
			player.GetModPlayer<ROTMGPlayer>().WisPot = 5;
			player.GetModPlayer<ROTMGPlayer>().VitPot = 5;
			player.GetModPlayer<ROTMGPlayer>().DexPot = 5;
			player.GetModPlayer<ROTMGPlayer>().AttPot = 10;
			player.GetModPlayer<ROTMGPlayer>().DefPot = 10;
			player.GetModPlayer<ROTMGPlayer>().SpdPot = 5;
			player.GetModPlayer<ROTMGPlayer>().ManaPot = 5;
			player.GetModPlayer<ROTMGPlayer>().LifePot = 10;

			player.GetModPlayer<ROTMGPlayer>().GWisPot = 5;
			player.GetModPlayer<ROTMGPlayer>().GVitPot = 5;
			player.GetModPlayer<ROTMGPlayer>().GDexPot = 5;
			player.GetModPlayer<ROTMGPlayer>().GAttPot = 10;
			player.GetModPlayer<ROTMGPlayer>().GDefPot = 10;
			player.GetModPlayer<ROTMGPlayer>().GSpdPot = 5;
			player.GetModPlayer<ROTMGPlayer>().GManaPot = 5;
			player.GetModPlayer<ROTMGPlayer>().GLifePot = 10;
			return true;
		}
	}
}