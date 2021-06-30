using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Abilities
{
    public class t6Cloak : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cloak of the Lunar Thieves");
            Tooltip.SetDefault("Makes you invisible.\nWhile invisible, no enemies will target you.\nA cloak made from otherwordly silk. It is designed specifically so nothing can spot you, ever.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            AncientCost = 50;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 9);
            item.buffType = ModContent.BuffType<Buffs.RogueInvisible>();
            item.buffTime = 1440;
        }
    }
}