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
    public partial class Trainer_Triforce : Form
    {
        private DolphinManager dolphin;
        private WWTriforceMask triforce;
        public Trainer_Triforce(DolphinManager d, WWTriforceMask t)
        {
            dolphin = d;
            triforce = t;
            InitializeComponent();

            SetCheckboxesFromTriforce();
        }
        private void triforceChecklist_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            byte newTriforce = 0;
            System.Collections.IEnumerator triforceShards = triforceChecklist.CheckedIndices.GetEnumerator();
            while (triforceShards.MoveNext() != false)
            {
                int current = (int)triforceShards.Current;
                newTriforce |= (byte)(1 << current);
            }

            //if (newTriforce != triforce)
                //dolphin.SetTriforce(newTriforce);
        }

        private void SetCheckboxesFromTriforce()
        {
            for (int i = 0; i < 8; i++)
            {
                triforceChecklist.SetItemChecked(i, false);

                if (((1 << i) & (int)triforce) != 0)
                    triforceChecklist.SetItemChecked(i, true);
            }
        }
    }
}
