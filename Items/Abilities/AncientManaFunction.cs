using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Abilities
{
	public abstract class AncientCostFunction : ModItem
	{
		public override bool CloneNewInstances => true;
		public int AncientCost = 0;
		public int AncientHeal = 0;
		public bool isAbility;
		public virtual void SafeSetDefaults()
		{
		}

		public override void SetDefaults()
		{
			isAbility = true;
			SafeSetDefaults();
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			if (AncientCost > 0)
			{
				tooltips.Add(new TooltipLine(mod, "Ancient Mana Cost", $"Uses {AncientCost} Ancient Mana."));
			}
		}

		// Make sure you can't use the item if you don't have enough mana and then use the mana otherwise.
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