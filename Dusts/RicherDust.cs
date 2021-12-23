using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.Dusts
{
	public class RicherDust : ModDust
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "ROTMG_Items/Dusts/RichDust";
			return base.Autoload(ref name, ref texture);
		}
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.noLight = false;
			dust.scale = 2f;
			dust.frame = new Rectangle(0, Main.rand.Next(3) * 22, 14, 22);
			dust.scale *= 0.5f;
			dust.velocity = Vector2.Zero;
		}

		public override bool Update(Dust dust)
		{
			dust.scale -= 0.01f;
			if (dust.customData != null && dust.customData is Player player)
			{
				dust.position = player.Center + Vector2.UnitX.RotatedBy(dust.rotation, Vector2.Zero) * dust.scale * 50;
			}

			//dust.velocity = ;

			if (dust.scale < 0.25f)
			{
				dust.active = false;
			}

			return false;
		}
	}
}