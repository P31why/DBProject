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
using System.Data;

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
                try
                {
                    await connetion.OpenAsync();
                    statusBar.Content = "Подключение установлено";
                }
                catch
                {
                    statusBar.Content = "Подключение отсутствует";
                }
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            statusBar.Content = "Подключение ...";
            TestConnection();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            EmplAdd win = new EmplAdd(connectionString);
            win.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            JodTitleWin win = new JodTitleWin(connectionString);
            win.Show();
        }
        private void ViewEmployeesBase(bool withID)
        {
            string sqlQueryEmpl;
            if (withID)
                sqlQueryEmpl = "select * from ViewEmploeys";
            else 
                sqlQueryEmpl = "select * from ViewEmploeysID";

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlQueryEmpl, connect);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    DataGrid.ItemsSource=ds.Tables[0].DefaultView;
                }
                catch
                {
                    statusBar.Content = "Неудалось выполнить команду";
                }
                
            }
        }

        private void ViewJobTitlesBase(bool withID)
        {
            string sqlQueryJobTitles;
            if (withID)
                sqlQueryJobTitles = "select * from ViewJobTitlesID";
            else
                sqlQueryJobTitles = "select * from ViewJobTitles";
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQueryJobTitles,connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataGrid.ItemsSource = ds.Tables[0].DefaultView;
            }
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            ViewEmployeesBase(true);
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            ViewEmployeesBase(false);
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            ViewJobTitlesBase(false);
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            ViewJobTitlesBase(true);
        }

        private void DeleteEmployee_Click_8(object sender, RoutedEventArgs e)
        {
            DeleteEmplWindow win = new DeleteEmplWindow(connectionString);
            win.Show();
        }

        private void DeleteJobTitle_Click_9(object sender, RoutedEventArgs e)
        {
            DeleteJobTitleWindow win = new DeleteJobTitleWindow(connectionString);
            win.Show();
        }

        private void ChangeEmploye_Click_10(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeJobTitle_Click_11(object sender, RoutedEventArgs e)
        {

        }
    }
}