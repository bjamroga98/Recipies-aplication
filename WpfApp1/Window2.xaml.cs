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
using System.Windows.Shapes;
using System.Reflection;
using WpfApp1.models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        /// <summary>
        /// Contains link 
        /// </summary>
        private string link;
        /// <summary>
        /// JSON response in C# object
        /// </summary>
        private RootModel rootModel;

        /// <summary>
        /// Main Window method , create top panel
        /// </summary>
        /// <param name="link">Contains link </param>
        /// <param name="rootModel">JSON response in C# object</param>
        public Window2(string link, RootModel rootModel)
        {

            this.link = link;
            this.rootModel = rootModel;
            InitializeComponent();
            InitializeComponent();
            InitializeComponent();
            minimized.Click += (s, e) => WindowState = WindowState.Minimized;
            maximized.Click += (s, e) => WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            close.Click += (s, e) => Close();
            wb.Navigate(link);
            wb.Navigated += (sender, args) => { HideScriptErrors((WebBrowser)sender, true); };

        }
        /// <summary>
        /// Button click lisner, hide current window and oprn window with card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 w = new Window1(rootModel);
            w.Show();
            this.Close();
        }

        /// <summary>
        /// Method Hide errors in browser Internet Explorer
        /// </summary>
        /// <param name="wb">Xaml elemet webbrowser</param>
        /// <param name="Hide"></param>
        public void HideScriptErrors(WebBrowser wb, bool Hide)
        {
            FieldInfo fiComWebBrowser = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            if (fiComWebBrowser == null) return;
            object objComWebBrowser = fiComWebBrowser.GetValue(wb);
            if (objComWebBrowser == null) return;
            objComWebBrowser.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, objComWebBrowser, new object[] { Hide });
        }
    }

}
