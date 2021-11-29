using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ROTMG_Items.Items.Accesories
{
	public class Mana_Crown : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mana Crown");
			Tooltip.SetDefault("Admin Item\nThe admin crown, but just the mana.");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 24;
			item.accessory = true;
			item.rare = ItemRarityID.Expert;
			item.expert = true;
			item.value = Item.sellPrice(platinum: 6, gold: 9);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent = player.GetModPlayer<ROTMGPlayer>().AbilityPowerMax;
		}
	}
}
