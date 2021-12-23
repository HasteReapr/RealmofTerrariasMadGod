using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Items.Materials;

namespace ROTMG_Items.Items.Abilities
{
    public class Oreo : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seal of the Lunatic Cultists");
            Tooltip.SetDefault("A seal of utter blasphemy.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            AncientCost = 175;
            item.rare = ItemRarityID.Expert;
            item.value = Item.buyPrice(gold: 1);
            item.buffType = ModContent.BuffType<Buffs.Damaging>();
            item.buffTime = 480;
            buffType2 = ModContent.BuffType<Buffs.Invulnerable>();
            buffTime2 = 150;
            isAbility = true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(buffType2, buffTime2);
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.HasBuff(ModContent.BuffType<Buffs.Damaging>()))
            {
                return false;
            }
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