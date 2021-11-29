using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.Items.Abilities
{
    class t1Poison : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Venom");
            Tooltip.SetDefault("A barely potent venom harvested from jungle seeds.");
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.noUseGraphic = true;
            item.useTime = 10;
            item.useAnimation = 10;
            AncientCost = 25;
            isAbility = true;
            item.shoot = ModContent.ProjectileType<t1PoisonBottle>();
            item.shootSpeed = 16;
            item.rare = ItemRarityID.Cyan;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bottle, 1);
            recipe.AddIngredient(ItemID.JungleGrassSeeds, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
