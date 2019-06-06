using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Task1
{
    
    class Program
    {

        private static void ShowArray(int[]arr)
        {
            foreach (var i in arr)
            {
                Console.WriteLine("arr= "+i);
            }
        }
        static void Main(string[] args)
        {
            ArrayLoader l = new ArrayLoader();
            Sort s = new Sort();
            int[] arr = l.GetArray(1);
            s.ArraySort(arr);
            ShowArray(arr);
                       
        }
    }
}
