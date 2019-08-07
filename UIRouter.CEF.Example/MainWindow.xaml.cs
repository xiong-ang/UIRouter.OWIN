using CefSharp;
using CefSharp.Wpf;
using Microsoft.Owin.Hosting;
using System.Windows;
using System.Windows.Input;

namespace UIRouter.CEF.Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ChromiumWebBrowser _cef;
        public MainWindow()
        {
            InitializeComponent();
            _cef = Cef;

            WebApp.Start<Startup>("http://localhost:12345");


            _cef.Address = @"http://localhost:12345/ui";
            _cef.RequestHandler = new MyRequestHandler();


            KeyDown += MainWindow_KeyDown;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.F12)
            {
                _cef?.ShowDevTools();
            }
        }
    }
}
