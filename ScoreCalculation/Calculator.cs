using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculation
{
    public class Calculator
    {
        //Given an array of integers, keep a total score based on the following:
        //a.Add 1 point for each even number in the array.
        //b.Add 3 points for each odd number in the array.
        //c.Add 5 points for every time you encounter an 8 in the array

        public static int CalculateScore(int[] arr)
        {
            int score = 0;

            foreach (int num in arr)
            {
                // Checks if the number is even
                if (num % 2 == 0) 
                {
                    score += 1;
                }
                else // The number is odd
                {
                    score += 3;
                }

                if (num == 8) // Check for the specific number 8
                {
                    score += 5;
                }
            }

            return score;
        }
    }
}
