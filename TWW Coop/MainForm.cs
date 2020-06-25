using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TWW_Coop
{
    public partial class MainForm : Form
    {

        public static DolphinManager dolphin;
        private static bool listeningToDolphin;
        private List<string> dolphinInQueue;

        public MainForm()
        {
            InitializeComponent();
            modeBox.SelectedIndex = 0;

            dolphin = new DolphinManager();
            PrintConsole("Opened and attached Dolphin");

            dolphinListener.DoWork += this.DolphinListener;
            listeningToDolphin = true;
            dolphinInQueue = new List<string>();
            dolphinListener.RunWorkerAsync();

            //string newTitle = dolphin.ReadLine();
            //PrintConsole(newTitle);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void modeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PrintConsole(string msg, params object[] args)
        {
            string formatted = String.Format(msg, args);
            consoleBox.Text += formatted + "\r\n";
        }

        private void ParseDolphinMsg(object sender, EventArgs e)
        {

        }

        private void DolphinListener(object sender, DoWorkEventArgs e)
        {
            PlayerStatus player = new PlayerStatus();
            PlayerStatus old = new PlayerStatus();
            int playerSize = Marshal.SizeOf(player);

            WorldState state = new WorldState();
            WorldState oldState = new WorldState();
            int worldStateSize = Marshal.SizeOf(state);

            bool firstPass = true;

            while (listeningToDolphin && dolphin.isRunning)
            {
                DolphinPacket msg = dolphin.ReadPacket();
                
                if (msg.type == PacketType.PlayerStatusInfo)
                {
                    IntPtr buffer = Marshal.AllocHGlobal(playerSize);
                    Marshal.Copy(msg.data, 0, buffer, playerSize);
                    player = Marshal.PtrToStructure<PlayerStatus>(buffer);
                    Marshal.FreeHGlobal(buffer); // perhaps we'll move to allocating on connect and freeing on disconnect?
                    
                    if (firstPass)
                    {
                        firstPass = false;
                        old = player;
                    }

                    #region GUI Autotracker
                    if (player.inventory.telescope != old.inventory.telescope)
                    {
                        if (player.inventory.telescope == (byte)WWItem.Telecope)
                            telescopePicture.Image = TWW_Coop.Resources.item_Telescope;
                        else
                            telescopePicture.Image = TWW_Coop.Resources.item_TelescopeN;
                    }

                    if (player.inventory.sail != old.inventory.sail)
                    {
                        if (player.inventory.sail == (byte)WWItem.Sail)
                            sailPicture.Image = TWW_Coop.Resources.item_SwiftSail;
                        else
                            sailPicture.Image = TWW_Coop.Resources.item_SwiftSailN;
                    }

                    if (player.inventory.windwaker != old.inventory.windwaker)
                    {
                        if (player.inventory.windwaker == (byte)WWItem.WW)
                            wwPicture.Image = TWW_Coop.Resources.item_WindWaker;
                        else
                            wwPicture.Image = TWW_Coop.Resources.item_WindWakerN;
                    }

                    if (player.inventory.grapplingHook != old.inventory.grapplingHook)
                    {
                        if (player.inventory.grapplingHook == (byte)WWItem.GrapplingHook)
                            grapplingHookPicture.Image = TWW_Coop.Resources.item_GrapplingHook;
                        else
                            grapplingHookPicture.Image = TWW_Coop.Resources.item_GrapplingHookN;
                    }

                    if (player.inventory.spoilsBag != old.inventory.spoilsBag)
                    {
                        if (player.inventory.spoilsBag == (byte)WWItem.SpoilsBag)
                            spoilsBagPicture.Image = TWW_Coop.Resources.bag_SpoilsBag;
                        else
                            spoilsBagPicture.Image = TWW_Coop.Resources.bag_SpoilsBagN;
                    }

                    if (player.inventory.boomerang != old.inventory.boomerang)
                    {
                        if (player.inventory.boomerang == (byte)WWItem.Boomerang)
                            boomerangPicture.Image = TWW_Coop.Resources.item_Boomerang;
                        else
                            boomerangPicture.Image = TWW_Coop.Resources.item_BoomerangN;
                    }

                    if (player.inventory.dekuLeaf != old.inventory.dekuLeaf)
                    {
                        if (player.inventory.dekuLeaf == (byte)WWItem.DekuLeaf)
                            dekuLeafPicture.Image = TWW_Coop.Resources.item_DekuLeaf;
                        else
                            dekuLeafPicture.Image = TWW_Coop.Resources.item_DekuLeafN;
                    }

                    if (player.inventory.sword != old.inventory.sword)
                    {
                        switch (player.inventory.sword)
                        {
                            case (byte)WWItem.Sword1:
                                swordPicture.Image = TWW_Coop.Resources.item_Sword1;
                                break;
                            case (byte)WWItem.Sword2:
                                swordPicture.Image = TWW_Coop.Resources.item_Sword2;
                                break;
                            case (byte)WWItem.Sword3:
                                swordPicture.Image = TWW_Coop.Resources.item_Sword3;
                                break;
                            case (byte)WWItem.Sword4:
                                swordPicture.Image = TWW_Coop.Resources.item_Sword4;
                                break;
                            default:
                                swordPicture.Image = TWW_Coop.Resources.item_SwordN;
                                break;
                        }
                    }

                    if (player.inventory.tingleTuner != old.inventory.tingleTuner)
                    {
                        if (player.inventory.tingleTuner == (byte)WWItem.TingleTuner)
                            tingleTunerPicture.Image = TWW_Coop.Resources.item_TingleTuner;
                        else
                            tingleTunerPicture.Image = TWW_Coop.Resources.item_TingleTunerN;
                    }

                    if (player.inventory.pictoBox != old.inventory.pictoBox)
                    {
                        switch (player.inventory.pictoBox)
                        {
                            case (byte)WWItem.PictoBox1:
                                pictoBoxPicture.Image = TWW_Coop.Resources.item_PictoBox1;
                                break;
                            case (byte)WWItem.PictoBox2:
                                pictoBoxPicture.Image = TWW_Coop.Resources.item_PictoBox2;
                                break;
                            default:
                                pictoBoxPicture.Image = TWW_Coop.Resources.item_PictoBoxN;
                                break;
                        }
                    }

                    if (player.inventory.ironBoots != old.inventory.ironBoots)
                    {
                        if (player.inventory.ironBoots == (byte)WWItem.Boots)
                            ironBootsPicture.Image = TWW_Coop.Resources.item_IronBoots;
                        else
                            ironBootsPicture.Image = TWW_Coop.Resources.item_IronBootsN;
                    }

                    if (player.inventory.magicArmor != old.inventory.magicArmor)
                    {
                        if (player.inventory.magicArmor == (byte)WWItem.MagicArmor)
                            magicArmorPicture.Image = TWW_Coop.Resources.item_MagicArmor;
                        else
                            magicArmorPicture.Image = TWW_Coop.Resources.item_MagicArmorN;
                    }

                    if (player.inventory.baitBag != old.inventory.baitBag)
                    {
                        if (player.inventory.baitBag == (byte)WWItem.BaitBag)
                            baitBagPicture.Image = TWW_Coop.Resources.bag_BaitBag;
                        else
                            baitBagPicture.Image = TWW_Coop.Resources.bag_BaitBagN;
                    }

                    if (player.inventory.bow != old.inventory.bow)
                    {
                        switch (player.inventory.bow)
                        {
                            case (byte)WWItem.Bow1:
                                bowPicture.Image = TWW_Coop.Resources.item_Bow1;
                                break;
                            case (byte)WWItem.Bow2:
                                bowPicture.Image = TWW_Coop.Resources.item_Bow2;
                                break;
                            case (byte)WWItem.Bow3:
                                bowPicture.Image = TWW_Coop.Resources.item_Bow3;
                                break;
                            default:
                                bowPicture.Image = TWW_Coop.Resources.item_BowN;
                                break;
                        }
                    }

                    if (player.inventory.bombs != old.inventory.bombs)
                    {
                        if (player.inventory.bombs == (byte)WWItem.Bombs)
                            bombsPicture.Image = TWW_Coop.Resources.item_Bomb;
                        else
                            bombsPicture.Image = TWW_Coop.Resources.item_BombN;
                    }

                    if (player.ammo.bombCapacity != old.ammo.bombCapacity)
                    {
                        if (player.inventory.bombs == (byte)WWItem.Bombs)
                        {
                            switch (player.ammo.bombCapacity)
                            {
                                case 60:
                                    bombsPicture.Image = TWW_Coop.Resources.capacity_Bomb60;
                                    break;
                                case 99:
                                    bombsPicture.Image = TWW_Coop.Resources.capacity_Bomb99;
                                    break;
                                default:
                                    bombsPicture.Image = TWW_Coop.Resources.item_Bomb;
                                    break;
                            }
                        }
                    }

                    if (player.inventory.shield != old.inventory.shield)
                    {
                        switch (player.inventory.shield)
                        {
                            case (byte)WWItem.Shield1:
                                shieldPicture.Image = TWW_Coop.Resources.item_Shield1;
                                break;
                            case (byte)WWItem.Shield2:
                                shieldPicture.Image = TWW_Coop.Resources.item_Shield2;
                                break;
                            default:
                                shieldPicture.Image = TWW_Coop.Resources.item_ShieldN;
                                break;
                        }
                    }

                    old = player;
                    #endregion
                }

                if (msg.type == PacketType.WorldState)
                {
                    IntPtr buffer = Marshal.AllocHGlobal(worldStateSize);
                    Marshal.Copy(msg.data, 0, buffer, worldStateSize);
                    state = Marshal.PtrToStructure<WorldState>(buffer);
                    Marshal.FreeHGlobal(buffer);
                    
                    if (firstPass)
                    {
                        firstPass = false;
                        oldState = state;
                    }

                    if ((state.StageName != "sea_T") && (state.StageName != "Name") && (state.StageName != "\0\0\0\0\0\0\0\0"))
                    {
                        if ((state.StageName != oldState.StageName) || (state.zone != oldState.zone) || (state.stageID != oldState.stageID))
                        {
                            string movedMsg = String.Format("Player '{0}' moved to stage '{1}' (ID {2}), zone {3}", state.PlayerName, state.StageName, state.stageID, state.zone);
                            dolphinInQueue.Add(movedMsg);
                        }
                    }

                    oldState = state;
                }


                if (dolphinInQueue.Count > 0)
                {
                    Invoke(new Action(() => { PrintConsole("Dolphin: {0}", dolphinInQueue[0]); }));
                    dolphinInQueue.RemoveAt(0);
                }

                
                    
            }
        }

        private void telescopePicture_Click(object sender, EventArgs e)
        {

        }

        private void testButton_Click(object sender, EventArgs e)
        {
            dolphin.GiveItem(WWItem.PictoBox2);
        }
    }
}
