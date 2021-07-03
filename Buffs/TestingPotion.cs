using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Buffs
{
    public class TestingPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Testing Potion");;
            Tooltip.SetDefault("Applies whatever buff/debuff I was debugging at the time.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Orange;
            item.value = Item.buyPrice(gold: 1);
            item.buffType = ModContent.BuffType<Buffs.ZeroGravity>(); //Specify an existing buff to be applied when used.
            item.buffTime = 60000; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }
    }
}