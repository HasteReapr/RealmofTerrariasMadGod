using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ROTMG_Items.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class t15Leggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gemstone Leggings");
			Tooltip.SetDefault("A strong pair of leggings made from gemstone."
				+ "\n+20% movespeed." +
				"\n+20 max life." +
				"\n+20% increased melee speed and damage.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.defense = 60;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<ROTMGPlayer>().t15Leggings = true;
			player.meleeDamage += 0.2f;
			player.moveSpeed += 0.2f;
			player.statLifeMax2 += 20;
		}
	}
}