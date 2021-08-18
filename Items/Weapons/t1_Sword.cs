using System;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using ROTMG_Items.Items.Weapons.Projectiles;

namespace ROTMG_Items.Items.Weapons
{
    class t1_Sword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Broad Sword");
            Tooltip.SetDefault("A simple broad sword made from iron.");
        }

        public override void SetDefaults()
        {
            item.damage = 10;
            item.width = 34;
            item.height = 34;
            item.melee = true;
            item.useTime = 20;
            item.useAnimation = 20;
            item.autoReuse = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
            item.shootSpeed = 16;
            item.shoot = ModContent.ProjectileType<t1_Sword_Proj>();
        }
    }
}
