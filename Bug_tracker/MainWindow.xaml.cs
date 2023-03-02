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
using MySql.Data.MySqlClient;

namespace Bug_tracker
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

        private string title, sql;
        private DateTime date;
        private Connection conn = new Connection();
        private MySqlCommand command;
        private void ButtonAddBug_Click(object sender, RoutedEventArgs e)
        {
            title = bugName.Text;
            date = DateTime.Now;
            if (!string.IsNullOrWhiteSpace(bugName.Text) && !bugList.Items.Contains(bugName.Text))
            {
                //bugList.Items.Add(new BugItem() { Title = bugName.Text, Date = DateTime.Now }); 
                sql = "INSERT INTO bugs (Title, Date) VALUES ('" + title + "',STR_TO_DATE('" + DateTime.Now.ToString("MM/dd/yyyy") + "', '%d/%m/%Y'))";
                if(conn.OpenConnection() == true)
                {
                    try
                    {
                        command = new MySqlCommand(sql, conn.GetConnection());
                        object a = command.ExecuteScalar();
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
            }
        }

        public class BugItem
        {
            public string Title { get; set; }
            public DateTime Date { get; set; }
        }
    }
}
