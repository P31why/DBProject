using System.Text;
using System.Windows;
using Microsoft.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DBProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        event SettingsUpdate SendCurrrentConnection;
        string connectionString = "Server=DESKTOP-CND4IL3;Database=TestBase;Trusted_Connection=True;TrustServerCertificate=True;"; 
        public MainWindow()
        {
            InitializeComponent();
            
        }
        public void UpdateConnection(string text)
        {
            connectionString = text;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow window = new SettingsWindow();
            window.UpdateConnectionString += UpdateConnection;
            SendCurrrentConnection += window.AcceptConnection;
            SendCurrrentConnection?.Invoke(connectionString);
            window.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            statusBar.Content = "Подключение ...";
            TestConnection();
        }
        private async void TestConnection()
        {
            using (SqlConnection connetion = new SqlConnection(connectionString))
            {
                await connetion.OpenAsync();
                statusBar.Content = "Подключение установлено";
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            statusBar.Content = "Подключение ...";
            TestConnection();
        }
    }
}