using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tujen
{
    internal class ScreenInputHandler
    {
        private static Bitmap CaptureScreen(Rectangle bounds)
        {
            Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format64bppArgb);

            using (Graphics graphic = Graphics.FromImage(screenshot))
            {
                graphic.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);
            }

            return screenshot;
        }
    }
}
