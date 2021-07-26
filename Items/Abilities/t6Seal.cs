using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Items.Materials;

namespace ROTMG_Items.Items.Abilities
{
    public class t6Seal : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seal of of the Monk");
            Tooltip.SetDefault("A seal used by monks to bless others.Increases your healing.\nIncreases your health by 80.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            AncientCost = 60;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 1);
            isAbility = true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Buffs.Damaging>(), 1560, false);
            player.AddBuff(ModContent.BuffType<Buffs.Healing>(), 1560, false);
            player.AddBuff(ModContent.BuffType<Buffs.HPBoost>(), 1560, false);
            for (int i = 0; i < Main.maxPlayers; i++)
                if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                {
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.Damaging>(), 1560, false);
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.Healing>(), 1560, false);
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.HPBoost>(), 1560, false);
                }
            return true;
        }
    }
}