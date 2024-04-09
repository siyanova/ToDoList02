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

namespace ToDoList02
{
    /// <summary>
    /// Логика взаимодействия для AddCheckBox.xaml
    /// </summary>
    public partial class AddCheckBox : Window
    {
        Delo delo = new Delo(); 
        public AddCheckBox(Delo delo)
        {
            InitializeComponent();
            this.delo = delo;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            delo.Name = Vvod.Text;
            this.Close();
        }
    }
}
