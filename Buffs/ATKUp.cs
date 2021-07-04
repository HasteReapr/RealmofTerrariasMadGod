using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.Buffs
{
    public class ATKUp : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Attack Up");
            Description.SetDefault("You hit harder.\nIncreases your defense by 25.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.allDamage += 1.25f;
        }
    }
}