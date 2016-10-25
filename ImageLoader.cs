using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MMDB3
{
    public static class ImageLoader
    {
        public static BitmapSource GetActorIconContet()
        {
            Assembly assembly= Assembly.GetExecutingAssembly();
            const string PATH = "MMDB3.Resources.actor.png";

            using (Stream stream = assembly.GetManifestResourceStream(PATH))
            {
                var bitmap= new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = stream;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                return bitmap;
            }
        }
        public static BitmapSource GetActorDirectorIconContet()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            const string PATH = "MMDB3.Resources.actor_director.png";

            using (Stream stream = assembly.GetManifestResourceStream(PATH))
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = stream;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                return bitmap;
            }
        }
        public static BitmapSource GetMovieIconContet()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            const string PATH = "MMDB3.Resources.movie.png";

            using (Stream stream = assembly.GetManifestResourceStream(PATH))
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = stream;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                return bitmap;
            }
        }
        public static BitmapSource GetUnknownIconContet()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            const string PATH = "MMDB3.Resources.unknown.png";

            using (Stream stream = assembly.GetManifestResourceStream(PATH))
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = stream;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                return bitmap;
            }
        }
        public static BitmapSource GetDirectorIconContet()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            const string PATH = "MMDB3.Resources.director.png";

            using (Stream stream = assembly.GetManifestResourceStream(PATH))
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = stream;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                return bitmap;
            }
        }

    }

}
