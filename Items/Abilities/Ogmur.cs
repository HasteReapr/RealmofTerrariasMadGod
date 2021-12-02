using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Buffs;
using ROTMG_Items.Items.Materials;
using ROTMG_Items.Items.Abilities.Projectiles;


namespace ROTMG_Items.Items.Abilities
{
    class Ogmur : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shield of the Ancients");
            Tooltip.SetDefault("A shield once wielded by the ancient knights of a long forgotten kingdom.\nImbued with an ancient power, it inflicts armor shattered on your target for 12 seconds.");
        }

        public override void SetDefaults()
        {
            item.damage = 120;
            item.width = 36;
            item.height = 34;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            AncientCost = 100;
            item.shoot = ModContent.ProjectileType<Ogmur_Proj>();
            item.shootSpeed = 16;
            item.rare = ItemRarityID.Expert;
            item.value = Item.buyPrice(gold: 1);
            isAbility = true;
        }
    }
}
