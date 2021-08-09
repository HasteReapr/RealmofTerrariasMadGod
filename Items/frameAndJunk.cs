using Microsoft.Xna.Framework;
using Terraria;

namespace ROTMG_Items.Items
{
    static class frameAndJunk
    {
        public static Rectangle GetCurrentFrame(this Item item, ref int frame, ref int frameCounter, int frameDelay, int frameAmt, bool frameCounterUp = true)
        {
            if (frameCounter >= frameDelay)
            {
                frameCounter = -1;
                frame = ((frame != frameAmt - 1) ? (frame + 1) : 0);
            }
            if (frameCounterUp)
            {
                frameCounter++;
            }
            return new Rectangle(0, item.height * frame, item.width, item.height);
        }
    }
}