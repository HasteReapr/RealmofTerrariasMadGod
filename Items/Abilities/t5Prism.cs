using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Items;
using ROTMG_Items.Items.Materials;

namespace ROTMG_Items.Items.Abilities
{
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
			item.useStyle = ItemUseStyleID.HoldingOut; //yes the floor here is made out of floor. I'm glad i figured out how to make code readable bc i wouldnt know what the FUCK this is
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
			item.shoot = ModContent.ProjectileType<t5Decoy>();
			item.shootSpeed = 16f;
			isAbility = true;
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
}