using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace UPS_Manager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (UPS_Manager.Properties.Settings.Default.AutoStart)
                {
                    ModuleMain.StartService();
                    //UPS.MegatecProtocol.TestFor10Seconds();
                }
                else
                {
                    ModuleMain.StartUPSManager.Enabled = true;
                    ModuleMain.StopUPSManager.Enabled = false;
                    ModuleMain.SettingsUPSManager.Enabled = true;
                    ModuleMain.InfoUPSManager.Enabled = false;
                    ModuleMain.MuteBeeper.Enabled = false;
                }
                //NotifyIcon UPSNotifyIcon = new NotifyIcon();
                ModuleMain.UPSNotifyIcon = new NotifyIcon();
                ContextMenu contextMenu = new ContextMenu();

                MenuItem ExitUPSManager = new MenuItem();
                contextMenu.MenuItems.AddRange(new MenuItem[] { ModuleMain.StartUPSManager, ModuleMain.StopUPSManager, ModuleMain.SettingsUPSManager, ModuleMain.InfoUPSManager, ExitUPSManager, ModuleMain.MuteBeeper, ModuleMain.DrainBattery });
                ModuleMain.MuteBeeper.Index = 0;
                ModuleMain.DrainBattery.Index = 1;
                ModuleMain.StartUPSManager.Index = 2;
                ModuleMain.StopUPSManager.Index = 3;
                ModuleMain.SettingsUPSManager.Index = 5;
                ModuleMain.InfoUPSManager.Index = 4;
                ExitUPSManager.Index = 6;
                ModuleMain.MuteBeeper.Text = "Mute Beeper";
                ModuleMain.DrainBattery.Text = "Battery Test";
                ModuleMain.StartUPSManager.Text = "Start Monitor";
                ModuleMain.StopUPSManager.Text = "Stop Monitor";
                ModuleMain.SettingsUPSManager.Text = "Settings";
                ModuleMain.InfoUPSManager.Text = "UPS Info";
                ExitUPSManager.Text = "E&xit";
                ModuleMain.MuteBeeper.Click += new EventHandler(MuteBeeper_Click);
                ModuleMain.DrainBattery.Click += new EventHandler(DrainBattery_Click);
                ModuleMain.StartUPSManager.Click += new EventHandler(StartUPSManager_Click);
                ModuleMain.StopUPSManager.Click += new EventHandler(StopUPSManager_Click);
                ModuleMain.SettingsUPSManager.Click += new EventHandler(SettingsUPSManager_Click);
                ModuleMain.InfoUPSManager.Click += new EventHandler(InfoUPSManager_Click);
                ModuleMain.UPSNotifyIcon.DoubleClick += new EventHandler(CostEST_Click);
                ExitUPSManager.Click += new EventHandler(ExitUPSManager_Click);
                ModuleMain.UPSNotifyIcon.Icon = Properties.Resources.OffLine;
                ModuleMain.UPSNotifyIcon.ContextMenu = contextMenu;
                ModuleMain.UPSNotifyIcon.Visible = true;
                Application.Run();
                ModuleMain.UPSNotifyIcon.Visible = false;
                // Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static void MuteBeeper_Click(object Sender, EventArgs e)
        {
            try
            {
                if (ModuleMain.MuteBeeper.Text == "Mute Beeper")
                    {
                        UPS_Manager.Properties.Settings.Default.MuteBeeper = true;
                    }
                    else
                    {
                        UPS_Manager.Properties.Settings.Default.MuteBeeper = false;
                    }

                UPS_Manager.Properties.Settings.Default.Save();
                UPS.MegatecProtocol.TurnOnOffBeep();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static void DrainBattery_Click(object Sender, EventArgs e)
        {
            try
            {
                //UPS.MegatecProtocol.ShutdownCommand(5);
                UPS.MegatecProtocol.TestFor10Seconds();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static void StartUPSManager_Click(object Sender, EventArgs e)
        {
            try
            {
                ModuleMain.StartService();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static void StopUPSManager_Click(object Sender, EventArgs e)
        {
            try
            {
                ModuleMain.StopService();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static void SettingsUPSManager_Click(object Sender, EventArgs e)
        {
            try
            {
                Form frm = new UPS_Manager.Settings();
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static void InfoUPSManager_Click(object Sender, EventArgs e)
        {
            try
            {
                Form frm = new UPS_Manager.Info();
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static void ExitUPSManager_Click(object Sender, EventArgs e)
        {
            try
            {
                ModuleMain.StopService();
                Application.Exit();
            }
            catch (Exception ex)
            {
                Application.Exit();
            }
        }
        private static void CostEST_Click(object Sender, EventArgs e)
        {
            try
            {
                if (!ModuleMain.IsCostfrmOpen)
                {
                    Form CostFrm = new UPS_Manager.CostEst();
                    CostFrm.Show();
                    ModuleMain.IsCostfrmOpen = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
