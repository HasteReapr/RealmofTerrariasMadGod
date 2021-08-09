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
    class AbilityUIElementFunction : ModPlayer
    {
        //player.DirectionTo(Main.MouseWorld) * speed
        private int UseCost = 0;
        private int healing = 0;
        private int buffType = -1;
        private int buffType2 = -1;
        private int buffType3 = -1;
        private int buffType4 = -1;
        private int buffType5 = -1;
        private int buffTime = 0;
        private int buffTime2 = 0;
        private int buffTime3 = 0;
        private int buffTime4 = 0;
        private int buffTime5 = 0;
        private int projectileType = -1;
        private int speed = 16;
        private int knockBack = 0;
        private int Damage = 0;
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item?.IsAir ?? true)
            {
                UseCost = 0;
                healing = 0;
                buffType = -1;
                buffType2 = -1;
                buffType3 = -1;
                buffType4 = -1;
                buffType5 = -1;
                buffTime = 0;
                buffTime2 = 0;
                buffTime3 = 0;
                buffTime4 = 0;
                buffTime5 = 0;
                projectileType = -1;
                speed = 16;
                knockBack = 0;
                Damage = 0;
            }
            if (ROTMG_Items.AbilityHotKey.JustPressed)
            {
                Vector2 v = player.DirectionFrom(Main.MouseWorld);
                Vector2 perpendicular = v.RotatedBy(MathHelper.PiOver2);
                Vector2 toMouse = Vector2.Normalize(Main.MouseWorld - (Main.MouseWorld + (v * 60) + (perpendicular * 60)));
                if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item?.IsAir ?? true)
                {
                    Main.NewText("You need to have an item in the slot to use it!");
                    UseCost = 0;
                }

                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t1Cloak>())
                {
                    buffType2 = ModContent.BuffType<RogueInvisible>();
                    buffTime2 = 540;
                    UseCost = 20;
                    buffType = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t2Cloak>())
                {
                    buffType2 = ModContent.BuffType<RogueInvisible>();
                    buffTime2 = 720;
                    UseCost = 30;
                    buffType = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t3Cloak>())
                {
                    buffType2 = ModContent.BuffType<RogueInvisible>();
                    buffTime2 = 900;
                    UseCost = 35;
                    buffType = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t4Cloak>())
                {
                    buffType2 = ModContent.BuffType<RogueInvisible>();
                    buffTime2 = 1080;
                    UseCost = 40;
                    buffType = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t5Cloak>())
                {
                    buffType2 = ModContent.BuffType<RogueInvisible>();
                    buffTime2 = 1260;
                    UseCost = 45;
                    buffType = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t6Cloak>())
                {
                    buffType2 = ModContent.BuffType<RogueInvisible>();
                    buffTime2 = 1440;
                    UseCost = 50;
                    buffType = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<BloodySurprises>())
                {
                    buffType2 = ModContent.BuffType<RogueInvisible>();
                    buffTime2 = 1200;
                    buffType3 = ModContent.BuffType<ATKUp>();
                    buffTime3 = 1200;
                    buffType4 = ModContent.BuffType<Slowed>();
                    buffTime4 = 1440;
                    UseCost = 20;
                    buffType = -1;
                    buffType5 = -1;
                } // These are cloaks, they make you invinsible, aka completely undectatable by enemies. This means any enemy. Everything ignores you.

                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t1Helm>())
                {
                    buffType = ModContent.BuffType<WarrBuff>();
                    buffTime = 300;
                    buffType2 = ModContent.BuffType<Speedy>();
                    buffTime2 = 300;
                    UseCost = 20;

                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t2Helm>())
                {
                    buffType = ModContent.BuffType<WarrBuff>();
                    buffTime = 420;
                    buffType2 = ModContent.BuffType<Speedy>();
                    buffTime2 = 420;
                    UseCost = 25;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t3Helm>())
                {
                    buffType = ModContent.BuffType<WarrBuff>();
                    buffTime = 560;
                    buffType2 = ModContent.BuffType<Speedy>();
                    buffTime2 = 560;
                    UseCost = 30;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t4Helm>())
                {
                    buffType = ModContent.BuffType<WarrBuff>();
                    buffTime = 640;
                    buffType2 = ModContent.BuffType<Speedy>();
                    buffTime2 = 640;
                    UseCost = 0;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t5Helm>())
                {
                    buffType = ModContent.BuffType<WarrBuff>();
                    buffTime = 760;
                    buffType2 = ModContent.BuffType<Speedy>();
                    buffTime2 = 760;
                    UseCost = 40;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t6Helm>())
                {
                    buffType = ModContent.BuffType<WarrBuff>();
                    buffTime = 1560;
                    buffType2 = ModContent.BuffType<Speedy>();
                    buffTime2 = 1560;
                    UseCost = 50;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<Jugg>())
                {
                    buffType = ModContent.BuffType<WarrBuff>();
                    buffTime = 1560;
                    buffType2 = ModContent.BuffType<Armored>();
                    buffTime2 = 1560;
                    UseCost = 65;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                } //Helmets, they give warrior buff which is usetime * 1.75 or 75% faster.

                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t1Seal>())
                {
                    buffType = ModContent.BuffType<Damaging>();
                    buffTime = 300;
                    UseCost = 20;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t2Seal>())
                {
                    buffType = ModContent.BuffType<Damaging>();
                    buffTime = 420;
                    buffType4 = ModContent.BuffType<Healing>();
                    buffTime4 = 420;
                    UseCost = 35;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t3Seal>())
                {
                    buffType = ModContent.BuffType<Damaging>();
                    buffTime = 560;
                    buffType4 = ModContent.BuffType<Healing>();
                    buffTime4 = 560;
                    UseCost = 40;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t4Seal>())
                {
                    buffType = ModContent.BuffType<HPBoost>();
                    buffTime = 640;
                    buffType4 = ModContent.BuffType<Damaging>();
                    buffTime4 = 640;
                    buffType5 = ModContent.BuffType<Healing>();
                    buffTime5 = 640;
                    UseCost = 50;
                    buffType2 = -1;
                    buffType3 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t5Seal>())
                {
                    buffType = ModContent.BuffType<HPBoost>();
                    buffTime = 760;
                    buffType4 = ModContent.BuffType<Damaging>();
                    buffTime4 = 760;
                    buffType5 = ModContent.BuffType<Healing>();
                    buffTime5 = 760;
                    UseCost = 55;
                    buffType2 = -1;
                    buffType3 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t6Seal>())
                {
                    buffType = ModContent.BuffType<HPBoost>();
                    buffTime = 1560;
                    buffType4 = ModContent.BuffType<Damaging>();
                    buffTime4 = 1560;
                    buffType5 = ModContent.BuffType<Healing>();
                    buffTime5 = 1560;
                    UseCost = 60;
                    buffType2 = -1;
                    buffType3 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<Oreo>())
                {
                    buffType2 = ModContent.BuffType<Invulnerable>();
                    buffTime2 = 120;
                    buffType = ModContent.BuffType<Damaging>();
                    buffTime = 480;
                    UseCost = 85;
                    buffType = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }//seals give healing damagin and health boost

                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t1Tome>())
                {
                    healing = 40;
                    buffType = ModContent.BuffType<Healing>();
                    buffTime = 300;
                    UseCost = 20;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t2Tome>())
                {
                    healing = 70;
                    buffType = ModContent.BuffType<Healing>();
                    buffTime = 420;
                    UseCost = 30;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t3Tome>())
                {
                    healing = 100;
                    buffType = ModContent.BuffType<Healing>();
                    buffTime = 540;
                    UseCost = 40;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t4Tome>())
                {
                    healing = 130;
                    buffType = ModContent.BuffType<Healing>();
                    buffTime = 660;
                    UseCost = 50;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t5Tome>())
                {
                    healing = 160;
                    buffType = ModContent.BuffType<Healing>();
                    buffTime = 780;
                    UseCost = 60;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t6Tome>())
                {
                    healing = 220;
                    buffType = ModContent.BuffType<Healing>();
                    buffTime = 1440;
                    UseCost = 75;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                } // tomes heal for x ammount and give healing


                // Below here, everything shoots a projectile.
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<GFate>())
                {
                    projectileType = ModContent.ProjectileType<CoinParticle>();
                    speed = 16;
                    Damage = 0;
                    knockBack = 0;
                    UseCost = 75;
                    buffType = -1;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t1Prism>())
                {
                    projectileType = ModContent.ProjectileType<t1Decoy>();
                    speed = 16;
                    Damage = 0;
                    knockBack = 0;
                    UseCost = 20;
                    buffType = -1;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t2Prism>())
                {
                    projectileType = ModContent.ProjectileType<t2Decoy>();
                    speed = 16;
                    Damage = 0;
                    knockBack = 0;
                    UseCost = 25;
                    buffType = -1;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t3Prism>())
                {
                    projectileType = ModContent.ProjectileType<t3Decoy>();
                    speed = 16;
                    Damage = 0;
                    knockBack = 0;
                    UseCost = 30;
                    buffType = -1;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t4Prism>())
                {
                    projectileType = ModContent.ProjectileType<t4Decoy>();
                    speed = 16;
                    Damage = 0;
                    knockBack = 0;
                    UseCost = 35;
                    buffType = -1;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t5Prism>())
                {
                    projectileType = ModContent.ProjectileType<t5Decoy>();
                    speed = 16;
                    Damage = 0;
                    knockBack = 0;
                    UseCost = 40;
                    buffType = -1;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t6Prism>())
                {
                    projectileType = ModContent.ProjectileType<t6Decoy>();
                    speed = 16;
                    Damage = 0;
                    knockBack = 0;
                    UseCost = 45;
                    buffType = -1;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<GPrism>())
                {
                    projectileType = ModContent.ProjectileType<GBomb>();
                    speed = 16;
                    Damage = 0;
                    knockBack = 0;
                    UseCost = 45;
                    buffType = -1;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                } // Prisms, these shoot a decoy that draws aggro from the player. Except GPrism, it just explodes and doesn't draw aggro.


                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t1Skull>())
                {
                    projectileType = ModContent.ProjectileType<SkullAOE>();
                    speed = 16;
                    Damage = 40;
                    knockBack = 0;
                    UseCost = 35;
                    buffType = -1;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t2Skull>())
                {
                    projectileType = ModContent.ProjectileType<SkullAOE>();
                    speed = 16;
                    Damage = 60;
                    knockBack = 0;
                    UseCost = 45;
                    buffType = -1;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t3Skull>())
                {
                    projectileType = ModContent.ProjectileType<SkullAOE>();
                    speed = 16;
                    Damage = 80;
                    knockBack = 0;
                    UseCost = 55;
                    buffType = -1;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t4Skull>())
                {
                    projectileType = ModContent.ProjectileType<SkullAOE>();
                    speed = 16;
                    Damage = 110;
                    knockBack = 0;
                    UseCost = 65;
                    buffType = -1;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t5Skull>())
                {
                    projectileType = ModContent.ProjectileType<SkullAOE>();
                    speed = 16;
                    Damage = 140;
                    knockBack = 0;
                    UseCost = 75;
                    buffType = -1;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t6Skull>())
                {
                    projectileType = ModContent.ProjectileType<SkullAOE>();
                    speed = 16;
                    Damage = 210;
                    knockBack = 0;
                    UseCost = 85;
                    buffType = -1;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }//Skulls, a life stealing thing and only use 1 projectile which heals 45% of the damage

                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t1Waki>())
                {
                    Projectile.NewProjectile(Main.MouseWorld + (v * 40) + (perpendicular * 90), toMouse * 8, ModContent.ProjectileType<t1Waki_Proj>(), 40, 0, player.whoAmI, 0, 0);
                    UseCost = 35;
                    buffType = -1;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                }

                if (player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent >= UseCost)
                {
                    player.statLife += healing;
                    if(buffType != -1)
                    {
                        player.AddBuff(buffType, buffTime, false);
                        for (int i = 0; i < Main.maxPlayers; i++)
                            if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                            {
                                Main.player[i].AddBuff(buffType, buffTime, false);
                            }
                    }
                    if(buffType2 != -1)
                    {
                        player.AddBuff(buffType2, buffTime2, false);
                    }
                    if(buffType3 != -1)
                    {
                        player.AddBuff(buffType3, buffTime3, false);
                    }
                    if(buffType4 != -1)
                    {
                        player.AddBuff(buffType4, buffTime4, false);
                        for (int i = 0; i < Main.maxPlayers; i++)
                            if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                            {
                                Main.player[i].AddBuff(buffType4, buffTime4, false);
                            }
                    }
                    if(buffType5 != -1)
                    {
                        player.AddBuff(buffType5, buffTime5, false);
                        for (int i = 0; i < Main.maxPlayers; i++)
                            if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                            {
                                Main.player[i].AddBuff(buffType5, buffTime5, false);
                            }
                    }
                    for (int i = 0; i < Main.maxPlayers; i++)
                        if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                        {
                            Main.player[i].statLife += healing;
                        }
                    if(projectileType != -1)
                    {
                        Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * speed, projectileType, Damage, knockBack, Main.myPlayer, 0, 0);
                    }
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= UseCost;
                }
                else
                {
                    UseCost = 0;
                    healing = 0;
                    buffType = -1;
                    buffType2 = -1;
                    buffType3 = -1;
                    buffType4 = -1;
                    buffType5 = -1;
                    buffTime = 0;
                    buffTime2 = 0;
                    buffTime3 = 0;
                    buffTime4 = 0;
                    buffTime5 = 0;
                    projectileType = -1;
                    speed = 16;
                    knockBack = 0;
                    Damage = 0;
                    return;
                }
            }
        }
    }
}
