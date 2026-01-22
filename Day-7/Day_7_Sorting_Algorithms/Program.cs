using System;

class Program
{
    static void CountingSortByDigit(int[] arr, int exp)
    {
        int n = arr.Length;
        int[] output = new int[n];     // sorted result for this digit
        int[] count = new int[10];     // digits 0-9

        // Step 1: Count digits
        for (int i = 0; i < n; i++)
        {
            int digit = (arr[i] / exp) % 10;
            count[digit]++;
        }

        // Step 2: Convert count[] to prefix sum (positions)
        for (int i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        // Step 3: Build output array (stable)
        for (int i = n - 1; i >= 0; i--)
        {
            int digit = (arr[i] / exp) % 10;
            output[count[digit] - 1] = arr[i];
            count[digit]--;
        }

        // Step 4: Copy output back into arr
        for (int i = 0; i < n; i++)
        {
            arr[i] = output[i];
        }
    }

    static void RadixSort(int[] arr)
    {
        int max = arr[0];
        for (int i = 1; i < arr.Length; i++)
            if (arr[i] > max) max = arr[i];

        // Do counting sort for each digit
        for (int exp = 1; max / exp > 0; exp *= 10)
        {
            CountingSortByDigit(arr, exp);
        }
    }

    static void Main()
    {
        int[] arr = { 170, 45, 75, 90, 802, 24, 2, 66 };

        RadixSort(arr);

        Console.WriteLine(string.Join(", ", arr));
    }
}
