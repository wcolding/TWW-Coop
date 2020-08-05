using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TWW_Coop
{
    public partial class Trainer_MailBag : Form
    {
        DolphinManager dolphin;
        Bag mailBag;
        bool initializing = true;

        private List<WWItem> mailIndices = new List<WWItem>()
        {
           WWItem.NoItem,
           WWItem.FathersLetter,
           WWItem.NotetoMom,
           WWItem.MaggiesLetter,
           WWItem.MoblinsLetter,
           WWItem.CabanaDeed,
           WWItem.ComplimentaryID,
           WWItem.FillupCoupon,
           WWItem.TownFlower,
           WWItem.SeaFlower,
           WWItem.ExoticFlower,
           WWItem.HerosFlag,
           WWItem.BigCatchFlag,
           WWItem.BigSaleFlag,
           WWItem.Pinwheel,
           WWItem.SickleMoonFlag,
           WWItem.SkullTowerIdol,
           WWItem.FountainIdol,
           WWItem.PostmanStatue,
           WWItem.ShopGuruStatue
        };

        public Trainer_MailBag(DolphinManager d, Bag b)
        {
            dolphin = d;
            mailBag = b;
            InitializeComponent();

            SetBoxesFromMailBag();
        }

        private void SetBoxesFromMailBag()
        {
            mailBox1.SelectedIndex = mailIndices.IndexOf((WWItem)mailBag.contents[0]);
            mailBox2.SelectedIndex = mailIndices.IndexOf((WWItem)mailBag.contents[1]);
            mailBox3.SelectedIndex = mailIndices.IndexOf((WWItem)mailBag.contents[2]);
            mailBox4.SelectedIndex = mailIndices.IndexOf((WWItem)mailBag.contents[3]);

            mailBox5.SelectedIndex = mailIndices.IndexOf((WWItem)mailBag.contents[4]);
            mailBox6.SelectedIndex = mailIndices.IndexOf((WWItem)mailBag.contents[5]);
            mailBox7.SelectedIndex = mailIndices.IndexOf((WWItem)mailBag.contents[6]);
            mailBox8.SelectedIndex = mailIndices.IndexOf((WWItem)mailBag.contents[7]);
            initializing = false;
        }
        private void SetSlotFromBox(int index, ComboBox box)
        {
            if (initializing)
                return;

            WWItem value = mailIndices[box.SelectedIndex];
            dolphin.SetMailBagSlot(index, (byte)value);
        }

        private void mailBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSlotFromBox(0, mailBox1);
        }

        private void mailBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSlotFromBox(1, mailBox2);
        }

        private void mailBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSlotFromBox(2, mailBox3);
        }

        private void mailBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSlotFromBox(3, mailBox4);
        }

        private void mailBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSlotFromBox(4, mailBox5);
        }

        private void mailBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSlotFromBox(5, mailBox6);
        }

        private void mailBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSlotFromBox(6, mailBox7);
        }

        private void mailBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSlotFromBox(7, mailBox8);
        }
    }
}
