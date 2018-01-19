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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            Text.Text = "";
            foreach (var obj in GlobalObject.userList)
            {
                string textToWrite = string.Format("{0} {1} {2}\n", obj.Name, obj.SName, obj.PhoneNumber);
                Text.Text += textToWrite;
            }
        }
        private void ShowUserList()
        {
            Text.Text = "";
            foreach (var obj in GlobalObject.userList)
            {
                string textToWrite = string.Format("{0} {1} {2}\n", obj.Name, obj.SName, obj.PhoneNumber);
                Text.Text += textToWrite;
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalObject.userList.Count == 0)
                return;
            IOrderedEnumerable<User> Query = null;
            int switchState = Counter.value;
            switch (switchState)
            {
                case 0: Query = GlobalObject.userList.OrderBy(x => x.Name);
                    break;
                case 1: Query = GlobalObject.userList.OrderBy(x => x.PhoneNumber);
                    break;
                case 2:
                    Query = GlobalObject.userList.OrderBy(x => x.SName);
                    break;
                default: ShowUserList(); return;
            }
            Counter.IncreaseValue();

            GlobalObject.userList = Query.ToList();
            ShowUserList();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            var Window = new DeleteUserWindow();
            Window.Show();
            this.Hide();
            Window.Closed += ShowUpWindow;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            var Window = new SerchUserWindow();
            Window.Show();
            this.Hide();
            Window.Closed += ShowUpWindow;
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, GlobalObject.userList);
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                GlobalObject.userList = (List<User>)formatter.Deserialize(fs);

            }
        }
    }
}
