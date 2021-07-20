using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Consumables
{
	public class GLifePot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Potion of Greater Life");
			Tooltip.SetDefault("Permanetly increases life by 20.");
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
		public override bool CanUseItem(Player player) => player.GetModPlayer<ROTMGPlayer>().GLifePot <= 9;
		public override bool UseItem(Player player)
		{
			player.statLifeMax2 += 20;
			if (Main.myPlayer == player.whoAmI)
			{
				// This spawns the green numbers showing the heal value and informs other clients as well.
				player.HealEffect(20, true);
			}
			// This is very important. This is what makes it permanent.
			player.GetModPlayer<ROTMGPlayer>().GLifePot += 1;
			return true;
		}
	}
}