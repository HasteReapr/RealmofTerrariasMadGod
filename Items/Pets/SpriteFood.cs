using ROTMG_Items.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Pets
{
	public class SpriteFood : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName and Tooltip are automatically set from the .lang files, but below is how it is done normally.
			DisplayName.SetDefault("Sprite Food");
			Tooltip.SetDefault("Summons a baby sprite to follow you around!");
		}

		public override void SetDefaults()
		{
			item.damage = 0;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.shoot = ModContent.ProjectileType<Items.Pets.SpritePet>();
			item.width = 32;
			item.height = 32;
			item.UseSound = SoundID.Item2;
			item.useAnimation = 20;
			item.useTime = 20;
			item.rare = ItemRarityID.Yellow;
			item.noMelee = true;
			item.value = Item.sellPrice(0, 5, 50, 0);
			item.buffType = ModContent.BuffType<Buffs.Pets.SpriteBuff>();
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