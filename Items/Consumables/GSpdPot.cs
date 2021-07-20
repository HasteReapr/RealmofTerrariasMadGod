using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Consumables
{
	public class GSpdPot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Potion of Greater Speed");
			Tooltip.SetDefault("Permanetly increases movespeed by 5%.");
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
		public override bool CanUseItem(Player player) => player.GetModPlayer<ROTMGPlayer>().GSpdPot <= 4;
		public override bool UseItem(Player player)
		{
			player.moveSpeed += 0.05f;
			if (Main.myPlayer == player.whoAmI)
				// This is very important. This is what makes it permanent.
				player.GetModPlayer<ROTMGPlayer>().GSpdPot += 1;
			return true;
		}
	}
}