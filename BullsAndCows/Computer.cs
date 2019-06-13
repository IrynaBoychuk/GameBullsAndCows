using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public class Computer
    {
        private int[] currentTurn;
        private List<int[]> currentNumberList;
        private BullsCows clBullsCows = new BullsCows();

        public Computer()
        {
            currentNumberList = clBullsCows.GenerateAllGameNumbers();
            //вибір першого ходу
            currentTurn= clBullsCows.RandomNumberFromCurrentList(currentNumberList);
        }

        public int[] GetTurn()
        {
            return currentTurn;
        }
         public void SetTurnAnswer(int bulls, int cows)
        {
            //вибір наступного ходу
            clBullsCows.ComputerAlgoritm(bulls, cows, currentNumberList, currentTurn);
            currentTurn = clBullsCows.RandomNumberFromCurrentList(currentNumberList);

        }
    }
}
