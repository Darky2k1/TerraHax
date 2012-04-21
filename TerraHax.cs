using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TerrariAPI;
using TerrariAPI.Commands;
using TerrariAPI.Hooking;
using TerrariAPI.Plugins;
using Mono.Cecil.Cil;
using Mono.Cecil;

namespace TerraHax
{
    public class TerraHax : Plugin
    {
        public override string author { get { return "MarioE"; } }
        public override string name { get { return "TerraHax"; } }
        public override int version { get { return 1; } }

        public static bool fullbright;

        public TerraHax()
        {
            onHook += TerraHax_onHook;
            onInitialize += TerraHax_onInitialize;
            onUpdate += TerraHax_onUpdate;
        }

        void TerraHax_onHook(object sender, PluginEventArgs e)
        {
            MethodDefinition terrariaLighting = GetMethod("Lighting", "LightColor");
            ILProcessor ilpL = terrariaLighting.Body.GetILProcessor();
            Instruction fL = terrariaLighting.Body.Instructions[0];
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(typeof(TerraHax).GetField("fullbright"))));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Brfalse, fL));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldc_R4, 1f));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Stsfld, GetField("Lighting", "negLight")));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldc_R4, 1f));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Stsfld, GetField("Lighting", "wetLightR")));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldc_R4, 1f));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Stsfld, GetField("Lighting", "negLight2")));

            terrariaLighting = GetMethod("Lighting", "LightColor2");
            ilpL = terrariaLighting.Body.GetILProcessor();
            fL = terrariaLighting.Body.Instructions[0];
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(typeof(TerraHax).GetField("fullbright"))));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Brfalse, fL));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldc_R4, 0f));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Stsfld, GetField("Lighting", "negLight")));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldc_R4, 0f));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Stsfld, GetField("Lighting", "wetLightR")));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldc_R4, 0f));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Stsfld, GetField("Lighting", "negLight2")));

            terrariaLighting = GetMethod("Lighting", "LightColorG");
            ilpL = terrariaLighting.Body.GetILProcessor();
            fL = terrariaLighting.Body.Instructions[0];
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(typeof(TerraHax).GetField("fullbright"))));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Brfalse, fL));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldc_R4, 1f));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Stsfld, GetField("Lighting", "negLight")));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldc_R4, 1f));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Stsfld, GetField("Lighting", "wetLightR")));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldc_R4, 1f));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Stsfld, GetField("Lighting", "negLight2")));

            terrariaLighting = GetMethod("Lighting", "LightColorG2");
            ilpL = terrariaLighting.Body.GetILProcessor();
            fL = terrariaLighting.Body.Instructions[0];
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(typeof(TerraHax).GetField("fullbright"))));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Brfalse, fL));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldc_R4, 0f));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Stsfld, GetField("Lighting", "negLight")));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldc_R4, 0f));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Stsfld, GetField("Lighting", "wetLightR")));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldc_R4, 0f));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Stsfld, GetField("Lighting", "negLight2")));

            terrariaLighting = GetMethod("Lighting", "LightColorB");
            ilpL = terrariaLighting.Body.GetILProcessor();
            fL = terrariaLighting.Body.Instructions[0];
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(typeof(TerraHax).GetField("fullbright"))));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Brfalse, fL));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldc_R4, 1f));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Stsfld, GetField("Lighting", "negLight")));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldc_R4, 1f));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Stsfld, GetField("Lighting", "wetLightR")));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldc_R4, 1f));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Stsfld, GetField("Lighting", "negLight2")));

            terrariaLighting = GetMethod("Lighting", "LightColorB2");
            ilpL = terrariaLighting.Body.GetILProcessor();
            fL = terrariaLighting.Body.Instructions[0];
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldsfld, e.asm.MainModule.Import(typeof(TerraHax).GetField("fullbright"))));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Brfalse, fL));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldc_R4, 0f));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Stsfld, GetField("Lighting", "negLight")));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldc_R4, 0f));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Stsfld, GetField("Lighting", "wetLightR")));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Ldc_R4, 0f));
            ilpL.InsertBefore(fL, ilpL.Create(OpCodes.Stsfld, GetField("Lighting", "negLight2")));
        }

        void TerraHax_onInitialize(object sender, PluginEventArgs e)
        {
            Command.Add(new Command("clearinv", ClearInv));
            Command.Add(new Command("damage", Damage));
            Command.Add(new Command("fullbright", Fullbright));
            Command.Add(new Command("maxstack", MaxStack));
            Command.Add(new Command("netsend", NetSend));
            Command.Add(new Command("tp", Tp));
        }
        void TerraHax_onUpdate(object sender, PluginEventArgs e)
        {
            if (fullbright)
            {
                Wrapper.lighting.LightTile((int)Wrapper.main.currPlayer.position.X / 16, (int)Wrapper.main.currPlayer.position.Y / 16, 1.0f);
            }
        }

        [Description("Completely clears the inventory except for the hotbar.")]
        void ClearInv(object sender, CommandEventArgs e)
        {
            for (int i = 10; i < Wrapper.main.currPlayer.inventory.Length; i++)
            {
                Wrapper.main.currPlayer.inventory[i] = Wrapper.item.New();
            }
            PrintNotification("Cleared inventory.");
        }
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
            Wrapper.main.currentItem.damage = damage;
            PrintNotification("Set selected item's damage to " + damage + ".");
        }
        [Description("Toggles the ability to see everything on the screen.")]
        void Fullbright(object sender, CommandEventArgs e)
        {
            fullbright = !fullbright;
            PrintNotification((fullbright ? "En" : "Dis") + "abled fullbright.");
        }
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
                Wrapper.main.currentItem.stack = Wrapper.main.currentItem.maxStack;
                PrintNotification("Maximized selected item's stack size.");
            }
            else
            {
                switch (e[0])
                {
                    case "all":
                        for (int i = 0; i < Wrapper.main.currPlayer.inventory.Length; i++)
                        {
                            Wrapper.main.currPlayer.inventory[i].stack = Wrapper.main.currPlayer.inventory[i].maxStack;
                        }
                        PrintNotification("Maximized all items' stack size.");
                        break;
                    case "ammo":
                        for (int i = 0; i < Wrapper.main.currPlayer.inventory.Length; i++)
                        {
                            if (Wrapper.main.currPlayer.inventory[i].ammo)
                            {
                                Wrapper.main.currPlayer.inventory[i].stack = Wrapper.main.currPlayer.inventory[i].maxStack;
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
        [Description("Directly sends network data.")]
        void NetSend(object sender, CommandEventArgs e)
        {
            if (e.length < 1 || e.length > 7)
            {
                PrintError("Syntax: netsend <packet ID> [<arg1>] [<arg2>] [<arg3>] [<arg4>] [<arg5>] [<arg6>]");
                return;
            }
            int packet;
            if (!int.TryParse(e[0], out packet))
            {
                PrintError("Invalid packet ID.");
                return;
            }
            int num1 = 0, num5 = 0;
            float num2 = 0, num3 = 0, num4 = 0;
            string str = "";
            try
            {
                if (!int.TryParse(e[2], out num1))
                {
                    PrintError("Invalid integer.");
                    return;
                }
                if (!float.TryParse(e[3], out num2) || !float.TryParse(e[4], out num3) || !float.TryParse(e[5], out num4))
                {
                    PrintError("Invalid float.");
                    return;
                }
                if (!int.TryParse(e[6], out num5))
                {
                    PrintError("Invalid integer.");
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            {
            }
            finally
            {
                Wrapper.netMessage.SendData(packet, str, num1, num2, num3, num4, num5);
                PrintNotification("Sent " + packet + ", " + (str == "" ? "\"\"" : str) + ", " + num1 + ", " + num2 + ", " + num3 + ", " + num4 + ", " + num5);
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
                Wrapper.main.currPlayer.position = Wrapper.main.players[index].position;
                Wrapper.netMessage.SendData(13, "", Wrapper.main.Get("myPlayer"));
                PrintNotification("Teleported to " + Wrapper.main.players[index].name + ".");
            }
        }
    }
}
