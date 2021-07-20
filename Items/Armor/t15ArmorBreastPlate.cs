using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class t15ArmorBreastPlate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Gemstone Breastplate");
			Tooltip.SetDefault("A heavy breastplate made from gemstone."
				+ "\nImmune to most fire based debuffs."
				+ "\nImmune to drowning."
				+ "\n+20 max life and +20% melee speed and damage." +
				"\n+20% movespeed.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.defense = 75;
		}

		public override void UpdateEquip(Player player)
		{
			player.buffImmune[BuffID.OnFire] = true;
			player.buffImmune[BuffID.WeaponImbueFire] = true;
			player.buffImmune[BuffID.Cursed] = true;
			player.buffImmune[BuffID.CursedInferno] = true;
			player.buffImmune[BuffID.WeaponImbueCursedFlames] = true;
			player.buffImmune[BuffID.Burning] = true;
			player.statLifeMax2 += 20;
			player.meleeDamage += 0.2f;
			player.GetModPlayer<ROTMGPlayer>().t15Breastplate = true;
			player.moveSpeed += 0.2f;
			player.ignoreWater = true;
			player.breathCD -= 100000;
		}
	}
}
