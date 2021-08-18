using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

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
                if (Main.expertMode)
                {
                    player.statLife -= 4;
                }
                else if (NPC.downedBoss3)
                {
                    if (Main.expertMode)
                    {
                        player.statLife -= 7;
                    }
                    else
                    {
                        player.statLife -= 4;
                    }
                }
                else if (NPC.downedMechBoss3)
                {
                    if (Main.expertMode)
                    {
                        player.statLife -= 11;
                    }
                    else
                    {
                        player.statLife -= 7;
                    }
                }
                else if (NPC.downedPlantBoss)
                {
                    if (Main.expertMode)
                    {
                        player.statLife -= 16;
                    }
                    else
                    {
                        player.statLife -= 11;
                    }
                }
                else if (NPC.downedMoonlord)
                {
                    if (Main.expertMode)
                    {
                        player.statLife -= 20;
                    }
                    else
                    {
                        player.statLife -= 15;
                    }
                }
                else
                {
                    player.statLife -= 1;
                }
                Dust.NewDust(player.Center, randomizedsize, randomizedsize, ModContent.DustType<Dusts.GhostlyDust>(), Main.rand.Next(3), Main.rand.Next(3));
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
