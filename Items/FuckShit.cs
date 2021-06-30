using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items
{
	public class FuckShit : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fuck and shit");
			Tooltip.SetDefault("Fuck you I did this so I could make my testing world hard mode so I could test if the drop rates work");
		}

		public override void SetDefaults()
		{
			item.damage = 10000000;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 0;
			item.useAnimation = 0;
			item.pick = 1000000000;
			item.axe = 1000000000;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 1000000000;
			item.rare = ItemRarityID.Expert;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.tileBoost = 10000000;
		}
		public override void HoldItem(Player player)
		{
			player.maxFallSpeed = 10000;
			player.noFallDmg = true;
			player.statLifeMax2 = 9999;
			player.lifeRegen = 1000;
			player.statManaMax2 = 9999;
			player.manaRegen = 1000;
			//player.extraFall = 10000;
			//player.fallStart = 10000;
			player.fallStart2 = 10000;
}
	}
}