using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items
{
	public class Vital : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Staff of the Vital Unity");
			Tooltip.SetDefault("A golden staff of elysian consciousness, shining with the base power of empyrean truths.");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 540;
			item.magic = true;
			item.mana = 2;
			item.width = 40;
			item.height = 40;
			item.useTime = 5;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<YellowMissle>();
			item.shootSpeed = 16f;
		}
	}
}