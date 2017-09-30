using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_algorethims
{
    static class Sorts
    {
        public enum SortType
        {
            counting,
            bubble,
            cocktail,
            doubleselection,
            insersion,
            quick,
            selection,
            gravity,
            merge
        }
        public static int[] SortArray(int[] array, SortType s)
        {
            switch (s)
            {
                case SortType.bubble:
                    array.bubbleSort();
                    break;
                case SortType.cocktail:
                    array.cocktailShakerSort();
                    break;
                case SortType.counting:
                    array.countingSort();
                    break;
                case SortType.doubleselection:
                    array.doubleSelectionSort();
                    break;
                case SortType.insersion:
                    array.insersionSort();
                    break;
                case SortType.quick:
                    array.quickSort();
                    break;
                case SortType.selection:
                    array.selectionSort();
                    break;
                case SortType.gravity:
                    array.gravitySort();
                    break;
                case SortType.merge:
                    array.mergeSort();
                    break;
            }
            return array;
        }
        private static void countingSort(this int[] rawdata)
        {
            int k = Max(rawdata);

            int[] count = new int[k + 1];
            int[] output = new int[rawdata.Length];

            for (int i = 0; i < rawdata.Length; i++)
                count[rawdata[i]] += 1;

            for (int i = 1; i < k + 1; i++)
                count[i] = count[i] + count[i - 1];

            for (int i = rawdata.Length - 1; i >= 0; i--)
            {
                output[count[rawdata[i]] - 1] = rawdata[i];
                count[rawdata[i]]--;
            }
            for (int i = 0; i < output.Length; i++)
                rawdata[i] = output[i];
        }
        private static void bubbleSort(this int[] rawdata)
        {
            for (int i = rawdata.Length - 1; i > 0; i--)
                for (int j = 0; j < i; j++)
                    if (rawdata[j] > rawdata[j + 1])
                    {
                        rawdata.Swap(j, j + 1);
                    }
        }
        private static void cocktailShakerSort(this int[] array)
        {
            int i = 0;
            while (i < array.Length / 2)
            {
                for (int j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                        array.Swap(j, j + 1);
                }
                for (int j = array.Length - i - 1; j > i; j--)
                {
                    if (array[j] < array[j - 1])
                        array.Swap(j, j - 1);
                }
                i++;
            }
        }
        private static void doubleSelectionSort(this int[] array)
        {

            int left = 0;
            int right = array.Length - 1;
            int smallest = 0;
            int biggest = 0;
            while (left <= right)
            {
                for (int i = left; i <= right; i++)
                {
                    if (array[i] > array[biggest])
                        biggest = i;
                    if (array[i] < array[smallest])
                        smallest = i;
                }
                if (biggest == left)
                    biggest = smallest;
                array.Swap(left, smallest);
                array.Swap(right, biggest);
                left++;
                right--;
                smallest = left;
                biggest = right;
            }
        }
        private static void gravitySort(this int[] array)
        {
            int max = Max(array);
            int[][] abacus = new int[array.Length][];
            for (int i = 0; i < abacus.GetLength(0); i++)
                abacus[i] = new int[max];


            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array[i]; j++)
                    abacus[i][abacus[0].Length - j - 1] = 1;

            //apply gravity
            for (int i = 0; i < abacus[0].Length; i++)
            {
                for (int j = 0; j < abacus.Length; j++)
                {
                    if (abacus[j][i] == 1)
                    {
                        //Drop it
                        int droppos = j;
                        while (droppos + 1 < abacus.Length && abacus[droppos][i] == 1)
                            droppos++;
                        if (abacus[droppos][i] == 0)
                        {
                            abacus[j][i] = 0;
                            abacus[droppos][i] = 1;
                        }
                    }
                }

                int count = 0;
                for (int x = 0; x < abacus.Length; x++)
                {
                    count = 0;
                    for (int y = 0; y < abacus[0].Length; y++)
                        count += abacus[x][y];
                    array[x] = count;
                }
            }
        }
        private static void insersionSort(this int[] array)
        {
            int pos;
            for (int i = 1; i < array.Length; i++)
            {
                pos = i;
                while (pos > 0 && array[pos] <= array[pos - 1])
                {
                    array.Swap(pos, pos - 1);
                    pos--;
                }
            }
        }
        private static void mergeSort(this int[] array)
        {
            array.mergeSort(0, array.Length - 1);
            
        }
        private static void quickSort(this int[] array)
        {
            array.quickSort(0, array.Length - 1);
        }
        private static void selectionSort(this int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int lowestindex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[lowestindex])
                    {
                        lowestindex = j;
                    }
                }
                array.Swap(i, lowestindex);
            }
        }
        private static void shatterSort(this int[] array)
        {

        }
        private static int Max(this int[] data)
        {
            int max = data[0];
            for (int i = 1; i < data.Length; i++)
                if (data[i] > max)
                    max = data[i];
            return max;
        }
        private static int Min(this int[] data)
        {

            int min = data[0];
            for (int i = 1; i < data.Length; i++)
                if (data[i] < min)
                    min = data[i];
            return min;
        }

        #region ShatterSortFunctions

        #endregion

        #region QuickSortFunctions
        private static void quickSort(this int[] arr, int left, int right)
        {
            // For Recusrion
            if (left < right)
            {
                int pivot = partition(arr, left, right);

                if (pivot > 1)
                    quickSort(arr, left, pivot - 1);

                if (pivot + 1 < right)
                    quickSort(arr, pivot + 1, right);
            }
        }
        private static int partition(int[] numbers, int left, int right)
        {
            int pivot = numbers[left];
            while (true)
            {
                while (numbers[left] < pivot)
                    left++;

                while (numbers[right] > pivot)
                    right--;

                if (left <= right)
                {
                    int temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }


        #endregion

        #region MergeSortFunctions
        static public void DoMerge(this int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[numbers.Length];
            int i, eol, num, pos;

            eol = (mid - 1);
            pos = left;
            num = (right - left + 1);

            while ((left <= eol) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[pos++] = numbers[left++];
                else
                    temp[pos++] = numbers[mid++];
            }

            while (left <= eol)
                temp[pos++] = numbers[left++];

            while (mid <= right)
                temp[pos++] = numbers[mid++];

            for (i = 0; i < num; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }
        private static void Push(this int[] array, int s, int e)
        {
            for (int i = s; i < e; i++)
            {
                if (array[i] > array[i + 1])
                {
                    array.Swap(i, i + 1);
                }
            }
        }
        private static void mergeSort(this int[] numbers, int left, int right)
        {
            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                numbers.mergeSort(left, mid);
                numbers.mergeSort((mid + 1), right);

                numbers.DoMerge(left, (mid + 1), right);
            }
        }
        #endregion
    }
}
