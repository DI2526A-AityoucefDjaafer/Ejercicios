using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace A4._1_MemeMaker
{
    public class StringToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = value as string;
            if (string.IsNullOrWhiteSpace(s))
                return null;

            try
            {
                if (File.Exists(s))
                {
                    var uri = new Uri(Path.GetFullPath(s), UriKind.Absolute);
                    return CreateBitmapFromUri(uri);
                }

                if (Uri.TryCreate(s, UriKind.RelativeOrAbsolute, out var uri2))
                {
                    if (!uri2.IsAbsoluteUri && File.Exists(s))
                        uri2 = new Uri(Path.GetFullPath(s), UriKind.Absolute);

                    return CreateBitmapFromUri(uri2);
                }
            }
            catch
            {
            }

            return null;
        }

        private BitmapImage CreateBitmapFromUri(Uri uri)
        {
            var bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = uri;
            bi.CacheOption = BitmapCacheOption.OnLoad;
            bi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bi.EndInit();
            bi.Freeze();
            return bi;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}