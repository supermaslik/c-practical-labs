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
using System.Text.RegularExpressions;
namespace Задание12ПавловскаяWPF
{
    /// <summary>
    /// Interaction logic for TranslateWindow.xaml
    /// </summary>
    public partial class TranslateWindow : Window
    {
        public TranslateWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            HandleProc();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-1]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }
        private void HandleProc()
        {
            if (BinaryTextBox.Text == "")
                return;
            try
            {
                var digit = Convert.ToInt32(BinaryTextBox.Text,2);

                if (_8Mode.IsChecked.Value)
                    ResultBox.Text = Convert.ToString(digit, 8);
                else if (_10Mode.IsChecked.Value)
                    ResultBox.Text = Convert.ToString(digit, 10);
                else if (_16Mode.IsChecked.Value)
                    ResultBox.Text = Convert.ToString(digit, 16);
            }
            catch (System.OverflowException)
            {
                BinaryTextBox.Text = BinaryTextBox.Text.Remove(BinaryTextBox.Text.Length - 1, 1);
            }
        }

        private void _8Mode_Checked(object sender, RoutedEventArgs e)
        {
            HandleProc();
        }

        private void _10Mode_Checked(object sender, RoutedEventArgs e)
        {
            HandleProc();
        }

        private void _16Mode_Checked(object sender, RoutedEventArgs e)
        {
            HandleProc();
        }
    }
}
