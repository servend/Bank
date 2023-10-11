using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Ocsp;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
        
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        public  void upd()
        {
            string sql = "SELECT * FROM account  WHERE ID=@id ";
            MySqlConnection connection = DB.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = ID.Content;
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {    
                rub.Content = reader.GetFloat("rub");
                dol.Content = reader.GetFloat("dol");
            }
            connection.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void main_Initialized(object sender, EventArgs e)
        {
            this.ShowInTaskbar= false;
            authreg Window;
            authreg author = new authreg();
            author.ShowDialog();
            if (authreg.au == false)
            {
                Close();
            }
            else
            {
                login.Content = authreg.log.ToString();
                age.Content = authreg.age.ToString();
                rub.Content = authreg.rub.ToString();
                dol.Content = authreg.dol.ToString();
                ID.Content = authreg.id.ToString();
                main.ShowInTaskbar = true;
            }
            
        }

        private void money_Click(object sender, RoutedEventArgs e)
        {
            money Window;
            money mon = new money();
            Console.WriteLine(authreg.age.ToString());
            if (Convert.ToInt16(authreg.age.ToString()) < 18) { MessageBox.Show("Вам нет 18 лет"); }
            else { mon.ShowDialog(); }
            upd();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (rubtxt.Text == "") { rubtxt.Text = "0"; }
            if (doltxt.Text == "") { doltxt.Text = "0"; }
            if (idtxt.Text == "")
            {
                MessageBox.Show("Напишите ID");
            }
                bool test = rubtxt.Text.All(char.IsDigit);
            if (test == false)
            {
                MessageBox.Show("Некорректная сумма в рублях");
                return;
            }
             test = doltxt.Text.All(char.IsDigit);
            if (test == false)
            {
                MessageBox.Show("Некорректная сумма в долларах");
                return;
            }
            if (Convert.ToInt16(authreg.age.ToString()) < 17) { MessageBox.Show("Вам нет 18 лет"); }
            else if(Convert.ToInt16(rubtxt.Text)<=0){ MessageBox.Show("Некорректное число"); }
            else
            {
                DB.updplus(Convert.ToInt16(idtxt.Text), Convert.ToInt16(rubtxt.Text), Convert.ToInt16(doltxt.Text));
                DB.updmin(Convert.ToInt16(authreg.id.ToString()), Convert.ToInt16(rubtxt.Text), Convert.ToInt16(doltxt.Text));
                upd();
            }
        }
    }
    
}

