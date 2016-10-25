using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MMDB3
{
    public static class ImageResources
    {
        public static readonly BitmapImage ActorIcon = new BitmapImage(new Uri("C:\\Users\\Ola\\Documents\\Visual Studio 2015\\Projects\\MMDB3\\Resources\\actor.png"));
        public static readonly BitmapImage ActorDirectorIcon = new BitmapImage(new Uri("C:\\Users\\Ola\\Documents\\Visual Studio 2015\\Projects\\MMDB3\\Resources\\actor_director.png"));
        public static readonly BitmapImage DirectorIcon = new BitmapImage(new Uri("C:\\Users\\Ola\\Documents\\Visual Studio 2015\\Projects\\MMDB3\\Resources\\director.png"));
        public static readonly BitmapImage MovieIcon = new BitmapImage(new Uri("C:\\Users\\Ola\\Documents\\Visual Studio 2015\\Projects\\MMDB3\\Resources\\movie.png"));
        public static readonly BitmapImage UnknownIcon = new BitmapImage(new Uri("C:\\Users\\Ola\\Documents\\Visual Studio 2015\\Projects\\MMDB3\\Resources\\unknown.png"));

    }
}
