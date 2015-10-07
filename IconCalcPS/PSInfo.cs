using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IconCalcPS
{
    public class BRange
    {
        public double BatteryRangeMax = 0;
        public double BatteryRangeMin = 0;
    }
    public static class PSInfo
    {
        public static double BatteryMax = 0;
        public static double BatteryMin = 0;
        public static BRange BatteryRange = new BRange {BatteryRangeMax = 0, BatteryRangeMin = 0 };
        public static double BatteryStep = 0;
        public static BRange BatteryRange1 = new BRange { BatteryRangeMax = 0, BatteryRangeMin = 0 };
        public static BRange BatteryRange2 = new BRange { BatteryRangeMax = 0, BatteryRangeMin = 0 };
        public static BRange BatteryRange3 = new BRange { BatteryRangeMax = 0, BatteryRangeMin = 0 };
        public static BRange BatteryRange4 = new BRange { BatteryRangeMax = 0, BatteryRangeMin = 0 };
        public static double BatteryXFactor = 0;
        public static int BatteryPercentage = 0;
        public static int BatteryPercentage1 = 0;
        public static int BatteryPercentage2 = 0;
        public static int BatteryPercentage3 = 0;
        public static int BatteryPercentage4 = 0;

        public static void CalcPS(double BMax, double BMin)
        {
            BatteryMax = BMax;
            BatteryMin = BMin;
            BatteryRange.BatteryRangeMax = BMax - BMin;
            BatteryRange.BatteryRangeMin = 0;
            BatteryStep = BatteryRange.BatteryRangeMax / 4.0;
            BatteryRange1.BatteryRangeMax = BatteryRange.BatteryRangeMax;
            BatteryRange1.BatteryRangeMin = BatteryRange.BatteryRangeMax - BatteryStep;
            BatteryRange2.BatteryRangeMax = BatteryRange1.BatteryRangeMin;
            BatteryRange2.BatteryRangeMin = BatteryRange1.BatteryRangeMin - BatteryStep;
            BatteryRange3.BatteryRangeMax = BatteryRange2.BatteryRangeMin;
            BatteryRange3.BatteryRangeMin = BatteryRange2.BatteryRangeMin - BatteryStep;
            BatteryRange4.BatteryRangeMax = BatteryRange3.BatteryRangeMin;
            BatteryRange4.BatteryRangeMin = BatteryRange3.BatteryRangeMin - BatteryStep;
            BatteryXFactor = 100 / BatteryStep;
       }

        public static void GetBatteryPercentage(double BatteryVoltage)
        {
            BatteryPercentage = Convert.ToInt32(((BatteryVoltage - BatteryMin) * (100 / BatteryRange.BatteryRangeMax)));
           //////////////////////////////////////// gia na mhn pigenei panw apo 100%
            if (BatteryPercentage > 100)
            {
                BatteryPercentage = 100;
            }
            ///////////////////////////////////////

            if (BatteryVoltage - BatteryMin > BatteryRange1.BatteryRangeMax)
            {
                BatteryPercentage1 = 100;
                BatteryPercentage2 = 100;
                BatteryPercentage3 = 100;
                BatteryPercentage4 = 100;
            }
            else
            {
                if (BatteryVoltage - BatteryMin > BatteryRange2.BatteryRangeMax)
                {
                    BatteryPercentage1 = Convert.ToInt32((BatteryVoltage - BatteryMin - BatteryRange1.BatteryRangeMin) * BatteryXFactor);
                    BatteryPercentage2 = 100;
                    BatteryPercentage3 = 100;
                    BatteryPercentage4 = 100;
                }
                else
                {
                    if (BatteryVoltage - BatteryMin > BatteryRange3.BatteryRangeMax)
                    {
                        BatteryPercentage1 = 0;
                        BatteryPercentage2 = Convert.ToInt32((BatteryVoltage - BatteryMin - BatteryRange2.BatteryRangeMin) * BatteryXFactor);
                        BatteryPercentage3 = 100;
                        BatteryPercentage4 = 100;
                    }
                    else
                    {
                        if (BatteryVoltage - BatteryMin > BatteryRange4.BatteryRangeMax)
                        {
                            BatteryPercentage1 = 0;
                            BatteryPercentage2 = 0;
                            BatteryPercentage3 = Convert.ToInt32((BatteryVoltage - BatteryMin - BatteryRange3.BatteryRangeMin) * BatteryXFactor);
                            BatteryPercentage4 = 100;
                        }
                        else
                        { 
                            BatteryPercentage1 = 0;
                            BatteryPercentage2 = 0;
                            BatteryPercentage3 = 0;
                            BatteryPercentage4 = Convert.ToInt32((BatteryVoltage - BatteryMin - BatteryRange4.BatteryRangeMin) * BatteryXFactor);
                        }
                    }
                }
            
            }
        }

    }
}
