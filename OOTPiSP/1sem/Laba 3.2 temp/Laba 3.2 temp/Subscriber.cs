using Laba_3._2_temp;
using System;
using System.Collections.Generic;

internal class Subscriber
{
    private string _name;
    private List<Payment> _payments = new List<Payment>();

    public int PaymentsCount
        => _payments.Count;

    public Subscriber(string name)
    {
        _name = name;
    }

    public bool IsExsist(string name)
        => _name == name;

    public void ShowSubscribers()
    {
        Console.WriteLine(_name);
    }

    public void AddPayment(string type, int amount, DateTime date)
    {
        _payments.Add(new Payment(type, amount, date));
    }

    public void AddPayment()
    {
        _payments.Add(new Payment());
    }

    public void CopyPayments(Payment payment, int count)
    {
        for (int i = 0; i < count; i++)
        {
            _payments.Add(new Payment(payment));
        }
    }

    public void ShowPayments(string name)
    {
        if (!IsExsist(name))
            return;

        foreach (Payment payment in _payments)
            payment.ShowGrade();
    }

    public void ShowPayments() // Перегрузка
    {
        foreach (Payment payment in _payments)
            payment.ShowGrade();
    }


    public void EditPayment()
    {
        var type = Checks.TypeChoise();

        Console.WriteLine("Введите дату:");
        var date = Checks.ReadDate();

        foreach (Payment payment in _payments)
        {
            if (!payment.IsExsist(type, date))
                continue;

            Console.WriteLine("Введите новую сумму платежа для " + _name + ":");
            var amount = Checks.ReadInt();

            payment.SetPayment(amount);
            Console.WriteLine("Платеж изменен");
            return;
        }

        Console.WriteLine("Платеж не найден");
    }

    public void DeletePayment()
    {
        var type = Checks.TypeChoise();

        Console.WriteLine("Введите дату:");
        var date = Checks.ReadDate();

        for (var i = 0; i < _payments.Count; i++)
        {
            if (!_payments[i].IsExsist(type, date))
                continue;

            _payments.RemoveAt(i);
            Console.WriteLine("Платеж удален!");
            i--;
        }
    }
}

