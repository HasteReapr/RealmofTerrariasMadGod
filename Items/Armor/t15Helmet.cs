using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ROTMG_Items.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class t15Helmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gemstone Helmet");
			Tooltip.SetDefault("A heavy helmet made for the berserking warriors." +
				"\n+20% movespeed." +
				"\n+20 max life." +
				"\n+20% melee damage and speed.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.defense = 50;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<t15ArmorBreastPlate>() && legs.type == ModContent.ItemType<t15Leggings>();
		}

        public override void UpdateEquip(Player player)
        {
			player.statLifeMax2 += 20;
			player.moveSpeed += 0.2f;
			player.meleeDamage += 0.2f;

        }
        public override void UpdateArmorSet(Player player)
		{
			item.autoReuse = true;
			player.AddBuff(ModContent.BuffType<Buffs.WarrBuff>(), 10);
			player.setBonus = "Increases your swing speed by 80%.\nApplies Berserker while full set is equipped.";
			player.meleeDamage += 0.2f;
			player.GetModPlayer<ROTMGPlayer>().t15SetBonus = true;
			/* Here are the individual weapon class bonuses.
			player.meleeDamage -= 0.2f;
			player.thrownDamage -= 0.2f;
			player.rangedDamage -= 0.2f;
			player.magicDamage -= 0.2f;
			player.minionDamage -= 0.2f;
			*/
		}
	}
}