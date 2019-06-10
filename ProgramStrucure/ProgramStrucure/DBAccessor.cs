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

        public object ExecuteScalar( String sqlText, Dictionary<String, object> sqlPrameters)
        {            
            dbCon.Open();
            NpgsqlCommand dbAdd = new NpgsqlCommand(sqlText);

            foreach (var item in sqlPrameters)
            {
                dbAdd.Parameters.AddWithValue(item.Key, item.Value);
            }            
            dbAdd.Connection = dbCon;
            object a = dbAdd.ExecuteScalar();
            dbCon.Close();
            return a;
        }
    }
}
