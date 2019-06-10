using System;
using System.Collections.Generic;
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
        }
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

        }
    }
}
