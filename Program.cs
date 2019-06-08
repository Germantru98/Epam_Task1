using System;

namespace Epam_Task1
{
    internal class Program
    {
        private static void ShowArray(int[] arr)
        {
            foreach (var i in arr)
            {
                Console.WriteLine("arr= " + i);
            }
        }

        private static void Main(string[] args)
        {
            ArrayLoader l = new ArrayLoader();
            Sort s = new Sort();
            int[] arr = l.GetArray(1);
            s.ArraySort(arr);
            ShowArray(arr);
        }
    }
}