using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace Tujen.Bot
{
    public static class PixelBot
    {
        private const int RECTANGLE_HEIGHT= 18;
        private const int RECTANGLE_WIDTH = 150;
        private const string HANGLE_STRIP_BMP_PATH = @"C:\Users\pusca\source\repos\Tujen\Tujen\Bot\Src\RedHangleStrip.bmp";
        private const int COLLOR_THRESHHOLD = 120; // Adjust this value to handle color differences
        private static Bitmap GameScreenBitmap()
        { 
            // Define the rectangular area to be captured (800x632)
            Rectangle rect = new Rectangle(140, 468, RECTANGLE_WIDTH, RECTANGLE_HEIGHT);

            // Get a reference to the primary screen
            var screen = Screen.PrimaryScreen;

            // Get the bounds of the screen
            var bounds = screen.Bounds;

            // Create a bitmap of the screen
            using (var bitmap = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format64bppArgb))
            {
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                    // Copy the screen to the bitmap
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);

                    // Select the specified rectangular area from the bitmap
                    return bitmap.Clone(rect, bitmap.PixelFormat);
                }
            }
        }
        //public static int CheckPixelFormatSize(string filePath)
        //{
        //    Bitmap bitmap = new Bitmap(filePath);
        //    int size = Image.GetPixelFormatSize(bitmap.PixelFormat);

        //    return size;
        //}
        private static Bitmap LoadBitmapFromFile(string filePath)
        {
            return new Bitmap(filePath);
        }
        private static bool IsMatch(Bitmap source, Bitmap search, int x, int y, int threshold)
        {
            for (int i = 0; i < search.Width; i++)
            {
                for (int j = 0; j < search.Height; j++)
                {
                    // Compare the color difference between the pixels in both images
                    System.Drawing.Color sourcePixel = source.GetPixel(x + i, y + j);
                    System.Drawing.Color searchPixel = search.GetPixel(i, j);
                    int deltaR = Math.Abs(sourcePixel.R - searchPixel.R);
                    int deltaG = Math.Abs(sourcePixel.G - searchPixel.G);
                    int deltaB = Math.Abs(sourcePixel.B - searchPixel.B);
                    if (deltaR + deltaG + deltaB > threshold)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool ContainsImage()
        {
            var source = GameScreenBitmap();
            var search = LoadBitmapFromFile(HANGLE_STRIP_BMP_PATH);

            // Check that the search image is smaller than the source image
            if (search.Width > source.Width || search.Height > source.Height)
                throw new ArgumentException("Search image must be smaller than the source image");

                                // Loop through each pixel in the source image
            for (int x = 0; x <= source.Width - search.Width; x++)
            {
                for (int y = 0; y <= source.Height - search.Height; y++)
                {
                    // Check if the search image matches the current position in the source image
                    if (IsMatch(source, search, x, y, COLLOR_THRESHHOLD))
                    {
                        Console.WriteLine("RedBar contain true");
                        return true;
                    }
                }
            }
            Console.WriteLine("Contains RedBar false");
            return false;
        }
        //private static void BitmapToJpg(Bitmap sourceBitmap, string outputFilePath)
        //{
        //    sourceBitmap.Save(outputFilePath, ImageFormat.Jpeg);
        //}

    }
}
