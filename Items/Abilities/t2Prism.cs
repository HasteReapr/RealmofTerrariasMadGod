using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Items;
using Terraria.DataStructures;
using ROTMG_Items.Items.Materials;
using ROTMG_Items.Items.Abilities.Projectiles;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.Items.Abilities
{
	public class t2Prism : AncientCostFunction
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prism of Phantoms");
			Tooltip.SetDefault("A prism with the trapped souls of liars from ages old.");
		}

		public override void SetDefaults()
		{
			AncientCost = 25;
			item.rare = ItemRarityID.Cyan;
			item.damage = 0;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.width = 40;
			item.height = 40;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<DecoyProjectile>();
			item.shootSpeed = 16f;
			isAbility = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * item.shootSpeed, item.shoot, item.damage, item.knockBack, player.whoAmI, 0, 1);
			return false;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.useStyle = ItemUseStyleID.HoldingUp;
				item.useTime = 30;
				item.useAnimation = 30;
				player.Hurt(PlayerDeathReason.ByCustomReason($"{player.name} was too greedy."), (int)(player.statLifeMax2 * 0.25f), 0);
				player.Teleport(Main.MouseWorld);
			}
			return base.CanUseItem(player);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<GreaterEssence>());
			recipe.AddIngredient(ModContent.ItemType<t1Prism>());
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}