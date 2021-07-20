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
            DisplayName.SetDefault("Seal of Blasphemous Prayer");
            Tooltip.SetDefault("A seal infused with an unholy power.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            AncientCost = 85;
            item.rare = ItemRarityID.Expert;
            item.value = Item.buyPrice(gold: 1);
            item.buffType = ModContent.BuffType<Buffs.Damaging>();
            item.buffTime = 480;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Buffs.Invulnerable>(), 120);
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