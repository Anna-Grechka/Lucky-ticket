using System;

namespace Lucky_ticket
{
    class Ticket
    {
        static void Main(string[] args)
        {
           Repeat:
           Console.WriteLine("Write a number with 4-8 digits");
           int number = int.Parse(Console.ReadLine());
           string numberString = Convert.ToString(number);

           int firstPartSum = 0;
           int secondPartSum = 0;

            //condition check.

            if (numberString.Length < 4 ||
                numberString.Length > 8)
            {
                Console.WriteLine("Wrong");
                goto Repeat;
            }

            //filling the array.

            int[] arr = new int[numberString.Length];

            for (int i = numberString.Length - 1; i >= 0; i--)
            {
                arr[i] = number % 10;
                number /= 10;

                if (number == 0)
                {
                    break;
                }
            }    
            
            //solution for number with an odd number of digits.

            static int[] OddDigits(int[] array)
            {
                int[] oddArray = new int[array.Length + 1];

                oddArray[0] = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    oddArray[i + 1] = array[i];
                }

                return oddArray;
            }   

            //summation of each part of the array.

            void Summation(int[] array)
            {
                for (int i = 0; i < numberString.Length / 2; i++)
                {
                    firstPartSum += array[i];
                }

                for (int i = numberString.Length - 1; i >= numberString.Length / 2; i--)
                {
                    secondPartSum += array[i];
                }
            }

            //terms.

            if (arr.Length % 2 != 0 )
            {
                OddDigits(arr);
                Summation(arr);
            }
            else
            {
                Summation(arr);
            }

            if (firstPartSum == secondPartSum)
            {
                Console.WriteLine("It is a lucky ticket");
            }
            else
            {
                Console.WriteLine("It is not a lucky ticket");
            }
            Console.WriteLine();

            goto Repeat;
        }
    }
}
