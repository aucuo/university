using PaymentJournal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PaymentJournal
{
    internal class MyArray<T>
    {
        private T[] array;
        private int length = 0;

        public int Length { get { return length; } }

        public MyArray(int n)
        {
            array = new T[n];
        }
        public void AddElement(int index, T element)
        {
            if (index >= 0 && index < array.Length)
            {
                array[index] = element;
                length++;
            }
            else
            {
                Console.WriteLine("Недопустимый индекс");
            }
        }
        public T GetElement(int index)
        {
            if (index >= 0 && index < array.Length)
            {
                return array[index];
            }
            else
            {
                Console.WriteLine("Недопустимый индекс");
                return default(T);
            }
        }
        public int FindItem(T obj)
        {
            for (int i = 0; i < length; i++)
            {
                if (array is PaymentJournal.Income[]) // для Income
                {
                    if ((array[i] as Income) == (obj as PaymentJournal.Income)) return i;
                }
                else if (array is PaymentJournal.Expense[]) // для Expense
                {
                    if ((array[i] as PaymentJournal.Expense) == (obj as PaymentJournal.Expense)) return i;
                }
                else if (EqualityComparer<T>.Default.Equals(array[i], obj))
                {
                    return i;
                }
            }
            return -1;
        }
        public T Min()
        {
            if (length == 0)
            {
                Console.WriteLine("Массив пуст!");
                return default(T);
            }

            T min = array[0];
            for (int i = 1; i < length; i++)
            {
                if (array is PaymentJournal.Income[] && (min as PaymentJournal.Income).Amount > (array[i] as PaymentJournal.Income).Amount) // для Income
                {
                    min = array[i];
                }
                else if (array is PaymentJournal.Expense[] && (min as PaymentJournal.Expense).Amount > (array[i] as PaymentJournal.Expense).Amount) // для Expense
                {
                    min = array[i];
                }
                if (!(array is PaymentJournal.Income[]) && !(array is PaymentJournal.Expense[]))
                {
                    if (Comparer<T>.Default.Compare(array[i], min) < 0)
                    {
                        min = array[i];
                    }
                }
            }

            return min;
        }
        public T Max()
        {
            if (length == 0)
            {
                Console.WriteLine("Массив пуст!");
                return default(T);
            }

            T max = array[0];
            for (int i = 1; i < length; i++)
            {
                if (array is PaymentJournal.Income[] && (max as PaymentJournal.Income).Amount < (array[i] as PaymentJournal.Income).Amount) // для Income
                {
                    max = array[i];
                }
                else if (array is PaymentJournal.Expense[] && (max as PaymentJournal.Expense).Amount < (array[i] as PaymentJournal.Expense).Amount) // для Expense
                {
                    max = array[i];
                }
                if (!(array is PaymentJournal.Income[]) && !(array is PaymentJournal.Expense[]))
                {
                    if (Comparer<T>.Default.Compare(array[i], max) > 0)
                    {
                        max = array[i];
                    }
                }
            }

            return max;
        }
        public void Sort()
        {
            if (length == 0) // проверка на пустоту
            {
                Console.WriteLine("Шаблон пустой!");
                return;
            }
            if (length == 1) // проверка на пустоту
            {
                Console.WriteLine("В шаблоне только 1 элемент!");
                return;
            }
            if (array is PaymentJournal.Income[]) // для Income
            {
                Array.Sort(array, (x, y) =>
                {
                    if (x is PaymentJournal.Income && y is PaymentJournal.Income)
                    {
                        return (x as PaymentJournal.Income)?.Amount.CompareTo((y as PaymentJournal.Income)?.Amount) ?? 0;
                    }
                    return 0;
                });
            }
            else if (array is PaymentJournal.Expense[]) // для Expense
            {
                Array.Sort(array, (x, y) =>
                {
                    if (x is PaymentJournal.Expense && y is PaymentJournal.Expense)
                    {
                        return (x as PaymentJournal.Expense)?.Amount.CompareTo((y as PaymentJournal.Expense)?.Amount) ?? 0;
                    }
                    return 0;
                });
            }
            else
            {
                Array.Sort(array);
            }
            Console.WriteLine("Массив осортирован!");
        }
    }
}
