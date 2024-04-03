using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Логика взаимодействия для addTask.xaml
    /// </summary>
    public partial class addTask : Window
    {
        Section section;
        public addTask(Section section)
        {
            InitializeComponent();
            this.section = section;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            section.name = NameSection.Text;
            this.Close();
        }
        private void RadioButton_item1(object sender, RoutedEventArgs e)
        {
            section.idIcon = "1";
        }
        private void RadioButton_item2(object sender, RoutedEventArgs e)
        {
            section.idIcon = "2";
        }

        private void RadioButton_item3(object sender, RoutedEventArgs e)
        {
            section.idIcon = "3";
        }
       private void RadioButton_fon1(object sender, RoutedEventArgs e)
       {
            section.idIcon = "4";
       }
        private void RadioButton_fon2(object sender, RoutedEventArgs e)
        {
            section.idIcon = "5";
        }

        private void RadioButton_fon3(object sender, RoutedEventArgs e)
        {
            section.idIcon = "6";
        }
    }
}
