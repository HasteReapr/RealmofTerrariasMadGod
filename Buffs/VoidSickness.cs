using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace ROTMG_Items.Buffs
{
    class VoidSickness : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Void Sickness");
            Description.SetDefault("The void drains your life.");
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
        int timer = 2;
        int randomizedsize = Main.rand.Next(8, 64);
        public override void Update(Player player, ref int buffIndex)
        {
            timer--;
            if(timer <= 0)
            {
                randomizedsize = Main.rand.Next(8, 64);
                player.Hurt(PlayerDeathReason.ByCustomReason($"{player.name} was consumed by the void."), 3, 0);
                Dust.NewDust(player.Center + new Vector2(Main.rand.Next(-16, 16), Main.rand.Next(-16, 16)), randomizedsize, randomizedsize, ModContent.DustType<Dusts.GhostlyDust>(), Main.rand.Next(3), Main.rand.Next(3));
                timer = 2;
            }
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            timer--;
            if(timer <= 0)
            {
                Dust.NewDust(npc.Center, randomizedsize, randomizedsize, ModContent.DustType<Dusts.GhostlyDust>(), Main.rand.Next(3), Main.rand.Next(3));
                npc.life -= 5;
                timer = 2;
            }
        }
    }
}
