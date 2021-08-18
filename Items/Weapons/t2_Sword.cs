using System;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using ROTMG_Items.Items.Weapons.Projectiles;

namespace ROTMG_Items.Items.Weapons
{
    class t2_Sword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Saber");
            Tooltip.SetDefault("A sharp saber made from steel.");
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.width = 34;
            item.height = 34;
            item.melee = true;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shootSpeed = 16;
            item.shoot = ModContent.ProjectileType<t2_Sword_Proj>();
        }
    }
}
