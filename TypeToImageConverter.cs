using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using MMDB.MovieDatabase.ValueObjects;

namespace MMDB3
{
    public class TypeToImageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value == null)
            {
                return null;
            }

            var _value = (SearchResultItem)value;

            switch (_value.Type)
            {
                case SearchResultItemType.Movie:
                    return ImageResources.MovieIcon;
                case SearchResultItemType.Actor:
                    return ImageResources.ActorIcon;
                case SearchResultItemType.Director:
                    return ImageResources.DirectorIcon;
                case SearchResultItemType.ActorDirector:
                    return ImageResources.ActorDirectorIcon;
                case SearchResultItemType.None:
                    return ImageResources.UnknownIcon;
                default:
                    return ImageResources.UnknownIcon;
            }
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
