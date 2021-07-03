using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Items;
using Terraria.DataStructures;

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
			item.shoot = ModContent.ProjectileType<t2Decoy>();
			item.shootSpeed = 16f;
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
				player.Hurt(PlayerDeathReason.ByCustomReason("Teleportation greed."), (int)(player.statLifeMax2 * .25f), 0, false, false, false, -1);
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