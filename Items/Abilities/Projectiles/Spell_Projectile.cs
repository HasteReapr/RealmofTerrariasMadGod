using ROTMG_Items.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Abilities.Projectiles
{
	public class Spell_Projectile : ModProjectile
	{
		string[] TextureString =
			{
			"ROTMG_Items/Items/Abilities/Projectiles/t1Spell_Proj",
			"ROTMG_Items/Items/Abilities/Projectiles/t2Spell_Proj",
			"ROTMG_Items/Items/Abilities/Projectiles/t3Spell_Proj",
			"ROTMG_Items/Items/Abilities/Projectiles/t4Spell_Proj",
			"ROTMG_Items/Items/Abilities/Projectiles/t5Spell_Proj",
			"ROTMG_Items/Items/Abilities/Projectiles/t6Spell_Proj"
		};
		public override string Texture => TextureString[(int)projectile.ai[1]];
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 15;
		}

		public override void AI()
		{
			projectile.velocity.Y += projectile.ai[0];
			projectile.rotation = projectile.velocity.ToRotation();
		}
	}
}