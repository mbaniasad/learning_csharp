using System;

namespace ProgramStructure
{
    class Program
    {
        /// <summary>
        /// static
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Console.ReadLine();
            //GetText firstObj = new GetText();
            //firstObj.PrintText();
            ProgramStrucure.TransactionModel transactionModel = new ProgramStrucure.TransactionModel();
            ProgramStrucure.Transaction transaction = new ProgramStrucure.Transaction("Netto", new Decimal(15.4), new DateTime(2019, 05, 20), ProgramStrucure.CurrencyType.EURO);
            try
            {
                int element = transactionModel.Create(transaction);
                Console.WriteLine(element);
                Console.WriteLine(transaction.To_String());
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);                
            }
            finally
            {
                Console.WriteLine("Finally");
                Console.ReadLine();
            }    
            

            // int entityId = 
        }
    }

}
