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
    public partial class CostEst : Form
    {
        public CostEst()
        {
            InitializeComponent();
        }

        private void CostEst_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ModuleMain.IsCostfrmOpen = false;
                timer.Stop();
                timer.Dispose();
                this.Hide();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (ModuleMain.Info != null)
                {
                    if (ModuleMain.Info.Success && ModuleMain.RatingInfo.Success)
                    {
                        double KWh = 0.10252;
                        double watt = ((ModuleMain.RatingInfo.RatingCurrent*(ModuleMain.Info.OMaximumCurrent/100.0))*ModuleMain.Info.OVoltage);
                        labelCurrentPS.Text = ModuleMain.Info.OMaximumCurrent.ToString()+"%";
                        labelWattage.Text = Math.Round(watt,2).ToString() + "W";
                        labelCostEST.Text = Math.Round((((watt / 1000) * KWh)*(16*30)),2).ToString() + "€/Month";
                        labelTemperature.Text = ModuleMain.Info.Temperature.ToString() + "°C";
                        
                        int Red_ = (550 / 100) * ModuleMain.Info.OMaximumCurrent;
                        if (Red_ > 255) Red_ = 255;
                        int Green_ = (255 / 100) * ModuleMain.Info.OMaximumCurrent;
                        if (Green_ > 255) Green_ = 255;
                        this.BackColor = Color.FromArgb(Red_, 255 - Green_, 0);


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CostEst_Load(object sender, EventArgs e)
        {
            try
            {
                int TmpWidth = SystemInformation.PrimaryMonitorSize.Width;
                int TmpHeight = SystemInformation.PrimaryMonitorSize.Height;
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(TmpWidth - this.Size.Width, TmpHeight - this.Size.Height-30);

                timer.Interval = UPS_Manager.Properties.Settings.Default.DataTimerInterval;
                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
