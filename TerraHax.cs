using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Mono.Cecil;
using Mono.Cecil.Cil;
using TerrariAPI;
using TerrariAPI.Commands;
using TerrariAPI.Hooking;
using TerrariAPI.Plugins;

namespace TerraHax
{
    public class TerraHax : Plugin
    {
        public override string author { get { return "MarioE"; } }
        public override string name { get { return "TerraHax"; } }
        public override int version { get { return 2; } }

        public static bool fullbright;
        public static bool godMode;
        public static bool gps;
        public static bool pickupItems;

        public TerraHax()
        {
            onHook += TerraHax_onHook;
            onInitialize += TerraHax_onInitialize;
            onUpdate += TerraHax_onUpdate;
        }

        void TerraHax_onHook(object sender, PluginEventArgs e)
        {
            ILProcessor temp = null;
            Instruction tempInstr = null;
            #region Main
            MethodDefinition draw = e.asm.GetMethod("Main", "Draw");
            temp = draw.Body.GetILProcessor();
            temp.InsertBefore(draw.Body.Instructions[0], temp.Create(OpCodes.Call, e.asm.MainModule.Import(typeof(TerraHax).GetMethod("TerraHax_beforeDraw"))));
            #endregion
            #region Lighting
            MethodDefinition terrariaLighting = e.asm.GetMethod("Lighting", "LightColor");
            temp = terrariaLighting.Body.GetILProcessor();
            tempInstr = terrariaLighting.Body.Instructions[0];
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(typeof(TerraHax).GetField("fullbright"))));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Brfalse, tempInstr));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldc_R4, 1f));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight")));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldc_R4, 1f));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "wetLightR")));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldc_R4, 1f));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight2")));

            terrariaLighting = e.asm.GetMethod("Lighting", "LightColor2");
            temp = terrariaLighting.Body.GetILProcessor();
            tempInstr = terrariaLighting.Body.Instructions[0];
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(typeof(TerraHax).GetField("fullbright"))));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Brfalse, tempInstr));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldc_R4, 0f));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight")));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldc_R4, 0f));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "wetLightR")));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldc_R4, 0f));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight2")));

            terrariaLighting = e.asm.GetMethod("Lighting", "LightColorG");
            temp = terrariaLighting.Body.GetILProcessor();
            tempInstr = terrariaLighting.Body.Instructions[0];
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(typeof(TerraHax).GetField("fullbright"))));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Brfalse, tempInstr));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldc_R4, 1f));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight")));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldc_R4, 1f));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "wetLightR")));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldc_R4, 1f));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight2")));

            terrariaLighting = e.asm.GetMethod("Lighting", "LightColorG2");
            temp = terrariaLighting.Body.GetILProcessor();
            tempInstr = terrariaLighting.Body.Instructions[0];
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(typeof(TerraHax).GetField("fullbright"))));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Brfalse, tempInstr));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldc_R4, 0f));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight")));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldc_R4, 0f));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "wetLightR")));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldc_R4, 0f));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight2")));

            terrariaLighting = e.asm.GetMethod("Lighting", "LightColorB");
            temp = terrariaLighting.Body.GetILProcessor();
            tempInstr = terrariaLighting.Body.Instructions[0];
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(typeof(TerraHax).GetField("fullbright"))));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Brfalse, tempInstr));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldc_R4, 1f));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight")));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldc_R4, 1f));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "wetLightR")));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldc_R4, 1f));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight2")));

            terrariaLighting = e.asm.GetMethod("Lighting", "LightColorB2");
            temp = terrariaLighting.Body.GetILProcessor();
            tempInstr = terrariaLighting.Body.Instructions[0];
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(typeof(TerraHax).GetField("fullbright"))));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Brfalse, tempInstr));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldc_R4, 0f));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight")));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldc_R4, 0f));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "wetLightR")));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldc_R4, 0f));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Stsfld, e.asm.GetField("Lighting", "negLight2")));
            #endregion
            #region Player
            MethodDefinition getItem = e.asm.GetMethod("Player", "GetItem");
            temp = getItem.Body.GetILProcessor();
            tempInstr = getItem.Body.Instructions[0];
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldarg_1));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldsfld, e.asm.GetField("Main", "myPlayer")));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Bne_Un, tempInstr));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(typeof(TerraHax).GetField("pickupItems"))));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Brfalse, tempInstr));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Newobj, e.asm.GetMethod("Item", ".ctor")));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ret));
            MethodDefinition hurt = e.asm.GetMethod("Player", "Hurt");
            temp = hurt.Body.GetILProcessor();
            tempInstr = hurt.Body.Instructions[0];
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldarg_0));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldfld, e.asm.GetField("Player", "whoAmi")));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldsfld, e.asm.GetField("Main", "myPlayer")));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Bne_Un, tempInstr));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(typeof(TerraHax).GetField("godMode"))));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Brfalse, tempInstr));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldc_R8, 0.0));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ret));
            MethodDefinition killMe = e.asm.GetMethod("Player", "KillMe");
            temp = killMe.Body.GetILProcessor();
            tempInstr = killMe.Body.Instructions[0];
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldarg_0));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldfld, e.asm.GetField("Player", "whoAmi")));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldsfld, e.asm.GetField("Main", "myPlayer")));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Bne_Un, tempInstr));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(typeof(TerraHax).GetField("godMode"))));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Brfalse, tempInstr));
            temp.InsertBefore(tempInstr, temp.Create(OpCodes.Ret));
            #endregion
        }

        void TerraHax_onInitialize(object sender, PluginEventArgs e)
        {
            AddCommand(new Command("clearinv", ClearInv));
            AddCommand(new Command("damage", Damage));
            AddCommand(new Command("fullbright", Fullbright));
            AddCommand(new Command("god", God));
            AddCommand(new Command("gps", GPS));
            AddCommand(new Command("itempickup", ItemPickup));
            AddCommand(new Command("maxstack", MaxStack));
            AddCommand(new Command("tp", Tp));
            AddCommand(new Command("usetime", Usetime));
        }
        void TerraHax_onUpdate(object sender, PluginEventArgs e)
        {
            if (fullbright)
            {
                Lighting.LightTile((int)Main.currPlayer.position.X / 16, (int)Main.currPlayer.position.Y / 16, 1.0f);
            }
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
        [Alias("clrinv", "cinv")]
        [Description("Completely clears the inventory except for the hotbar.")]
        void ClearInv(object sender, CommandEventArgs e)
        {
            for (int i = 10; i < Main.currPlayer.inventory.Length; i++)
            {
                Main.currPlayer.inventory[i] = Item.New();
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
            if (!int.TryParse(e[0], out damage))
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
        [Alias("itemp")]
        [Description("Toggles picking up items.")]
        void ItemPickup(object sender, CommandEventArgs e)
        {
            pickupItems = !pickupItems;
            PrintNotification((pickupItems ? "En" : "Dis") + "abled item pickups.");
        }
        [Alias("maxs")]
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
                            if (Main.currPlayer.inventory[i].ammo)
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
        [Description("Teleports you to another player.")]
        void Tp(object sender, CommandEventArgs e)
        {
            if (e.length != 1)
            {
                PrintError("Syntax: tp <player>");
                return;
            }
            int index = Command.GetPlayer(e[0]);
            if (index >= 0)
            {
                Main.currPlayer.position = Main.players[index].position;
                NetMessage.SendData(13, "", Main.playerIndex);
                PrintNotification("Teleported to " + Main.players[index].name + ".");
            }
        }
        [Alias("uset")]
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
                PrintError("Invalid damage.");
                return;
            }
            Main.currItem.useTime = useTime;
            PrintNotification("Set selected item's usetime to " + useTime + ".");
        }
    }
}
