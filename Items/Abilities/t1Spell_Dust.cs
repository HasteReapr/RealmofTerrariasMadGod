using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.Items.Abilities
{
	public class t1Spell_Dust : ModProjectile
	{
		public override string Texture => "ROTMG_Items/Items/Abilities/t1Spell_Proj";
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
        public override void Kill(int timeLeft)
        {
			float speed = 24;
			Vector2 side = new Vector2((float)Math.Cos(45) / speed, (float)Math.Sin(45) / speed); // to define a Vector2 like this, you need to start with the variable name, and then after the = put New Vector2. If you don't do this, it won't work.
			Vector2 side2 = new Vector2((float)Math.Cos(90) / speed, (float)Math.Sin(90) / speed);
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("t1Spell_Proj"), 10, 0f, projectile.owner, 0f, 0f);
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X * -1, projectile.velocity.Y * -1, mod.ProjectileType("t1Spell_Proj"), 10, 0f, projectile.owner, 0f, 0f);

			Projectile.NewProjectile(projectile.position, (side * -1) * (speed * 16), mod.ProjectileType("t1Spell_Proj"), 10, 0f, Main.myPlayer); // left
			Projectile.NewProjectile(projectile.position, side * (speed * 16), mod.ProjectileType("t1Spell_Proj"), 10, 0f, Main.myPlayer);

			Projectile.NewProjectile(projectile.position, (side2 * -1) * (speed * 16), mod.ProjectileType("t1Spell_Proj"), 10, 0f, Main.myPlayer); //right
			Projectile.NewProjectile(projectile.position, side2 * (speed * 16), mod.ProjectileType("t1Spell_Proj"), 10, 0f, Main.myPlayer);
		}
    }
}