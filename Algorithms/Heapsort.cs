using System;
using System.Collections.Generic;
using System.Security.Authentication;
using Microsoft.Win32.SafeHandles;

namespace Algorithms {
    public class Heapsort {
        private static void Exchange(int[] a, int i, int j) {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
        
        void MaxHeapify(int[] a, int n, int i) {
            var l = 2 * i + 1;
            var r = 2 * i + 2;
            var largest = i;

            if (l < n && a[l] > a[largest])
                largest = l;

            if (r < n && a[r] > a[largest])
                largest = r;
            
            if (largest != i) {
                Exchange(a, i, largest);
                MaxHeapify(a, n, largest);
            }
        }

        void MinHeapify(int[] a, int n, int i) {
            var l = 2 * i + 1;
            var r = 2 * i * 2;
            var smallest = i;

            if (l < n && a[l] < a[smallest])
                smallest = l;

            if (r < n && a[r] < a[smallest])
                smallest = r;

            if (smallest != i) {
                Exchange(a, i, smallest);
                MinHeapify(a, n, smallest);
            }
        }

        void BuildMinHeap(int[] a) {
            var n = a.Length;
            for (var i = n / 2 - 1; i >= 0; i--)
                MinHeapify(a, n, i);
        }
        
        void BuildMaxHeap(int[] a) {
            var n = a.Length;
            for (var i = n / 2 - 1; i >= 0; i--) 
                MaxHeapify(a, n, i);
        }

        public void SortASC(int[] a) {
            BuildMaxHeap(a);
            var n = a.Length;
            for (var i = n - 1; i >= 0; i--) {
                Exchange(a, 0, i);
                MaxHeapify(a, i, 0);
            }
        }

        public void SortDESC(int[] a) {
            BuildMinHeap(a);
            var n = a.Length;
            for (var i = n - 1; i >= 0; i--) {
                Exchange(a, 0, i);
                MinHeapify(a, i, 0);
            }
        }
    }
}