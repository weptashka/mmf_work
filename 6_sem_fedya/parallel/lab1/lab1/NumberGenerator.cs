using System;
using System.Collections.Generic;

namespace lab1
{
    public class NumberGenerator
    {
        private const int MinValue = 1;
        private const int MaxValue = 100;
        private const int ArrayCount = 2500000;
        private const int NumbersInArrayCount = 3;
        
        public static int[][] GenerateNumbersArray()
        {
            var randNum = new Random();
            var result = new List<int[]>();
            
            for (var i = 0; i < ArrayCount; i++)
            {
                var numbersList = new List<int>();
                
                for (var j = 0; j < NumbersInArrayCount; j++)
                {
                    numbersList.Add(randNum.Next(MinValue, MaxValue));
                }
                
                result.Add(numbersList.ToArray());
            }

            return result.ToArray();
        }
    }
}