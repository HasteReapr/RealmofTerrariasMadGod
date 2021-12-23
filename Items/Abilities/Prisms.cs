using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ROTMG_Items.Items.Materials;
using ROTMG_Items.Items.Abilities.Projectiles;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.Items.Abilities
{
	public class Prisms : AncientCostFunction
	{
		//t1 Prism
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prism of Lies");
			Tooltip.SetDefault("A prism fabricated from mysterious crystals and pure lies.");
		}

		public override void SetDefaults()
		{
			AncientCost = 20;
			item.rare = ItemRarityID.Cyan;
			item.damage = 0;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.magic = true;
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
			tier = 0;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * item.shootSpeed, item.shoot, item.damage, item.knockBack, player.whoAmI, 0, tier); 
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
				player.Hurt(PlayerDeathReason.ByCustomReason($"{player.name} was too greedy."), (int)(player.statLifeMax2*0.25f), 0);
				player.Teleport(Main.MouseWorld);
			}
			return base.CanUseItem(player);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<RefinedPrismaticShard>(), 10);
			recipe.AddIngredient(ModContent.ItemType<DecoyEssense>());
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}



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
			tier = 1;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * item.shootSpeed, item.shoot, item.damage, item.knockBack, player.whoAmI, 0, tier); 
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
			recipe.AddIngredient(ModContent.ItemType<Prisms>());
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}



	public class t3Prism : AncientCostFunction
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prism of Imagination");
			Tooltip.SetDefault("A prism that throws fragments of the users imagination into reality.");
		}

		public override void SetDefaults()
		{
			AncientCost = 30;
			item.rare = ItemRarityID.Cyan;
			item.damage = 0;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.magic = true;
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
			tier = 2;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * item.shootSpeed, item.shoot, item.damage, item.knockBack, player.whoAmI, 0, tier); 
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
			recipe.AddIngredient(ModContent.ItemType<UnholyEssence>());
			recipe.AddIngredient(ModContent.ItemType<t2Prism>());
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}



	public class t4Prism : AncientCostFunction
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prism of Fragmentation");
			Tooltip.SetDefault("A prism that fragments reality to distract enemies.");
		}

		public override void SetDefaults()
		{
			AncientCost = 35;
			item.rare = ItemRarityID.Cyan;
			item.damage = 0;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.magic = true;
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
			tier = 3;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * item.shootSpeed, item.shoot, item.damage, item.knockBack, player.whoAmI, 0, tier); 
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
			recipe.AddIngredient(ModContent.ItemType<MechanicalEssence>());
			recipe.AddIngredient(ModContent.ItemType<t3Prism>());
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}



	public class t5Prism : AncientCostFunction
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prism of Phantasmal Power");
			Tooltip.SetDefault("A prism that summons a phantom of yourself to distract enemies.");
		}

		public override void SetDefaults()
		{
			AncientCost = 40;
			item.rare = ItemRarityID.Cyan;
			item.damage = 0;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.magic = true;
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
			tier = 4;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * item.shootSpeed, item.shoot, item.damage, item.knockBack, player.whoAmI, 0, tier); 
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
				item.useTime = 20;
				item.useAnimation = 20;
				player.Teleport(Main.MouseWorld);
			}
			return base.CanUseItem(player);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<HerbalEssence>());
			recipe.AddIngredient(ModContent.ItemType<t4Prism>());
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}



	public class t6Prism : AncientCostFunction
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prism of Apparitions");
			Tooltip.SetDefault("A deep blue prism of sun cut topaz, used by doppelganger spies to aid in their vile missions of assassination and murder.");
		}

		public override void SetDefaults()
		{
			AncientCost = 45;
			item.rare = ItemRarityID.Cyan;
			item.damage = 0;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.magic = true;
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
			tier = 5;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * item.shootSpeed, item.shoot, item.damage, item.knockBack, player.whoAmI, 0, tier);
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
				item.useTime = 20;
				item.useAnimation = 20;
				player.Teleport(Main.MouseWorld);
			}
			return base.CanUseItem(player);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<LunarEssence>());
			recipe.AddIngredient(ModContent.ItemType<t5Prism>());
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}