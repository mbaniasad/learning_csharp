using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Npgsql;


namespace ProgramStrucure
{
    public class TransactionModel : Ideleteable
    {
        DBAccessor dbAccess = new DBAccessor();
        public int Create(Transaction entity)
        {
            // throw new NotImplementedException();    

            var sqlPrameter = new Dictionary<String, object>
            {
                { "category", entity.type },
                { "value", entity.value },
                { "date_time", entity.datetime },
                { "currency_type", entity.currencyType.ToString() }
            };
            // sqlPrameter.Add("category", "sd");
            // DBAccessor dbInsert = new DBAccessor();
            object dbReturn = dbAccess.ExecuteScalar(@"INSERT INTO entities.transactions
            (category, value, date_time, currency_type)
            VALUES(:category, :value, :date_time, :currency_type) returning id", sqlPrameter);            

            return (int)dbReturn;
        }

        public int Delete(int id)
        {
            var sqlPrameter = new Dictionary<String, object>
            {
                { "id", id}
            };
            // throw new NotImplementedException();
            object dbReturn = dbAccess.ExeNoneQuery(@"DELETE FROM entities.transactions
            WHERE id = :id", sqlPrameter);
            
            return (int)dbReturn;
        }

        public Transaction Read(int id)
        {
            var sqlPrameter = new Dictionary<String, object>
            {
                { "id", id}
            };
            DataTable dbReturn = dbAccess.ExeRead(@"select * from entities.transactions where id = :id",
                sqlPrameter);
            if (dbReturn != null && dbReturn.Rows.Count >0)
            {
                DataRow row = dbReturn.Rows[0];
                //int tranid = row["id"].ToString();
                Transaction readTransaction = new Transaction(
                    row["category"].ToString(), 
                    Convert.ToDecimal(row["value"]), 
                    Convert.ToDateTime(row["date_time"]), 
                    (CurrencyType) Enum.Parse(typeof(CurrencyType), row["currency_type"].ToString())
                    );
                return readTransaction;

            }
            return null;
            
            //throw new NotImplementedException();

        }

        public bool Update(Transaction entity)
        {
            // throw new NotImplementedException();
            return true;
        }
    }
}
