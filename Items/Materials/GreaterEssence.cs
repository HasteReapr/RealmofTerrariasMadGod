using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Materials
{
	public class GreaterEssence : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Essence of Greater Power");
			Tooltip.SetDefault("A cursed but very powerful essence. \nYou may be able to use this to make more powerful gear.");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.width = 12;
			item.height = 12;
			item.value = 3000;
		}
	}
}