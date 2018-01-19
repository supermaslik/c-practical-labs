using CollectionFunctions.Models;
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
using CollectionFunctions.Models;


namespace CollectionFunctions
{

    /// <summary>
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorTextBox.Text = "";
            User newUser = new User();
            newUser.Name = FnameBox.Text;
            newUser.SName = SnameBox.Text;
            newUser.PhoneNumber = PNumberBox.Text;
            if (!GlobalFunctions.IsNotEmpty(newUser.Name))
                ErrorTextBox.Text += "Empty Name";
            else if (!GlobalFunctions.IsNotEmpty(newUser.SName))
                ErrorTextBox.Text += "Empty SName";
            else if (!GlobalFunctions.IsNotEmpty(newUser.PhoneNumber))
                ErrorTextBox.Text += "Phone number is not march";
            else
            {
                GlobalObject.userList.Add(newUser);
            }
        }
    }
}
