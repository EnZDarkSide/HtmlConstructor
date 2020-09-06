﻿using System;
using System.Collections.Generic;
using System.IO;
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

namespace HtmlConstructor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Uri URI
        {
            get => Browser.Source;
            set => Browser.Source = value;
        }

 
        public MainWindow()
        {
            InitializeComponent();

            var defaultDirectory = Directory.GetCurrentDirectory() + "\\www\\index.html";

            URI = new Uri(defaultDirectory);
        }

        private void ElementsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}