using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.Drawing.Imaging;
using System.IO;
using SharpImage = SixLabors.ImageSharp.Image;
using DotNetImage = System.Drawing.Image;

namespace SorterExpress
{
    /// <summary>
    /// https://github.com/SixLabors/Samples/issues/15
    /// </summary>
    public static class ImageExtensions
    {
        /// <summary>
        /// Extension method that converts a Image to an byte array
        /// </summary>
        /// <param name="imageIn">The Image to convert</param>
        /// <returns>An byte array containing the JPG format Image</returns>
        public static byte[] ToArray(this SharpImage imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, JpegFormat.Instance);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Extension method that converts a Image to an byte array
        /// </summary>
        /// <param name="imageIn">The Image to convert</param>
        /// <param name="fmt"></param>
        /// <returns>An byte array containing the JPG format Image</returns>
        public static byte[] ToArray(this SharpImage imageIn, IImageFormat fmt)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, fmt);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Extension method that converts a Image to an byte array
        /// </summary>
        /// <param name="imageIn">The Image to convert</param>
        /// <returns>An byte array containing the JPG format Image</returns>
        public static byte[] ToArray(this DotNetImage imageIn)
        {
            return ToArray(imageIn, ImageFormat.Png);
        }

        /// <summary>
        /// Converts the image data into a byte array.
        /// </summary>
        /// <param name="imageIn">The image to convert to an array</param>
        /// <param name="fmt">The format to save the image in</param>
        /// <returns>An array of bytes</returns>
        public static byte[] ToArray(this DotNetImage imageIn, ImageFormat fmt)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, fmt);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Extension method that converts a byte array with JPG data to an Image
        /// </summary>
        /// <param name="byteArrayIn">The byte array with JPG data</param>
        /// <returns>The reconstructed Image</returns>
        public static SharpImage ToImageSharpImage(this byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                var returnImage = SharpImage.Load(ms);
                return returnImage;
            }
        }

        public static DotNetImage ToSystemDrawingImage(this byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                var returnImage = DotNetImage.FromStream(ms);
                return returnImage;
            }
        }
    }
}
