using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Items.Weapons.Projectiles;

namespace ROTMG_Items.Items.Weapons
{
	public class Majesty : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sword of Majesty"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("A gleaming obsidian sword of imperial power, fashioned by enslaved demons for the personal use of a world-conquering leader of mortals.");
		}

		public override void SetDefaults() 
		{
			item.damage = 475;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 5000000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<Majesty_Shot>();
			item.shootSpeed = 16f;
		}
	}
}