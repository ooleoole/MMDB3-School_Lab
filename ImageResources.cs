using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MMDB3
{
    public static class ImageResources
    {
        public static readonly BitmapSource ActorIcon = ImageLoader.GetActorIconContet();
        public static readonly BitmapSource ActorDirectorIcon = ImageLoader.GetActorDirectorIconContet();
        public static readonly BitmapSource DirectorIcon = ImageLoader.GetDirectorIconContet();
        public static readonly BitmapSource MovieIcon = ImageLoader.GetMovieIconContet();
        public static readonly BitmapSource UnknownIcon = ImageLoader.GetUnknownIconContet();

    }
}
