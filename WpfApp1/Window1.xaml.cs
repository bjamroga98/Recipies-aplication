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
using WpfApp1.models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ///<summary>
        /// JSON response in C# object
        ///</summary>  
        private RootModel rootModel;

        /// <summary>
        /// Button click lisner , open Window with website and close Window with card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Click(object sender, EventArgs e)
        {
            
            Button b = (Button)sender;
            Window2 w = new Window2(b.Tag.ToString(), rootModel);
            w.Show();
            this.Close(); 
        }
        /// <summary>
        /// Main Window method , create a top panel
        /// </summary>
        /// <param name="rootModel">
        /// JSON response in C# object
        /// </param>
        public Window1(RootModel rootModel)
        {
            this.rootModel = rootModel;
            InitializeComponent();
            InitializeComponent();
            minimized.Click += (s, e) => WindowState = WindowState.Minimized;
            maximized.Click += (s, e) => WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            close.Click += (s, e) => Close();
            cardAdapter();
        }
        /// <summary>
        /// Card create method, XAML
        /// </summary>
        public void cardAdapter ()
        {

            foreach (RecipeModel model in rootModel.results)
            {
                // Create Card 
                MaterialDesignThemes.Wpf.Card card = new MaterialDesignThemes.Wpf.Card
                {
                    Width = 200,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(10),
                };

                wrap.Children.Add(card);

                // Create Grid
                Grid grid = new Grid();
                grid.Height = 288;

                RowDefinition row1 = new RowDefinition();
                RowDefinition row2 = new RowDefinition();
                RowDefinition row3 = new RowDefinition();

                row1.Height = new GridLength(140);
                row2.Height = new GridLength(1, GridUnitType.Star);
                row3.Height = new GridLength(1, GridUnitType.Auto);

                grid.RowDefinitions.Add(row1);
                grid.RowDefinitions.Add(row2);
                grid.RowDefinitions.Add(row3);

                card.Content = grid;



                //Create image
                Image image = new Image();
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                if (string.IsNullOrWhiteSpace(model.thumbnail))
                {
                    bitmap.UriSource = new Uri("background.jpg", UriKind.Relative);
                }
                else
                {
                    bitmap.UriSource = new Uri(model.thumbnail, UriKind.Absolute);
                }
                bitmap.EndInit();
                image.Stretch = Stretch.UniformToFill;
                image.Source = bitmap;
                image.Height = 140;

                grid.Children.Add(image);

                // Create Button
                Button button = new Button
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0, 0, 16, -20)
                };
                Style style = this.FindResource("MaterialDesignFloatingActionMiniAccentButton") as Style;
                button.Style = style;
                button.Foreground = new SolidColorBrush(Color.FromRgb(225, 225, 225));
                button.Background = new SolidColorBrush(Color.FromRgb(77, 41, 145));
                button.BorderBrush = new SolidColorBrush(Color.FromRgb(225, 225, 225));
                MaterialDesignThemes.Wpf.PackIcon icon = new MaterialDesignThemes.Wpf.PackIcon();
                icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Food;
                button.Content = icon;
                Grid.SetRow(button, 0);
                grid.Children.Add(button);

                StackPanel stackPanel = new StackPanel();
                stackPanel.Margin = new Thickness(8, 24, 8, 0);

                Grid.SetRow(stackPanel, 1);
                grid.Children.Add(stackPanel);
                TextBlock textBlock1 = new TextBlock
                {
                    FontWeight = FontWeights.Bold,
                    Text = model.title,
                };
                stackPanel.Children.Add(textBlock1);

                TextBlock textBlock2 = new TextBlock
                {
                    Text = model.ingredients,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextWrapping = TextWrapping.Wrap
                };
                stackPanel.Children.Add(textBlock2);


                StackPanel stackPanel2 = new StackPanel
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(8),
                };
                Grid.SetRow(stackPanel2, 2);
                grid.Children.Add(stackPanel2);

                Button buttonMore = new Button();
                Style style2 = this.FindResource("MaterialDesignRaisedButton") as Style;
                buttonMore.Style = style2;
                buttonMore.Height = 35;
                buttonMore.FontSize = 11;
                buttonMore.Content = "See more";
                buttonMore.Click += new RoutedEventHandler(btn_Click);
                buttonMore.Tag = model.href;

                stackPanel2.Children.Add(buttonMore);
            }
        }

        /// <summary>
        /// Button click lisner , close current Window and  open MainWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            this.Close();
        }

    }
}
