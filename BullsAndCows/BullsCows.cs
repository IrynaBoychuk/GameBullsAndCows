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

        //public void MakeTurn(int[] turnNumber, int[] secretNumber)
        //{
        //    BullsCounter(turnNumber, secretNumber);
        //    CowsCounter(turnNumber, secretNumber);
        //}

        //enum Message {ZeroControl,RepitControl,Length };

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


        public int[] RandomNumberFromCurrentList(List<int[]> currentListOfNumber)
        {
            Random MyRandom = new Random();
            return currentListOfNumber[MyRandom.Next(currentListOfNumber.Count)];
        }


        public int[] ComputerAlgoritm(int checkBullsCounter, int checkCowsCounter, List<int[]> currentListOfNumber, int[] currentNumber)
        //3 параметр змінений List всіх варіантів що залишил відповідно до минулих кроків буде вертати новий ліст
        {
            //обираємо рандомне число

            //int[] currentNumber;
            //currentNumber = RandomNumberFromCurrentList(currentListOfNumber);
            Analyze(checkBullsCounter, checkCowsCounter, currentListOfNumber, currentNumber);
            return currentNumber; //ЩЕ НЕ ПРАВИЛЬНОО



            //функція що буде вертати данну мною відповідь про к-сть корів і биків з datagridView2
            //через якусь конструк( бик.корови) і if відносно результата тото к-сть биків та корів застосовуємо функції виключення 
            // 0б0к 1б0к 2б0к 3б0к 4б(Кінець) 0б1к 0б2к 0б3к 0б4к 1б1б 1б2к 1б3к 2б2к


        }

        //ф-ція крок комп'ютера

        public void Analyze(int checkBullsCounter, int checkCowsCounter, List<int[]> currentListOfNumber, int[] currentNumber)
        {
            Debug.WriteLine($"{currentNumber}: count");
            foreach (var number in currentListOfNumber.ToList())
            {
                if (!(BullsCounter(number, currentNumber) == checkBullsCounter
                    && CowsCounter(number, currentNumber) == checkCowsCounter))
                {
                    if (string.Join("", number) == "1234")
                    {

                    }
                    currentListOfNumber.Remove2(number);

                }
            }
            Debug.WriteLine($"{currentNumber}: count {currentListOfNumber.Count}");

            //if (checkBullsCounter == 0 && checkCowsCounter == 0)
            //{
            //    RemoveArrayFromListFirstTypeZero(currentListOfNumber, currentNumber);
            //}
            //else if ((checkBullsCounter == 0 && checkCowsCounter == 1) || (checkBullsCounter == 1 && checkCowsCounter == 0))
            //{
            //    RemoveArrayFromListSecondTypeOne(currentListOfNumber, currentNumber);
            //}
            //else if ((checkBullsCounter == 0 && checkCowsCounter == 2) ||
            //    (checkBullsCounter == 1 && checkCowsCounter == 1) ||
            //    (checkBullsCounter == 0 && checkCowsCounter == 1))
            //{
            //    RemoveArrayFromListThirdTypeTwo(currentListOfNumber, currentNumber);
            //}
            //else if ((checkBullsCounter == 0 && checkCowsCounter == 3) ||
            //    (checkBullsCounter == 1 && checkCowsCounter == 2) ||
            //    (checkBullsCounter == 2 && checkCowsCounter == 1))
            //{
            //    RemoveArrayFromListFourthTypeThree(currentListOfNumber, currentNumber);
            //}
            //else if ((checkBullsCounter == 0 && checkCowsCounter == 4) ||
            //    (checkBullsCounter == 2 && checkCowsCounter == 2) ||
            //    (checkBullsCounter == 1 && checkCowsCounter == 3))
            //{
            //    RemoveArrayFromListFifthTypeFour(currentListOfNumber, currentNumber);
            //}
        }

        //видаляє якщо хоч один елемент є в числі
        public void RemoveOneOfFourIsPresentElem(List<int[]> currentListOfNumber, int[] currentNumber)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < currentListOfNumber.Count; j++)
                {
                    if (currentListOfNumber[j].Contains(currentNumber[i]))
                    {
                        currentListOfNumber.Remove2(currentListOfNumber[j]);
                    }
                }
            }
        }

        

        //видаляє якщо 
        public void RemoveAtLeastOneofFourIsAbsentElem(List<int[]> currentListOfNumber, int[] currentNumber)
        {
            for (int j = 0; j < currentListOfNumber.Count; j++)
            {
                if (!currentListOfNumber[j].Contains(currentNumber[0]) ||
                    !currentListOfNumber[j].Contains(currentNumber[1]) ||
                    !currentListOfNumber[j].Contains(currentNumber[2]) ||
                    !currentListOfNumber[j].Contains(currentNumber[3]))
                {
                    currentListOfNumber.Remove2(currentListOfNumber[j]);
                }
            }
        }




        public void RemoveNumber(List<int[]> currentListOfNumber, int[] currentNumber)
        {
            for (int j = 0; j < currentListOfNumber.Count; j++)
            {
                if (currentListOfNumber[j].Contains(currentNumber[0]) &&
                    currentListOfNumber[j].Contains(currentNumber[1]) &&
                    currentListOfNumber[j].Contains(currentNumber[2]) &&
                    currentListOfNumber[j].Contains(currentNumber[3]))
                {
                    currentListOfNumber.Remove2(currentListOfNumber[j]);
                }
            }
        }
        // 012 013 023 123
        public void RemoveEveryThreeElem(List<int[]> currentListOfNumber, int[] currentNumber)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int k = i + 1; k < 3; k++)
                {
                    for (int p = k + 1; p < 4; p++)
                        for (int j = 0; j < currentListOfNumber.Count; j++)
                        {
                            if (currentListOfNumber[j].Contains(currentNumber[i]) && currentListOfNumber[j].Contains(currentNumber[k])
                                    && currentListOfNumber[j].Contains(currentNumber[p]))
                            {
                                currentListOfNumber.Remove2(currentListOfNumber[j]);
                            }

                        }
                }

            }
        }
        // 01 02 03 12 13 23
        public void RemoveEveryTwoElem(List<int[]> currentListOfNumber, int[] currentNumber)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int k = i + 1; k < 4; k++)
                {
                    for (int j = 0; j < currentListOfNumber.Count; j++)
                    {
                        if (currentListOfNumber[j].Contains(currentNumber[i]) && currentListOfNumber[j].Contains(currentNumber[k]))
                        {
                            currentListOfNumber.Remove2(currentListOfNumber[j]);
                        }

                    }
                }

            }
        }



        public void RemoveArrayFromListFirstTypeZero(List<int[]> currentListOfNumber, int[] currentNumber) //видаляє всі масиви в яких є хлча бодна цифра
        {
            RemoveNumber(currentListOfNumber, currentNumber);
            RemoveOneOfFourIsPresentElem(currentListOfNumber, currentNumber);
        }

        public void RemoveArrayFromListSecondTypeOne(List<int[]> currentListOfNumber, int[] currentNumber) // більше одного елемента сходяться
        {
            RemoveEveryTwoElem(currentListOfNumber, currentNumber);
            RemoveEveryThreeElem(currentListOfNumber, currentNumber);
            RemoveNumber(currentListOfNumber, currentNumber);
        }


        public void RemoveArrayFromListThirdTypeTwo(List<int[]> currentListOfNumber, int[] currentNumber) //видаляє всі масиви в яких є хлча бодна цифра
        {
            RemoveNumber(currentListOfNumber, currentNumber);
            RemoveEveryThreeElem(currentListOfNumber, currentNumber);
        }


        public void RemoveArrayFromListFourthTypeThree(List<int[]> currentListOfNumber, int[] currentNumber)
        {
            //не може бути наявними тільки 2 з 4
            //якщо наявні тільки два елементи бо має бути хоча б якісь 3 з 4
            RemoveEveryTwoElem(currentListOfNumber, currentNumber);
            //якщо наявний тільки один елемент з 4 не може та бути
            RemoveOneOfFourIsPresentElem(currentListOfNumber, currentNumber);
        }

        public void RemoveArrayFromListFifthTypeFour(List<int[]> currentListOfNumber, int[] currentNumber)
        {
            RemoveAtLeastOneofFourIsAbsentElem(currentListOfNumber, currentNumber);
        }

        //як зібрати інформацію з data яку я буду заповнювати в табличці?
        public void ReadDataGridView()
        {

        }

    }

    public static class Extensions
    {
        public static void Remove2(this List<int[]> list, int[] number)
        {
            if (string.Join("", number) == "1234")
            {

            }
            list.Remove(number);
        }
    }
}
