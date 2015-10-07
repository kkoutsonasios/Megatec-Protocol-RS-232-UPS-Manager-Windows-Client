using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace UPS_Manager
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            try
            {
                //textBoxUPSPort.Text = UPS_Manager.Properties.Settings.Default.UPSPort;
                //textBoxInterval.Text = UPS_Manager.Properties.Settings.Default.DataTimerInterval.ToString();
                numericUpDownInterval.Value = (decimal)(UPS_Manager.Properties.Settings.Default.DataTimerInterval/1000.0);
                //textBoxVoltageMax.Text = UPS_Manager.Properties.Settings.Default.BatteryMax.ToString();
                //textBoxVoltageMin.Text = UPS_Manager.Properties.Settings.Default.BatteryMin.ToString();
                numericUpDownVoltageMax.Value = (decimal)(UPS_Manager.Properties.Settings.Default.BatteryMax);
                numericUpDownVoltageMin.Value = (decimal)(UPS_Manager.Properties.Settings.Default.BatteryMin);
                checkBoxAutoStart.Checked = UPS_Manager.Properties.Settings.Default.AutoStart;
                checkBoxAutoMaxMin.Checked = UPS_Manager.Properties.Settings.Default.AutoMaxMin;
                //17-2-2014
                string[] ports = SerialPort.GetPortNames();
                comboBoxUPSPort.DataSource = ports;
                comboBoxUPSPort.SelectedItem = UPS_Manager.Properties.Settings.Default.UPSPort;
                //textBoxChargingVoltageMax.Text = UPS_Manager.Properties.Settings.Default.BatteryChargeMax.ToString();
                //textBoxChargingVoltageMin.Text = UPS_Manager.Properties.Settings.Default.BatteryChargeMin.ToString();
                numericUpDownChargingVoltageMax.Value = (decimal)(UPS_Manager.Properties.Settings.Default.BatteryChargeMax);
                numericUpDownChargingVoltageMin.Value = (decimal)(UPS_Manager.Properties.Settings.Default.BatteryChargeMin);
                textBoxControlerName.Text = UPS_Manager.Properties.Settings.Default.RS232DeviveName;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                UPS_Manager.Properties.Settings.Default.UPSPort = comboBoxUPSPort.SelectedItem.ToString(); //textBoxUPSPort.Text;
                //UPS_Manager.Properties.Settings.Default.DataTimerInterval = Convert.ToInt32(textBoxInterval.Text);
                UPS_Manager.Properties.Settings.Default.DataTimerInterval = Convert.ToInt32(numericUpDownInterval.Value*1000);
                //UPS_Manager.Properties.Settings.Default.BatteryMax = Convert.ToDouble(textBoxVoltageMax.Text.Replace(".",","));
                //UPS_Manager.Properties.Settings.Default.BatteryMin = Convert.ToDouble(textBoxVoltageMin.Text.Replace(".", ","));
                UPS_Manager.Properties.Settings.Default.BatteryMax = Convert.ToDouble(numericUpDownVoltageMax.Value);
                UPS_Manager.Properties.Settings.Default.BatteryMin = Convert.ToDouble(numericUpDownVoltageMin.Value);
                UPS_Manager.Properties.Settings.Default.AutoStart = checkBoxAutoStart.Checked;
                UPS_Manager.Properties.Settings.Default.AutoMaxMin = checkBoxAutoMaxMin.Checked;

                //17-2-2014
                //UPS_Manager.Properties.Settings.Default.BatteryChargeMax = Convert.ToDouble(textBoxChargingVoltageMax.Text.Replace(".", ","));
                //UPS_Manager.Properties.Settings.Default.BatteryChargeMin = Convert.ToDouble(textBoxChargingVoltageMin.Text.Replace(".", ","));
                UPS_Manager.Properties.Settings.Default.BatteryChargeMax = Convert.ToDouble(numericUpDownChargingVoltageMax.Value);
                UPS_Manager.Properties.Settings.Default.BatteryChargeMin = Convert.ToDouble(numericUpDownChargingVoltageMin.Value);
                UPS_Manager.Properties.Settings.Default.RS232DeviveName = textBoxControlerName.Text;

                UPS_Manager.Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
