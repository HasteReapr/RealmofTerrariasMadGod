using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.Items.Pets
{
    class StoneIdolCharm : ModItem
    {
		public override void SetStaticDefaults()
		{
			// DisplayName and Tooltip are automatically set from the .lang files, but below is how it is done normally.
			DisplayName.SetDefault("Stone Charm");
			Tooltip.SetDefault("Summons a Stone Idol to ominously follow you.\n" +
				"Sprite made by Cosmic!");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = ModContent.ProjectileType<StoneIdolPet>();
			item.buffType = ModContent.BuffType<Buffs.Pets.OminousStone>();
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}
