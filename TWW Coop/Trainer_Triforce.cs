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
            this.BeginInvoke(new Action(() =>
            {
                byte newTriforce = 0;

                for (int i = 0; i < 8; i++)
                {
                    if (triforceChecklist.GetItemChecked(i))
                    {
                        newTriforce |= (byte)(1 << i);
                    }
                }

                if (newTriforce != (byte)triforce)
                {
                    dolphin.SetTriforce(newTriforce);
                    triforce = (WWTriforceMask)newTriforce;
                }
            }));
            
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
