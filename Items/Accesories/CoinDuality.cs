using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.Items.Accesories
{
    class CoinDuality : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Coin Duality");
			Tooltip.SetDefault("The duality of coins." +
				"\nGives you a chance of doubling the amount of coins you pick up.");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(15, 4));
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 52;
			item.height = 52;
			item.accessory = true;
			item.rare = ItemRarityID.Expert;
			item.expert = true;
			item.value = Item.sellPrice(platinum: 5, gold: 25);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            if (Main.rand.NextBool(120))
            {
				Dust dust = Dust.NewDustDirect(player.Center, 0, 0, ModContent.DustType<Dusts.RicherDust>(), Scale: 2);
				dust.rotation = Main.rand.NextFloat(6.28f);
				dust.customData = player;
				dust.position = player.Center + Vector2.UnitX.RotatedBy(dust.rotation, Vector2.Zero) * dust.scale * 50;

			}
			if (Main.rand.NextBool(100))
            {
				// check if the item the player just picked up is a currency, and then give the chance to double it
            }	
		}
	}
}
