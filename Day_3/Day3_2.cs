using System;
using System.Collections;
using System.Collections.Generic;

namespace Day3
{
    class Day3_2
    {
        public static void run()
        {
            string text = System.IO.File.ReadAllText(@"../../../Day3_input.txt");
            String[] allBinaryNums = text.Split("\n");
            int nrOfBinaryDigits = allBinaryNums[0].Trim().Length;
            LinkedList<int> oxygenCandidateIndexes = new LinkedList<int>();
            LinkedList<int> co2CandidateIndexes = new LinkedList<int>();
            for(int i = 0; i< allBinaryNums.Length; i++)
            {
                oxygenCandidateIndexes.AddLast(i);
                co2CandidateIndexes.AddLast(i);
            }
            string[] oxygenCandidates = new string[allBinaryNums.Length];
            allBinaryNums.CopyTo(oxygenCandidates, 0);
            for(int columnIndex = 0; oxygenCandidates.Length > 1 ; columnIndex++)
            {
                int[] oxygenColSums = new int[nrOfBinaryDigits];
                for (int i = 0; i < oxygenCandidates.Length; i++)
                {
                    char[] binaryDigits = oxygenCandidates[i].ToCharArray();
                    for (int j = 0; j < nrOfBinaryDigits; j++)
                    {
                        oxygenColSums[j] += Int32.Parse(binaryDigits[j].ToString());
                    }
                }
                ArrayList indexesToKeep = new ArrayList();
                for(int rowIndex = 0; rowIndex < oxygenCandidates.Length; rowIndex++)
                {
                    double halfLen = Convert.ToDouble(oxygenCandidates.Length) / 2.0;
                    bool isMostOnesOrEqual = Convert.ToDouble(oxygenColSums[columnIndex]) >= halfLen;
                    int nr = isMostOnesOrEqual ? 1 : 0;
                    if(isMostOnesOrEqual)
                    {
                        if (oxygenCandidates[rowIndex][columnIndex] == '1')
                        {
                            indexesToKeep.Add(rowIndex);
                        }
                    }
                    else if(oxygenCandidates[rowIndex][columnIndex] == '0')
                    {
                        indexesToKeep.Add(rowIndex);
                    }
                }
                string[] newOxygenCandidates = new string[indexesToKeep.Count];
                for(int i = 0; i < indexesToKeep.Count; i++) {
                    newOxygenCandidates[i] = oxygenCandidates[(int)indexesToKeep[i]];
                }
                oxygenCandidates = newOxygenCandidates;
            }
            string[] co2Candidates = new string[allBinaryNums.Length];
            allBinaryNums.CopyTo(co2Candidates, 0);
            for (int columnIndex = 0; co2Candidates.Length > 1; columnIndex++)
            {

                int[] co2ColSums = new int[nrOfBinaryDigits];
                for (int i = 0; i < co2Candidates.Length; i++)
                {
                    char[] binaryDigits = co2Candidates[i].ToCharArray();
                    for (int j = 0; j < nrOfBinaryDigits; j++)
                    {
                        co2ColSums[j] += Int32.Parse(binaryDigits[j].ToString());
                    }
                }
                ArrayList indexesToKeep = new ArrayList();
                for (int rowIndex = 0; rowIndex < co2Candidates.Length; rowIndex++)
                {
                    double halfLen = Convert.ToDouble(co2Candidates.Length) / 2.0;
                    bool isMostOnesOrEqual = Convert.ToDouble(co2ColSums[columnIndex]) >= halfLen;
                    int nr = isMostOnesOrEqual ? 1 : 0;
                    if (isMostOnesOrEqual)
                    {
                        if (co2Candidates[rowIndex][columnIndex] == '0')
                        {
                            indexesToKeep.Add(rowIndex);
                        }
                    }
                    else if (co2Candidates[rowIndex][columnIndex] == '1')
                    {
                        indexesToKeep.Add(rowIndex);
                    }
                }
                string[] newCo2Candidates = new string[indexesToKeep.Count];
                for (int i = 0; i < indexesToKeep.Count; i++)
                {
                    newCo2Candidates[i] = co2Candidates[(int)indexesToKeep[i]];
                }
                co2Candidates = newCo2Candidates;
            }
            int oxygen = binaryToDecimal(oxygenCandidates[0].Trim().ToCharArray());
            int co2 = binaryToDecimal(co2Candidates[0].Trim().ToCharArray());
            Console.WriteLine(oxygen * co2);
        }

        static int binaryToDecimal(char[] binaryDigits)
        {
            int result = 0;
            for (int i = 0; i < binaryDigits.Length; i++)
            {
                int power = binaryDigits.Length - i - 1;
                if (binaryDigits[i] == '1')
                {
                    result += (int)Math.Pow(2, power);
                }
            }
            return result;
        }
    }
}
