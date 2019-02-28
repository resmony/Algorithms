using System;
using System.Runtime.InteropServices;

namespace Algorithms {
    public class Quicksort {
        public void QuickSort(int[] arr, int low, int high) {
            if (low < high) {
                var part = Partition(arr, low, high);
                QuickSort(arr, low, part - 1);
                QuickSort(arr, part + 1, high);
            }
        }

        static int Partition(int[] arr, int low, int high) {
            var pivot = arr[high];
            var i = low - 1;
            for (var j = low; j < high; j++) {
                if (arr[j] <= pivot) {
                    i++;
                    Swap(arr, i, j);
                }
            }
            Print(arr);
            Swap(arr, i + 1, high);
            return i + 1;
        }

        static void Swap(int[] arr, int i, int j) {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        static void Print(int[] arr) {
            foreach (var var in arr) {
                Console.Write($"{var} ");
            }
            Console.WriteLine();
        }
    }
}