using System;

namespace Midterm
{
    class Program
    {
        static void Main(string[] args)
        {
            #region maxSumQ1
            // Max sum of consecutive elements in an array
            int[] array = { -1, 5, 3, -10, 3, 5, 1 };
            int comboStart = 0; // array index where maxSum group combination will begin
            int comboEnd = 0; // array index where maxSum group combination will end
            int maxSum = array[0]; // maxSum will always be first element of array
            int total; // store total of a group

            for (int j = 0; j < array.Length; j++)
            {
                total = array[j];// set total to first number in group of consecutive elements
                for (int i = j + 1; i < array.Length; i++) //starting at element after first element in a group
                {
                    total = total + array[i]; // total plus next element in array

                    if (total >= maxSum)
                    {
                        maxSum = total; // change maxSum to new high number
                        comboStart = j; //which element consecutive group starts on 
                        comboEnd = i; //which element consecutive group ends on
                    }
                }
            }

            Console.WriteLine("The max sum of consecutive elements in the array: ");
            for (int i = 0; i < array.Length; i++) // printing elements from array
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("\nTake place at elements: ");
            for (int i = comboStart; i <= comboEnd; i++) // printing elements from array that were used to make the maxSum
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("\nThe total is {0}.\n", maxSum);
            #endregion

            #region maxSemiSortedQ2
            int[] arrayQ2 = { 1, 3, 4, 7, 9, 10, 12, 13, 12, 6, 3 };
            //int[] arrayQ2 = { 1, 3, 4, 7, 15, 13, 12, 11, 9, 6, 3 };
            int middle = arrayQ2.Length / 2; // find middle of array
            int maxSemi = findMax(arrayQ2, middle); //find max using recursive method findMax

            Console.WriteLine("\nThe max element in the 'semi-sorted' array: ");
            for (int i = 0; i < arrayQ2.Length; i++) // printing elements from array
            {
                Console.Write(arrayQ2[i] + " ");
            }
            Console.WriteLine("\nis {0}.", maxSemi);

            Console.Read();

        }

        static int findMax(int[] A, int midIndex) //takes array and middle index for searching
        {
            int current = 0; // current highest number
            int mid = midIndex; 

            current = A[mid]; // sets current highest to middle indexed element

            if (A[mid - 1] > current) // if left element in array is larger do this
            {
                int leftMid = mid - mid / 2; // find middle of left side of middle current middle index
                current = findMax(A, leftMid);
            }
            else if(A[mid+1] > current) // if right element in array is larger do this
            {
                int rightMid = A.Length - mid; // find difference in length of array and mid point
                rightMid = rightMid / 2; // divide difference and use to add to current middle index
                rightMid = mid + rightMid; // add new divided difference to current index for right midIndex
                current = findMax(A, rightMid);
            }

            return current; 
        }
        #endregion
    }
}
