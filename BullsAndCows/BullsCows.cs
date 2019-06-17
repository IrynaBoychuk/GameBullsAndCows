using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public int[] SeparateInt(int number)
        {
            string selectNumber = number.ToString();
            int[] digits = Separate(selectNumber);
            return digits;
        }


        public int RandomSecretNumber()
        {
            Random MyRandom = new Random();
            return MyRandom.Next(0000, 9999);
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
        
        public const string INCORRECT_LENGTH = "Incorrect lenght. Enter a 4-character number. ";
        public const string GOOD_MESSAGE = "All is good";
        public const string ZERO_START = "Can't start from 0.";
        public const string REPEAT_NUMBER = "Can't repeat characters.";
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
                for (int k = i + 1; k < 4; k++)
                {
                    if (turnNumber[i] == turnNumber[k])
                        return REPEAT_NUMBER;
                }
            }

            int[] legalNumbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            if (!turnNumber.All(c => legalNumbers.Contains(c)))
            {
                return ONLY_0_9_ALLOWED;
            }
            return GOOD_MESSAGE;
        }

        public bool ControlNumberAsResult(int[] turnNumber)
        {

            if (turnNumber.Length != 4)
            {
                return false;
            }
            if (turnNumber.First() == 0)
            {
                return false;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int k = i + 1; k < 4; k++)
                {
                    if (turnNumber[i] == turnNumber[k])
                        return false;
                }
            }

            int[] legalNumbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            if (!turnNumber.All(c => legalNumbers.Contains(c)))
            {
                return false;
            }

            return true;
        }

        public List<int[]> GenerateAllGameNumbers()
        {

            var AllNumbers = new List<int[]>();
            for (int i = 1; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    for (int k = 0; k < 10; k++)
                        for (int m = 0; m < 10; m++)
                        {
                            int[] currentNumber = new int[4];
                            currentNumber[0] = i;
                            currentNumber[1] = j;
                            currentNumber[2] = k;
                            currentNumber[3] = m;
                            if (ControlNumber(currentNumber) == GOOD_MESSAGE)
                                AllNumbers.Add(currentNumber);
                        }
            return AllNumbers;

        }


        public int[] RandomNumberFromCurrentList(List<int[]> currentListOfNumber)
        {
            Random MyRandom = new Random();
            return currentListOfNumber[MyRandom.Next(currentListOfNumber.Count)];
        }


        public int[] ComputerAlgoritm(int checkBullsCounter, int checkCowsCounter, List<int[]> currentListOfNumber, int[] currentNumber)
        {
            
            Analyze(checkBullsCounter, checkCowsCounter, currentListOfNumber, currentNumber);
            return currentNumber; 
            // 0б0к 1б0к 2б0к 3б0к 4б(Кінець) 0б1к 0б2к 0б3к 0б4к 1б1б 1б2к 1б3к 2б2к
        }

        //ф-ція крок комп'ютера

        public void Analyze(int checkBullsCounter, int checkCowsCounter, List<int[]> currentListOfNumber, int[] currentNumber)
        {
            //Debug.WriteLine($"{currentNumber}: count");
            //foreach (var number in currentListOfNumber.ToList())
            //{
            //    if (!(BullsCounter(number, currentNumber) == checkBullsCounter
            //        && CowsCounter(number, currentNumber) == checkCowsCounter))
            //    {
            //        if (string.Join("", number) == "1234")
            //        {

            //        }
            //        currentListOfNumber.Remove2(number);

            //    }
            //}
            Debug.WriteLine($"{currentNumber}: count {currentListOfNumber.Count}");
            //
            if (checkBullsCounter == 0 && checkCowsCounter == 0)
            {
                RemoveZero(currentListOfNumber, currentNumber);
            }
            //
            else if (checkBullsCounter == 1 && checkCowsCounter == 0)
            {
                RemoveOneBul(currentListOfNumber, currentNumber);
            }
            //+ OnlyForCows
            else if (checkBullsCounter == 0 && checkCowsCounter == 1)
            {
                RemoveOneCow(currentListOfNumber, currentNumber);
            }
            //
            else if (checkBullsCounter == 2 && checkCowsCounter == 0)
            {
                RemoveTwoBulls(currentListOfNumber, currentNumber);
            }
            //
            else if (checkBullsCounter == 1 && checkCowsCounter == 1)
            {
                RemoveArrayFromListThirdTypeTwo(currentListOfNumber, currentNumber);
            }
            //
            else if (checkBullsCounter == 0 && checkCowsCounter == 2)
            {
                RemoveTwoCows(currentListOfNumber, currentNumber);
            }
            //{
            //    RemoveArrayFromListThirdTypeTwo(currentListOfNumber, currentNumber);
            //}
            else if (checkBullsCounter == 0 && checkCowsCounter == 3)
            { RemoveThreeCows(currentListOfNumber, currentNumber); }
            else if(checkBullsCounter == 3 && checkCowsCounter == 0)
            { RemoveThreeBulls(currentListOfNumber, currentNumber); }
            else if ((checkBullsCounter == 1 && checkCowsCounter == 2) || (checkBullsCounter == 2 && checkCowsCounter == 1))
            { RemoveArrayFromListFourthTypeThree(currentListOfNumber, currentNumber); }
            
            else if (checkBullsCounter == 0 && checkCowsCounter == 4)
            { RemoveFourCows(currentListOfNumber, currentNumber); }
            //+
            else if( (checkBullsCounter == 2 && checkCowsCounter == 2)|| (checkBullsCounter == 1 && checkCowsCounter == 3))
            { RemoveArrayFromListFifthTypeFour(currentListOfNumber, currentNumber); }
            
        }

        //видаляє якщо хоч один елемент є в числі
        //for 0 c
        public void RemoveOneOfFourIsPresentElem(List<int[]> currentListOfNumber, int[] currentNumber)
        {
            var List = currentListOfNumber.ToList();
           foreach(var number in List)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (number.Contains(currentNumber[i]))
                    {
                        currentListOfNumber.Remove2(number);
                        break;
                    }
                }
            }
        }

        
        //видаляє якщо 
        //for 4 c
        public void RemoveAtLeastOneofFourIsAbsentElem(List<int[]> currentListOfNumber, int[] currentNumber)
        {
            var List = currentListOfNumber.ToList();
            foreach (var number in List)
            {

                if (!number.Contains(currentNumber[0]) ||
                    !number.Contains(currentNumber[1]) ||
                    !number.Contains(currentNumber[2]) ||
                    !number.Contains(currentNumber[3]))
                {                 
                    currentListOfNumber.Remove2(number);
                    break;
                }
            }
        }

        public void RemoveFourCows(List<int[]> currentListOfNumber, int[] currentNumber)
        {
            RemoveAtLeastOneofFourIsAbsentElem(currentListOfNumber, currentNumber);
            RemoveOnlyForCows(currentListOfNumber, currentNumber);
        }



        public void RemoveNumber(List<int[]> currentListOfNumber, int[] currentNumber)
        {
            var List = currentListOfNumber.ToList();
            foreach (var number in List)
            {
                if (number[0] ==currentNumber[0] &&
                    number[1] == currentNumber[1] &&
                    number[2] == currentNumber[2] &&
                    number[3] == currentNumber[3])
                {
                    currentListOfNumber.Remove2(number);
                    break;
                }
            }
        }

        // 012 013 023 123  
        // for 2 c
        public void RemoveEveryThreeElem(List<int[]> currentListOfNumber, int[] currentNumber)
        {
            var List = currentListOfNumber.ToList();
            foreach (var number in List)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int k = i + 1; k < 3; k++)
                    {
                        for (int p = k + 1; p < 4; p++) 
                          if (number.Contains(currentNumber[i]) && number.Contains(currentNumber[k])
                                        && number.Contains(currentNumber[p]))
                          {
                              currentListOfNumber.Remove2(number);
                                break;
                          }

                    }

                }
            }
        }
        // 01 02 03 12 13 23
        //for 1 c
        public void RemoveEveryTwoElemIsPresent(List<int[]> currentListOfNumber, int[] currentNumber)
        {
            var List = currentListOfNumber.ToList();
            foreach (var number in List)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int k = i + 1; k < 4; k++)
                    {
                            if (number.Contains(currentNumber[i]) && number.Contains(currentNumber[k]))
                            {
                                currentListOfNumber.Remove2(number);
                                break;
                            }
                    }

                }
            }
        }


        //for 3c
        public void RemoveThreeElemIsAbsent(List<int[]> currentListOfNumber, int[] currentNumber)
        {
            var List = currentListOfNumber.ToList();
            foreach (var number in List)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int k = i + 1; k < 3; k++)
                    {
                        for (int p = k + 1; p < 4; p++)
                        {
                            if (!number.Contains(currentNumber[i]) && !number.Contains(currentNumber[k])
                                                            && !number.Contains(currentNumber[p]))
                            {
                                currentListOfNumber.Remove2(number);
                                break; //ADDThis
                            }
                        }


                    }

                }
            }
        }

        public void RemoveTwoElemIsAbsent(List<int[]> currentListOfNumber, int[] currentNumber)
        {
            var List = currentListOfNumber.ToList();
            foreach (var number in List)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int k = i + 1; k < 3; k++)
                    {
                       if (!number.Contains(currentNumber[i]) && !number.Contains(currentNumber[k]))
                        {
                            currentListOfNumber.Remove2(number);
                            break;
                        }

                        
                    }

                }
            }
        }

        
        public void RemoveOneBul(List<int[]> currentListOfNumber, int[] currentNumber)
        {
            RemoveEveryTwoElemIsPresent(currentListOfNumber, currentNumber);
            RemoveOnlyForBulls(currentListOfNumber, currentNumber);

        }

        public void RemoveTwoBulls(List<int[]> currentListOfNumber, int[] currentNumber)
        {
            RemoveArrayFromListThirdTypeTwo(currentListOfNumber, currentNumber);
            RemoveOnlyForBulls(currentListOfNumber, currentNumber);
        }

        public void RemoveThreeBulls(List<int[]> currentListOfNumber, int[] currentNumber)
        {
            RemoveArrayFromListFourthTypeThree(currentListOfNumber, currentNumber);
            RemoveOnlyForBulls(currentListOfNumber, currentNumber);
        }

        public void RemoveOnlyForBulls(List<int[]> currentListOfNumber, int[] currentNumber)
        {
            var List = currentListOfNumber.ToList();
            foreach (var number in List)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (number[i] != currentNumber[i] )
                    {
                        currentListOfNumber.Remove2(number);
                        break;
                    }
                }

                //for (int i = 0; i < 4; i++)
                //{
                //    if (number[0] != currentNumber[0] &&
                //        number[1] != currentNumber[1] &&
                //        number[2] != currentNumber[2] &&
                //        number[3] != currentNumber[3])
                //    {
                //        currentListOfNumber.Remove2(number);
                //        break;
                //    }
                //}
            }

        }

        public void RemoveOnlyForCows(List<int[]> currentListOfNumber, int[] currentNumber)
        {
            var List = currentListOfNumber.ToList();
            foreach (var number in List)
            {
                
                for (int i = 0; i < 4; i++)
                {
                    if (number[i] == currentNumber[i])
                    {
                        currentListOfNumber.Remove2(number);
                        break;
                    }
                }

            }

        }

        public void RemoveZero(List<int[]> currentListOfNumber, int[] currentNumber) //видаляє всі масиви в яких є хлча бодна цифра
        {
            RemoveNumber(currentListOfNumber, currentNumber);
            RemoveOneOfFourIsPresentElem(currentListOfNumber, currentNumber);
        }

        public void RemoveOneCow(List<int[]> currentListOfNumber, int[] currentNumber) // більше одного елемента сходяться
        {
            RemoveEveryTwoElemIsPresent(currentListOfNumber, currentNumber);
            RemoveNumber(currentListOfNumber, currentNumber);
            RemoveOnlyForCows(currentListOfNumber, currentNumber);
        }

        public void RemoveTwoCows(List<int[]> currentListOfNumber, int[] currentNumber) // більше одного елемента сходяться
        {
            RemoveEveryThreeElem(currentListOfNumber, currentNumber);
            RemoveNumber(currentListOfNumber, currentNumber);
            RemoveOnlyForCows(currentListOfNumber, currentNumber);
        }

        public void RemoveThreeCows(List<int[]> currentListOfNumber, int[] currentNumber) // більше одного елемента сходяться
        {
            RemoveArrayFromListFourthTypeThree(currentListOfNumber, currentNumber);
            //RemoveNumber(currentListOfNumber, currentNumber);
            RemoveOnlyForCows(currentListOfNumber, currentNumber);
        }

        public void RemoveArrayFromListThirdTypeTwo(List<int[]> currentListOfNumber, int[] currentNumber) //видаляє всі масиви в яких є хлча бодна цифра
        {
            RemoveNumber(currentListOfNumber, currentNumber);
            RemoveEveryThreeElem(currentListOfNumber, currentNumber);
        }


        public void RemoveArrayFromListFourthTypeThree(List<int[]> currentListOfNumber, int[] currentNumber)
        {
            //якщо рівно 3 цифри з числа відсутні 
            RemoveThreeElemIsAbsent(currentListOfNumber, currentNumber);
            RemoveNumber(currentListOfNumber, currentNumber);
            //якщо рівно 2 цифри з числа присутня
            RemoveTwoElemIsAbsent(currentListOfNumber, currentNumber);
            //RemoveOneOfFourIsPresentElem(currentListOfNumber, currentNumber);
        }

        public void RemoveArrayFromListFifthTypeFour(List<int[]> currentListOfNumber, int[] currentNumber)
        {
            RemoveNumber(currentListOfNumber, currentNumber);
            RemoveAtLeastOneofFourIsAbsentElem(currentListOfNumber, currentNumber);
        }


    }

    public static class Extensions
    {
        public static void Remove2(this List<int[]> list, int[] number)
        {
            if (string.Join("", number) == "5678")
            {

            }
            list.Remove(number);
        }
    }
}
