using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Buffs
{
    class t6Poison : ModBuff
    {

        public override bool Autoload(ref string name, ref string texture)
        {
            texture = "ROTMG_Items/Buffs/BuffTemplate";
            return base.Autoload(ref name, ref texture);
        }
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Poisoned!");
            Description.SetDefault("Losing health rapidly.");
        }

        private int timer = 5;
        public override void Update(NPC npc, ref int buffIndex)
        {
            timer--;
            if (timer <= 0)
            {
                npc.StrikeNPC(2000, 0, 0);
                timer = 5;
            }
        }
    }
}
