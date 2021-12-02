using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using ROTMG_Items.Items;

namespace ROTMG_Items.Items.Abilities.Projectiles
{
	public class DecoyProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 6;
		}
		public override string Texture => "ROTMG_Items/Items/Abilities/Projectiles/Prism_Sheet";
		public override void SetDefaults()
        {
            if (projectile.ai[1] == 0)
            {
                projectile.timeLeft = (20 + (60 * 3));
            }
			else if(projectile.ai[1] == 1)
            {
				projectile.timeLeft = (20 + (60 * 6));
			}
			else if(projectile.ai[1] == 2)
            {
				projectile.timeLeft = (20 + (60 * 9));
			}
			else if(projectile.ai[1] == 3)
            {
				projectile.timeLeft = (20 + (60 * 12));
			}
			else if(projectile.ai[1] == 4)
            {
				projectile.timeLeft = (20 + (60 * 15));
			}
			else if(projectile.ai[1] == 5)
            {
				projectile.timeLeft = (20 + (60 * 18));
			}
            projectile.width = 30;
			projectile.height = 34;
			projectile.friendly = true;
			projectile.penetrate = 1000;
		}
        /*public static List<PlayerLayer> GetDrawLayers(Player drawPlayer)
		{
			List<PlayerLayer> layers = new List<PlayerLayer> {
				PlayerLayer.HairBack,
				PlayerLayer.MiscEffectsBack,
				PlayerLayer.BackAcc,
				PlayerLayer.Wings,
				PlayerLayer.BalloonAcc,
				PlayerLayer.Skin
			};
			return layers;
		}*/
        /*Public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{ //todo figure this shit out and use it as the sprite 
		PlayerDrawInfo info = new PlayerDrawInfo(GetDrawLayers, ref);
		PlayerLayer.HairBack.Draw();
		PlayerLayer.MiscEffectsBack.Draw();
		PlayerLayer.BackAcc.Draw();
		PlayerLayer.Wings.Draw();
		PlayerLayer.BalloonAcc.Draw();
		PlayerLayer.Skin.Draw();
		return base.PreDraw(spriteBatch, lightColor);
		}*/
        // PlayerDrawInfo info = new PlayerDrawInfo(stuff here);
        // layer.Draw(info); figure this out too
        // need ref on the draw call
        // Draw()
        /*
		 *         public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
					{
					PlayerDrawInfo info = new PlayerDrawInfo(GetDrawLayers, ref);
					PlayerLayer.HairBack.Draw();
					PlayerLayer.MiscEffectsBack.Draw();
					PlayerLayer.BackAcc.Draw();
					PlayerLayer.Wings.Draw();
					PlayerLayer.BalloonAcc.Draw();
					PlayerLayer.Skin.Draw();
					return base.PreDraw(spriteBatch, lightColor);
					}*/
        public override void AI()
		{
			projectile.frame = (int)projectile.ai[1];
			projectile.timeLeft--;
			if (projectile.ai[1] == 0)
			{
				if(projectile.timeLeft <= (60 * 3))
                {
					projectile.velocity *= 0;
                }
			}
			else if (projectile.ai[1] == 1)
			{
				if (projectile.timeLeft <= (60 * 6))
				{
					projectile.velocity *= 0;
				}
			}
			else if (projectile.ai[1] == 2)
			{
				if (projectile.timeLeft <= (60 * 9))
				{
					projectile.velocity *= 0;
				}
			}
			else if (projectile.ai[1] == 3)
			{
				if (projectile.timeLeft <= (60 * 12))
				{
					projectile.velocity *= 0;
				}
			}
			else if (projectile.ai[1] == 4)
			{
				if (projectile.timeLeft <= (60 * 15))
				{
					projectile.velocity *= 0;
				}
			}
			else if (projectile.ai[1] == 5)
			{
				if (projectile.timeLeft <= (60 * 18))
				{
					projectile.velocity *= 0;
				}
			}
			Main.player[projectile.owner].tankPet = projectile.whoAmI;
			Main.player[projectile.owner].tankPetReset = false;
			Vector2 vectorToCursor = Main.MouseWorld - projectile.Center;
			float distanceToCursor = vectorToCursor.Length();
			//Vector2.Distance(projectile.Center, cachedMousePosition) < 10f;
		}
		public override void Kill(int timeLeft)
		{
			//Main.PlaySound(); do that one weird magic sound, just whenever you find it
		}
	}
}