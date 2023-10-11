using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Bank
{
    internal class DB
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=bank";
            MySqlConnection connection = new MySqlConnection(sql);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("MySQL connection! \n" + ex.Message, "error");
            }
            return connection;
        }
        public static float searchrub(int id)
        {
            bool au = false;
            float rub = 0;
            string sql = "SELECT * FROM account  WHERE ID=@id";
            MySqlConnection connection = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                au = true;
            }
            if (au == true)
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    rub = reader.GetFloat("rub");
                }
            }
            connection.Close();
            return rub;
        }
        public static float searchdol(int id)
        {
            bool au = false;
            float dol = 0;
            string sql = "SELECT * FROM account  WHERE ID=@id";
            MySqlConnection connection = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                au = true;
            }
            if (au == true)
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dol = reader.GetFloat("dol");
                }
            }
            connection.Close();
            return dol;
        }
        public static void updplus(int id, float r1, float d1)
        {
            float rub = searchrub(id);
            float dol = searchdol(id);
            string sql = "UPDATE account SET rub=@rub, dol=@dol WHERE ID=@id";
            MySqlConnection connection = DB.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            float r = r1 + rub, d = d1 + dol;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value =id;
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
        public static void updmin(int id, float r1, float d1)
        {
            float rub = searchrub(id);
            float dol = searchdol(id);
            string sql = "UPDATE account SET rub=@rub, dol=@dol WHERE ID=@id";
            MySqlConnection connection = DB.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            float r = rub - r1, d = dol-d1;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
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
