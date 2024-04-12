using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3_temp
{
    internal class Card : Payment
    {
        private string cardNum;
        private string cvv;

        public string CardNum { get { return cardNum; } }
        public string Cvv { get { return cvv; } }

        public Card(int amount, string date) : base(amount, date)
        {
            Console.WriteLine("Конструктор Card с параметрами");

            Console.WriteLine("Введите последние 4 цифры номера карты:");
            this.cardNum = Check.ReadCardNum();

            Console.WriteLine("Введите CVV (3 цифры): ");
            this.cvv = Check.ReadCvv();
        }
        public Card() : base()
        {
            Console.WriteLine("Конструктор Cash без параметров");

            this.cardNum = "0000";
            this.cvv = "000";
        }
        public Card(Card card) : base (card)
        {
            Console.WriteLine("Конструктор Card копирования");

            this.cardNum = card.cardNum;
            this.cvv = card.cvv;
        }
        public override void Print()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}",
                base.Date, this.cardNum, this.cvv, base.Amount, "Картой");
        }
        ~Card()
        {
            Console.WriteLine("Деструктор Card");
        }
    }
}
