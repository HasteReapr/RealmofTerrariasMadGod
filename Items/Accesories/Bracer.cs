using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ROTMG_Items.Items.Accesories
{
	[AutoloadEquip(EquipType.HandsOn)]
	public class Bracer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sentinel's Bracing");
			Tooltip.SetDefault("A powerful gauntlet worn by the Bridge Sentinel.\n+40 Life\n+12 Defense\n+15% Damage\n+15% Swing Speed");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 24;
			item.accessory = true;
			item.rare = ItemRarityID.Expert;
			item.expert = true;
			item.value = Item.sellPrice(platinum: 5, gold: 25);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statLifeMax2 += 40;
			player.statDefense += 12;
			player.allDamage *= 1.15f;
			player.GetModPlayer<ROTMGPlayer>().Bracer = true;
		}
	}
}
