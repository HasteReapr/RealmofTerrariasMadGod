using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.Buffs
{
    public class Exposed : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Exposed");
            Description.SetDefault("Your armor is weakened.\nDefense lowered by 20.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense -= 20;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.defense -= 20;
        }
    }
}