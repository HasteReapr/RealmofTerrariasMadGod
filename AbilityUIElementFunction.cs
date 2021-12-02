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
    //make a new UI element thats a draggable UI element, like how the pot UI is, but with an item slot on it
    // this new UI element is accessed by "/dupe" and when you put the item in there, it will have a 1/500 chance of duplicating
    // it will have a custom resource that will display on the draggable UI element, that uses ChronoType (learn how to do custom font later)
    // if you have enough of this resource, then it will allow you to attempt duplication, if not, then it will not allow you to attempt
    // the resource would regenerate incredibly slow, taking 1 day per point, needing
    // 10 points pre boss
    // 9 post eye
    // 8 post skeletron
    // 7 post wall
    // 6 post mech
    // 5 post plant
    // 4 post golem
    // 3 post lunatic
    // 1 post moon

    // the lower the cost, the longer the regeneration, so it is essentially the same
    public interface IItemInAbilitySlot
    {
        void OnTrigger(AbilityUIElementFunction uiFunc);
    }

    public class AbilityUIElementFunction : ModPlayer
    {
        public Item AbilitySlotItem => ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item;
        public int useCost = 0;
        public int buffInt = -1;
        public int buffLength = 0;
        public int buffInt2 = -1;
        public int buffLength2 = 0;
        public int buffInt3 = -1;
        public int buffLength3 = 0;
        public int projType = 0;
        public int damage = 0;
        public int tier = 0;
        public float speed = 16;
        public float knockBack = 0;
        public bool teamBuff = false;
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            var ancFunc = ModContent.GetInstance<AncientCostFunction>();
            var item = AbilitySlotItem.modItem;
            //AbilitySlotItem.modItem as IItemInAbilitySlot.OnTrigger();
            // what if MyItem was AncientCostFunction instead?
            if(item is AncientCostFunction ancCost)
            {
                useCost = ancCost.AncientCost;
                buffInt = ancCost.item.buffType;
                buffLength = ancCost.item.buffTime;
                projType = ancCost.item.shoot;
                speed = ancCost.item.shootSpeed;
                damage = ancCost.item.damage;
                tier = ancCost.tier;
                knockBack = ancCost.item.knockBack;
                teamBuff = ancCost.teamBuff;
            }
            var currentMana = player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent;
            if (ROTMG_Items.AbilityHotKey.JustPressed)
            {
                if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item?.IsAir ?? true)
                {
                    Main.NewText("You need to have an item in the slot to use it!");
                }
                if (currentMana >= useCost)
                {
                    if (buffInt != -1)
                    {
                        player.AddBuff(buffInt, buffLength, false);
                    }

                    if (buffInt2 != -1)
                    {
                        player.AddBuff(buffInt2, buffLength2, false);
                    }

                    if (buffInt3 != -1)
                    {
                        player.AddBuff(buffInt3, buffLength3, false);
                    }

                    if (projType != 0)
                    {
                        Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * speed, projType, damage, knockBack, player.whoAmI, 0, tier);
                    }

                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= useCost;
                }
                else
                {
                    useCost = 0;
                    buffInt = -1;
                    buffLength = 0;
                    buffInt2 = -1;
                    buffLength2 = 0;
                    buffInt3 = -1;
                    buffLength3 = 0;
                    projType = 0;
                    speed = 16;
                    knockBack = 0;
                    damage = 0;
                    tier = 0;
                    return;
                }
            }
        }
    }
}