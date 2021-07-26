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
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (ROTMG_Items.AbilityHotKey.JustPressed)
            {
                if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item?.IsAir ?? true)
                {
                    Main.NewText("You need to have an item in the slot to use it!");
                }

                else if(ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t1Cloak>())
                {
                    player.AddBuff(ModContent.BuffType<RogueInvisible>(), 540, false);
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 20;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t2Cloak>())
                {
                    player.AddBuff(ModContent.BuffType<RogueInvisible>(), 720, false);
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 30;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t3Cloak>())
                {
                    player.AddBuff(ModContent.BuffType<RogueInvisible>(), 900, false);
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 35;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t4Cloak>())
                {
                    player.AddBuff(ModContent.BuffType<RogueInvisible>(), 1080, false);
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 40;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t5Cloak>())
                {
                    player.AddBuff(ModContent.BuffType<RogueInvisible>(), 1260, false);
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 45;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t6Cloak>())
                {
                    player.AddBuff(ModContent.BuffType<RogueInvisible>(), 1440, false);
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 50;
                }
                else if(ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<BloodySurprises>())
                {
                    player.AddBuff(ModContent.BuffType<RogueInvisible>(), 1200, false);
                    player.AddBuff(ModContent.BuffType<ATKUp>(), 1200, false);
                    player.AddBuff(ModContent.BuffType<Slowed>(), 1440, false);
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 20;
                } // These are cloaks, they make you invinsible, aka completely undectatable by enemies. This means any enemy. Everything ignores you.

                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t1Helm>())
                {
                    player.AddBuff(ModContent.BuffType<WarrBuff>(), 300, false);
                    player.AddBuff(ModContent.BuffType<Speedy>(), 300, false);
                    for (int i = 0; i < Main.maxPlayers; i++)
                        if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                        {
                            Main.player[i].AddBuff(ModContent.BuffType<WarrBuff>(), 300, false);
                        }
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 20;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t2Helm>())
                {
                    player.AddBuff(ModContent.BuffType<WarrBuff>(), 420, false);
                    player.AddBuff(ModContent.BuffType<Speedy>(), 420, false);
                    for (int i = 0; i < Main.maxPlayers; i++)
                        if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                        {
                            Main.player[i].AddBuff(ModContent.BuffType<WarrBuff>(), 420, false);
                        }
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 25;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t3Helm>())
                {
                    player.AddBuff(ModContent.BuffType<WarrBuff>(), 560, false);
                    player.AddBuff(ModContent.BuffType<Speedy>(), 560, false);
                    for (int i = 0; i < Main.maxPlayers; i++)
                        if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                        {
                            Main.player[i].AddBuff(ModContent.BuffType<WarrBuff>(), 560, false);
                        }
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 30;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t4Helm>())
                {
                    player.AddBuff(ModContent.BuffType<WarrBuff>(), 640, false);
                    player.AddBuff(ModContent.BuffType<Speedy>(), 640, false);
                    for (int i = 0; i < Main.maxPlayers; i++)
                        if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                        {
                            Main.player[i].AddBuff(ModContent.BuffType<WarrBuff>(), 640, false);
                        }
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 35;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t5Helm>())
                {
                    player.AddBuff(ModContent.BuffType<WarrBuff>(), 760, false);
                    player.AddBuff(ModContent.BuffType<Speedy>(), 760, false);
                    for (int i = 0; i < Main.maxPlayers; i++)
                        if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                        {
                            Main.player[i].AddBuff(ModContent.BuffType<WarrBuff>(), 760, false);
                        }
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 40;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t6Helm>())
                {
                    player.AddBuff(ModContent.BuffType<WarrBuff>(), 1560, false);
                    player.AddBuff(ModContent.BuffType<Speedy>(), 1560, false);
                    for (int i = 0; i < Main.maxPlayers; i++)
                        if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                        {
                            Main.player[i].AddBuff(ModContent.BuffType<WarrBuff>(), 1560, false);
                        }
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 50;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<Jugg>())
                {
                    player.AddBuff(ModContent.BuffType<WarrBuff>(), 1560, false);
                    player.AddBuff(ModContent.BuffType<Armored>(), 1560, false);
                    for (int i = 0; i < Main.maxPlayers; i++)
                        if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                        {
                            Main.player[i].AddBuff(ModContent.BuffType<WarrBuff>(), 1560, false);
                        }
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 65;
                } //Helmets, they give warrior buff which is usetime * 1.75 or 75% faster.

                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t1Seal>())
                {
                    player.AddBuff(ModContent.BuffType<Damaging>(), 300, false);
                    for (int i = 0; i < Main.maxPlayers; i++)
                        if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                        {
                            Main.player[i].AddBuff(ModContent.BuffType<Damaging>(), 300, false);
                        }
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 20;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t2Seal>())
                {
                    player.AddBuff(ModContent.BuffType<Damaging>(), 420, false);
                    player.AddBuff(ModContent.BuffType<Healing>(), 420, false);
                    for (int i = 0; i < Main.maxPlayers; i++)
                        if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                        {
                            Main.player[i].AddBuff(ModContent.BuffType<Damaging>(), 420, false);
                            Main.player[i].AddBuff(ModContent.BuffType<Healing>(), 420, false);
                        }
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 35;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t3Seal>())
                {
                    player.AddBuff(ModContent.BuffType<Damaging>(), 560, false);
                    player.AddBuff(ModContent.BuffType<Healing>(), 560, false);
                    for (int i = 0; i < Main.maxPlayers; i++)
                        if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                        {
                            Main.player[i].AddBuff(ModContent.BuffType<Damaging>(), 560, false);
                            Main.player[i].AddBuff(ModContent.BuffType<Healing>(), 560, false);
                        }
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 40;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t4Seal>())
                {
                    player.AddBuff(ModContent.BuffType<HPBoost>(), 640, false);
                    player.AddBuff(ModContent.BuffType<Damaging>(), 640, false);
                    player.AddBuff(ModContent.BuffType<Healing>(), 640, false);
                    for (int i = 0; i < Main.maxPlayers; i++)
                        if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                        {
                            Main.player[i].AddBuff(ModContent.BuffType<HPBoost>(), 640, false);
                            Main.player[i].AddBuff(ModContent.BuffType<Damaging>(), 640, false);
                            Main.player[i].AddBuff(ModContent.BuffType<Healing>(), 640, false);
                        }
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 50;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t5Seal>())
                {
                    player.AddBuff(ModContent.BuffType<HPBoost>(), 760, false);
                    player.AddBuff(ModContent.BuffType<Damaging>(), 760, false);
                    player.AddBuff(ModContent.BuffType<Healing>(), 760, false);
                    for (int i = 0; i < Main.maxPlayers; i++)
                        if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                        {
                            Main.player[i].AddBuff(ModContent.BuffType<HPBoost>(), 760, false);
                            Main.player[i].AddBuff(ModContent.BuffType<Damaging>(), 760, false);
                            Main.player[i].AddBuff(ModContent.BuffType<Healing>(), 760, false);
                        }
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 55;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t6Seal>())
                {
                    player.AddBuff(ModContent.BuffType<HPBoost>(), 1560, false);
                    player.AddBuff(ModContent.BuffType<Damaging>(), 1560, false);
                    player.AddBuff(ModContent.BuffType<Healing>(), 1560, false);
                    for (int i = 0; i < Main.maxPlayers; i++)
                        if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                        {
                            Main.player[i].AddBuff(ModContent.BuffType<HPBoost>(), 1560, false);
                            Main.player[i].AddBuff(ModContent.BuffType<Damaging>(), 1560, false);
                            Main.player[i].AddBuff(ModContent.BuffType<Healing>(), 1560, false);
                        }
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 60;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<Oreo>())
                {
                    player.AddBuff(ModContent.BuffType<Invulnerable>(), 120, false);
                    player.AddBuff(ModContent.BuffType<Damaging>(), 480, false);
                    for (int i = 0; i < Main.maxPlayers; i++)
                        if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                        {
                            Main.player[i].AddBuff(ModContent.BuffType<Damaging>(), 480, false);
                        }
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 85;
                }

                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t1Tome>())
                {
                    player.statLife += 40;
                    player.AddBuff(ModContent.BuffType<Healing>(), 300, false);
                    for (int i = 0; i < Main.maxPlayers; i++)
                        if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                        {
                            Main.player[i].AddBuff(ModContent.BuffType<Healing>(), 300, false);
                            Main.player[i].statLife += 40;
                        }
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 20;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t2Tome>())
                {
                    player.statLife += 70;
                    player.AddBuff(ModContent.BuffType<Healing>(), 420, false);
                    for (int i = 0; i < Main.maxPlayers; i++)
                        if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                        {
                            Main.player[i].AddBuff(ModContent.BuffType<Healing>(), 420, false);
                            Main.player[i].statLife += 70;
                        }
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 30;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t3Tome>())
                {
                    player.statLife += 100;
                    player.AddBuff(ModContent.BuffType<Healing>(), 540, false);
                    for (int i = 0; i < Main.maxPlayers; i++)
                        if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                        {
                            Main.player[i].AddBuff(ModContent.BuffType<Healing>(), 540, false);
                            Main.player[i].statLife += 100;
                        }
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 40;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t4Tome>())
                {
                    player.statLife += 130;
                    player.AddBuff(ModContent.BuffType<Healing>(), 660, false);
                    for (int i = 0; i < Main.maxPlayers; i++)
                        if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                        {
                            Main.player[i].AddBuff(ModContent.BuffType<Healing>(), 660, false);
                            Main.player[i].statLife += 130;
                        }
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 50;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t5Tome>())
                {
                    player.statLife += 160;
                    player.AddBuff(ModContent.BuffType<Healing>(), 780, false);
                    for (int i = 0; i < Main.maxPlayers; i++)
                        if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                        {
                            Main.player[i].AddBuff(ModContent.BuffType<Healing>(), 780, false);
                            Main.player[i].statLife += 160;
                        }
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 60;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t6Tome>())
                {
                    player.statLife += 220;
                    player.AddBuff(ModContent.BuffType<Healing>(), 1440, false);
                    for (int i = 0; i < Main.maxPlayers; i++)
                        if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                        {
                            Main.player[i].AddBuff(ModContent.BuffType<Healing>(), 1440, false);
                            Main.player[i].statLife += 220;
                        }
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 75;
                }


                // Below here, everything shoots a projectile.
                else if(ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<GFate>())
                {
                    Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * 16, ModContent.ProjectileType<CoinParticle>(), 0, 0, Main.myPlayer, 0, 0);
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 75;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t1Prism>())
                {
                    Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * 16, ModContent.ProjectileType<t1Decoy>(), 0, 0, Main.myPlayer, 0, 0);
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 20;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t2Prism>())
                {
                    Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * 16, ModContent.ProjectileType<t2Decoy>(), 0, 0, Main.myPlayer, 0, 0);
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 25;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t3Prism>())
                {
                    Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * 16, ModContent.ProjectileType<t3Decoy>(), 0, 0, Main.myPlayer, 0, 0);
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 30;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t4Prism>())
                {
                    Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * 16, ModContent.ProjectileType<t4Decoy>(), 0, 0, Main.myPlayer, 0, 0);
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 35;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t5Prism>())
                {
                    Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * 16, ModContent.ProjectileType<t5Decoy>(), 0, 0, Main.myPlayer, 0, 0);
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 40;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t6Prism>())
                {
                    Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * 16, ModContent.ProjectileType<t6Decoy>(), 0, 0, Main.myPlayer, 0, 0);
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 45;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<GPrism>())
                {
                    Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * 16, ModContent.ProjectileType<GBomb>(), 0, 0, Main.myPlayer, 0, 0);
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 45;
                } // Prisms, these shoot a decoy that draws aggro from the player. Except GPrism, it just explodes and doesn't draw aggro.


                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t1Skull>())
                {
                    Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * 16, ModContent.ProjectileType<SkullAOE>(), 40, 0, Main.myPlayer, 0, 0);
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 35;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t2Skull>())
                {
                    Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * 16, ModContent.ProjectileType<SkullAOE>(), 60, 0, Main.myPlayer, 0, 0);
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 45;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t3Skull>())
                {
                    Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * 16, ModContent.ProjectileType<SkullAOE>(), 80, 0, Main.myPlayer, 0, 0);
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 55;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t4Skull>())
                {
                    Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * 16, ModContent.ProjectileType<SkullAOE>(), 110, 0, Main.myPlayer, 0, 0);
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 65;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t5Skull>())
                {
                    Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * 16, ModContent.ProjectileType<SkullAOE>(), 140, 0, Main.myPlayer, 0, 0);
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 75;
                }
                else if (ModContent.GetInstance<ROTMG_Items>().AbilitySlotUI._vanillaItemSlot.Item.type == ModContent.ItemType<t6Skull>())
                {
                    Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * 16, ModContent.ProjectileType<SkullAOE>(), 210, 0, Main.myPlayer, 0, 0);
                    player.GetModPlayer<ROTMGPlayer>().AbilityPowerCurrent -= 85;
                }//Skulls, a life stealing thing and only use 1 projectile which heals 45% of the damage
            }
        }
    }
}
