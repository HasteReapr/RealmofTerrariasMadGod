using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ROTMG_Items.Items;
using ROTMG_Items;
using ROTMG_Items.Items.Materials;

namespace ROTMG_Items.Items.Abilities
{
    public class t1Scepter : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scepter of Storms");
            Tooltip.SetDefault("A simple wakizashi made from steel.");
        }

        public override void SetDefaults()
        {
            item.damage = 40;
            AncientCost = 35;
            item.width = 40;
            item.height = 40;
            item.useTime = 14;
            item.noMelee = true;
            item.useAnimation = 14;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 3;
            item.value = 1000000;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.shoot = ModContent.ProjectileType<Scepter_Projectile>();
            item.shootSpeed = 16f;
            isAbility = true;
        }

        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 speed = new Vector2(speedX, speedY);
            bool found = false;
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && player.Distance(Main.npc[k].Center) < 300f)
                {
                    Projectile.NewProjectile(player.Center, speed, type, damage, knockBack, player.whoAmI, 0, 0);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                // cone of dust
            }
            return false;
        }*/

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}