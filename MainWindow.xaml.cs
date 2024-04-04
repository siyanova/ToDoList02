using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public MainWindow(SqlConnection conn, string id)
        {
            InitializeComponent();
            this.conn = conn;
            this.id = id;
            WriteNickname();
            WriteCategories();
           
        }
        private SqlConnection conn;
        private string id;
        private void WriteNickname()
        {
            SqlCommand comm = new SqlCommand("select FIO from [User] where idUser = "+id,conn);
            SqlDataReader reader = comm.ExecuteReader();
            reader.Read();
            NickName.Text = reader[0].ToString();
            reader.Close();
        }
        private void WriteCategories()
        {
            SqlCommand sqlCommand = new SqlCommand("select name, idIcon from [Section] where idUser= " + id, conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ListSection.Items.Insert(0,CreateButton(reader[1].ToString(), reader[0].ToString()));
            }
            reader.Close();
        } 
        public Grid CreateButton(string idIcon,string NameTask)
        {
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            Image image = new Image();
            image.Source = new BitmapImage(new Uri("image/icon/"+idIcon+".png", UriKind.Relative));
            image.Width = 48;
            image.Height = 43;
            Grid.SetColumn(image, 0);
            grid.Children.Add(image);

            TextBlock textBlock = new TextBlock();
            textBlock.Text = NameTask;
            textBlock.FontSize = 14;
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
            ListSection.Items.Insert(0,CreateButton(section.idIcon, section.name));
        }

        private void ListSection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Stack.Children.Clear();
            string a = ((TextBlock)((Grid)ListSection.SelectedItem).Children[1]).Text;
            SqlCommand comm = new SqlCommand($"select description from Task where idSection = (select id from Section where name = '"+a+"');", conn);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                CheckBox checkbox = new CheckBox();
                checkbox.Content = reader[0];
                checkbox.FontSize = 15;
                Stack.Children.Add(checkbox);
            }
            reader.Close();
        }
    }
}
