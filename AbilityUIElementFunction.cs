using Terraria;
using Terraria.ModLoader;
using Terraria.GameInput;
using ROTMG_Items.UI;
using ROTMG_Items.Items.Abilities;
using ROTMG_Items.Buffs;
using ROTMG_Items;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.IO;

namespace ROTMG_Items
{
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
            var item = AbilitySlotItem.modItem;
            if(item is AncientCostFunction ancCost)
            {
                useCost = ancCost.AncientCost;
                buffInt = ancCost.item.buffType;
                buffLength = ancCost.item.buffTime;
                buffInt2 = ancCost.buffType2;
                buffLength2 = ancCost.buffTime2;
                buffInt3 = ancCost.buffType3;
                buffLength3 = ancCost.buffTime3;
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

        public override TagCompound Save()
        {
            return new TagCompound {
				{"itemType", ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type},
            };
        }

        public override void Load(TagCompound tag)
        {
            ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type = tag.GetInt("itemType");
        }

        public override void Initialize()
        {
            //make it load the item from the slot here so it saves when the mod reloads
        }
    }
}