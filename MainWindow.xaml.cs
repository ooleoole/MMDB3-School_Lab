﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MMDB.MovieDatabase.Services;
using MMDB.MovieDatabase.ValueObjects;


namespace MMDB3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FreeTextSearchService SearchService { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            SearchService = new FreeTextSearchService();
           

        }

        private void TBSearchFeild_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            LBCastCrewOrMovie.ItemsSource = SearchService.Search(TBSearchFeild.Text,true);
            if (TBSearchFeild.Text=="")
            {
                LBCastCrewOrMovie.ItemsSource = null;
            }
        }

       

        private void LBCastCrewOrMovie_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var test = LBCastCrewOrMovie.SelectedItem;
        }
    }
}
