using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Mono.Cecil;
using Mono.Cecil.Cil;
using TerrariAPI;
using TerrariAPI.Commands;
using TerrariAPI.Hooking;
using TerrariAPI.Plugins;
using XNAForms;

namespace TerraHax
{
    public class TerraHax : Plugin
    {
        public override string author { get { return "MarioE"; } }
        public override string name { get { return "TerraHax"; } }

        public static bool fullbright;
        public static bool godMode;
        public static bool gps;
        public static bool[] infBuff;
        public static bool noclip;
        public static bool pickupItems;
        public static Vector2 prevPosition;

        public TerraHax()
        {
            onHook += TerraHax_onHook;
            onInitialize += TerraHax_onInitialize;
            onUpdate += TerraHax_onUpdate;
            onUpdate2 += Terrahax_onUpdate2;
        }

        FieldInfo GetField(string name)
        {
            return typeof(TerraHax).GetField(name);
        }
        MethodInfo GetMethod(string name)
        {
            return typeof(TerraHax).GetMethod(name);
        }

        void TerraHax_onHook(object sender, PluginEventArgs e)
        {
            #region Main
            e.asm.GetMethod("Main", "Draw").Body.GetILProcessor().Insert(Target.START,
                Instruction.Create(OpCodes.Call, e.asm.MainModule.Import(GetMethod("TerraHax_beforeDraw")))
                );
            #endregion
            #region Lighting
            e.asm.GetMethod("Lighting", "LightColor").Body.GetILProcessor().Insert(Target.START,
                Instruction.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(typeof(TerraHax).GetField("fullbright"))),
                Instruction.Create(OpCodes.Brfalse, e.asm.GetMethod("Lighting", "LightColor").Body.Instructions[0]),
                Instruction.Create(OpCodes.Ldc_R4, 1f),
                Instruction.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight")),
                Instruction.Create(OpCodes.Ldc_R4, 1f),
                Instruction.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "wetLightR")),
                Instruction.Create(OpCodes.Ldc_R4, 1f),
                Instruction.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight2"))
                );
            e.asm.GetMethod("Lighting", "LightColorG").Body.GetILProcessor().Insert(Target.START,
                Instruction.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(typeof(TerraHax).GetField("fullbright"))),
                Instruction.Create(OpCodes.Brfalse, e.asm.GetMethod("Lighting", "LightColorG").Body.Instructions[0]),
                Instruction.Create(OpCodes.Ldc_R4, 1f),
                Instruction.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight")),
                Instruction.Create(OpCodes.Ldc_R4, 1f),
                Instruction.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "wetLightR")),
                Instruction.Create(OpCodes.Ldc_R4, 1f),
                Instruction.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight2"))
                );
            e.asm.GetMethod("Lighting", "LightColorB").Body.GetILProcessor().Insert(Target.START,
                Instruction.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(typeof(TerraHax).GetField("fullbright"))),
                Instruction.Create(OpCodes.Brfalse, e.asm.GetMethod("Lighting", "LightColorB").Body.Instructions[0]),
                Instruction.Create(OpCodes.Ldc_R4, 1f),
                Instruction.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight")),
                Instruction.Create(OpCodes.Ldc_R4, 1f),
                Instruction.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "wetLightR")),
                Instruction.Create(OpCodes.Ldc_R4, 1f),
                Instruction.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight2"))
                );
            e.asm.GetMethod("Lighting", "LightColor2").Body.GetILProcessor().Insert(Target.START,
                Instruction.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(typeof(TerraHax).GetField("fullbright"))),
                Instruction.Create(OpCodes.Brfalse, e.asm.GetMethod("Lighting", "LightColor2").Body.Instructions[0]),
                Instruction.Create(OpCodes.Ldc_R4, 0f),
                Instruction.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight")),
                Instruction.Create(OpCodes.Ldc_R4, 0f),
                Instruction.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "wetLightR")),
                Instruction.Create(OpCodes.Ldc_R4, 0f),
                Instruction.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight2"))
                );
            e.asm.GetMethod("Lighting", "LightColorG2").Body.GetILProcessor().Insert(Target.START,
                Instruction.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(typeof(TerraHax).GetField("fullbright"))),
                Instruction.Create(OpCodes.Brfalse, e.asm.GetMethod("Lighting", "LightColorG2").Body.Instructions[0]),
                Instruction.Create(OpCodes.Ldc_R4, 0f),
                Instruction.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight")),
                Instruction.Create(OpCodes.Ldc_R4, 0f),
                Instruction.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "wetLightR")),
                Instruction.Create(OpCodes.Ldc_R4, 0f),
                Instruction.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight2"))
                );
            e.asm.GetMethod("Lighting", "LightColorB2").Body.GetILProcessor().Insert(Target.START,
                Instruction.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(typeof(TerraHax).GetField("fullbright"))),
                Instruction.Create(OpCodes.Brfalse, e.asm.GetMethod("Lighting", "LightColorB2").Body.Instructions[0]),
                Instruction.Create(OpCodes.Ldc_R4, 0f),
                Instruction.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight")),
                Instruction.Create(OpCodes.Ldc_R4, 0f),
                Instruction.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "wetLightR")),
                Instruction.Create(OpCodes.Ldc_R4, 0f),
                Instruction.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight2"))
                );
            #endregion
            #region Player
            Instruction getItem = e.asm.GetMethod("Player", "GetItem").Body.Instructions[0];
            e.asm.GetMethod("Player", "GetItem").Body.GetILProcessor().Insert(Target.START,
                Instruction.Create(OpCodes.Ldarg_1),
                Instruction.Create(OpCodes.Ldsfld, e.asm.GetField("Main", "myPlayer")),
                Instruction.Create(OpCodes.Bne_Un, getItem),
                Instruction.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(GetField("pickupItems"))),
                Instruction.Create(OpCodes.Brfalse, getItem),
                Instruction.Create(OpCodes.Newobj, e.asm.GetMethod("Item", ".ctor")),
                Instruction.Create(OpCodes.Ret)
                );
            Instruction getHurt = e.asm.GetMethod("Player", "Hurt").Body.Instructions[0];
            e.asm.GetMethod("Player", "Hurt").Body.GetILProcessor().Insert(Target.START,
                Instruction.Create(OpCodes.Ldarg_0),
                Instruction.Create(OpCodes.Ldfld, e.asm.GetField("Player", "whoAmi")),
                Instruction.Create(OpCodes.Ldsfld, e.asm.GetField("Main", "myPlayer")),
                Instruction.Create(OpCodes.Bne_Un, getHurt),
                Instruction.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(GetField("godMode"))),
                Instruction.Create(OpCodes.Brfalse, getHurt),
                Instruction.Create(OpCodes.Ldc_R8, 0.0),
                Instruction.Create(OpCodes.Ret)
                );
            Instruction killMe = e.asm.GetMethod("Player", "KillMe").Body.Instructions[0];
            e.asm.GetMethod("Player", "KillMe").Body.GetILProcessor().Insert(Target.START,
                Instruction.Create(OpCodes.Ldarg_0),
                Instruction.Create(OpCodes.Ldfld, e.asm.GetField("Player", "whoAmi")),
                Instruction.Create(OpCodes.Ldsfld, e.asm.GetField("Main", "myPlayer")),
                Instruction.Create(OpCodes.Bne_Un, killMe),
                Instruction.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(GetField("godMode"))),
                Instruction.Create(OpCodes.Brfalse, killMe),
                Instruction.Create(OpCodes.Ret)
                );
            #endregion
        }

        void TerraHax_onInitialize(object sender, PluginEventArgs e)
        {
            infBuff = new bool[Main.buffNames.Length];

            AddCommand(new Command("ammo", Ammo));
            AddCommand(new Command("autoreuse", AutoReuse));
            AddCommand(new Command("buff", Buff));
            AddCommand(new Command("clearinv", ClearInv));
            AddCommand(new Command("damage", Damage));
            AddCommand(new Command("fullbright", Fullbright));
            AddCommand(new Command("god", God));
            AddCommand(new Command("gps", GPS));
            AddCommand(new Command("infbuff", InfBuff));
            AddCommand(new Command("item", Item));
            AddCommand(new Command("itempickup", ItemPickup));
            AddCommand(new Command("jump", Jump));
            AddCommand(new Command("maxstack", MaxStack));
            AddCommand(new Command("noclip", Noclip));
            AddCommand(new Command("shoot", Shoot));
            AddCommand(new Command("shootspeed", ShootSpeed));
            AddCommand(new Command("tp", Tp));
            AddCommand(new Command("usetime", Usetime));
        }
        void TerraHax_onUpdate(object sender, PluginEventArgs e)
        {
            for (int i = 0; i < infBuff.Length; i++)
            {
                if (infBuff[i])
                {
                    bool buffed = false;
                    for (int j = 0; j < Main.currPlayer.buffType.Length; j++)
                    {
                        if (i == Main.currPlayer.buffType[j])
                        {
                            Main.currPlayer.buffTime[j] = 2;
                        }
                    }
                    if (!buffed)
                    {
                        Main.currPlayer.AddBuff(i, 2);
                    }
                }
            }
            if (fullbright)
            {
                Lighting.LightTile((int)Main.currPlayer.position.X / 16, (int)Main.currPlayer.position.Y / 16, 1.0f);
            }
            if (godMode)
            {
                Main.currPlayer.statLife = Main.currPlayer.statLifeMax;
                for (int i = 0; i < Main.currPlayer.buffType.Length; i++)
                {
                    if (Main.debuff[Main.currPlayer.buffType[i]])
                    {
                        Main.currPlayer.DelBuff(i);
                    }
                }
                Main.currPlayer.breath = 200;
            }
            if (noclip)
            {
                if (!disableKeys && !Main.currPlayer.dead)
                {
                    int dist = Input.Shift ? 32 : 16;
                    if (Main.currPlayer.controlUp)
                    {
                        Main.currPlayer.position = new Vector2(Main.currPlayer.position.X, Main.currPlayer.position.Y - dist);
                    }
                    if (Main.currPlayer.controlLeft)
                    {
                        Main.currPlayer.position = new Vector2(Main.currPlayer.position.X - dist, Main.currPlayer.position.Y);
                    }
                    if (Main.currPlayer.controlRight)
                    {
                        Main.currPlayer.position = new Vector2(Main.currPlayer.position.X + dist, Main.currPlayer.position.Y);
                    }
                    if (Main.currPlayer.controlDown)
                    {
                        Main.currPlayer.position = new Vector2(Main.currPlayer.position.X, Main.currPlayer.position.Y + dist);
                    }
                }
                Main.currPlayer.velocity = Vector2.Zero;
            }
            prevPosition = Main.currPlayer.position;
        }
        void Terrahax_onUpdate2(object sender, PluginEventArgs e)
        {
            if (noclip)
            {
                Main.currPlayer.position = prevPosition;
            }
        }
        public static void TerraHax_beforeDraw()
        {
            if (godMode)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (Main.debuff[Main.currPlayer.buffType[i]])
                    {
                        Main.currPlayer.buffTime[i] = 0;
                    }
                }
                Main.currPlayer.breath = 200;
            }
            if (gps)
            {
                Main.currPlayer.accCompass = 2;
                Main.currPlayer.accDepthMeter = 1;
                Main.currPlayer.accWatch = 3;
            }
        }
        [Description("Sets the item used as ammo for the selected item.")]
        void Ammo(object sender, CommandEventArgs e)
        {
            if (e.length != 1)
            {
                PrintError("Syntax: ammo <item ID>");
                return;
            }
            int ammo;
            if (!int.TryParse(e[0], out ammo))
            {
                PrintError("Invalid ammo.");
                return;
            }
            Main.currItem.useAmmo = ammo;
            PrintNotification("Set selected item's ammo to " + ammo + ".");
        }
        [Alias("ar")]
        [Description("Toggles the autoreuse-ness of the selected item.")]
        void AutoReuse(object sender, CommandEventArgs e)
        {
            Main.currItem.autoReuse = !Main.currItem.autoReuse;
            PrintNotification((Main.currItem.autoReuse ? "En" : "Dis") + "abled autoreuse for the selected item.");
        }
        [Description("Adds buffs.")]
        void Buff(object sender, CommandEventArgs e)
        {
            if (e.length != 1 && e.length != 2)
            {
                PrintError("Syntax: buff <buff> [<time>]");
                return;
            }
            Match match = Command.GetBuff(e[0]);
            if (match.ID > 0)
            {
                int time = 300;
                if (e.length == 2 && !int.TryParse(e[1], out time))
                {
                    PrintError("Invalid time.");
                    return;
                }
                Main.currPlayer.AddBuff(match.ID, time * 60);
                PrintNotification("Buffed " + match.name + " for " + time + " seconds.");
            }
        }
        [Alias("cinv")]
        [Description("Completely clears the inventory except for the hotbar.")]
        void ClearInv(object sender, CommandEventArgs e)
        {
            for (int i = 10; i < Main.currPlayer.inventory.Length; i++)
            {
                Main.currPlayer.inventory[i] = TerrariAPI.Hooking.Item.New();
            }
            PrintNotification("Cleared inventory.");
        }
        [Alias("dam")]
        [Description("Sets the damage of the selected item.")]
        void Damage(object sender, CommandEventArgs e)
        {
            if (e.length != 1)
            {
                PrintError("Syntax: damage <damage>");
                return;
            }
            int damage;
            if (!int.TryParse(e[0], out damage) || damage <= 0)
            {
                PrintError("Invalid damage.");
                return;
            }
            Main.currItem.damage = damage;
            PrintNotification("Set selected item's damage to " + damage + ".");
        }
        [Alias("fb", "light")]
        [Description("Toggles the ability to see everything on the screen.")]
        void Fullbright(object sender, CommandEventArgs e)
        {
            fullbright = !fullbright;
            PrintNotification((fullbright ? "En" : "Dis") + "abled fullbright.");
        }
        [Description("Toggles god mode.")]
        void God(object sender, CommandEventArgs e)
        {
            godMode = !godMode;
            PrintNotification((godMode ? "En" : "Dis") + "abled god mode.");
        }
        [Description("Toggles the GPS.")]
        void GPS(object sender, CommandEventArgs e)
        {
            gps = !gps;
            PrintNotification((gps ? "En" : "Dis") + "abled GPS.");
        }
        [Alias("ibuff")]
        [Description("Adds infinite buffs.")]
        void InfBuff(object sender, CommandEventArgs e)
        {
            if (e.length != 1 && e.length != 2)
            {
                PrintError("Syntax: infbuff <buff>");
                return;
            }
            Match match = Command.GetBuff(e[0]);
            if (match.ID > 0)
            {
                infBuff[match.ID] = !infBuff[match.ID];
                PrintNotification((infBuff[match.ID] ? "En" : "Dis") + "abled infinite buff for " + match.name + ".");
            }
        }
        [Alias("i")]
        [Description("Spawns items.")]
        void Item(object sender, CommandEventArgs e)
        {
            if (e.length != 1 && e.length != 2)
            {
                PrintError("Syntax: item <item> [<stack>]");
                return;
            }
            Match match = Command.GetItem(e[0]);
            if (match.ID > 0)
            {
                dynamic item = TerrariAPI.Hooking.Item.New();
                item.SetDefaults(match.ID);
                int stack = item.maxStack;
                if (e.length == 2 && !int.TryParse(e[1], out stack))
                {
                    PrintError("Invalid stack size.");
                    return;
                }
                int index = TerrariAPI.Hooking.Item.NewItem((int)Main.currPlayer.position.X, (int)Main.currPlayer.position.Y,
                    Main.currPlayer.width, Main.currPlayer.height, match.ID, stack);
                Main.items[index] = Main.currPlayer.GetItem(Main.playerIndex, Main.items[index]);
                PrintNotification("Spawned " + stack + " " + match.name + "(s).");
            }
        }
        [Alias("itemp")]
        [Description("Toggles picking up items.")]
        void ItemPickup(object sender, CommandEventArgs e)
        {
            pickupItems = !pickupItems;
            PrintNotification((pickupItems ? "Dis" : "En") + "abled item pickups.");
        }
        [Description("Moves the player to the cursor location.")]
        void Jump(object sender, CommandEventArgs e)
        {
            Main.currPlayer.position = Main.screenPosition + new Vector2(Input.mX, Input.mY);
        }
        [Alias("max")]
        [Description("Maximizes the stack size of items.")]
        void MaxStack(object sender, CommandEventArgs e)
        {
            if (e.length > 1)
            {
                PrintError("Syntax: maxstack [all|ammo]");
                return;
            }
            if (e.length == 0)
            {
                Main.currItem.stack = Main.currItem.maxStack;
                PrintNotification("Maximized selected item's stack size.");
            }
            else
            {
                switch (e[0])
                {
                    case "all":
                        for (int i = 0; i < Main.currPlayer.inventory.Length; i++)
                        {
                            Main.currPlayer.inventory[i].stack = Main.currPlayer.inventory[i].maxStack;
                        }
                        PrintNotification("Maximized all items' stack size.");
                        break;
                    case "ammo":
                        for (int i = 0; i < Main.currPlayer.inventory.Length; i++)
                        {
                            if (Main.currPlayer.inventory[i].ammo != 0)
                            {
                                Main.currPlayer.inventory[i].stack = Main.currPlayer.inventory[i].maxStack;
                            }
                        }
                        PrintNotification("Maximized all ammos' stack size.");
                        break;
                    default:
                        PrintError("Invalid maxstack option.");
                        return;
                }
            }
        }
        [Alias("nc")]
        [Description("Toggles noclip.")]
        void Noclip(object sender, CommandEventArgs e)
        {
            noclip = !noclip;
            PrintNotification((noclip ? "En" : "Dis") + "abled noclip.");
        }
        [Description("Sets the projectile of the selected item.")]
        void Shoot(object sender, CommandEventArgs e)
        {
            if (e.length != 1)
            {
                PrintError("Syntax: shoot <projectile>");
                return;
            }
            Match match = Command.GetProjectile(e[0]);
            if (match.ID >= 0)
            {
                Main.currItem.shoot = match.ID;
                PrintNotification("Set selected item to shoot " + match.name + ".");
            }
        }
        [Alias("ss")]
        [Description("Sets the shooting speed of the selected item.")]
        void ShootSpeed(object sender, CommandEventArgs e)
        {
            if (e.length != 1)
            {
                PrintError("Syntax: shootspeed <speed>");
                return;
            }
            float shootSpeed;
            if (!float.TryParse(e[0], out shootSpeed))
            {
                PrintError("Invalid shoot speed.");
                return;
            }
            Main.currItem.shootSpeed = shootSpeed;
            PrintNotification("Set selected item's shoot speed to " + shootSpeed + ".");
        }
        [Description("Teleports you to another player.")]
        void Tp(object sender, CommandEventArgs e)
        {
            if (e.length != 1)
            {
                PrintError("Syntax: tp <player>");
                return;
            }
            Match match = Command.GetPlayer(e[0]);
            if (match.ID >= 0)
            {
                Main.currPlayer.position = Main.players[match.ID].position;
                NetMessage.SendData(13, "", Main.playerIndex);
                PrintNotification("Teleported to " + match.name + ".");
            }
        }
        [Alias("ut")]
        [Description("Sets the usetime of the selected item.")]
        void Usetime(object sender, CommandEventArgs e)
        {
            if (e.length != 1)
            {
                PrintError("Syntax: usetime <time>");
                return;
            }
            int useTime;
            if (!int.TryParse(e[0], out useTime))
            {
                PrintError("Invalid usetime.");
                return;
            }
            Main.currItem.useTime = useTime;
            PrintNotification("Set selected item's usetime to " + useTime + ".");
        }
    }
}
