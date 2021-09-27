using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteCalisma
{
    class Program
    {
        static string connectionString = @"Data Source=VeritabanininBulunduguDosyaYolu\deneme_db.db;Version=3;";
        static void Main(string[] args)
        {
            VeriYaz("Samet", "Kuşbey", "Frontend Developer");
            Guncelle(7, "Samet", "Kuşbey", "Lazy Developer");
            VeriSil(6);
            VeriOku();
            Console.Read();
        }

        static void VeriYaz(string ad,string soyad,string meslek)
        {
            string query = @"insert into Tbl_User(Ad,Soyad,Meslek) values(@p1,@p2,@p3)";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@p1", ad);
            command.Parameters.AddWithValue("@p2", soyad);
            command.Parameters.AddWithValue("@p3", meslek);

            command.ExecuteNonQuery();

            connection.Close();
        }

        static void Guncelle(int id,string ad,string soyad,string meslek)
        {
            string query = "update Tbl_User set Ad=@p1,Soyad=@p2,Meslek=@p3 where Id=@p4";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(query,connection);
            command.Parameters.AddWithValue("@p1", ad);
            command.Parameters.AddWithValue("@p2", soyad);
            command.Parameters.AddWithValue("@p3", meslek);
            command.Parameters.AddWithValue("@p4", id);

            command.ExecuteNonQuery();

            connection.Close();
        }

        static void VeriOku()
        {
            string query = @"select * from Tbl_User";

            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            SQLiteCommand command = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID:{reader.GetInt32(0)} AD:{reader.GetString(1)} SOYAD:{reader.GetString(2)} MESLEK:{reader.GetString(3)}");
            }

            connection.Close();
        }

        static void VeriSil(int id)
        {
            string query = "delete from Tbl_User where Id=@p1";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@p1", id);

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
