using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.Items.Abilities
{
    class t5Poison : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Herbal Poison");
            Tooltip.SetDefault("A poison made from Plantera's bulb.");
        }

        public override void SetDefaults()
        {
            item.damage = 500;
            item.useTime = 10;
            item.noUseGraphic = true;
            item.useAnimation = 10;
            AncientCost = 90;
            isAbility = true;
            item.shoot = ModContent.ProjectileType<t5PoisonBottle>();
            item.shootSpeed = 16;
            item.rare = ItemRarityID.Cyan;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<t4Poison>());
            recipe.AddIngredient(ModContent.ItemType<Materials.HerbalEssence>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
