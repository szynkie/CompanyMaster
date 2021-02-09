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
using System.Data.Entity;

namespace CompanyMaster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //CollectionViewSource companiesViewSource;
        

        public MainWindow()
        {
            InitializeComponent();
            //companiesViewSource = ((CollectionViewSource)(FindResource("companiesViewSource")));
            
            //DataContext = this;
        }


        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //System.Windows.Data.CollectionViewSource companiesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("companiesViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // companiesViewSource.Source = [generic data source]
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFr.Content = new SearchPg();
            
        }

        private void HomePg_Click(object sender, RoutedEventArgs e)
        {
            MainFr.Content = new Page3();
        }

        private void AddPg_Click(object sender, RoutedEventArgs e)
        {
            MainFr.Content = new AddPg();
        }
    }
}
