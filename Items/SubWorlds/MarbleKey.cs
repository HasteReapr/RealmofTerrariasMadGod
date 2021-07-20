using Terraria.ModLoader;
using Terraria.ID;
using SubworldLibrary;
using Terraria;

namespace ROTMG_Items.Items.SubWorlds
{
    class MarbleKey : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lost Halls Key");
            Tooltip.SetDefault("Teleports you to the Lost Halls.");
        }

        public override void SetDefaults()
        {
            item.height = 34;
            item.width = 34;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.maxStack = 1;
        }

        public override bool UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                Subworld.Enter<MarbleWorld>();
            }

            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
