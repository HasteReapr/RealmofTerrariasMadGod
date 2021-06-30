using Terraria;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria.ModLoader; // dependencies

namespace ROTMG_Items.Buffs // the file location
{
	public class Unstable : ModBuff // name : dependencies
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Unstable"); // sets the name
			Description.SetDefault("You are unable to shoot straight."); // sets the description
			Main.debuff[Type] = true; // this makes it a debuff so you can't right click and cancel it.
			Main.pvpBuff[Type] = true; // i don't know what pvp buff does but every other debuff has it in it so i just put it here
			Main.buffNoSave[Type] = true; // just makes it so the buff doesn't stay when you leave/join worlds
		}
		public override void Update(Player player, ref int buffIndex) //// public override void is saying "hey im overriding this and i don't expect a return, hence void."
			{
				player.GetModPlayer<ROTMGPlayer>().Unstable = true; // this sets the Unstable buff in ROTMG Player to true, activating the effects. In the player class it just uses a function that randomizes the X/Y coords of the mouse position just like in rotmg
            
			}

			public override bool ReApply(Player player, int time, int buffIndex) //this just resets the timer if the buff is reapplied
			{
				player.buffTime[buffIndex] += time;
				return true;
			}
	}
}