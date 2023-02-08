using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    internal class ProcessDatabese
    {
        SqlConnection conn;
        string s = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\SOURCE\\C#\\DEMOKTRA\\WindowsFormsApp1\\WindowsFormsApp1\\Database1.mdf;Integrated Security=True";

        public ProcessDatabese()
        {
            conn = new SqlConnection(s);
        }
        private void Connect() // mo ket noi
        {
            if(conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }
        private void Disconnect()  // dong ket noi
        {
            if(conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }
        public DataTable ReadTable(string sql)
        {

            DataTable tb = new DataTable();
            Connect();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(tb);
            Disconnect();
            tb.Dispose();
            return tb;

        }
        public void RunSql(string sql)
        {
            Connect();
            SqlCommand cm = new SqlCommand(sql, conn);
            cm.ExecuteNonQuery();
            Disconnect();
        }
    }
}
