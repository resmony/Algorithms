using System;

namespace Algorithms {
    class Runner {
        public static void Main(string[] args) {
            var quick = new Quicksort();
            var arr = RandomNumbers(25, 0, 100);
            Print(arr);
            quick.QuickSort(arr, 0, arr.Length -1);
            Print(arr);
            
        }
        
        static int[] RandomNumbers(int quantity, int rangeStart, int rangeEnd) {
            var rand = new Random();
            var numbers = new int[quantity];

            for (var i = 0; i < quantity; i++)
               lock (rand)
                   numbers[i] = rand.Next(rangeStart, rangeEnd);
            return numbers;
        }
        
        static void Print(int[] arr) {
            foreach (var elem in arr) {
                Console.Write("{0} ", elem);
            }
            Console.WriteLine();
        }
    }
    
    
    public class Quicksort {
        public void QuickSort(int[] arr, int low, int high) {
            if (low < high) {
                //var part = Partition(arr, low, high);
                //var part = RandomizedPartition(arr, low, high);
                //var part = HoarePartition(arr, low, high);
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
            //Print(arr);
            Swap(arr, i + 1, high);
            return i + 1;
        }
        
        // random Partition
        static int RandomizedPartition(int[] arr, int low, int high) {
            var rand = new Random();
            var i = rand.Next(low, high);
            Swap(arr, high, i);
            return Partition(arr, low, high);
        }
        
        // hoare Partition
        static int HoarePartition(int[] arr, int low, int high) {
            var x = arr[low];
            //Console.WriteLine("x {0}, len {1}", x, arr.Length);
            var i = low - 1;
            var j = high + 1;
            //Console.WriteLine("i {0}, j {1}", i, j);
            
            while (true) {       
                do {
                    j = j - 1;
                }while (arr[j] > x);
                do {
                    i = i + 1;
                }while (arr[i] < x);
                
                if (i < j)
                    Swap(arr, i, j);
            
                return j;
            }
                
            
        }

        static void Swap(int[] arr, int i, int j) {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

       
    }
}
