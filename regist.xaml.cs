using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace ToDoList02
{
    /// <summary>
    /// Логика взаимодействия для regist.xaml
    /// </summary>
    public partial class regist : Window
    {
        private SqlConnection conn;
        public regist()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source = 3205EC01; Initial Catalog = ToDoList2; Integrated Security=SSPI;");
            conn.Open();

        }

        private void entry_Click(object sender, RoutedEventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand("select idUser from [User] where login = '" + UserNameLogin.Text + "' and password = '" + UserNamePassword.Text + "';", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                var id = reader[0].ToString();
                reader.Close();
                MainWindow mainWindow = new MainWindow(conn,id);
                mainWindow.Show();
                this.Close();
            }

        }
    }
}
