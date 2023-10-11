using MySql.Data.MySqlClient;
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
using MySql.Data.MySqlClient;
using System.Data;

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для auth.xaml
    /// </summary>
    /// 
    public partial class authreg : Window
    {
        public static bool au = false;
        public static string log,age,id;
        public static float rub, dol;


        public authreg()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SOLAR Window;
            SOLAR solar = new SOLAR();
            solar.ShowDialog();
        }

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("1");
            string sql = "SELECT * FROM account  WHERE login=@login and pass=@password";
            MySqlConnection connection = DB.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@login", MySqlDbType.VarChar).Value = login.Text;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password.Text;
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                au = true;
            }
            if (au == true) { Console.WriteLine("вы успешно вошли");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    log = reader.GetString("login");
                    age = reader.GetString("age");
                    rub = reader.GetFloat("rub");
                    dol = reader.GetFloat("dol");
                    id = reader.GetString("ID");
                    Console.WriteLine(rub);
                }
                Close(); 
            }
            else { Console.WriteLine("вы не вошли"); }
            connection.Close();
        }



        private void reg_Click(object sender, RoutedEventArgs e)
        {
            reg Window;
            reg registr = new reg();
            registr.ShowDialog();
        }
    }
}
