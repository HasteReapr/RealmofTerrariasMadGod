using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ROTMG_Items.Items;
using ROTMG_Items;
using ROTMG_Items.Items.Materials;
using ROTMG_Items.Items.Abilities.Projectiles;

namespace ROTMG_Items.Items.Abilities
{
	public class t2Skull : AncientCostFunction
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Skull");
			Tooltip.SetDefault("A skull taken from the dungeon, it's still warm from the curse.\nHeal 45% of the damage you do.");
		}

		public override void SetDefaults()
		{
			item.damage = 60;
			AncientCost = 45;
			item.width = 40;
			item.height = 40;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 3;
			item.value = 1000000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<SkullAOE>();
			item.shootSpeed = 24f;
			isAbility = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<t1Skull>(), 1);
			recipe.AddIngredient(ModContent.ItemType<GreaterEssence>(), 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}