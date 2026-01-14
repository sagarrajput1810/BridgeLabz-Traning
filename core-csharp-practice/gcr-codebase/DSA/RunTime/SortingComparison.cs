using System;
using System.Diagnostics;

namespace AlgorithmComparisons
{
    public class SortingComparison
    {
        public static void Run()
        {
            Console.WriteLine("\n--- 2. Sorting Large Data Efficiently ---");
            // Sizes adjusted for practicality. 1,000,000 is too slow for Bubble Sort demonstration.
            int[] sizes = { 1000, 10000 }; 

            foreach (int size in sizes)
            {
                Console.WriteLine($"\nDataset Size (N): {size}");
                int[] data = GenerateRandomArray(size);
                
                // Bubble Sort
                int[] bubbleData = (int[])data.Clone();
                Stopwatch sw = Stopwatch.StartNew();
                BubbleSort(bubbleData);
                sw.Stop();
                Console.WriteLine($"Bubble Sort Time: {sw.Elapsed.TotalMilliseconds:F4} ms");

                // Merge Sort
                int[] mergeData = (int[])data.Clone();
                sw.Restart();
                MergeSort(mergeData, 0, mergeData.Length - 1);
                sw.Stop();
                Console.WriteLine($"Merge Sort Time: {sw.Elapsed.TotalMilliseconds:F4} ms");

                // Quick Sort
                int[] quickData = (int[])data.Clone();
                sw.Restart();
                QuickSort(quickData, 0, quickData.Length - 1);
                sw.Stop();
                Console.WriteLine($"Quick Sort Time: {sw.Elapsed.TotalMilliseconds:F4} ms");
            }
        }

        static int[] GenerateRandomArray(int size)
        {
            Random rand = new Random();
            int[] arr = new int[size];
            for(int i=0; i<size; i++) arr[i] = rand.Next(100000);
            return arr;
        }

        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
        }

        static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] L = new int[n1];
            int[] R = new int[n2];

            Array.Copy(arr, left, L, 0, n1);
            Array.Copy(arr, mid + 1, R, 0, n2);

            int i = 0, j = 0, k = left;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j]) arr[k++] = L[i++];
                else arr[k++] = R[j++];
            }
            while (i < n1) arr[k++] = L[i++];
            while (j < n2) arr[k++] = R[j++];
        }

        static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;
            return i + 1;
        }
    }
}
