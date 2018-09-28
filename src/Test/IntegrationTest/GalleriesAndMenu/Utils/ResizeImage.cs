using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace AddinX.Ribbon.IntegrationTest.GalleriesAndMenu.Utils
{
    public class ResizeImage
    {
        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Image Resize(Image image, int width, int height) {

            return (Image) image.GetThumbnailImage(width, height, null, IntPtr.Zero);
        }
    }
}