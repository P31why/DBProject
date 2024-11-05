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
    /// Логика взаимодействия для JodTitleWin.xaml
    /// </summary>
    public partial class JodTitleWin : Window
    {
        string connectionStr;
        public JodTitleWin(string connectionStr)
        {
            this.connectionStr = connectionStr;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddNewJobTitle_Click(object sender, RoutedEventArgs e)
        {
            string sqlquery = "AddNewJobTitle";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlquery,connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("jobname", TitleText.Text);
                    command.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
