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
    /// Логика взаимодействия для money.xaml
    /// </summary>
    public partial class money : Window
    {
        public money()
        {
            InitializeComponent();
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            string sql = "UPDATE account SET rub=@rub, dol=@dol WHERE ID=@id";
            MySqlConnection connection = DB.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            float r= (float.Parse(rubtxt.Text) + authreg.rub), d= float.Parse(doltxt.Text) + authreg.dol;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = authreg.id.ToString();
            cmd.Parameters.Add("@rub", MySqlDbType.Float).Value = Convert.ToString(r);
            cmd.Parameters.Add("@dol", MySqlDbType.Float).Value = Convert.ToString(d);
            Console.WriteLine(r);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Участник обновлен.", "Информация");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Участник не обновлен. \n" + ex.Message, "error");
            }
            connection.Close();
        }
    }
    }

