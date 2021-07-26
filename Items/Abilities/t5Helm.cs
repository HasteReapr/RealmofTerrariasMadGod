using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Items.Materials;

namespace ROTMG_Items.Items.Abilities
{
    public class t5Helm : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Helmet");
            Tooltip.SetDefault("A helmet made of steel and infused with Plantera's rage.\nGives speedy and berserk.");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            AncientCost = 40;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 1);
            item.buffType = ModContent.BuffType<Buffs.Speedy>();
            item.buffTime = 780;
            isAbility = true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Buffs.WarrBuff>(), 780, false);
            for (int i = 0; i < Main.maxPlayers; i++)
                if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                {
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.WarrBuff>(), 780, false);
                }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<t4Helm>());
            recipe.AddIngredient(ModContent.ItemType<HerbalEssence>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}