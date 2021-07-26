using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Currency
{
	public class Fame : ModItem
	{
		public override void SetStaticDefaults()
		{
			// See here for help on using Tags: http://terraria.gamepedia.com/Chat#Tags
			DisplayName.SetDefault("Fame");
			Tooltip.SetDefault("You should've nexused...");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 6));
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.maxStack = 1000000;
			item.width = 34;
			item.height = 34;
			item.rare = ItemRarityID.Blue;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
	}
}