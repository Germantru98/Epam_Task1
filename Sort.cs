using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Task1
{
    class Sort
    {   //Класс, реализующий быструю сортировку для массива целых чисел
        private int partition(int[] array, int start, int end)
        {
            int tmp;
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] < array[end])
                {
                    tmp = array[marker]; 
                    array[marker] = array[i];
                    array[i] = tmp;
                    marker += 1;
                }
            }
            
            tmp = array[marker];
            array[marker] = array[end];
            array[end] = tmp;
            return marker;
        }
        private void quicksort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = partition(array, start, end);
            quicksort(array, start, pivot - 1);
            quicksort(array, pivot + 1, end);
        }
        public void ArraySort(int[] array)
        {
            quicksort(array, 0, array.Length - 1);
        }
    }
}
