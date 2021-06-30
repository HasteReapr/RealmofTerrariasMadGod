using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.Buffs
{
    public class AncientSickness : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Ancient Sickness");
            Description.SetDefault("You feel strange.\nYou shouldn't use Ancient Potions.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
    }
}
