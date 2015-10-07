using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UPS_Manager
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                textBoxLastDuration.Text = UPS_Manager.Properties.Settings.Default.Duration.ToString();
                textBoxIPvoltage.Text = ModuleMain.Info.IVoltage.ToString();
                textBoxIPfaultvoltage.Text = ModuleMain.Info.IFaultVoltage.ToString();
                textBoxOPvoltage.Text = ModuleMain.Info.OVoltage.ToString();
                textBoxOPcurrent.Text = ModuleMain.Info.OMaximumCurrent.ToString();
                textBoxIPfrequency.Text = ModuleMain.Info.IFrequency.ToString();
                textBoxBatteryvoltage.Text = ModuleMain.Info.BatteryVoltage.ToString();
                textBoxTemperature.Text = ModuleMain.Info.Temperature.ToString();
                checkBoxUtilityFail.Checked = ModuleMain.Info.UtilityFail_Immediate;
                checkBoxBatteryLow.Checked = ModuleMain.Info.BatteryLow;
                checkBoxBypassBoostorBuckActive.Checked = ModuleMain.Info.Bypass_Boost_or_Buck_Active;
                checkBoxUPSFailed.Checked = ModuleMain.Info.UPS_Failed;
                checkBoxUPSTypeIsStandby.Checked = ModuleMain.Info.UPSTypeisStandby_0isOn_line;
                checkBoxTestInProgress.Checked = ModuleMain.Info.TestinProgress;
                checkBoxShutdownActive.Checked = ModuleMain.Info.ShutdownActive;
                checkBoxBeeperOn.Checked = ModuleMain.Info.BeeperOn;
                checkBoxSuccess.Checked = ModuleMain.Info.Success;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Info_Load(object sender, EventArgs e)
        {
            try
            {
                timer.Interval = UPS_Manager.Properties.Settings.Default.DataTimerInterval;
                timer.Enabled = true;
                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Info_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Dispose();
        }
    }
}
