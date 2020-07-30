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
        private static bool trainermode = false;

        private static PlayerStatus player;

        private List<WWItem> upgradeItems = new List<WWItem>() { WWItem.PictoBox1, WWItem.PictoBox2, WWItem.Bow1, WWItem.Bow2, WWItem.Bow3, WWItem.Sword1, WWItem.Sword2, WWItem.Sword3, WWItem.Sword4, WWItem.Shield1, WWItem.Shield2 };

        public MainForm()
        {
            InitializeComponent();

            triforcePicture.Controls.Add(triforceCounter);
            triforceCounter.Location = new Point(32, 26);
            triforceCounter.BackColor = Color.Transparent;

            trainerModeCheckbox.Checked = trainermode;

            modeBox.SelectedIndex = 0;

            dolphin = new DolphinManager();
            PrintConsole("Opened and attached Dolphin");

            dolphinListener.DoWork += this.DolphinListener;
            listeningToDolphin = true;
            dolphinInQueue = new List<string>();
            dolphinListener.RunWorkerAsync();
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
            player = new PlayerStatus();
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

                    if (player.ammo.bowCapacity != old.ammo.bowCapacity)
                    {
                        ThreadSetText(bowCapacity, player.ammo.bowCapacity.ToString());
                    }

                    if (player.inventory.bombs != old.inventory.bombs)
                    {
                        if (player.inventory.bombs == (byte)WWItem.Bombs)
                        {
                            bombsPicture.Image = TWW_Coop.Resources.item_Bomb;
                        }
                        else
                        {
                            bombsPicture.Image = TWW_Coop.Resources.item_BombN;
                        }
                    }

                    if (player.ammo.bombCapacity != old.ammo.bombCapacity)
                    {
                        ThreadSetText(bombCapacity, player.ammo.bombCapacity.ToString());
                    }

                    // Bottle counter
                    if ((player.inventory.bottle1 != old.inventory.bottle1) || (player.inventory.bottle2 != old.inventory.bottle2) || (player.inventory.bottle3 != old.inventory.bottle3) || (player.inventory.bottle4 != old.inventory.bottle4))
                    {
                        int bottleCount = 0;
                        if (player.inventory.bottle1 != (byte)WWBottleContents.NoBottle)
                            bottleCount++;
                        if (player.inventory.bottle2 != (byte)WWBottleContents.NoBottle)
                            bottleCount++;
                        if (player.inventory.bottle3 != (byte)WWBottleContents.NoBottle)
                            bottleCount++;
                        if (player.inventory.bottle4 != (byte)WWBottleContents.NoBottle)
                            bottleCount++;

                        ThreadSetText(bottleCounter, bottleCount.ToString());

                        if (bottleCount > 0)
                            bottlePicture.Image = TWW_Coop.Resources.item_Bottle;
                        else
                            bottlePicture.Image = TWW_Coop.Resources.item_BottleN;
                    }

                    if (player.inventory.deliveryBag != old.inventory.deliveryBag)
                    {
                        if (player.inventory.deliveryBag == (byte)WWItem.MailBag)
                            deliveryBagPicture.Image = TWW_Coop.Resources.bag_DeliveryBag;
                        else
                            deliveryBagPicture.Image = TWW_Coop.Resources.bag_DeliveryBagN;
                    }

                    if (player.inventory.hookshot != old.inventory.hookshot)
                    {
                        if (player.inventory.hookshot == (byte)WWItem.Hookshot)
                            hookshotPicture.Image = TWW_Coop.Resources.item_Hookshot;
                        else
                            hookshotPicture.Image = TWW_Coop.Resources.item_HookshotN;
                    }

                    if (player.inventory.skullHammer != old.inventory.skullHammer)
                    {
                        if (player.inventory.skullHammer == (byte)WWItem.Hammer)
                            skullHammerPicture.Image = TWW_Coop.Resources.item_SkullHammer;
                        else
                            skullHammerPicture.Image = TWW_Coop.Resources.item_SkullHammerN;
                    }

                    if (player.inventory.bracelets != old.inventory.bracelets)
                    {
                        if (player.inventory.bracelets == (byte)WWItem.Bracelet)
                            powerBraceletsPicture.Image = TWW_Coop.Resources.item_PowerBracelets;
                        else
                            powerBraceletsPicture.Image = TWW_Coop.Resources.item_PowerBraceletsN;
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

                    if (player.questStatus.triforce != old.questStatus.triforce)
                    {
                        ThreadSetText(triforceCounter, player.questStatus.GetTriforceCount().ToString());
                    }

                    if (player.questStatus.statues != old.questStatus.statues)
                    {
                        ThreadSetText(tingleCounter, player.questStatus.GetStatueCount().ToString());
                    }

                    if (player.questStatus.pearls != old.questStatus.pearls)
                    {
                        if ((player.questStatus.pearls & WWPearlMask.Din) != 0)
                            dinPicture.Image = TWW_Coop.Resources.pearl_Din;
                        else
                            dinPicture.Image = TWW_Coop.Resources.pearl_N;

                        if ((player.questStatus.pearls & WWPearlMask.Farore) != 0)
                            farorePicture.Image = TWW_Coop.Resources.pearl_Farore;
                        else
                            farorePicture.Image = TWW_Coop.Resources.pearl_N;

                        if ((player.questStatus.pearls & WWPearlMask.Nayru) != 0)
                            nayruPicture.Image = TWW_Coop.Resources.pearl_Nayru;
                        else
                            nayruPicture.Image = TWW_Coop.Resources.pearl_N;
                    }

                    if (player.questStatus.songs != old.questStatus.songs)
                    {
                        if ((player.questStatus.songs & WWSongMask.WindsRequiem) != 0)
                            windsRequiemPicture.Image = TWW_Coop.Resources.song_WindsRequiem;
                        else
                            windsRequiemPicture.Image = TWW_Coop.Resources.item_WindWakerN;

                        if ((player.questStatus.songs & WWSongMask.BalladofGales) != 0)
                            balladOfGalesPicture.Image = TWW_Coop.Resources.song_BalladofGales;
                        else
                            balladOfGalesPicture.Image = TWW_Coop.Resources.item_WindWakerN;

                        if ((player.questStatus.songs & WWSongMask.CommandMelody) != 0)
                            commandMelodyPicture.Image = TWW_Coop.Resources.song_CommandMelody;
                        else
                            commandMelodyPicture.Image = TWW_Coop.Resources.item_WindWakerN;

                        if ((player.questStatus.songs & WWSongMask.EarthGodsLyric) != 0)
                            earthGodsLyricPicture.Image = TWW_Coop.Resources.song_EarthGodsLyric;
                        else
                            earthGodsLyricPicture.Image = TWW_Coop.Resources.item_WindWakerN;

                        if ((player.questStatus.songs & WWSongMask.WindGodsAria) != 0)
                            windGodsAriaPicture.Image = TWW_Coop.Resources.song_WindGodsAria;
                        else
                            windGodsAriaPicture.Image = TWW_Coop.Resources.item_WindWakerN;

                        if ((player.questStatus.songs & WWSongMask.SongofPassing) != 0)
                            songOfPassingPicture.Image = TWW_Coop.Resources.song_SongofPassing;
                        else
                            songOfPassingPicture.Image = TWW_Coop.Resources.item_WindWakerN;
                    }

                    if (player.questStatus.charts.HasFlag(WWChartMask.GhostShipChart))
                    {
                        ghostShipChartPicture.Image = TWW_Coop.Resources.item_GhostShipChart;
                    }

                    if (player.status.maxMagic != old.status.maxMagic)
                    {
                        switch (player.status.maxMagic)
                        {
                            case 0x10:
                                magicPicture.Image = TWW_Coop.Resources.capacity_Magic1;
                                break;
                            case 0x20:
                                magicPicture.Image = TWW_Coop.Resources.capacity_Magic2;
                                break;
                            default:
                                magicPicture.Image = TWW_Coop.Resources.capacity_MagicN;
                                break;
                        }
                    }

                    if (player.status.wallet != old.status.wallet)
                    {
                        switch (player.status.wallet)
                        {
                            case 0:
                                walletPicture.Image = TWW_Coop.Resources.capacity_WalletN;
                                break;
                            case 1:
                                walletPicture.Image = TWW_Coop.Resources.capacity_Wallet1;
                                break;
                            case 2:
                                walletPicture.Image = TWW_Coop.Resources.capacity_Wallet2;
                                break;
                            default:
                                walletPicture.Image = TWW_Coop.Resources.capacity_WalletN;
                                break;
                        }
                    }

                    // "Disposable" items to keep on the tracker once found
                    if (player.bags.deliveryBag.HasItem(WWItem.CabanaDeed))
                    {
                        cabanaDeedPicture.Image = TWW_Coop.Resources.item_CabanaDeed;
                    }

                    if (player.bags.deliveryBag.HasItem(WWItem.MaggiesLetter))
                    {
                        maggiesLetterPicture.Image = TWW_Coop.Resources.mail_MaggiesLetter;
                    }

                    if (player.bags.deliveryBag.HasItem(WWItem.MoblinsLetter))
                    {
                        moblinsLetterPicture.Image = TWW_Coop.Resources.mail_MoblinsLetter;
                    }

                    if (player.bags.deliveryBag.HasItem(WWItem.NotetoMom))
                    {
                        noteToMomPicture.Image = TWW_Coop.Resources.mail_NoteToMom;
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

        private void ToggleItem(WWItem item, MouseEventArgs e)
        {
            if (trainermode)
            {
                if (e.Button == MouseButtons.Left)
                    dolphin.GiveItem(item);
                if (e.Button == MouseButtons.Right)
                    dolphin.RevokeItem(item);
            }
        }

        private void AdjustItem(ItemCode itemCode, MouseEventArgs e)
        {
            if (trainermode)
            {
                if (e.Button == MouseButtons.Left)
                    dolphin.UpgradeItem(itemCode);
                if (e.Button == MouseButtons.Right)
                    dolphin.DowngradeItem(itemCode);
            }
        }

        private void TogglePearl(WWPearlMask pearl, MouseEventArgs e)
        {
            if (trainermode)
            {
                if (e.Button == MouseButtons.Left)
                    dolphin.AddPearl(pearl);
                if (e.Button == MouseButtons.Right)
                    dolphin.RemovePearl(pearl);
            }
        }

        private void ToggleSong(WWSongMask song, MouseEventArgs e)
        {
            if (trainermode)
            {
                if (e.Button == MouseButtons.Left)
                    dolphin.AddSong(song);
                if (e.Button == MouseButtons.Right)
                    dolphin.RemoveSong(song);
            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            dolphin.GiveItem(WWItem.HurricaneSpin);
        }

        private void triforcePicture_Click(object sender, EventArgs e)
        {
            if (trainermode)
            {
                Trainer_Triforce triforceForm = new Trainer_Triforce(dolphin, player.questStatus.triforce);
                triforceForm.ShowDialog();
            }
        }

        private void ThreadSetText(Label label, string text)
        {
            Invoke(new Action(() =>
            {
                label.Text = text;
            }));
        }

        private void ThreadSetTextVisible(Label label, bool visible)
        {
            Invoke(new Action(() =>
            {
                label.Visible = visible;
            }));
        }

        private void trainerModeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            trainermode = trainerModeCheckbox.Checked;
        }

        #region Trainer Mode Toggles
        private void telescopePicture_Click(object sender, MouseEventArgs e)
        {
            ToggleItem(WWItem.Telecope, e);
        }

        private void sailPicture_Click(object sender, MouseEventArgs e)
        {
            ToggleItem(WWItem.Sail, e);
        }

        private void wwPicture_Click(object sender, MouseEventArgs e)
        {
            ToggleItem(WWItem.WW, e);
        }
        private void grapplingHookPicture_Click(object sender, MouseEventArgs e)
        {
            ToggleItem(WWItem.GrapplingHook, e);
        }

        private void spoilsBagPicture_Click(object sender, MouseEventArgs e)
        {
            ToggleItem(WWItem.SpoilsBag, e);
        }

        private void boomerangPicture_Click(object sender, MouseEventArgs e)
        {
            ToggleItem(WWItem.Boomerang, e);
        }

        private void dekuLeafPicture_Click(object sender, MouseEventArgs e)
        {
            ToggleItem(WWItem.DekuLeaf, e);
        }

        private void tingleTunerPicture_Click(object sender, MouseEventArgs e)
        {
            ToggleItem(WWItem.TingleTuner, e);
        }

        private void pictoBoxPicture_Click(object sender, MouseEventArgs e)
        {
            AdjustItem(ItemCode.PictoBox, e);
        }

        private void ironBootsPicture_Click(object sender, MouseEventArgs e)
        {
            ToggleItem(WWItem.Boots, e);
        }

        private void magicArmorPicture_Click(object sender, MouseEventArgs e)
        {
            ToggleItem(WWItem.MagicArmor, e);
        }

        private void baitBagPicture_Click(object sender, MouseEventArgs e)
        {
            ToggleItem(WWItem.BaitBag, e);
        }

        private void bowPicture_Click(object sender, MouseEventArgs e)
        {
            AdjustItem(ItemCode.Bow, e);
        }

        private void bombsPicture_Click(object sender, MouseEventArgs e)
        {
            ToggleItem(WWItem.Bombs, e);
        }

        private void magicPicture_Click(object sender, MouseEventArgs e)
        {
            AdjustItem(ItemCode.Magic, e);
        }

        private void deliveryBagPicture_Click(object sender, MouseEventArgs e)
        {
            ToggleItem(WWItem.MailBag, e);
        }

        private void hookshotPicture_Click(object sender, MouseEventArgs e)
        {
            ToggleItem(WWItem.Hookshot, e);
        }

        private void skullHammerPicture_Click(object sender, MouseEventArgs e)
        {
            ToggleItem(WWItem.Hammer, e);
        }

        private void powerBraceletsPicture_Click(object sender, MouseEventArgs e)
        {
            ToggleItem(WWItem.Bracelet, e);
        }

        private void swordPicture_Click(object sender, MouseEventArgs e)
        {
            AdjustItem(ItemCode.Sword, e);
        }

        private void shieldPicture_Click(object sender, MouseEventArgs e)
        {
            AdjustItem(ItemCode.Shield, e);
        }

        private void dinPicture_Click(object sender, MouseEventArgs e)
        {
            TogglePearl(WWPearlMask.Din, e);
        }

        private void farorePicture_Click(object sender, MouseEventArgs e)
        {
            TogglePearl(WWPearlMask.Farore, e);
        }

        private void nayruPicture_Click(object sender, MouseEventArgs e)
        {
            TogglePearl(WWPearlMask.Nayru, e);
        }

        private void windsRequiemPicture_Click(object sender, MouseEventArgs e)
        {
            ToggleSong(WWSongMask.WindsRequiem, e);
        }

        private void balladOfGalesPicture_Click(object sender, MouseEventArgs e)
        {
            ToggleSong(WWSongMask.BalladofGales, e);
        }

        private void commandMelodyPicture_Click(object sender, MouseEventArgs e)
        {
            ToggleSong(WWSongMask.CommandMelody, e);
        }

        private void earthGodsLyricPicture_Click(object sender, MouseEventArgs e)
        {
            ToggleSong(WWSongMask.EarthGodsLyric, e);
        }

        private void windGodsAriaPicture_Click(object sender, MouseEventArgs e)
        {
            ToggleSong(WWSongMask.WindGodsAria, e);
        }

        private void songOfPassingPicture_Click(object sender, MouseEventArgs e)
        {
            ToggleSong(WWSongMask.SongofPassing, e);
        }

        private void walletPicture_Click(object sender, MouseEventArgs e)
        {
            AdjustItem(ItemCode.Wallet, e);
        }

        private void bowCapacity_Click(object sender, MouseEventArgs e)
        {
            AdjustItem(ItemCode.BowCapacity, e);
        }

        private void bombCapacity_Click(object sender, MouseEventArgs e)
        {
            AdjustItem(ItemCode.BombCapacity, e);
        }


        #endregion

        private void tingleStatuePicture_Click(object sender, EventArgs e)
        {
            if (trainermode)
            {
                Trainer_Statues statueForm = new Trainer_Statues(dolphin, player.questStatus.statues);
                statueForm.ShowDialog();
            }
        }

        private void bottlePicture_Click(object sender, EventArgs e)
        {
            if (trainermode)
            {
                Trainer_Bottles bottleForm = new Trainer_Bottles(dolphin, player.inventory.bottle1, player.inventory.bottle2, player.inventory.bottle3, player.inventory.bottle4);
                bottleForm.ShowDialog();
            }
        }
    }
}
