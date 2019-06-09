using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using System.Data.SqlClient;


namespace ProgramStrucure
{
    public class TransactionModel : Ideleteable
    {

        public int Create(Transaction entity)
        {
            // throw new NotImplementedException();
            // TODO: Save to DB

            NpgsqlConnection dbCon = new NpgsqlConnection("Server=192.168.0.252;" +
                "Port=5432;" +
                "Database=home_fin;" +
                "User ID=postgres;" +
                "Password=;");
            dbCon.Open();
            NpgsqlCommand dbAdd = new NpgsqlCommand(@"INSERT INTO entities.transactions
            (category, value, date_time, currency_type)
            VALUES(:category, :value, :date_time, :currency_type) returning id");
            dbAdd.Parameters.AddWithValue("category", entity.type);
            dbAdd.Parameters.AddWithValue("value", entity.value);
            dbAdd.Parameters.AddWithValue("date_time", entity.datetime);
            dbAdd.Parameters.AddWithValue("currency_type", entity.currencyType.ToString());
            dbAdd.Connection = dbCon;
            int a = (int) dbAdd.ExecuteScalar();
            dbCon.Close();
            return a;
        }

        public bool Delete(int id)
        {
            // throw new NotImplementedException();
            return true;
        }

        public Transaction Read(int id)
        {
            throw new NotImplementedException();

        }

        public bool Update(Transaction entity)
        {
            // throw new NotImplementedException();
            return true;
        }
    }
}
