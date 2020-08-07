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
    public partial class Trainer_Statues : Form
    {
        private DolphinManager dolphin;
        private WWStatueMask statues;
        private bool initializing = true;
        private List<WWStatueMask> statueIndices = new List<WWStatueMask>() 
        { 
            WWStatueMask.Dragon, 
            WWStatueMask.Forbidden, 
            WWStatueMask.Goddess, 
            WWStatueMask.Earth, 
            WWStatueMask.Wind 
        };

        public Trainer_Statues(DolphinManager d, WWStatueMask s)
        {
            dolphin = d;
            statues = s;
            InitializeComponent();

            SetCheckboxesFromStatues();
        }

        private void statueChecklist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initializing)
                return;
            if (IsHandleCreated)
            { 
                this.BeginInvoke(new Action(() =>
                {
                    byte newStatues = 0;

                    for (int i = 0; i < 5; i++)
                    {
                        if (statueChecklist.GetItemChecked(i))
                        {
                            newStatues |= (byte)statueIndices[i];
                        }
                    }

                    if (newStatues != (byte)statues)
                    {
                        dolphin.SetStatues(newStatues);
                        statues = (WWStatueMask)newStatues;
                    }
                }));
            }
        }
        private void SetCheckboxesFromStatues()
        {
            for (int i = 0; i < 5; i++)
            {
                statueChecklist.SetItemChecked(i, false);

                if ((statueIndices[i] & statues) != 0)
                    statueChecklist.SetItemChecked(i, true);
            }

            initializing = false;
        }
    }
}
