using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

namespace MyVideoExplorer
{
    class MyDPI
    {
        private static double dpiX = 0;
        private static double dpiY = 0;

        private static void SetDPIFromGraphics() {
            using (Graphics graphics = Application.OpenForms[0].CreateGraphics())
            {
                dpiX = graphics.DpiX;
                dpiY = graphics.DpiY;
            }
        }

        public static int ScaleDPIDimension(int dimension) {

            if (Application.OpenForms.Count == 0)
            {
                return dimension;
            }

            if (dpiX == 0 || dpiY == 0)
            {
                SetDPIFromGraphics();
            }


            /*

                96 dpi: This baseline matches the default dpi setting.
                120 dpi: 25% larger than baseline.
                144 dpi: 50% larger than baseline.
                192 dpi: 100% larger than baseline.

             */

            double scale = (dpiX - 96) / 96 + 1;
            // double scale = Math.Abs(dpiX - 140) / 140 + 1;
            if (scale < 0.5) {
                scale = 0.5;
            } else if (scale > 2) {
                scale = 2;
            }
            // hokey .. but works from dev of 134 to another pc with 120
            if (scale != 1 && dimension < 20)
            {
                // scale *= 6;
            }

            int scaled = (int)Math.Ceiling(dimension * scale);

            // MyLog.Add("ScaleDPIDimension: scale: " + scale.ToString("0.00") + " orig: " + dimension.ToString() + " new: " + scaled.ToString() + " dpix: " + dpiX.ToString());
            return scaled;
        }
    }
}
