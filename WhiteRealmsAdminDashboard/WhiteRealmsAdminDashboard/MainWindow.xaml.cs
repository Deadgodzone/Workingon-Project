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
using System.IO;
using System.Net;

namespace WhiteRealmsAdminDashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show("This is a test version connected with the Open Realms server and contains a simple login form, currently you can't make your own account. Ill get around this issue soon.");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (new LoadingWindow()).Show();
            CoreClass.TryLogin(UsernameBox.Text, PasswordBox.Password);
            if (CoreClass.isLogin == true)
            {
                CoreClass.shouldCloseLoading = true;
                MessageBox.Show("Connected successfully!");
            }
            else if (CoreClass.isLogin == false)
            {
                CoreClass.shouldCloseLoading = true;
                MessageBox.Show("Error, could not connect!");
            }
        }

        public static async void TryLoginAsync(string username, string password)
        {
            CoreClass.TryLogin(username, password);
        }
    }
}
