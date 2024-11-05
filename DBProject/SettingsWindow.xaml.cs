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

namespace DBProject
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public delegate void SettingsUpdate(string text);
    public partial class SettingsWindow : Window
    {
        
        public event SettingsUpdate UpdateConnectionString;
        
        public SettingsWindow()
        {
            InitializeComponent();
        }
        public void AcceptConnection(string text)
        {
            textBoxConnection.Text = text;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateConnectionString?.Invoke(textBoxConnection.Text);
        }
    }
}
