using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items
{
	public class EP : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Staff of the Extreme Prejudice");
			Tooltip.SetDefault("Once the most powerful staff in existence; a crack in its frame has rendered it incapable of focusing fire. It remains uniquely deadly.");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 420;
			item.magic = true;
			item.mana = 2;
			item.width = 40;
			item.height = 40;
			item.useTime = 12;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<EPMissile>();
			item.shootSpeed = 16f;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			float numberprojectiles = 10;
			float rotation = MathHelper.ToRadians(150);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 150;
			for (int i = 0; i < numberprojectiles; i++)
            {
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberprojectiles - 1))) * .2f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
    }
}