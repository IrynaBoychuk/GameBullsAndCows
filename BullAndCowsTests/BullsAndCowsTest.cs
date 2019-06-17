using System;
using BullsAndCows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace BullAndCows.Tests
{
    [TestClass]
    public class BullsAndCowsTest
    {
        [TestMethod]
        public void Separation1234()
        {
            // arrange-nastroiti
            string x = "1234";
            int[] expacted = { 1, 2, 3, 4 };
            BullsCows c = new BullsCows();

            //act
            int[] actual = c.Separate(x);
            // assert right or no 
            Assert.AreEqual(expacted[0], actual[0]);
            Assert.AreEqual(expacted[1], actual[1]);
            Assert.AreEqual(expacted[2], actual[2]);
            Assert.AreEqual(expacted[3], actual[3]);
        }


        [TestMethod]
        public void CowsCounter1234c3()
        {
            // arrange-nastroiti
            int[] secretNumber = { 1, 2, 3, 4 };
            int[] turnNumber = { 2, 3, 4, 5 };
            int expected=3;

            BullsCows c = new BullsCows();
            //act
            int actual = c.CowsCounter(turnNumber,secretNumber);
            // assert right or no 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BullsCounter1234c3()
        {
            // arrange-nastroiti
            int[] secretNumber = { 1, 2, 3, 4 };
            int[] turnNumber = { 6, 3, 4, 5 };
            int expected = 0;

            BullsCows c = new BullsCows();
            //act
            int actual = c.BullsCounter(turnNumber, secretNumber);
            // assert right or no 
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CowsCounter5678b4()
        {
            // arrange-nastroiti
            int[] secretNumber = { 5,6,7,8 };
            int[] turnNumber = { 5, 6, 7, 8 };
            int expected = 0;

            BullsCows c = new BullsCows();
            //act
            int actual = c.CowsCounter(turnNumber, secretNumber);
            // assert right or no 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BullsCounter5678b4()
        {
            // arrange-nastroiti
            int[] secretNumber = { 5,6,7,8 };
            int[] turnNumber = { 5, 6, 7, 8 };
            int expected = 4;

            BullsCows c = new BullsCows();
            //act
            int actual = c.BullsCounter(turnNumber, secretNumber);
            // assert right or no 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CowsCounter8097c0b0()
        {
            // arrange-nastroiti
            int[] secretNumber = { 8, 0, 9, 7 };
            int[] turnNumber = { 5, 6, 3, 4 };
            int expected = 0;

            BullsCows c = new BullsCows();
            //act
            int actual = c.CowsCounter(turnNumber, secretNumber);
            // assert right or no 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BullsCounter8097c0b0()
        {
            // arrange-nastroiti
            int[] secretNumber = { 8, 0, 9, 7 };
            int[] turnNumber = { 5, 6, 3, 4 };
            int expected = 0;

            BullsCows c = new BullsCows();
            //act
            int actual = c.BullsCounter(turnNumber, secretNumber);
            // assert right or no 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CowsCounter4321c4()
        {
            // arrange-nastroiti
            int[] secretNumber = { 4,3,2,1};
            int[] turnNumber = { 3,2,1,4 };
            int expected = 4;

            BullsCows c = new BullsCows();
            //act
            int actual = c.CowsCounter(turnNumber, secretNumber);
            // assert right or no 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BullsCounter4321c4()
        {
            // arrange-nastroiti
            int[] secretNumber = { 4, 3, 2, 1 };
            int[] turnNumber = { 3,2,1,4 };
            int expected = 0;

            BullsCows c = new BullsCows();
            //act
            int actual = c.BullsCounter(turnNumber, secretNumber);
            // assert right or no 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CowsCounter4321c2b2()
        {
            // arrange-nastroiti
            int[] secretNumber = { 4, 3, 2, 1 };
            int[] turnNumber = { 4,3, 1, 2 };
            int expected = 2;

            BullsCows c = new BullsCows();
            //act
            int actual = c.CowsCounter(turnNumber, secretNumber);
            // assert right or no 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BullsCounter4321c2b2()
        {
            // arrange-nastroiti
            int[] secretNumber = { 4, 3, 2, 1 };
            int[] turnNumber = { 4, 3, 1, 2 };
            int expected = 2;

            BullsCows c = new BullsCows();
            //act
            int actual = c.BullsCounter(turnNumber, secretNumber);
            // assert right or no 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CowsCounter4321c2b1()
        {
            // arrange-nastroiti
            int[] secretNumber = { 4, 3, 2, 1 };
            int[] turnNumber = { 4, 5, 1, 2 };
            int expected = 2;

            BullsCows c = new BullsCows();
            //act
            int actual = c.CowsCounter(turnNumber, secretNumber);
            // assert right or no 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BullsCounter4321c2b1()
        {
            // arrange-nastroiti
            int[] secretNumber = { 4, 3, 2, 1 };
            int[] turnNumber = { 4, 5, 1, 2 };
            int expected = 1;

            BullsCows c = new BullsCows();
            //act
            int actual = c.BullsCounter(turnNumber, secretNumber);
            // assert right or no 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ControlLength()
        {
            // arrange-nastroiti
            int[] turnNumber = { 4,5,6,7,8};
            string  expected = BullsCows.INCORRECT_LENGTH;

            BullsCows c = new BullsCows();
            //act
            string actual = c.ControlNumber(turnNumber);
            // assert right or no 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ControlRepeat()
        {
            // arrange-nastroiti
            int[] turnNumber = { 4, 5, 6, 4 };
            string expected = BullsCows.REPEAT_NUMBER;

            BullsCows c = new BullsCows();
            //act
            string actual = c.ControlNumber(turnNumber);
            // assert right or no 
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ControlRepeat4()
        {
            // arrange-nastroiti
            int[] turnNumber = { 4, 4, 4, 4 };
            string expected = BullsCows.REPEAT_NUMBER;

            BullsCows c = new BullsCows();
            //act
            string actual = c.ControlNumber(turnNumber);
            // assert right or no 
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ControlCorrect()
        {
            // arrange-nastroiti
            int[] turnNumber = { 1,2,3,4};
            string expected = BullsCows.GOOD_MESSAGE;

            BullsCows c = new BullsCows();
            //act
            string actual = c.ControlNumber(turnNumber);
            // assert right or no 
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void ControlZero()
        {
            // arrange-nastroiti
            int[] turnNumber = { 0, 5, 6, 8};
            string expected = BullsCows.ZERO_START;

            BullsCows c = new BullsCows();
            //act
            string actual = c.ControlNumber(turnNumber);
            // assert right or no 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GenerateAllGameNumbersCorrect()
        {
            // arrange-nastroiti
            var expected = 9 * 9 * 8 * 7;
            BullsCows c = new BullsCows();
            //act
            var actual = c.GenerateAllGameNumbers();
            // assert right or no 
            Assert.AreEqual(expected, actual.Count);
        }

        

    }
}
