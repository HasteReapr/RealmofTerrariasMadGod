using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Abilities
{
	public class GFate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gambler's Fate");
			Tooltip.SetDefault("A coin pilfered from the endless vault of Gemsbok’s hoarded wealth. Only the most daring would stake their lives on the equal odds of a coin flip.");
		}

		public override void SetDefaults()
		{
			item.rare = ItemRarityID.Expert;
			item.damage = 0;
			item.useStyle = ItemUseStyleID.HoldingOut; //yes
			item.magic = true;
			item.mana = 100;
			item.width = 40;
			item.height = 40;
			item.useTime = 120;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<CoinParticle>();
			item.shootSpeed = 16f;
		}
	}
}