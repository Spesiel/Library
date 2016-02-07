using Library.Cache;
using Library.Cache.Objects;
using Library.Resources;
using NReco.VideoConverter;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Works
{
    public static class Treatment
    {
        #region Methods

        /// <summary>
        /// Generate a thumbnail for a specified file
        /// </summary>
        /// <param name="background">The background color that item will have</param>
        /// <param name="pathToFile">The complete path to the file to open</param>
        /// <returns>The generated thumbnail</returns>
        public static Image GenerateThumbnail(Color background, string file)
        {
            Item item = CacheManager.Items[file];
            if (item.Thumbnail == null)
            {
                item = GenerateCacheObjectThumbnail(background, file);

                // Add it to the library
                CacheManager.Items[file] = item;
            }

            return item.Thumbnail;
        }

        private static Item GenerateCacheObjectThumbnail(Color background, String pathToFile)
        {
            Item ans = new Item();
            int targetWidth = 128, targetHeight = 128;

            Image temp = null;

            /// Generate the thumbnail depending on the type of file
            if (pathToFile != null)
            {
                string fileGotten = AtRuntime.Settings.GetFile(pathToFile);

                if (Constants.AllowedExtensionsImages().Any(fileGotten.ToUpperInvariant().EndsWith))
                {
                    using (FileStream fs = new FileStream(fileGotten, FileMode.Open, FileAccess.Read))
                    {
                        using (Image image = Image.FromStream(fs, true, false))
                        {
                            //temp = GenerateThumbnailPhoto(pathToFile);
                            temp = ScaleImage(image, 128, 128);
                            GetExifFromImage(pathToFile, image).ContinueWith(t => Console.WriteLine(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
                        }
                    }
                }
                else
                {
                    using (MemoryStream memStream = new MemoryStream())
                    {
                        FFMpegConverter ffmpeg = new FFMpegConverter();
                        ffmpeg.GetVideoThumbnail(pathToFile, memStream);
                        using (Image image = Image.FromStream(memStream, true, false))
                        {
                            temp = ScaleImage(image, 128, 128);
                        }
                    }
                }
            }

            Image target = new Bitmap(1, 1);
            (target as Bitmap).SetPixel(0, 0, background);
            target = new Bitmap(target, targetWidth, targetHeight);

            using (Graphics g = Graphics.FromImage(target))
            {
                g.Clear(background);
                int x = (targetWidth - temp.Width) / 2;
                int y = (targetHeight - temp.Height) / 2;
                g.DrawImage(temp, x, y);
            }

            ans.Thumbnail = target;

            return ans;
        }

        private static Task<Exif> GetExifFromImage(string file, Image image)
        {
            Exif exif = new Exif();

            Parallel.ForEach(image.PropertyItems, Constants.ParallelOptions,
                current =>
                {
                    var previousPriority = Thread.CurrentThread.Priority;
                    Thread.CurrentThread.Priority = ThreadPriority.Lowest;

                    if (Constants.ExifData.ContainsKey(current.Id))
                    {
                        exif.SetValue(Constants.ExifData[current.Id], current.Value);
                    }

                    //Reset previous priority of the TPL Thread
                    Thread.CurrentThread.Priority = previousPriority;
                });

            exif.HasBeenSet = true;

            Item item = CacheManager.Items[file];
            item.Exif = exif;
            CacheManager.Items[file] = item;

            return Task.FromResult(exif);
        }

        private static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            double ratioX = (double)maxWidth / image.Width;
            double ratioY = (double)maxHeight / image.Height;
            double ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);

            Bitmap newImage = new Bitmap(newWidth, newHeight);

            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }

        #endregion Methods
    }
}
