using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramStrucure
{
    public enum CurrencyType
    {
        RIAL, EURO, USD
    }
    public class Transaction
    {
        public String type { get; private set; }
        public Decimal value { get; private set; }
        public DateTime datetime { get; private set; }
        /// <summary>
        /// it should be either Euro or Rial
        /// </summary>
        public CurrencyType currencyType { get; private set; }

        public Transaction(string tranType, decimal price, DateTime dateTime, CurrencyType curType) {
            type = tranType;
            value = price;
            datetime = dateTime;
            currencyType = curType;
        }

        public string To_String() {
            return value + currencyType.ToString() + " spend on " + datetime + ": " + type;

        }

    }
}
