using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.Buffs
{
    public class RogueInvisible : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("True Invisibility");
            Description.SetDefault("Nothing can detect you... but you're not invincible.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.aggro -= 16000000;


			//figure out how this works at some point in time

			/*float num54 = drawPlayer.stealth;
			if ((double)num54 < 0.03)
			{
				num54 = 0.03f;
			}
			if (num54 < 0f)
			{
				num54 = 0f;
			}
			if (!(num54 < 1f - shadow) && shadow > 0f)
			{
				num54 = shadow * 0.5f;
			}
			num49 = num54;
			Microsoft.Xna.Framework.Color secondColor = new Microsoft.Xna.Framework.Color(Vector4.Lerp(Vector4.One, new Vector4(0f, 0.12f, 0.16f, 0f), 1f - num54));
			color11 = color11.MultiplyRGBA(secondColor);
			color12 = color12.MultiplyRGBA(secondColor);
			color13 = color13.MultiplyRGBA(secondColor);
			num54 *= num54;
			color2 = Microsoft.Xna.Framework.Color.Multiply(color2, num54);
			color3 = Microsoft.Xna.Framework.Color.Multiply(color3, num54);
			color = Microsoft.Xna.Framework.Color.Multiply(color, num54);
			color4 = Microsoft.Xna.Framework.Color.Multiply(color4, num54);
			color5 = Microsoft.Xna.Framework.Color.Multiply(color5, num54);
			color7 = Microsoft.Xna.Framework.Color.Multiply(color7, num54);
			color8 = Microsoft.Xna.Framework.Color.Multiply(color8, num54);
			color9 = Microsoft.Xna.Framework.Color.Multiply(color9, num54);
			color10 = Microsoft.Xna.Framework.Color.Multiply(color10, num54);
			color6 = Microsoft.Xna.Framework.Color.Multiply(color6, num54);
			value2 = Microsoft.Xna.Framework.Color.Multiply(value2, num54);
			glowMaskColor = Microsoft.Xna.Framework.Color.Multiply(glowMaskColor, num54);
			glowMaskColor2 = Microsoft.Xna.Framework.Color.Multiply(glowMaskColor2, num54);
			color15 = Microsoft.Xna.Framework.Color.Multiply(color15, num54);
			glowMaskColor3 = Microsoft.Xna.Framework.Color.Multiply(glowMaskColor3, num54);
		}
		drawInfo.hairColor = color;
			drawInfo.eyeWhiteColor = color2;
			drawInfo.eyeColor = color3;
			drawInfo.faceColor = color4;
			drawInfo.bodyColor = color5;
			drawInfo.legColor = color6;
			drawInfo.shirtColor = color7;
			drawInfo.underShirtColor = color8;
			drawInfo.pantsColor = color9;
			drawInfo.shoeColor = color10;
			drawInfo.upperArmorColor = color11;
			drawInfo.middleArmorColor = color12;
			drawInfo.lowerArmorColor = color13;
			drawInfo.headGlowMask = glowMask;
			drawInfo.bodyGlowMask = glowMask2;
			drawInfo.armGlowMask = glowMask3;
			drawInfo.legGlowMask = glowMask4;
			drawInfo.headGlowMaskColor = glowMaskColor;
			drawInfo.bodyGlowMaskColor = glowMaskColor2;
			drawInfo.armGlowMaskColor = color15;
			drawInfo.legGlowMaskColor = glowMaskColor3;*/
        }
    }
}