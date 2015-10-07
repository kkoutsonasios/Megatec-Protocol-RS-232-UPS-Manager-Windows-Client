using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace UPS_Manager
{
    public static class ModuleMain
    {
        //UPS.MegatecProtocol.TestFor10Seconds();
        public static NotifyIcon UPSNotifyIcon;
        public static bool IsCostfrmOpen = false;
        public static DateTime StartTime = DateTime.Now;
        public static bool Counting = false;
        public static MenuItem StartUPSManager = new MenuItem();
        public static MenuItem StopUPSManager = new MenuItem();
        public static MenuItem SettingsUPSManager = new MenuItem();
        public static MenuItem InfoUPSManager = new MenuItem();
        public static MenuItem MuteBeeper = new MenuItem();
        public static MenuItem DrainBattery = new MenuItem();
        public static System.Windows.Forms.Timer DataTimer;
        public static UPS.StatusInquiryInfo Info;
        public static UPS.UPSRatingInformationInfo RatingInfo = new UPS.UPSRatingInformationInfo();
        public static void GetUPSRatingInfo()
        {
            while (!RatingInfo.Success)
            {
                RatingInfo = UPS.MegatecProtocol.UPSRatingInformation();
            }
        }
        public static void GetUPSData()
        {
            Info = UPS.MegatecProtocol.StatusInquiry();
            //RatingInfo = UPS.MegatecProtocol.UPSRatingInformation();
            double TmpMax = UPS_Manager.Properties.Settings.Default.BatteryMax;
            double TmpMin = UPS_Manager.Properties.Settings.Default.BatteryMin;
            if (Info.Success && Info.UtilityFail_Immediate)
            {
                if (TmpMax < Info.BatteryVoltage)
                {
                    TmpMax = Info.BatteryVoltage;
                    UPS_Manager.Properties.Settings.Default.BatteryMax = TmpMax;
                    UPS_Manager.Properties.Settings.Default.Save();
                }
                if (TmpMin > Info.BatteryVoltage)
                {
                    TmpMin = Info.BatteryVoltage;
                    UPS_Manager.Properties.Settings.Default.BatteryMin = TmpMin;
                    UPS_Manager.Properties.Settings.Default.Save();
                }

                if (Counting == false && Info.UtilityFail_Immediate)
                {
                    Counting = true;
                    StartTime = DateTime.Now;
                }
                else
                {
                    if (!Info.UtilityFail_Immediate && Counting)
                    {
                        Counting = false;
                    }
                    else
                    {
                        UPS_Manager.Properties.Settings.Default.Duration = DateTime.Now.Subtract(StartTime);
                        UPS_Manager.Properties.Settings.Default.Save();
                    }
                }
            }
        }
        public static void InitUPS()
        {
            UPS.UPSModule.OpenRS232Port(UPS_Manager.Properties.Settings.Default.UPSPort);
            GetUPSRatingInfo();
        }
        public static void CloseUPS()
        {
            UPS.UPSModule.CloseRS232Port();
        }
        public static void TimerInit()
        {
            DataTimer = new System.Windows.Forms.Timer();
            DataTimer.Tick += new System.EventHandler(DataTimer_Tick);
            DataTimer.Interval = UPS_Manager.Properties.Settings.Default.DataTimerInterval;
        }
        public static void TimerClose()
        {
            DataTimer.Dispose();
        }
        private static void DataTimer_Tick(object sender, System.EventArgs e)
        {
            try
            {
                GetUPSData();
                if (Info.Success)
                {
                    bool ShowBatteryIcons = false;
                    if (Info.UtilityFail_Immediate || Info.TestinProgress)
                    {
                        ShowBatteryIcons = true;
                    }
                    else
                    {
                        ShowBatteryIcons = false;
                    }
                   // UpDateChargingIcon(Info.BatteryVoltage, ShowBatteryIcons);
                    UpDateIcons(Info.BatteryVoltage, ShowBatteryIcons, Info.BeeperOn, Info.TestinProgress);
                    // edw an einai anapoda
                    if (Info.BeeperOn == UPS_Manager.Properties.Settings.Default.MuteBeeper)
                    {
                        UPS.MegatecProtocol.TurnOnOffBeep();
                    }
                }
            }
            catch (Exception ex)
            {
                ModuleMain.StopService();
                string CMDCommand = Application.StartupPath;
                string strCmdText = CMDCommand + @"\DevManView.exe";
                string tmp = @"/disable_enable " + '"' +UPS_Manager.Properties.Settings.Default.RS232DeviveName +'"';
                System.Diagnostics.Process.Start(strCmdText, tmp);
                System.Threading.Thread.Sleep(5000);
                ModuleMain.StartService();
                //MessageBox.Show(ex.Message);
            }

        }
        public static void StartService()
        {
            IconCalcPS.PSInfo.CalcPS(UPS_Manager.Properties.Settings.Default.BatteryMax, UPS_Manager.Properties.Settings.Default.BatteryMin);
            StartUPSManager.Enabled = false;
            StopUPSManager.Enabled = true;
            SettingsUPSManager.Enabled = false;
            InfoUPSManager.Enabled = true;
            ModuleMain.MuteBeeper.Enabled = true;
            ModuleMain.DrainBattery.Enabled = true;
            InitUPS();
            TimerInit();
            DataTimer.Start();
        }
        public static void StopService()
        {
            DataTimer.Stop();
            TimerClose();
            CloseUPS();
            StartUPSManager.Enabled = true;
            StopUPSManager.Enabled = false;
            SettingsUPSManager.Enabled = true;
            ModuleMain.MuteBeeper.Enabled = false;
            ModuleMain.DrainBattery.Enabled = false;
            InfoUPSManager.Enabled = false;
            UPSNotifyIcon1.Visible = false;
            UPSNotifyIcon2.Visible = false;
            UPSNotifyIcon3.Visible = false;
            UPSNotifyIcon4.Visible = false;
            UPSNotifyIcon.Icon = Properties.Resources.OffLine;
            UPSNotifyIcon.Text = "";

        }
        private static NotifyIcon UPSNotifyIcon1 = new NotifyIcon();
        private static NotifyIcon UPSNotifyIcon2 = new NotifyIcon();
        private static NotifyIcon UPSNotifyIcon3 = new NotifyIcon();
        private static NotifyIcon UPSNotifyIcon4 = new NotifyIcon();
        public static void UpDateChargingIcon(double BatteryVoltage, bool OffLine)
        {
            int PercentageBattery = Convert.ToInt32(((BatteryVoltage - UPS_Manager.Properties.Settings.Default.BatteryChargeMin) / ((UPS_Manager.Properties.Settings.Default.BatteryChargeMax-0.1) - UPS_Manager.Properties.Settings.Default.BatteryChargeMin)) * 100);
            if (PercentageBattery <= 100 && !OffLine)
            {
                System.Drawing.Font drawFont = new System.Drawing.Font("Webdings", 70, FontStyle.Regular);
                System.Drawing.Font drawFont1 = new System.Drawing.Font("Webdings", 85, FontStyle.Bold);
                System.Drawing.SolidBrush DrawBrushEmpty = new System.Drawing.SolidBrush(System.Drawing.Color.Transparent);
                System.Drawing.SolidBrush DrawBrushSymbol = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                System.Drawing.SolidBrush DrawBrushSymbol1 = new System.Drawing.SolidBrush(System.Drawing.Color.White);
                System.Drawing.SolidBrush DrawBrushFull = new System.Drawing.SolidBrush(System.Drawing.Color.White);

                Bitmap bitmap = new Bitmap(100, 100); // new Bitmap(100, 100);
                System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);
                System.Drawing.Rectangle DrawRectRed = new Rectangle(0, 100 - PercentageBattery, 100, PercentageBattery);
                System.Drawing.Region DrawRegionRed = new System.Drawing.Region(DrawRectRed);
                graphics.FillRegion(DrawBrushFull, DrawRegionRed);
                System.Drawing.Rectangle DrawRectGreen = new Rectangle(0, 0, 100, 100 - PercentageBattery);
                System.Drawing.Region DrawRegionGreen = new System.Drawing.Region(DrawRectGreen);
                graphics.FillRegion(DrawBrushEmpty, DrawRegionGreen);
                graphics.DrawString("~", drawFont1, DrawBrushSymbol1, -22, -3);
                graphics.DrawString("~", drawFont, DrawBrushSymbol, -8, 0);
                Icon createdIcon = Icon.FromHandle(bitmap.GetHicon());

                UPSNotifyIcon.Icon = createdIcon;
                UPSNotifyIcon.Text = " " + PercentageBattery.ToString() + "%" + System.Environment.NewLine + BatteryVoltage.ToString() + "V";
            }
            else
            {
                UPSNotifyIcon.Icon = Properties.Resources.OnLine;
                UPSNotifyIcon.Text = BatteryVoltage.ToString() + "V";
            }
        }
        public static void UpDateIcons(double BatteryVoltage, bool OffLine, bool Mute, bool TestInProgress)
        {
            if (!TestInProgress)
            {
                if (!ModuleMain.DrainBattery.Enabled)
                {
                    ModuleMain.DrainBattery.Enabled = true;
                }
            }
            else
            {
                if (ModuleMain.DrainBattery.Enabled)
                {
                    ModuleMain.DrainBattery.Enabled = false;
                }
            }


            if (!Mute)
            {
                if (ModuleMain.MuteBeeper.Text != "Enable Beeper")
                {
                    ModuleMain.MuteBeeper.Text = "Enable Beeper";
                }
            }
            else
            {
                if (ModuleMain.MuteBeeper.Text != "Mute Beeper")
                {
                    ModuleMain.MuteBeeper.Text = "Mute Beeper";
                }
            }

            if (OffLine)
            {
                IconCalcPS.PSInfo.GetBatteryPercentage(BatteryVoltage);

                
                string PerSentStr = IconCalcPS.PSInfo.BatteryPercentage.ToString();

                if (IconCalcPS.PSInfo.BatteryPercentage < 100)
                {
                    if (IconCalcPS.PSInfo.BatteryPercentage < 10)
                    {
                        if (IconCalcPS.PSInfo.BatteryPercentage < 1)
                        {
                            PerSentStr = "   ";
                        }
                        else
                        {
                            PerSentStr = "  " + PerSentStr;
                        }
                    }
                    else 
                    {
                        PerSentStr = " " + PerSentStr;
                    }
                }

                System.Drawing.Font drawFont = new System.Drawing.Font("Consolas", 70, FontStyle.Bold);
                System.Drawing.SolidBrush DrawBrushRed = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                System.Drawing.SolidBrush DrawBrushGreen = new System.Drawing.SolidBrush(System.Drawing.Color.Lime);
                System.Drawing.SolidBrush DrawBrushWhite = new System.Drawing.SolidBrush(System.Drawing.Color.White);

                int PercentageBattery1 = IconCalcPS.PSInfo.BatteryPercentage1;
                Bitmap bitmap1 = new Bitmap(100, 100);
                System.Drawing.Graphics graphics1 = System.Drawing.Graphics.FromImage(bitmap1);
                //graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
                System.Drawing.Rectangle DrawRectRed1 = new Rectangle(0, 100 - PercentageBattery1, 100, PercentageBattery1);
                System.Drawing.Region DrawRegionRed1 = new System.Drawing.Region(DrawRectRed1);
                graphics1.FillRegion(DrawBrushGreen, DrawRegionRed1);
                System.Drawing.Rectangle DrawRectGreen1 = new Rectangle(0, 0, 100, 100 - PercentageBattery1);
                System.Drawing.Region DrawRegionGreen1 = new System.Drawing.Region(DrawRectGreen1);
                graphics1.FillRegion(DrawBrushRed, DrawRegionGreen1);
                graphics1.DrawString(PerSentStr[0].ToString(), drawFont, DrawBrushWhite, 4, 1);
                Icon createdIcon1 = Icon.FromHandle(bitmap1.GetHicon());
                UPSNotifyIcon1.Icon = createdIcon1;
                

                int PercentageBattery2 = IconCalcPS.PSInfo.BatteryPercentage2;
                Bitmap bitmap2 = new Bitmap(100, 100);
                System.Drawing.Graphics graphics2 = System.Drawing.Graphics.FromImage(bitmap2);
                //graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
                System.Drawing.Rectangle DrawRectRed2 = new Rectangle(0, 100 - PercentageBattery2, 100, PercentageBattery2);
                System.Drawing.Region DrawRegionRed2 = new System.Drawing.Region(DrawRectRed2);
                graphics2.FillRegion(DrawBrushGreen, DrawRegionRed2);
                System.Drawing.Rectangle DrawRectGreen2 = new Rectangle(0, 0, 100, 100 - PercentageBattery2);
                System.Drawing.Region DrawRegionGreen2 = new System.Drawing.Region(DrawRectGreen2);
                graphics2.FillRegion(DrawBrushRed, DrawRegionGreen2);
                graphics2.DrawString(PerSentStr[1].ToString(), drawFont, DrawBrushWhite, 4, 1);
                Icon createdIcon2 = Icon.FromHandle(bitmap2.GetHicon());
                UPSNotifyIcon2.Icon = createdIcon2;
                

                int PercentageBattery3 = IconCalcPS.PSInfo.BatteryPercentage3;
                Bitmap bitmap3 = new Bitmap(100, 100);
                System.Drawing.Graphics graphics3 = System.Drawing.Graphics.FromImage(bitmap3);
                //graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
                System.Drawing.Rectangle DrawRectRed3 = new Rectangle(0, 100 - PercentageBattery3, 100, PercentageBattery3);
                System.Drawing.Region DrawRegionRed3 = new System.Drawing.Region(DrawRectRed3);
                graphics3.FillRegion(DrawBrushGreen, DrawRegionRed3);
                System.Drawing.Rectangle DrawRectGreen3 = new Rectangle(0, 0, 100, 100 - PercentageBattery3);
                System.Drawing.Region DrawRegionGreen3 = new System.Drawing.Region(DrawRectGreen3);
                graphics3.FillRegion(DrawBrushRed, DrawRegionGreen3);
                graphics3.DrawString(PerSentStr[2].ToString(), drawFont, DrawBrushWhite, 4, 1);
                Icon createdIcon3 = Icon.FromHandle(bitmap3.GetHicon());
                UPSNotifyIcon3.Icon = createdIcon3;
                

                int PercentageBattery4 = IconCalcPS.PSInfo.BatteryPercentage4;
                Bitmap bitmap4 = new Bitmap(100, 100);
                System.Drawing.Graphics graphics4 = System.Drawing.Graphics.FromImage(bitmap4);
                //graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
                System.Drawing.Rectangle DrawRectRed4 = new Rectangle(0, 100 - PercentageBattery4, 100, PercentageBattery4);
                System.Drawing.Region DrawRegionRed4 = new System.Drawing.Region(DrawRectRed4);
                graphics4.FillRegion(DrawBrushGreen, DrawRegionRed4);
                System.Drawing.Rectangle DrawRectGreen4 = new Rectangle(0, 0, 100, 100 - PercentageBattery4);
                System.Drawing.Region DrawRegionGreen4 = new System.Drawing.Region(DrawRectGreen4);
                graphics4.FillRegion(DrawBrushRed, DrawRegionGreen4);
                graphics4.DrawString("%", drawFont, DrawBrushWhite, 0, 2);
                Icon createdIcon4 = Icon.FromHandle(bitmap4.GetHicon());
                UPSNotifyIcon4.Icon = createdIcon4;
                
                
                UPSNotifyIcon4.Visible = true;
                UPSNotifyIcon3.Visible = true;
                UPSNotifyIcon2.Visible = true;
                UPSNotifyIcon1.Visible = true;
                UPSNotifyIcon.Icon = Properties.Resources.UtilityFailed;
                UPSNotifyIcon.Text = "";
                                
            }
            else
            {
                UPSNotifyIcon1.Visible = false;
                UPSNotifyIcon2.Visible = false;
                UPSNotifyIcon3.Visible = false;
                UPSNotifyIcon4.Visible = false;
                UpDateChargingIcon(BatteryVoltage, OffLine);
            }            
        }
    }
}
