using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;

namespace ROTMG_Items.Items
{
	public class Acclaim : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sword of Acclaim"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("A great sword of recognition, forged by the gods for the champions of humankind.");
		}

		public override void SetDefaults()
		{
			item.damage = 175;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 1000000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<Acclaim_Shot>();
			item.shootSpeed = 24f;
		}
		
	}
}