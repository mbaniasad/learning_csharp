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
            Console.WriteLine("Enter the transaction details:");
            // Type, Price, Date(yyyy,mm,dd), Currency[RIAL, EURO (default), USD ]");
            Console.Write("Type: ");
            String tranType = Console.ReadLine();
            Console.Write("Price: ");
            String tranPriceStr = Console.ReadLine();
            decimal tranPriceDbl = Convert.ToDecimal(tranPriceStr);

            ProgramStrucure.CurrencyType tranCurrencyType = (ProgramStrucure.CurrencyType)2;
            Console.Write("Currency[0: RIAL, 1: EURO, 2: USD ]- (Press Enter for the default Value Euro): ");
            String tranCurrStr = Console.ReadLine();            
            if (tranCurrStr != "")
            {
                int tranCurrInt = Convert.ToInt16(tranCurrStr);
                tranCurrencyType = (ProgramStrucure.CurrencyType)tranCurrInt;
            }
            Console.Write("Date(yyyy,mm,dd): ");
            String tranDateStr = Console.ReadLine();
            DateTime tranDateTime = Convert.ToDateTime(tranDateStr);
            Console.WriteLine("--------------Saving to DB-----------------");
            
            ProgramStrucure.Transaction transaction = new ProgramStrucure.Transaction(tranType, tranPriceDbl, tranDateTime, tranCurrencyType);
            try
            {
                int element = transactionModel.Create(transaction);
                Console.WriteLine(element);
                Console.WriteLine(transaction.To_String());
            }
            catch (Exception ex)
            {
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
