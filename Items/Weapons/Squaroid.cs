using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using ROTMG_Items.Items.Weapons.Projectiles;
using Microsoft.Xna.Framework;


namespace ROTMG_Items.Items.Weapons
{
    class Squaroid : ModItem
    {


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Squaroid Staff");
            Tooltip.SetDefault("tooltip moment");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {

            item.damage = 40;
            item.magic = true;
            item.mana = 2;
            item.width = 36;
            item.height = 36;
            item.useTime = 14;
            item.useAnimation = 12;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = 52800;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<SquPro>();
            item.shootSpeed = 16;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 2;
            float rotation = MathHelper.ToRadians(90);
            Vector2 positionMod = position + Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i - 1f)) * .2f;
                Projectile.NewProjectile(positionMod.X, positionMod.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<SquSpec>(), 20, 1, player.whoAmI);
            }
            return true;
        }
    }
}