using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ROTMG_Items.Items;
using ROTMG_Items.UI;

namespace ROTMG_Items.Items.Consumables
{
	public class StatSheet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stat Sheet");
			Tooltip.SetDefault("Using it displays the Stats UI.");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 16;
			item.useTime = 14;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = 1000000;
			item.rare = ItemRarityID.Gray;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override bool UseItem(Player player)
        {
			StatUI.Visible = true;
			return true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}