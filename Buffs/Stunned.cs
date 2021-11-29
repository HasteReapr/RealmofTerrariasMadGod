using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace ROTMG_Items.Buffs
{
    class Stunned : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Stunned");
            Description.SetDefault("You cannot attack.");
            Main.debuff[Type] = false;
            Main.buffNoTimeDisplay[Type] = true;
        }
        int timer = 2;
        int randomizedsize = Main.rand.Next(8, 64);
        public override void Update(Player player, ref int buffIndex)
        {
         //need to do something here that prevents the player from attacking, something like a CanUseItem bool set to false.   
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.damage *= (int)0.60f;
        }
    }
}
