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
    public partial class Trainer_Charts : Form
    {
        private WWChartMask charts;
        private DolphinManager dolphin;
        public Trainer_Charts(DolphinManager d, WWChartMask c)
        {
            charts = c;
            dolphin = d;
            InitializeComponent();

            SetCheckboxesFromCharts();
        }

        private void SetCheckboxesFromCharts()
        {
            triforce1.Checked = charts.HasFlag(WWChartMask.TriforceChart1);
            triforce2.Checked = charts.HasFlag(WWChartMask.TriforceChart2);
            triforce3.Checked = charts.HasFlag(WWChartMask.TriforceChart3);
            triforce4.Checked = charts.HasFlag(WWChartMask.TriforceChart4);
            triforce5.Checked = charts.HasFlag(WWChartMask.TriforceChart5);
            triforce6.Checked = charts.HasFlag(WWChartMask.TriforceChart6);
            triforce7.Checked = charts.HasFlag(WWChartMask.TriforceChart7);
            triforce8.Checked = charts.HasFlag(WWChartMask.TriforceChart8);

            ghostShip.Checked = charts.HasFlag(WWChartMask.GhostShipChart);
            tingle.Checked = charts.HasFlag(WWChartMask.TinglesChart);
            incredible.Checked = charts.HasFlag(WWChartMask.IncredibleChart);
            octo.Checked = charts.HasFlag(WWChartMask.OctoChart);
            greatFairy.Checked = charts.HasFlag(WWChartMask.GreatFairyChart);
            islandHearts.Checked = charts.HasFlag(WWChartMask.IslandHeartsChart);
            seaHearts.Checked = charts.HasFlag(WWChartMask.SeaHeartsChart);
            secretCave.Checked = charts.HasFlag(WWChartMask.SecretCaveChart);
            lightRing.Checked = charts.HasFlag(WWChartMask.LightRingChart);
            platform.Checked = charts.HasFlag(WWChartMask.PlatformChart);
            beedle.Checked = charts.HasFlag(WWChartMask.BeedlesChart);
            submarine.Checked = charts.HasFlag(WWChartMask.SubmarineChart);

            treasure1.Checked = charts.HasFlag(WWChartMask.TreasureChart1);
            treasure2.Checked = charts.HasFlag(WWChartMask.TreasureChart2);
            treasure3.Checked = charts.HasFlag(WWChartMask.TreasureChart3);
            treasure4.Checked = charts.HasFlag(WWChartMask.TreasureChart4);
            treasure5.Checked = charts.HasFlag(WWChartMask.TreasureChart5);

            treasure6.Checked = charts.HasFlag(WWChartMask.TreasureChart6);
            treasure7.Checked = charts.HasFlag(WWChartMask.TreasureChart7);
            treasure8.Checked = charts.HasFlag(WWChartMask.TreasureChart8);
            treasure9.Checked = charts.HasFlag(WWChartMask.TreasureChart9);
            treasure10.Checked = charts.HasFlag(WWChartMask.TreasureChart10);

            treasure11.Checked = charts.HasFlag(WWChartMask.TreasureChart11);
            treasure12.Checked = charts.HasFlag(WWChartMask.TreasureChart12);
            treasure13.Checked = charts.HasFlag(WWChartMask.TreasureChart13);
            treasure14.Checked = charts.HasFlag(WWChartMask.TreasureChart14);
            treasure15.Checked = charts.HasFlag(WWChartMask.TreasureChart15);

            treasure16.Checked = charts.HasFlag(WWChartMask.TreasureChart16);
            treasure17.Checked = charts.HasFlag(WWChartMask.TreasureChart17);
            treasure18.Checked = charts.HasFlag(WWChartMask.TreasureChart18);
            treasure19.Checked = charts.HasFlag(WWChartMask.TreasureChart19);
            treasure20.Checked = charts.HasFlag(WWChartMask.TreasureChart20);

            treasure21.Checked = charts.HasFlag(WWChartMask.TreasureChart21);
            treasure22.Checked = charts.HasFlag(WWChartMask.TreasureChart22);
            treasure23.Checked = charts.HasFlag(WWChartMask.TreasureChart23);
            treasure24.Checked = charts.HasFlag(WWChartMask.TreasureChart24);
            treasure25.Checked = charts.HasFlag(WWChartMask.TreasureChart25);

            treasure26.Checked = charts.HasFlag(WWChartMask.TreasureChart26);
            treasure27.Checked = charts.HasFlag(WWChartMask.TreasureChart27);
            treasure28.Checked = charts.HasFlag(WWChartMask.TreasureChart28);
            treasure29.Checked = charts.HasFlag(WWChartMask.TreasureChart29);
            treasure30.Checked = charts.HasFlag(WWChartMask.TreasureChart30);

            treasure31.Checked = charts.HasFlag(WWChartMask.TreasureChart31);
            treasure32.Checked = charts.HasFlag(WWChartMask.TreasureChart32);
            treasure33.Checked = charts.HasFlag(WWChartMask.TreasureChart33);
            treasure34.Checked = charts.HasFlag(WWChartMask.TreasureChart34);
            treasure35.Checked = charts.HasFlag(WWChartMask.TreasureChart35);

            treasure36.Checked = charts.HasFlag(WWChartMask.TreasureChart36);
            treasure37.Checked = charts.HasFlag(WWChartMask.TreasureChart37);
            treasure38.Checked = charts.HasFlag(WWChartMask.TreasureChart38);
            treasure39.Checked = charts.HasFlag(WWChartMask.TreasureChart39);
            treasure40.Checked = charts.HasFlag(WWChartMask.TreasureChart40);

            treasure41.Checked = charts.HasFlag(WWChartMask.TreasureChart41);
        }

        private void ToggleChart(object sender, WWChartMask chart)
        {
            CheckBox box = sender as CheckBox;
            if (box.Checked)
                dolphin.GiveChart(chart);
            else
                dolphin.RemoveChart(chart);
        }

        #region Checkbox Toggles

        private void triforce1_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TriforceChart1);
        }

        private void triforce2_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TriforceChart2);
        }

        private void triforce3_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TriforceChart3);
        }

        private void triforce4_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TriforceChart4);
        }

        private void triforce5_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TriforceChart5);
        }

        private void triforce6_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TriforceChart6);
        }

        private void triforce7_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TriforceChart7);
        }

        private void triforce8_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TriforceChart8);
        }

        private void ghostShip_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.GhostShipChart);
        }

        private void tingle_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TinglesChart);
        }

        private void incredible_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.IncredibleChart);
        }

        private void octo_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.OctoChart);
        }

        private void greatFairy_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.GreatFairyChart);
        }

        private void islandHearts_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.IslandHeartsChart);
        }

        private void seaHearts_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.SeaHeartsChart);
        }

        private void secretCave_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.SecretCaveChart);
        }

        private void lightRing_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.LightRingChart);
        }

        private void platform_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.PlatformChart);
        }

        private void beedle_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.BeedlesChart);
        }

        private void submarine_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.SubmarineChart);
        }

        private void treasure1_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart1);
        }

        private void treasure2_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart2);
        }

        private void treasure3_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart3);
        }

        private void treasure4_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart4);
        }

        private void treasure5_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart5);
        }

        private void treasure6_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart6);
        }

        private void treasure7_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart7);
        }

        private void treasure8_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart8);
        }

        private void treasure9_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart9);
        }

        private void treasure10_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart10);
        }

        private void treasure11_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart11);
        }

        private void treasure12_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart12);
        }

        private void treasure13_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart13);
        }

        private void treasure14_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart14);
        }

        private void treasure15_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart15);
        }

        private void treasure16_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart16);
        }

        private void treasure17_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart17);
        }

        private void treasure18_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart18);
        }

        private void treasure19_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart19);
        }

        private void treasure20_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart20);
        }

        private void treasure21_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart21);
        }

        private void treasure22_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart22);
        }

        private void treasure23_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart23);
        }

        private void treasure24_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart24);
        }

        private void treasure25_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart25);
        }

        private void treasure26_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart26);
        }

        private void treasure27_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart27);
        }

        private void treasure28_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart28);
        }

        private void treasure29_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart29);
        }

        private void treasure30_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart30);
        }

        private void treasure31_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart31);
        }

        private void treasure32_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart32);
        }

        private void treasure33_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart33);
        }

        private void treasure34_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart34);
        }

        private void treasure35_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart35);
        }

        private void treasure36_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart36);
        }

        private void treasure37_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart37);
        }

        private void treasure38_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart38);
        }

        private void treasure39_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart39);
        }

        private void treasure40_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart40);
        }

        private void treasure41_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChart(sender, WWChartMask.TreasureChart41);
        }

        #endregion
    }
}
