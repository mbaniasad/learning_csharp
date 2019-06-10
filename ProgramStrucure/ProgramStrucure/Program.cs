using System;

namespace ProgramStructure
{
    class Program
    {
        ProgramStrucure.TransactionModel transactionModel = new ProgramStrucure.TransactionModel();
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
            Program program = new Program();
            Console.Write("Select a Function= C: Create, R: Read, U: Update, D: Delete: ");
            String sqlFunc = Console.ReadLine();
            switch (sqlFunc)
            {
                case "C":
                case "c":
                    program.CreateTransaction();
                    Console.ReadLine();
                    break;
                case "D":
                case "d":
                    program.DeleteTransaction();
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Wrong Input");
                    Console.ReadLine();
                    break;
            }



            
        }

        public void DeleteTransaction()
        {
            Console.WriteLine("Enter the ID: ");
            int tranId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-----Deleting from DB-----");

            try
            {
                int delElement = transactionModel.Delete(tranId);
                Console.WriteLine("Number of effected rows is " + delElement);
                //Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }                      

        }

        public void CreateTransaction()
        {
            Console.WriteLine("Enter the transaction details:");
            // Type, Price, Date(yyyy,mm,dd), Currency[RIAL, EURO (default), USD ]");
            Console.Write("Type: ");
            String tranType = Console.ReadLine();
            Console.Write("Price: ");
            String tranPriceStr = Console.ReadLine();
            decimal tranPriceDbl = Convert.ToDecimal(tranPriceStr);

            ProgramStrucure.CurrencyType tranCurrencyType = (ProgramStrucure.CurrencyType)1;
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
                Console.ReadLine();
            }
            finally
            {
                // Console.WriteLine("Finally");
                Console.ReadLine();
            }
        }
    }

}
