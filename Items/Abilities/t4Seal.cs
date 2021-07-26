using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Items.Materials;

namespace ROTMG_Items.Items.Abilities
{
    public class t4Seal : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seal of of the Monk");
            Tooltip.SetDefault("A seal used by monks to bless others.\nIncreases your damage by 25%.\nIncreases your healing.\nIncreases your health by 80.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            AncientCost = 50;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 1);
            isAbility = true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Buffs.Damaging>(), 660, false);
            player.AddBuff(ModContent.BuffType<Buffs.Healing>(), 660, false);
            player.AddBuff(ModContent.BuffType<Buffs.HPBoost>(), 660, false);
            for (int i = 0; i < Main.maxPlayers; i++)
                if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                {
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.Damaging>(), 660, false);
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.Healing>(), 660, false);
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.HPBoost>(), 660, false);
                }
            return true;
        }
    }
}