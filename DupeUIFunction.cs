using Terraria;
using Terraria.ModLoader;
using Terraria.GameInput;
using ROTMG_Items.UI;
using ROTMG_Items.Items.Abilities;
using ROTMG_Items.Buffs;
using ROTMG_Items;
using Microsoft.Xna.Framework;

namespace ROTMG_Items
{
    public class DupeUIFunction : ModPlayer
    {
        public int points = 0;
        public float regenRate = 0.01f;
        public float regen = 0f;
        public int regenTimer = 180;
        public int cost = 1;

        public override void PostUpdate()
        {
            handlePoints();
        }

        private void handlePoints()
        {
            if (player.name.Equals("Bee") || player.name.Equals("Test Subject")){
                regenRate = 1;
            }


            if(points > 10)
            {
                points = 10;
            } 
            // to make sure the points don't go over the max. it's a static max unlike ancient mana which has a 
            // max that is dependent on how many mana potions were consumed.

            if(regenTimer-- <= 0)
            {
                regenTimer = 600;
                regen += regenRate;
            }
            if(regen >= 1)
            {
                points += 1;
                regen = 0;
            }
        }

        public void dupeGamble()
        {
            var ui = ModContent.GetInstance<DupeUIPanel>();
            if(points >= cost)
            {
                points -= cost;
                if (player.name.Equals("Test Subject") && ui.vanillaItemSlot.Item.IsAir == false)
                {
                    Item.NewItem(player.position, ui.vanillaItemSlot.Item.type, ui.vanillaItemSlot.Item.stack);
                    //player.QuickSpawnItem(ui.vanillaItemSlot.Item, ui.vanillaItemSlot.Item.stack);
                }
                if (Main.rand.NextBool(500) && ui.vanillaItemSlot.Item.IsAir == false)
                {
                    player.QuickSpawnItem(ui.vanillaItemSlot.Item, ui.vanillaItemSlot.Item.stack);
                }
                else
                {
                    return;
                }
            }
            else
            {
                Main.NewText("You must have enough points. (You don't get to know how much though.)");
            }
        }

        public override void clientClone(ModPlayer clientClone)
        {
            DupeUIFunction clone = clientClone as DupeUIFunction;

        }
    }
}