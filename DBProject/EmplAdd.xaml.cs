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
    /// Логика взаимодействия для EmplAdd.xaml
    /// </summary>
    public partial class EmplAdd : Window
    {
        string connectionStr;
        public EmplAdd(string connectionStr)
        {
            this.connectionStr = connectionStr;
            InitializeComponent();
            InitJobTitles();
        }

        private void InitJobTitles()
        {
            string query = "SELECT jobID, jobName FROM JobTitles";
            using(SqlConnection connection=new SqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connectionStr);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    jobList.ItemsSource = ds.Tables[0].Rows;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void AddNewEmployee(object sender, RoutedEventArgs e)
        {

            string sqlQueryAddEmpl = $"EXEC AddNewEmploye ";
            using (SqlConnection connection=new SqlConnection(connectionStr))
            {
                try
                {
                    SqlCommand addEmpl = new SqlCommand(sqlQueryAddEmpl, connection);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }
    }
}
