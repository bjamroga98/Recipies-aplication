using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using WpfApp1.ClientAPI;
using WpfApp1.models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Main Window method , create a top panel
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            minimized.Click += (s, e) => WindowState = WindowState.Minimized;
            maximized.Click += (s, e) => WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            close.Click += (s, e) => Close();
        }
        /// <summary>
        /// Button click lisner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            MainWindowControler controler = new MainWindowControler();
            try
            {
               RootModel model = await controler.makeQueryAsync(ingradient.Text, category.Text);

                if (model == null)
                {
                   errorText.Text = "We don't find any recipe with your " + Environment.NewLine + "ingradients , please try again. ";
                   return;
                }

                Window1 w = new Window1(model);
                w.Show();
                this.Close();
            }
            catch(NullReferenceException ex)
            {
                errorText.Text = "Please write your ingradiets";
                return;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        } 
    }
}
