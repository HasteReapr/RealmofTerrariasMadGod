using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Items.Weapons.Projectiles;

namespace ROTMG_Items.Items.Projectiles
{
	public class DBow_Arrow_Item : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dreadful Arrow");
			Tooltip.SetDefault("An arrow infused with the power of the dead.");
		}

		public override void SetDefaults()
		{
			item.damage = 150;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 20f;
			item.value = 10;
			item.rare = ItemRarityID.Green;
			item.shoot = ModContent.ProjectileType<DBow_Arrow>();
			item.shootSpeed = 16f;
			item.ammo = AmmoID.Arrow;
		}

		public override void OnConsumeAmmo(Player player)
		{
			if (Main.rand.NextBool(10))
			{
				player.AddBuff(BuffID.Wrath, 300);
			}
		}
	}
}