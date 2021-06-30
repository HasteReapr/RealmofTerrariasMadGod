using Terraria;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.Buffs
{
    public class ZeroGravity : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Weightless");
            Description.SetDefault("You weigh absolutely nothing. \nHold JUMP to move up.\nHold DOWN to move down.\nUse LEFT/RIGHT to move left and right.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.gravity = 0;


            if (player.controlDown)
            {
                player.velocity.Y += player.runAcceleration;
            }
            else if (!player.controlDown)
            {
                if (player.controlJump)
                {
                    return;
                }
                else
                    player.velocity.Y *= 0.5f;
            }


            if (player.controlJump)
            {
                player.velocity.Y += player.runAcceleration;
            }
            else if (!player.controlJump)
            {
                if (player.controlDown)
                {
                    return;
                }
                else
                    player.velocity.Y *= 0.5f;
            }
        }
    }
}