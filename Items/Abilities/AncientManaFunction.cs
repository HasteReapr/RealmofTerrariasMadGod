using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Abilities
{
	public abstract class AncientCostFunction : ModItem
	{
		public override bool CloneNewInstances => true;
		public int AncientCost = 0;
		public int AncientHeal = 0;
		public virtual void SafeSetDefaults()
		{
		}

		public override void SetDefaults()
		{
			SafeSetDefaults();
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			if (AncientCost > 0)
			{
				tooltips.Add(new TooltipLine(mod, "Ancient Mana Cost", $"Uses {AncientCost} Ancient Mana."));
			}
		}

		// Make sure you can't use the item if you don't have enough resource and then use 10 resource otherwise.
		public override bool CanUseItem(Player player)
		{
			var exampleDamagePlayer = player.GetModPlayer<ROTMGPlayer>();

			if (exampleDamagePlayer.AbilityPowerCurrent >= AncientCost)
			{
				exampleDamagePlayer.AbilityPowerCurrent -= AncientCost;
				return true;
			}
			return false;
		}
	}
}