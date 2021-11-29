using Terraria;
using Terraria.ModLoader;
using ROTMG_Items.Items.Pets;

namespace ROTMG_Items.Buffs.Pets
{
	public class OminousStone : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Stone Idol");
			Description.SetDefault("\"Big man is coming for you.\"\n" +
				"Sprites drawn by Cosmic!");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<PetPlayer>().Stonepet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<StoneIdolPet>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<StoneIdolPet>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}