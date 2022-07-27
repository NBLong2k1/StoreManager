using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangFinal.Model
{
    class CHAMCONG
    {
        string connectionString;


        public string getConnect()
        {

            var conf = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())

              //             need full path
              .AddJsonFile("appsettings.json", true, true)

              .Build();
            connectionString = conf.GetConnectionString("DbConnection");


            return connectionString;

        }
        public bool insertGioVao(int msnv, DateTime giovao)
        {
            string connectionString = getConnect();

            SqlConnection connection = new SqlConnection(connectionString);

            

            SqlCommand command = new SqlCommand("INSERT INTO CHAMCONG (msnv,giovao)" + "VALUES (@msnv,@gv)", connection);
            command.Parameters.Add("@msnv", SqlDbType.Int).Value = msnv;

            command.Parameters.Add("@gv", SqlDbType.DateTime).Value = giovao;
            connection.Open() ;

            if (command.ExecuteNonQuery() == 1)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }


        }
        public DataTable laydanhsach(SqlCommand command)
        {
            string connectionString = getConnect();

            SqlConnection connection = new SqlConnection(connectionString);

            command.Connection = connection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;

        }
        public bool insertGioRa(int msnv, string hoten, DateTime giora, DateTime giovao, int sogio)
        {
            string connectionString = getConnect();

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand("UPDATE CHAMCONG SET hoten=@ht,giora=@gr,sogio=@sg WHERE giovao=@gv AND msnv=@msnv", connection);
            command.Parameters.Add("@msnv", SqlDbType.Int).Value = msnv;
            command.Parameters.Add("@gr", SqlDbType.DateTime).Value = giora;
            command.Parameters.Add("@gv", SqlDbType.DateTime).Value = giovao;
            command.Parameters.Add("@ht", SqlDbType.NVarChar).Value = hoten;
            command.Parameters.Add("@sg", SqlDbType.Int).Value = sogio;
            connection.Open();

            if (command.ExecuteNonQuery() == 1)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }
    }
}
