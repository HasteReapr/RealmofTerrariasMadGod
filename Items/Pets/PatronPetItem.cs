using ROTMG_Items.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Pets
{
	public class PatronPetItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName and Tooltip are automatically set from the .lang files, but below is how it is done normally.
			DisplayName.SetDefault("Supporter Pet");
			Tooltip.SetDefault("Thanks for supporting!\nSummons a generous orb to follow you around.\nVery rarely drops gold coins.");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = ModContent.ProjectileType<PatronPet>();
			item.buffType = ModContent.BuffType<Buffs.Pets.SupporterBuff>();
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}