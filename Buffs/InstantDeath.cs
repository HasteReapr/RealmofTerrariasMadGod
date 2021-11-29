using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace ROTMG_Items.Buffs
{
    class InstantDeath : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Instant Death");
            Description.SetDefault("You shouldn't be able to read this.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            Main.NewText("Instant death was applied.");
            npc.StrikeNPC(999999999, 0, 0, false, false, false);
            npc.life = 0;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statLife = 0;
            player.Hurt(PlayerDeathReason.ByCustomReason($"{player.name} was deleted."), int.MaxValue, 0);
        }
    }
}
