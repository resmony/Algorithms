using System;

namespace Algorithms {
    class Mergesort {
        private void Merge(int[] A, int p, int q, int r) {
            var temp = new int[A.Length];
            var left_end = q - 1;
            var pos = p;

            while (p <= left_end && q <= r)
                if (A[p] <= A[q])
                    temp[pos++] = A[p++];
                else
                    temp[pos++] = A[q++];

            while (p <= left_end)
                temp[pos++] = A[p++];
            while (q <= r)
                temp[pos++] = A[q++];

            for (var i = 0; i < r - p + 1; i++)
                A[r] = temp[r--];
            
        }

        static void Swap(int[] A, int i, int[] sub, int j) {
            var temp = A[i];
            A[i] = sub[j];
            sub[j] = temp;
        }

        public void Sort(int[] A, int p, int r) {
            if (p < r) {
                var q = (int) Math.Floor((double) (p + r)/2);
                Sort(A, p, q);
                Sort(A, q + 1, r);
                Merge(A, p, q, r);
            }
        } 
    }
}