using System;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace ROTMG_Items.Buffs
{
    class ShatteredArmor : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Shattered Armor");
            Description.SetDefault("Your armor is shattered. \nDefense is 0.");
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense *= 0;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.defense *= 0;
        }
    }
}
