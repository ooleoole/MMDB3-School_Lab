using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using MMDB.MovieDatabase.ValueObjects;
using System.Text.RegularExpressions;

namespace MMDB3
{
    public class SearchResultItemStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value==null)
            {
                return null;
            }
            if (value.GetType() == typeof(MovieSearchResultItem)||value.GetType()==typeof(CastOrCrewSearchResultItem))
            {
                var searchResultItem = (SearchResultItem)value;
                switch (searchResultItem.Type)
                {
                    case SearchResultItemType.None:
                        break;
                    case SearchResultItemType.Movie:
                        return Regex.Replace(searchResultItem.ToString(), "\\[.*?:", string.Empty);
                    case SearchResultItemType.Actor:
                        return Regex.Replace(searchResultItem.ToString(), "\\[.*?:", string.Empty);
                    case SearchResultItemType.Director:
                        return Regex.Replace(searchResultItem.ToString(), "\\[.*?:", string.Empty);
                    case SearchResultItemType.ActorDirector:
                        return Regex.Replace(searchResultItem.ToString(), "\\[.*?:", string.Empty);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            throw new Exception("Invalid type");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
