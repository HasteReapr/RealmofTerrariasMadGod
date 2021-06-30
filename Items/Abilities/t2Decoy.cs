using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using ROTMG_Items.Items;

namespace ROTMG_Items.Items.Abilities
{
	public class t2Decoy : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.frameCounter = 7;
			projectile.width = 32;
			projectile.height = 32;
			projectile.friendly = true;
			projectile.penetrate = 1000;
			projectile.timeLeft = 20;
		}
		public static List<PlayerLayer> GetDrawLayers(Player drawPlayer)
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
		}
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
			Main.player[projectile.owner].tankPet = projectile.whoAmI;
			Main.player[projectile.owner].tankPetReset = false;
			Vector2 vectorToCursor = Main.MouseWorld - projectile.Center;
			float distanceToCursor = vectorToCursor.Length();
			//Vector2.Distance(projectile.Center, cachedMousePosition) < 10f;
		}
		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("t2DecoyStationary"), 0, 0f, projectile.owner, 0f, 0f); //32 stands for damage
		}
	}
}