using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.Buffs
{
    public class ArmorShattered : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Armor Shattered");
            Description.SetDefault("Your armor is absolutely destroyed.\nDefense is 0.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }


        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense -= 1000;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.defense = 0;
        }
    }
}