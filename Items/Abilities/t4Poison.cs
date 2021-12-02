﻿using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ROTMG_Items.Items.Abilities.Projectiles;

namespace ROTMG_Items.Items.Abilities
{
    class t4Poison : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Poison");
            Tooltip.SetDefault("A poison made from the mechanical trio's oil.");
        }

        public override void SetDefaults()
        {
            item.damage = 120;
            item.useTime = 10;
            item.noUseGraphic = true;
            item.useAnimation = 10;
            AncientCost = 35;
            isAbility = true;
            item.shoot = ModContent.ProjectileType<PoisonBottle>();
            item.shootSpeed = 16;
            item.rare = ItemRarityID.Cyan;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
            tier = 3;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * item.shootSpeed, item.shoot, item.damage, item.knockBack, player.whoAmI, 0, tier);
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<t4Poison>());
            recipe.AddIngredient(ModContent.ItemType<Materials.MechanicalEssence>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
