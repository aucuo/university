using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laba_3_temp
{
    internal class Cash : Payment
    {
        private string currency;
        private string issuer;

        public string Currency { get { return currency; } }
        public string Issuer { get { return issuer; } }
        public Cash(int amount, string date) : base(amount, date)
        {
            Console.WriteLine("Конструктор Cash с параметрами");

            Console.WriteLine("Введите валюту платежа (BYN, USD...):");
            this.currency = Check.ReadCurrency();

            Console.WriteLine("Введите имя того, кто выдал наличные:");
            this.issuer = Check.ReadIssuer();

        }
        public Cash() : base()
        {
            Console.WriteLine("Конструктор Cash без параметров");

            this.issuer = "name";
            this.currency = "BYN";
        }

        public Cash(Cash cash) : base(cash)
        {
            Console.WriteLine("Конструктор Cash копирования");

            this.currency = cash.currency;
            this.issuer = cash.issuer;
        }

        public override void Print()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}",
                base.Date, this.issuer, this.currency, base.Amount, "Наличными");
        }
        ~Cash()
        {
            Console.WriteLine("Деструктор Cash");
        }
    }
}
