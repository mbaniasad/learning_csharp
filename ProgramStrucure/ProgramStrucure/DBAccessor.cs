using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Npgsql;

namespace ProgramStrucure
{
    class DBAccessor
    {
        private NpgsqlConnection dbCon = new NpgsqlConnection("Server=192.168.0.252;" +
                "Port=5432;" +
                "Database=home_fin;" +
                "User ID=postgres;" +
                "Password=mopostgres6687;");

        public object ExecuteScalar(String sqlText, Dictionary<String, object> sqlParam)
        {
            try
            {
                dbCon.Open();
                NpgsqlCommand dbAdd = new NpgsqlCommand(sqlText);

                foreach (var item in sqlParam)
                {
                    dbAdd.Parameters.AddWithValue(item.Key, item.Value);
                }
                dbAdd.Connection = dbCon;
                object r = dbAdd.ExecuteScalar();
                return r;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dbCon.Close();
            }
        }// End ExecuteScalar - Create
        public object ExeNoneQuery(String sqlText, Dictionary<String, object> sqlParam)
        {
            try
            {
                dbCon.Open();
                NpgsqlCommand dbAdd = new NpgsqlCommand(sqlText);
                foreach (var item in sqlParam)
                {
                    dbAdd.Parameters.AddWithValue(item.Key, item.Value);
                }
                dbAdd.Connection = dbCon;
                object r = dbAdd.ExecuteNonQuery();
                return r;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbCon.Close();
            }

        } // ENd ExeNoneQuery - Delete
        public DataTable ExeRead(String sqlText, Dictionary<String, object> sqlParam)
        {
            try
            {
                dbCon.Open();
                NpgsqlCommand dbRead = new NpgsqlCommand(sqlText);
                foreach (var item in sqlParam)
                {
                    dbRead.Parameters.AddWithValue(item.Key, item.Value);
                }
                dbRead.Connection = dbCon;
                var r = dbRead.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(r);
                return dataTable;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dbCon.Close();
            }
        }// ENd ExeRead - Read
    }//End Class DBAccessor
}
