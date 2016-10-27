using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MMDB.MovieDatabase.Domain;
using MMDB.MovieDatabase.Services;
using MMDB.MovieDatabase.ValueObjects;


namespace MMDB3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FreeTextSearchService SearchService { get; }
        private MovieService MovieService { get; }
        private CastOrCrewService CastOrCrewService { get; }
        public MainWindow()
        {
            InitializeComponent();
            this.SearchService = new FreeTextSearchService();
            this.MovieService = new MovieService();
            this.CastOrCrewService = new CastOrCrewService();
        }

        private void TBSearchFeild_OnTextChanged(object sender, TextChangedEventArgs e)
        {
          
            LBCastCrewOrMovie.ItemsSource = SearchService.Search(TBSearchFeild.Text, true);
            if (TBSearchFeild.Text == "")
            {
                LBCastCrewOrMovie.ItemsSource = null;
            }
        }



        private void LBCastCrewOrMovie_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearContentHeader();
            var selectedObject = (SearchResultItem)LBCastCrewOrMovie.SelectedItem;
            SPSelectedItemHeader.DataContext = selectedObject;

            if (selectedObject == null)
            {
                SPSelectedItemHeader.DataContext = null;
            }
            else
            {
                SelectedObjectContentBuilder(selectedObject);
            }

        }

        private void SelectedObjectContentBuilder(SearchResultItem selectedObject)
        {
            switch (selectedObject.Type)
            {
                case SearchResultItemType.None:
                    throw new Exception("Invalid Type");
                case SearchResultItemType.Movie:
                    var actors = MovieService.GetActors((Movie)selectedObject.ResultItem);
                    var directors = MovieService.GetDirectors((Movie)selectedObject.ResultItem);
                    MovieHeaderSetter();
                    VisabilitySetterMovies();
                    ActorsContentSetter(actors);
                    DirectorsContentSetter(directors);
                    break;
                case SearchResultItemType.Actor:
                    var actedMovies = CastOrCrewService.GetActedMovies((CastOrCrew)selectedObject.ResultItem);
                    VisabilitySetterActors();
                    ActorHeaderSetter();
                    ActedInContentSetter(actedMovies);
                    break;
                case SearchResultItemType.Director:
                    VisabilitySetterDirectrors();
                    DirectorHeaderSetter();
                    var directedMovies = CastOrCrewService.GetDirectedMovies((CastOrCrew)selectedObject.ResultItem);
                    DirectedInContentSetter(directedMovies);
                    break;
                case SearchResultItemType.ActorDirector:
                    var actedIn = CastOrCrewService.GetActedMovies((CastOrCrew) selectedObject.ResultItem);
                    var directedIn = CastOrCrewService.GetDirectedMovies((CastOrCrew) selectedObject.ResultItem);
                    VisabilitySetterActorsDirectrors();
                    ActedInContentSetter(actedIn);
                    DirectedInContentSetter(directedIn);
                    ActorDirectorHeaderSetter();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }


        }

        private void ActorHeaderSetter()
        {
            TBHeaderActedInActors.Text = "Actor in";
            TBHeaderDirectedInDirectedBy.Text = null;
        }
        private void ActorDirectorHeaderSetter()
        {
            TBHeaderActedInActors.Text = "Actor in";
            TBHeaderDirectedInDirectedBy.Text = "Directed in";
        }
        private void DirectorHeaderSetter()
        {
            TBHeaderDirectedInDirectedBy.Text = "Directed in";
            TBHeaderActedInActors.Text = null;
        }
        private void MovieHeaderSetter()
        {
            TBHeaderActedInActors.Text = "Actors";
            TBHeaderDirectedInDirectedBy.Text = "Directed By";
        }

        private void VisabilitySetterActors()
        {
            TBHeaderActedInActors.Visibility = Visibility.Visible;
            TBContentActedInActors.Visibility=Visibility.Visible;
            TBHeaderDirectedInDirectedBy.Visibility = Visibility.Collapsed;
            TBContentDirectedInDirectedBy.Visibility=Visibility.Collapsed;

        }

        private void VisabilitySetterActorsDirectrors()
        {
            TBHeaderActedInActors.Visibility = Visibility.Visible;
            TBContentActedInActors.Visibility = Visibility.Visible;
            TBHeaderDirectedInDirectedBy.Visibility = Visibility.Visible;
            TBContentDirectedInDirectedBy.Visibility = Visibility.Visible;
        }
        private void VisabilitySetterDirectrors()
        {
            TBHeaderActedInActors.Visibility = Visibility.Collapsed;
            TBContentActedInActors.Visibility = Visibility.Collapsed;
            TBHeaderDirectedInDirectedBy.Visibility = Visibility.Visible;
            TBContentDirectedInDirectedBy.Visibility = Visibility.Visible;
        }
        private void VisabilitySetterMovies()
        {
            TBHeaderActedInActors.Visibility = Visibility.Visible;
            TBContentActedInActors.Visibility = Visibility.Visible;
            TBHeaderDirectedInDirectedBy.Visibility = Visibility.Visible;
            TBContentDirectedInDirectedBy.Visibility = Visibility.Visible;
        }



        private void ActedInContentSetter(IEnumerable<Movie> moives)
        {
            TBContentActedInActors.Text = ContentBuilder(moives);
            
        }
        private void DirectedInContentSetter(IEnumerable<Movie> movies)
        {
            TBContentDirectedInDirectedBy.Text = ContentBuilder(movies);
            
        }
        private void ActorsContentSetter(IEnumerable<CastOrCrew>actors )
        {
            TBContentActedInActors.Text = ContentBuilder(actors);
            
        }
        private void DirectorsContentSetter(IEnumerable<CastOrCrew>directors)
        {
            TBContentDirectedInDirectedBy.Text = ContentBuilder(directors);
            
        }


        private string ContentBuilder(IEnumerable<CastOrCrew> persons)
        {
            return persons.Aggregate("", (current, person) => current + $"{person.Name}\n");
        }
        private string ContentBuilder(IEnumerable<Movie> movies)
        {
            return movies.Aggregate("", (current, movie) => current + $"{movie.Title}\n");
        }

        private void ClearContentHeader()
        {
            TBHeaderActedInActors.Text = null;
            TBHeaderDirectedInDirectedBy.Text = null;
            TBContentActedInActors.Text = null;
            TBContentDirectedInDirectedBy.Text = null;
        }



    }
}
