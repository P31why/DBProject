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
    /// Логика взаимодействия для DeleteEmplWindow.xaml
    /// </summary>
    public partial class DeleteEmplWindow : Window
    {
        string connectionStr;
        public DeleteEmplWindow(string connectionStr)
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
        private void DeleteNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (jobList.SelectedValue == null)
            {
                MessageBox.Show("Выберите должность сотрудника");
                return;
            }
            string sqlQueryAddEmpl = "DeleteEmployee";
            int job_title_id = (int)jobList.SelectedValue;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                    SqlCommand addEmpl = new SqlCommand(sqlQueryAddEmpl, connection);
                    addEmpl.CommandType = CommandType.StoredProcedure;
                    addEmpl.Parameters.AddWithValue("@emplSurname", FamText.Text);
                    addEmpl.Parameters.AddWithValue("@emplName", NameText.Text);
                    addEmpl.Parameters.AddWithValue("@jobtitle", job_title_id);
                    addEmpl.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
