using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Abilities
{
    public class t1Cloak : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cloak of Invisibility");
            Tooltip.SetDefault("Makes you invisible.\nWhile invisible, no enemies will target you.\nA cloak made of a magical essense that hides the user from sight.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            AncientCost = 20;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 1);
            item.buffType = ModContent.BuffType<Buffs.RogueInvisible>();
            item.buffTime = 540;
        }
    }
}