using System;
using System.Collections.Generic;

namespace Day3
{
    class Day3_1
    {
        public static void run()
        {
            string text = System.IO.File.ReadAllText(@"../../../Day3_input.txt");
            String[] allBinaryNums = text.Split("\n");
            int nrOfBinaryDigits = allBinaryNums[0].Trim().Length;
            int[] colSums = new int[nrOfBinaryDigits];
            for (int i = 0; i < allBinaryNums.Length; i++)
            {
                char[] binaryDigits = allBinaryNums[i].ToCharArray();
                for (int j = 0; j < nrOfBinaryDigits; j++)
                {
                    colSums[j] += Int32.Parse(binaryDigits[j].ToString());
                }
            }
            double halfLen = Convert.ToDouble(allBinaryNums.Length) / 2.0;
            int[] gammaDigits = new int[nrOfBinaryDigits];
            int[] epsilonDigits = new int[nrOfBinaryDigits];
            for (int i = 0; i < nrOfBinaryDigits; i++)
            {
                bool isMostOnes = Convert.ToDouble(colSums[i]) > halfLen;
                gammaDigits[i] = isMostOnes ? 1 : 0;
                epsilonDigits[i] = isMostOnes ? 0 : 1;
            }
            int gammaDecimal = binaryToDecimal(gammaDigits);
            int epsilonDecimal = binaryToDecimal(epsilonDigits);
            Console.WriteLine(gammaDecimal * epsilonDecimal);
        }

        static int binaryToDecimal(int[] binaryDigits)
        {
            int result = 0;
            for (int i = 0; i < binaryDigits.Length; i++)
            {
                int power = binaryDigits.Length - i - 1;
                if (binaryDigits[i] == 1)
                {
                    result += (int)Math.Pow(2, power);
                }
            }
            return result;
        }
    }
}
