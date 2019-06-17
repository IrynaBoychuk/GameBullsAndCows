using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BullsAndCows;

namespace GameBullsAndCows
{
    public partial class Form1 : Form
    {
        private BullsCows clBullsCows = new BullsCows();
        private Computer Computer = new Computer();
        private int step = 0;

        public Form1()
        {
            InitializeComponent();
            textBox1.Enabled=false;
            GuessButton.Enabled = false;
            textBox2.Enabled = false;
            MySecretNumberButton.Enabled = false;
            PCGuessButton.Enabled = false;
        }
        

        private void NumerateRows()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }
        private void NumerateRows2()
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }

        public int RandomSecretNumber()
        {
            Random MyRandom = new Random();
            return MyRandom.Next(0000, 9999);
        }

        private int computerSecretNumber; 
        private int[] computerSecretNumberArray;
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Computer choose number. Your turn.");
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            textBox1.Clear();
            textBox2.Clear();
            step = 0;
            textBox2.Enabled = true;
            MySecretNumberButton.Enabled = true;
           
            do
            {
                computerSecretNumber = RandomSecretNumber();
                computerSecretNumberArray = clBullsCows.SeparateInt(computerSecretNumber);
                
            }
            while (!clBullsCows.ControlNumberAsResult(computerSecretNumberArray));

        }

        // private object secret;
        private void GuessButton_Click(object sender, EventArgs e)
        {
            //КРОК ГРАВЦЯ
            string turnNumber = textBox1.Text;
            int[] turnNumberArray = clBullsCows.Separate(turnNumber);
            if (clBullsCows.ControlNumberAsResult(turnNumberArray))
            {
                var bulls = clBullsCows.BullsCounter(turnNumberArray, computerSecretNumberArray);
                var cows = clBullsCows.CowsCounter(turnNumberArray, computerSecretNumberArray);
                dataGridView1.Rows.Add(turnNumber, bulls + " Bulls", cows + " Cows");
                NumerateRows();
                //КРОК КОМП'ЮТЕРА
                //компютер дає число
                int[] pcTurn = Computer.GetTurn();
                dataGridView2[0, step].Value = String.Join("", pcTurn);
                if (clBullsCows.BullsCounter(turnNumberArray, computerSecretNumberArray) == 4)
                { MessageBox.Show("Congratulations!!!You win");

                    textBox1.Enabled = false;
                    GuessButton.Enabled = false;
                    PCGuessButton.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Not correct input.Try again.");
                textBox1.Clear();
            }
        }


        private string mySecretNumber;
        private int[] mySecretNumberArray;

        private void MySecretNumberButton_Click(object sender, EventArgs e)
        {

            mySecretNumber = textBox2.Text;
            mySecretNumberArray = clBullsCows.Separate(mySecretNumber);
            
            if (!clBullsCows.ControlNumberAsResult(mySecretNumberArray))
            { 
                textBox2.Clear();
                MessageBox.Show("Not correct input.Try again.");
            }
           else
            {
                MessageBox.Show("Start guesing.");
                textBox1.Enabled = true;
                GuessButton.Enabled = true;
                textBox2.Enabled = false;
                PCGuessButton.Enabled = true;
                
            }
        }

        private void PCGuessButton_Click(object sender, EventArgs e)
        {
            
            //Функція Алгоритму комп`ютера для зменшення лісту з варіантами
            int bullsCounter = 0;
            int cowsCounter = 0;
            //Відповідь гравця компютеру : к-сть корів та биків
            bullsCounter = Convert.ToInt32(dataGridView2[1, step].Value);
            cowsCounter = Convert.ToInt32(dataGridView2[2, step].Value);
            step++;
            Computer.SetTurnAnswer(bullsCounter, cowsCounter);
            NumerateRows2();
            if (bullsCounter == 4)
            {
                MessageBox.Show("You lose!!!Computer win");
                textBox1.Enabled = false;
                GuessButton.Enabled = false;
                PCGuessButton.Enabled = false;
            }
        }
    }
}
