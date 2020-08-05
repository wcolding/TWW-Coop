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
    public partial class Trainer_Bottles : Form
    {
        private DolphinManager dolphin;
        private byte[] bottles = new byte[4];
        private bool initializing = true;
        private List<WWBottleContents> bottleIndices = new List<WWBottleContents>()
        {
           WWBottleContents.NoBottle,
           WWBottleContents.Empty,
           WWBottleContents.RedPotion,
           WWBottleContents.GreenPotion,
           WWBottleContents.BluePotion,
           WWBottleContents.HalfSoup,
           WWBottleContents.FullSoup,
           WWBottleContents.Water,
           WWBottleContents.Fairy,
           WWBottleContents.Firefly,
           WWBottleContents.ForestWater,
        };
        public Trainer_Bottles(DolphinManager d, byte b1, byte b2, byte b3, byte b4)
        {
            dolphin = d;
            bottles[0] = b1;
            bottles[1] = b2;
            bottles[2] = b3;
            bottles[3] = b4;
            InitializeComponent();

            SetBoxesFromBottles();
        }

        private void SetBoxesFromBottles()
        {
            bottleBox1.SelectedIndex = bottleIndices.IndexOf((WWBottleContents)bottles[0]);
            bottleBox2.SelectedIndex = bottleIndices.IndexOf((WWBottleContents)bottles[1]);
            bottleBox3.SelectedIndex = bottleIndices.IndexOf((WWBottleContents)bottles[2]);
            bottleBox4.SelectedIndex = bottleIndices.IndexOf((WWBottleContents)bottles[3]);

            initializing = false;
        }

        private void SetBottleFromBox(int index, ComboBox box)
        {
            if (initializing)
                return;
            WWBottleContents value = bottleIndices[box.SelectedIndex];
            dolphin.SetBottleSlot(index, (byte)value);
        }

        private void bottleBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetBottleFromBox(0, bottleBox1);
        }

        private void bottleBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetBottleFromBox(1, bottleBox2);
        }

        private void bottleBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetBottleFromBox(2, bottleBox3);
        }

        private void bottleBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetBottleFromBox(3, bottleBox4);
        }
    }
}
