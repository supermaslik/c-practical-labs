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

namespace CollectionFunctions
{
    /// <summary>
    /// Interaction logic for DeleteUserWindow.xaml
    /// </summary>
    public partial class DeleteUserWindow : Window
    {
        public DeleteUserWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorTextBox.Text = "";
            if (FnameBox.Text == "")
                ErrorTextBox.Text = "Name is empty";
            else if (SnameBox.Text == "")
                ErrorTextBox.Text = "Second name is empty";
            else
            {
                var selectedUsers = GlobalObject.userList.Where(x => x.Name == FnameBox.Text && x.SName == SnameBox.Text);
                var listOfSelectedUsers = selectedUsers.ToList();
                if (listOfSelectedUsers.Count != 0)
                {
                    foreach (var user in listOfSelectedUsers)
                    {
                        GlobalObject.userList.Remove(user);
                        ErrorTextBox.Text += string.Format("{0} {1} was deleted\n", user.Name, user.SName);
                    }
                    return;
                }
                else
                    ErrorTextBox.Text = "There is no march in query you completed";
            }
        }
    }
}
