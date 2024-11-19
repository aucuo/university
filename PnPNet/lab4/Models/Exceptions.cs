using System;

namespace lab4.Models
{
    // Класс для обработки исключений корабля
    class ShipException : Exception
    {
        public ShipException(string message) : base(message) { }
        public override string Message
        {
            get
            {
                return "Йо-хохо! " + base.Message;
            }
        }
    }

    // Класс для обработки исключений кают
    class CabinCategoryException : Exception
    {
        public CabinCategoryException(string message) : base(message) { }
        public override string Message
        {
            get
            {
                return "Йо-хохо! " + base.Message;
            }
        }
    }

}