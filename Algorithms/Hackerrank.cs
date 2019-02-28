using System;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.Linq;

namespace Algorithms {
    public class Hackerrank {
        public int pairs { get; set; }
        /*public Hackerrank() {
            LoadEntry();    
        }*/

         private void LoadEntry() {
            var qtd = Convert.ToInt32(Console.ReadLine());
            int[] values = null;
            try {
                values = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);
            }
            catch (FormatException e) {
                Console.WriteLine("Incorrect input format. ");
            }
            if (values != null)
                SortKeys(values, qtd);
        }

        private void SortKeys(int[] arr, int n) {
            pairs = 0;
            var qs = new Quicksort();
            qs.QuickSort(arr, 0, arr.Length - 1);
            //qs.Print(arr);
            
            for (var i = 0; i < n - 1;) {
                var j = i + 1;
                if (arr[j] == arr[i]) {
                    pairs += 1;
                    i += 2;
                }
                else {
                    i = j;
                }
            }
        }
        
        // Complete the superDigit function below.
        public int SuperDigit(ulong number, int k) {
            if (number < 10)
                return (int) number;
            ulong sum = 0;
            while (number != 0) {
                sum += number % 10;
                number /= 10;
            }
            sum *= (ulong) k;
            
            return SuperDigit(sum, 1);
        }

        public int SuperDigit(string number, int k) {
            var num = number.ToCharArray();
            return Sum(num, k, 0);
        }

        // l = lower part of array
        // m = middle part of array
        // h = higher part of array
        // k = number of times number is repeated
        private int Sum(char[] arr, int k, int sum) {
            sum = arr.Sum(n => int.Parse(n.ToString())) * k;
            
            if (arr.Length == 1)
                return sum;
            
            return Sum(sum.ToString().ToCharArray(), 1, sum);
        }
    }
}