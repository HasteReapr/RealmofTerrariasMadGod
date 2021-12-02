using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Abilities
{
    public abstract class AncientCostFunction : ModItem, IItemInAbilitySlot
    {
        public override bool CloneNewInstances => true;
        public int AncientCost = 0;
        public int AncientHeal = 0;
        public int buffType2 = -1;
        public int buffTime2 = 0;
        public int buffType3 = -1;
        public int buffTime3 = 0;
        public int tier = 0;
        public bool teamBuff;
        public bool isAbility;

        public void OnTrigger(AbilityUIElementFunction uiFunc)
        {
            uiFunc.teamBuff = teamBuff;
            uiFunc.useCost = AncientCost;
            uiFunc.buffInt = item.buffType;
            uiFunc.buffLength = item.buffTime;
            uiFunc.buffInt2 = buffType2;
            uiFunc.buffLength2 = buffTime2;
            uiFunc.buffInt3 = buffType3;
            uiFunc.buffLength3 = buffTime3;
            uiFunc.projType = item.shoot;
            uiFunc.speed = item.shootSpeed;
            uiFunc.knockBack = item.knockBack;
            uiFunc.damage = item.damage;
            uiFunc.tier = tier;
        }

        public virtual void SafeSetDefaults()
        {
        }

        public override void SetDefaults()
        {
            item.buffType = -1;
            item.buffTime = 0;
            buffType2 = -1;
            buffTime2 = 0;
            buffType3 = -1;
            buffTime3 = 0;
            tier = 0;
            teamBuff = false;
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
            var modPlayer = player.GetModPlayer<ROTMGPlayer>();

            if (modPlayer.AbilityPowerCurrent >= AncientCost)
            {
                modPlayer.AbilityPowerCurrent -= AncientCost;
                return true;
            }
            return false;
        }
    }
}