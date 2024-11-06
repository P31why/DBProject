using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace DBProject
{
    /// <summary>
    /// Логика взаимодействия для ChooseParametrWindow.xaml
    /// </summary>
    public delegate void SendListValue(int value);
    public partial class ChooseParametrWindow : Window
    {
        string connectionStr;
        public event SendListValue SendJobTitle;
        public ChooseParametrWindow(string connectionStr)
        {
            this.connectionStr = connectionStr;
            InitializeComponent();
            InitJobTitles();
        }
        private void InitJobTitles()
        {
            string query = "SELECT jobID, jobName FROM JobTitles";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connectionStr);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    jobList.ItemsSource = ds.Tables[0].DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ChooseJobTitle_Click(object sender, RoutedEventArgs e)
        {
            SendJobTitle?.Invoke((int)jobList.SelectedValue);
        }
    }
}
