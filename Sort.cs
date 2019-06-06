using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Task1
{
    class Sort
    {
        private int partition(int[] array, int start, int end)
        {
            int tmp;//swap helper
            int marker = start;//divides left and right subarrays
            for (int i = start; i <= end; i++)
            {
                if (array[i] < array[end]) //array[end] is pivot
                {
                    tmp = array[marker]; // swap
                    array[marker] = array[i];
                    array[i] = tmp;
                    marker += 1;
                }
            }
            //put pivot(array[end]) between left and right subarrays
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
