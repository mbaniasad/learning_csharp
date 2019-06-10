using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;


namespace ProgramStrucure
{
    public class TransactionModel : Ideleteable
    {

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
            DBAccessor dbInsert = new DBAccessor();
            object dbReturn = dbInsert.ExecuteScalar(@"INSERT INTO entities.transactions
            (category, value, date_time, currency_type)
            VALUES(:category, :value, :date_time, :currency_type) returning id", sqlPrameter);            

            return (int)dbReturn;
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
