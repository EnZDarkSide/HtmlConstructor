using DotNetBrowser.Browser;
using DotNetBrowser.Engine;
using DotNetBrowser.Handlers;
using DotNetBrowser.Navigation.Events;
using System;
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

namespace HtmlConstructor.CustomControl
{
    /// <summary>
    /// Логика взаимодействия с BindableWebBrowser.xaml
    /// </summary>
    public partial class BindableWebBrowser : UserControl
    {
        private const string _SkipSourceChange = "Skip";

        private IBrowser browser;

        public BindableWebBrowser()
        {
            IEngine engine;

            Task.Run(() =>
            {
                engine = EngineFactory.Create(new EngineOptions.Builder
                {
                    LicenseKey = "1BNKDJZJSD0VJG7PNBGLC5BQMFIDWGOHCSSDSSY5VAJEU5U5QZEQFUPV6BMX0MIMB8O2ZD"
                }.Build());
                browser = engine.CreateBrowser();
            }).ContinueWith(t =>
            {
                browserView.InitializeFrom(browser);
                browser.Navigation.LoadUrl($@"file:///{Constants.WwwDirectory}/index.html");
            }, TaskScheduler.FromCurrentSynchronizationContext());

            InitializeComponent();

            InitializeComponent();

            CommandBindings.Add(new CommandBinding(NavigationCommands.BrowseBack, BrowseBack, CanBrowseBack));
            CommandBindings.Add(new CommandBinding(NavigationCommands.BrowseForward, BrowseForward, CanBrowseForward));
            CommandBindings.Add(new CommandBinding(NavigationCommands.Refresh, Refresh, TrueCanExecute));
        }


        public string BindableSource
        {
            get { return (string)GetValue(BindableSourceProperty); }
            set { SetValue(BindableSourceProperty, value); }
        }

        public bool ShouldHandleNavigated
        {
            get { return (bool)GetValue(ShouldHandleNavigatedProperty); }
            set { SetValue(ShouldHandleNavigatedProperty, value); }
        }

        public static readonly DependencyProperty BindableSourceProperty =
                                                        DependencyProperty.RegisterAttached(
                                                                "BindableSource",
                                                                typeof(string),
                                                                typeof(BindableWebBrowser));

        public static readonly DependencyProperty ShouldHandleNavigatedProperty =
                                                        DependencyProperty.RegisterAttached(
                                                                "ShouldHandleNavigated",
                                                                typeof(Boolean),
                                                                typeof(BindableWebBrowser));

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property == BindableSourceProperty)
            {
                BindableSourcePropertyChanged(e);
            }
            else if (e.Property == ShouldHandleNavigatedProperty)
            {
                ShouldHandleNavigatedPropertyChanged(e);
            }
        }

        public void ShouldHandleNavigatedPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (browser != null)
            {
                if ((bool)e.NewValue)
                {
                    browser.Navigation.NavigationFinished += Browser_Navigated;
                }
                else
                {
                    browser.Navigation.NavigationFinished -= Browser_Navigated;
                }
            }
        }

        public void BindableSourcePropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (browser != null)
            {
                string uri = e.NewValue as string;
                if (!_SkipSourceChange.Equals(browser))
                {
                    browser.Navigation.LoadUrl(!string.IsNullOrEmpty(uri) ? uri : null);
                }
            }
        }

        private void Browser_Navigated(object sender, NavigationFinishedEventArgs e)
        {
            WebBrowser browser = sender as WebBrowser;
            if (browser != null)
            {
                if (BindableSource != e.Browser.Url.ToString())
                {
                    browser.Tag = _SkipSourceChange;
                    this.BindableSource = browser.Source.AbsoluteUri;
                    browser.Tag = null;
                }
            }
        }

        private void CanBrowseBack(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = browser.Navigation.CanGoBack();
        }

        private void BrowseBack(object sender, ExecutedRoutedEventArgs e)
        {
            browser.Navigation.GoBack();
        }

        private void CanBrowseForward(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = browser.Navigation.CanGoForward();
        }

        private void BrowseForward(object sender, ExecutedRoutedEventArgs e)
        {
            browser.Navigation.GoForward();
        }

        private void TrueCanExecute(object sender, CanExecuteRoutedEventArgs e) { e.CanExecute = true; }

        private void Refresh(object sender, ExecutedRoutedEventArgs e)
        {
            try { browser.Navigation.Reload(); }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }
    }

}
