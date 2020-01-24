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

            if (checkTextBoxIsEmpty())
                return;
                
            NetworkService.InitializeClient();
            string pattern = "[,. /]";
            string resultLine = Regex.Replace(ingradient.Text.ToString().Trim(), pattern, ",");
            RootModel model = await LoadData(resultLine, category.Text);

            if (checkResultContent(model))
                return;

            Window1 w = new Window1(model);
            w.Show();
            this.Close();
        }
        /// <summary>
        /// Load data 
        /// </summary>
        /// <param name="ingradients">
        /// contains ingradient parameter
        /// </param>
        /// <param name="category">
        /// contains ingradient category
        /// </param>
        /// <returns></returns>
        private static async Task<RootModel> LoadData(string ingradients, string category)
        {
            RootModel rootModel = await NetworkAsync.getJSON(ingradients, category);
            return rootModel;
        }

        /// <summary>
        /// validation result content in TextBox
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private Boolean checkResultContent(RootModel model)
        {
            if (model.results.Count != 0)
                return false;

            errorText.Text = "We don't find any recipe with your " + Environment.NewLine + "ingradients , please try again. "; 
            return true;
        }
        /// <summary>
        /// validation result in TextBox 
        /// </summary>
        /// <returns> if TextBox is empty return false </returns>
        private Boolean checkTextBoxIsEmpty ()
        {
            if (string.IsNullOrWhiteSpace(ingradient.Text) && string.IsNullOrWhiteSpace(category.Text))
            {
                errorText.Text = "Please wrire your ingradiets";
                return true;
            }
            return false;
        }

    }
}
