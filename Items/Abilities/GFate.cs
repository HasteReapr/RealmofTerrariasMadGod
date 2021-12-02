using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Items.Materials;
using ROTMG_Items.Items.Abilities.Projectiles;

namespace ROTMG_Items.Items.Abilities
{
	public class GFate : AncientCostFunction
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
			AncientCost = 75;
			item.width = 36;
			item.height = 36;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item8;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<CoinParticle>();
			item.shootSpeed = 16f;
			isAbility = true;
		}
	}
}