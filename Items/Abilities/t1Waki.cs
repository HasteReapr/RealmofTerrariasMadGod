using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ROTMG_Items.Items;
using ROTMG_Items;
using ROTMG_Items.Items.Materials;

namespace ROTMG_Items.Items.Abilities
{
	public class t1Waki : AncientCostFunction
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Steel Wakizashi");
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
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 3;
			item.value = 1000000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<t1Waki_Proj>();
			item.shootSpeed = 24f;
			isAbility = true;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Vector2 v = player.DirectionFrom(Main.MouseWorld);
			Vector2 perpendicular = v.RotatedBy(MathHelper.PiOver2);
			Vector2 toMouse = Vector2.Normalize(Main.MouseWorld - (Main.MouseWorld + (v * 40) + (perpendicular * 90)));
			//origin + (v * someMagnitude) + (perpendicular * someMagnitude)
			// Vector2.Normalize(Main.MouseWorld - player.Center) is the same as player.DirectionTo(Main.MouseWorld)
			Projectile.NewProjectile(Main.MouseWorld + (v * 40) + (perpendicular * 90), toMouse * 8, type, damage, knockBack, player.whoAmI, 0, 0);
			return false;
        }

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