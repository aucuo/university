using Laba_3._2_temp;
using System;

internal class Payment
{
    private string _type;
    private DateTime _date;
    private int _amount;

    public Payment() // без параметров
    {
        _type = Checks.TypeChoise();

        _amount = 10;

        _date = DateTime.Today;

        Console.WriteLine("Конструктор без параметров");
    }

    public Payment(string type, int amount, DateTime date) // с параметрами
    {
        _type = type;
        _amount = amount;
        _date = date;

        Console.WriteLine("Конструктор с параметрами");
    }

    public Payment(Payment payment) // копирования
    {
        _type = payment._type;
        _amount = payment._amount;
        _date = payment._date;

        Console.WriteLine("Конструктор копирования");
    }

    ~Payment()
    {
        Console.WriteLine("Деструктор вызван");
    }

    public void ShowGrade()
    {
        Console.WriteLine("{0}\t{1}\t{2}", _type, _amount, _date);
    }

    public bool IsExsist(string type, DateTime date)
        => _date == date && _type == type;

    public void SetPayment(int amount)
        => _amount = amount;
}

