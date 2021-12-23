using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.Dusts
{
	public class RichDust : ModDust
	{
        public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.noLight = false;
			dust.scale = 2f;
			dust.frame = new Rectangle(0, Main.rand.Next(3) * 22, 14, 22);
			dust.scale *= 0.5f;
		}

		public override bool Update(Dust dust)
		{
			dust.velocity = new Vector2(0, 1);
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X;
			dust.scale -= 0.01f;
			if(dust.scale <= 0)
            {
				dust.active = false;
            }
			return false;
		}
	}
}