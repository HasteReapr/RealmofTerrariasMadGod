using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.Dusts
{
	public class PoisonTrail : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.noLight = false;
			dust.scale = Main.rand.NextFloat(1f, 2.5f);
		}

		public override bool Update(Dust dust)
		{
			dust.rotation = Main.rand.Next(10);
			dust.scale -= Main.rand.NextFloat(0.01f, 0.10f);
			return true;
		}
	}
}