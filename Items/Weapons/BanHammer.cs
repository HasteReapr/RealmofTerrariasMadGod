using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items;
using ROTMG_Items.Items.Weapons.Projectiles;

namespace ROTMG_Items.Items.Weapons
{
    class BanHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ban Hammer");
            Tooltip.SetDefault("Instantly erases all life it touches.");
            item.rare = ItemRarityID.Expert;
        }

        public override void SetDefaults()
        {
            item.damage = 1;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 1000000;
            item.shoot = ModContent.ProjectileType<BanArea>();
            item.UseSound = SoundID.Item84;
            item.shootSpeed = 16f;
            item.buffType = ModContent.BuffType<Buffs.InstantDeath>();
            item.buffTime = 600000;
            item.autoReuse = true;
        }
    }
}
