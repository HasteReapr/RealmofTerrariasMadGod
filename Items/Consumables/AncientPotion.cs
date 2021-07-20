using Terraria;
using Terraria.ID;
using ROTMG_Items.Items.Abilities;
using ROTMG_Items.Buffs;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Consumables
{
    class AncientPotion : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Potion");
            Tooltip.SetDefault("A potion used by the ancient ones to recover their energy.");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 17;
            item.useTime = 17;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Orange;
            item.value = Item.buyPrice(gold: 1);
        }

        public override bool UseItem(Player player)
        {
            if (player.HasBuff(ModContent.BuffType<AncientSickness>()))
            {
                player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 35;
            } else
            player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent += 75;
            player.AddBuff(ModContent.BuffType<Buffs.AncientSickness>(), 600, false);
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if(player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent < 35)
            {
                return false;
            }
            return true;
        }
    }
}