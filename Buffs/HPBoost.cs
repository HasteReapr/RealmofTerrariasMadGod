using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.Buffs
{
    public class HPBoost : ModBuff
    {
        // HPBoost is t1
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Health Boost");
            Description.SetDefault("You feel healthier.\nIncreases maximum life by 40.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statLifeMax2 += 40;
        }
    }

    public class HPBoost2 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Health Boost");
            Description.SetDefault("You feel healthier.\nIncreases maximum life by 60.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statLifeMax2 += 60;
        }
    }

    public class HPBoost3 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Health Boost");
            Description.SetDefault("You feel healthier.\nIncreases maximum life by 80.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statLifeMax2 += 80;
        }
    }

    public class HPBoost4 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Health Boost");
            Description.SetDefault("You feel healthier.\nIncreases maximum life by 100.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statLifeMax2 += 100;
        }
    }

    public class HPBoost5 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Health Boost");
            Description.SetDefault("You feel healthier.\nIncreases maximum life by 120.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statLifeMax2 += 120;
        }
    }

    public class HPBoost6 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Health Boost");
            Description.SetDefault("You feel healthier.\nIncreases maximum life by 140.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statLifeMax2 += 140;
        }
    }
}