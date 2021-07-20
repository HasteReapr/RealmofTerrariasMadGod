using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Materials
{
	public class MechanicalEssence : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Essence of Mechanical Power");
			Tooltip.SetDefault("An essence whirring with the power of the mechanical beasts.");
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