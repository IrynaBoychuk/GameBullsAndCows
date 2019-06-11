using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{

    public class BullsCows
    {

        public int[] Separate(string number)
        {
            int[] digits = number.Select(c => (int)char.GetNumericValue(c))
                                .ToArray();
            return digits;
        }

        public int CowsCounter(int[] turnNumber, int[] secretNumber)
        {
            int cowsCounter = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (turnNumber[i] == secretNumber[j] && i != j)
                    {
                        cowsCounter++;
                    }
                }

            }

            return cowsCounter;
        }


        public int BullsCounter(int[] turnNumber, int[] secretNumber)
        {
            int bullsCounter = 0;
            for (int i = 0; i < 4; i++)
            {
                if (turnNumber[i] == secretNumber[i])
                {
                    bullsCounter++;
                }
            }
            return bullsCounter;
        }

        public void MakeTurn(int[] turnNumber, int[] secretNumber)
        {
            BullsCounter(turnNumber, secretNumber);
            CowsCounter(turnNumber, secretNumber);
        }

        //enum Message {ZeroControl,RepitControl,Length };

        public const string INCORRECT_LENGTH = "Incorrect lenght. Enter a 4-character number. ";
        public const string GOOD_MESSAGE = "All is good";
        public const string ZERO_START= "Can't start from 0.";
        public const string REPEAT_NUMBER= "Can't repeat characters.";
        public const string ONLY_0_9_ALLOWED = "Allowed only number 0-9."; //todo

        public string ControlNumber(int[] turnNumber)
        {
            
            if (turnNumber.Length != 4)
            {
                return INCORRECT_LENGTH;
            }
            if (turnNumber.First() == 0)
            {
                return ZERO_START;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int k = i+1; k < 4; k++)
                {
                    if (turnNumber[i] == turnNumber[k])
                        return REPEAT_NUMBER;
                }
            }

            int[] legalNumbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            if(!turnNumber.All(c => legalNumbers.Contains(c)))
            {
                return ONLY_0_9_ALLOWED;
            }
            return GOOD_MESSAGE;
        }
        
        public List<int[]> GenerateAllGameNumbers()
        {
            
            var AllNumbers = new List<int[]>();
            for (int i = 1; i < 10; i++)
                for(int j=0;j<10;j++)
                    for(int k=0;k<10;k++)
                        for(int m=0;m<10;m++)
                        {
                            int[] currentNumber = new int[4];
                            currentNumber[0] = i;
                           currentNumber[1] = j;
                           currentNumber[2] = k;
                           currentNumber[3] = m;
                            if(ControlNumber(currentNumber) == GOOD_MESSAGE)
                                AllNumbers.Add(currentNumber);
                            //for(int p=0;p<3;p++)
                            //{
                            //    for(int t=p+1;t<4;t++)
                            //    {
                            //        if (currentNumber[p] != currentNumber[t])
                            //            AllNumbers.Add(currentNumber);
                            //    }
                            //}
                        }
            return AllNumbers;

        }


    }
}
