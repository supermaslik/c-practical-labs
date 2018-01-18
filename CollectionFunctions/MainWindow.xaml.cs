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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CollectionFunctions.Models;
namespace CollectionFunctions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addingUserButton_Click(object sender, RoutedEventArgs e)
        {
            var Window = new AddUserWindow();
            Window.Show();
            this.Hide();
            Window.Closed += ShowUpWindow;
        }





        private void ShowUpWindow(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
