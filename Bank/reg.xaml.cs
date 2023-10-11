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
    /// Логика взаимодействия для reg.xaml
    /// </summary>
    public partial class reg : Window
    {
        public reg()
        {
            InitializeComponent();
        }
 
        private void regb_Click(object sender, RoutedEventArgs e)
        {
           
                string sql = "INSERT INTO account VALUES(NULL,@login,@password,@age,0,0)";
                MySqlConnection connection = DB.GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@login", MySqlDbType.VarChar).Value = fiotxt.Text;
                cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = passtxt.Text;
                cmd.Parameters.Add("@age", MySqlDbType.VarChar).Value = agetxt.Text;
            try
            {
                cmd.ExecuteNonQuery();

                Console.WriteLine("Вы зарегистрированы");Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Вы не зарегистрированы. \n" + ex.Message, "error");
                }
                connection.Close();
            
        }
    }
}
