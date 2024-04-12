using Lab5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab5
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
                Console.WriteLine("Ошибка: Недопустимый индекс");
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
                Console.WriteLine("Ошибка: Недопустимый индекс");
                return default(T);
            }
        }
        public int FindItem(T obj)
        {
            for (int i = 0; i < length; i++)
            {
                if (array is Lab5.Exam[]) // для Exam
                {
                    if ((array[i] as Lab5.Exam) == (obj as Lab5.Exam)) return i;
                }
                else if (array is Lab5.Credit[]) // для Credit
                {
                    if ((array[i] as Lab5.Credit) == (obj as Lab5.Credit)) return i;
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
                Console.WriteLine("Ошибка: Массив пуст");
                return default(T);
            }

            T min = array[0];
            for (int i = 1; i < length; i++)
            {
                if (array is Lab5.Exam[] && (min as Lab5.Exam).Mark > (array[i] as Lab5.Exam).Mark) // для Exam
                {
                    min = array[i];
                }
                else if (array is Lab5.Credit[] && (min as Lab5.Credit).Mark > (array[i] as Lab5.Credit).Mark) // для Credit
                {
                    min = array[i];
                }
                if (!(array is Lab5.Exam[]) && !(array is Lab5.Credit[]))
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
                Console.WriteLine("Ошибка: Массив пуст");
                return default(T);
            }

            T max = array[0];
            for (int i = 1; i < length; i++)
            {
                if (array is Lab5.Exam[] && (max as Lab5.Exam).Mark < (array[i] as Lab5.Exam).Mark) // для Exam
                {
                    max = array[i];
                }
                else if (array is Lab5.Credit[] && (max as Lab5.Credit).Mark < (array[i] as Lab5.Credit).Mark) // для Credit
                {
                    max = array[i];
                }
                if (!(array is Lab5.Exam[]) && !(array is Lab5.Credit[]))
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
                Console.WriteLine("Ошибка: шаблон пустой!");
                return;
            }
            if (length == 1) // проверка на пустоту
            {
                Console.WriteLine("Ошибка: в шаблоне только 1 элемент!");
                return;
            }
            if (array is Lab5.Exam[]) // для Exam
            {
                Array.Sort(array, (x, y) =>
                {
                    if (x is Lab5.Exam && y is Lab5.Exam)
                    {
                        return (x as Lab5.Exam)?.Mark.CompareTo((y as Lab5.Exam)?.Mark) ?? 0;
                    }
                    return 0;
                });
            }
            else if (array is Lab5.Credit[]) // для Credit
            {
                Array.Sort(array, (x, y) =>
                {
                    if (x is Lab5.Credit && y is Lab5.Credit)
                    {
                        return (x as Lab5.Credit)?.Mark.CompareTo((y as Lab5.Credit)?.Mark) ?? 0;
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
