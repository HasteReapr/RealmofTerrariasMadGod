using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Buffs;

namespace ROTMG_Items.Items.Weapons.Projectiles
{
	public class Scythe_Projectiles : ModProjectile
	{
        public override string Texture => "ROTMG_Items/NPCs/Projectiles/Spooky_Break_Shot";
        public override void SetDefaults()
		{
			projectile.frameCounter = 7;
			projectile.width = 34;
			projectile.height = 34;
			projectile.friendly = true;
			projectile.penetrate = 10;
			projectile.timeLeft = 180;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
		}
		float rotation = 1;
		public override void AI()
		{
			rotation += 0.1f;
			projectile.rotation = rotation;
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(ModContent.BuffType<ShatteredArmor>(), 120);
        }
    }

	public class Scythe_Sick_Shot : ModProjectile
	{
		public override string Texture => "ROTMG_Items/NPCs/Projectiles/Spooky_Sick_Shot";
		public override void SetDefaults()
		{
			projectile.frameCounter = 7;
			projectile.width = 34;
			projectile.height = 34;
			projectile.friendly = true;
			projectile.penetrate = 10;
			projectile.timeLeft = 180;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
		}
		float rotation = 1;
		public override void AI()
		{
			rotation += 0.1f;
			projectile.rotation = rotation;
		}
	}

	public class Scythe_Slow_Shot : ModProjectile
	{
		public override string Texture => "ROTMG_Items/NPCs/Projectiles/Spooky_Slow_Shot";
		public override void SetDefaults()
		{
			projectile.frameCounter = 7;
			projectile.width = 34;
			projectile.height = 34;
			projectile.friendly = true;
			projectile.penetrate = 10;
			projectile.timeLeft = 180;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
		}
		float rotation = 1;
		public override void AI()
		{
			rotation += 0.1f;
			projectile.rotation = rotation;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Slow, 120);
		}
	}
}
