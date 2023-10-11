using MySql.Data.MySqlClient;
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

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для SOLAR.xaml
    /// </summary>
    public partial class SOLAR : Window
    {
        public SOLAR()
        {

            InitializeComponent();

            string sql = "SELECT * FROM account";
            MySqlConnection connection = DB.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            datagrid.ItemsSource = dt.DefaultView;
            connection.Close();
            datagrid.CanUserAddRows = false;

        }
    }
}
