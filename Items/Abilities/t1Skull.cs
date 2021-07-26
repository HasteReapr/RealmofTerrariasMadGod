using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ROTMG_Items.Items;
using ROTMG_Items;
using ROTMG_Items.Items.Materials;

namespace ROTMG_Items.Items.Abilities
{
	public class t1Skull : AncientCostFunction
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Goblin Skull");
			Tooltip.SetDefault("A skull taken from a goblin, just don't show it to the tinkerer...\nHeal 45% of the damage you do.");
		}

		public override void SetDefaults()
		{
			item.damage = 40;
			AncientCost = 35;
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
			recipe.AddIngredient(ModContent.ItemType<NecromaticEssence>(), 1);
			recipe.AddIngredient(ItemID.Bone, 15);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}