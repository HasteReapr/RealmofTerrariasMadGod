using Terraria;
using Terraria.ID;
using ROTMG_Items.Items.Abilities;
using ROTMG_Items.Buffs;
using Terraria.ModLoader;

namespace ROTMG_Items.Items
{
    class AbilityRegenStar : AncientCostFunction
    {
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.maxStack = 999;
        }

        public override bool OnPickup(Player player)
        {
            player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent += 20;
            return false;
        }
    }
}