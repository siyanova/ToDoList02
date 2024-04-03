using System;
using System.Collections.Generic;
using System.Dynamic;
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

namespace ToDoList02
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public Grid CreateButton(string idIcon, string nameTask)
        {
            Grid grid = new Grid();
            ColumnDefinition columnDefinition = new ColumnDefinition();
            grid.ColumnDefinitions.Add(columnDefinition);

            ColumnDefinition columnDefinition1 = new ColumnDefinition();
            columnDefinition1.Width = new GridLength(4, GridUnitType.Star);
            grid.ColumnDefinitions.Add(columnDefinition1);

            Image image = new Image();
            image.Source = new BitmapImage(new Uri("/image/fon/" + idIcon + ".jpg", UriKind.Relative));
            image.Width = 40;
            image.Height = 40;
            Grid.SetColumn(image, 0);
            grid.Children.Add(image);

            TextBlock textBlock = new TextBlock();
            textBlock.Text = nameTask;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetColumn(textBlock, 1);
            grid.Children.Add(textBlock);
            return grid;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Section section = new Section();
            addTask window = new addTask(section);
            window.ShowDialog();

        }
    }
}
