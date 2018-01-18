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

namespace Задание12ПавловскаяWPF
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

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            var Window = new AboutWindow();
            Window.Show();
            this.Hide();
            Window.Closed += ShowUpWindow;
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void TranslateButton_Click(object sender, RoutedEventArgs e)
        {
            var Window = new TranslateWindow();
            Window.Show();
            this.Hide();
            Window.Closed += ShowUpWindow;
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            var Window = new HelpWindow();
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
