using System;

namespace Epam_Task1
{
    internal class Program
    {
        private static void ShowArray(int[] arr)
        {
            foreach (var i in arr)
            {
                Console.WriteLine("arr = " + i);
            }
        }

        private static void Main(string[] args)
        {
            ArrayLoader l = new ArrayLoader();
            Sort s = new Sort();
            Console.WriteLine("Выберите вариант ввода массива\n0-c клавиатуры\n1-из файла");
            int caseSwitch = int.Parse(Console.ReadLine());
            int[] arr;
            switch (caseSwitch)
            {
                case 0:
                    {
                        arr = l.GetArray(0);
                        s.ArraySort(arr);
                        ShowArray(arr);
                        break;
                    }
                case 1:
                    {
                        arr = l.GetArray(1);
                        s.ArraySort(arr);
                        ShowArray(arr);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Введено неверное значение");
                        break;
                    }
            }
        }
    }
}