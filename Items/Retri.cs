using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items
{
	public class Retri : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wand of Retribution");
			Tooltip.SetDefault("A golden wand of breathtaking power, created by elemental forces from the realms of ice and flame to unleash revenge on their enemies.");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 430;
			item.magic = true;
			item.mana = 2;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<PurpleDart>();
			item.shootSpeed = 16f;
		}
	}
}