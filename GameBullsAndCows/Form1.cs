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

        public Form1()
        {
            InitializeComponent();
            textBox1.Enabled=false;
            GuessButton.Enabled = false;
        }
        

        private void NumerateRows()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }

        public int RandomSecretNumber()
        {
            Random MyRandom = new Random();
            return MyRandom.Next(0000, 9999);
        }

        private int secretNumber;
        private int[] secretNumberArray;
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Number is chosen. Start Guesing.");
            dataGridView1.Rows.Clear();
            textBox1.Clear();
            do
            {
                secretNumber = RandomSecretNumber();
                secretNumberArray = clBullsCows.SeparateInt(secretNumber);
            }
            while (!clBullsCows.ControlNumberAsResult(secretNumberArray));
            textBox1.Enabled = true;
            GuessButton.Enabled = true;

        }

        // private object secret;
        private void GuessButton_Click(object sender, EventArgs e)
        {
            string turnNumber = textBox1.Text;
            int[] turnNumberArray = clBullsCows.Separate(turnNumber);
            if(clBullsCows.ControlNumberAsResult(turnNumberArray))
            {
                dataGridView1.Rows.Add(turnNumber, clBullsCows.BullsCounter(turnNumberArray, secretNumberArray)
                    + " Bulls", clBullsCows.CowsCounter(turnNumberArray, secretNumberArray) + " Cows");
                NumerateRows();
                if (clBullsCows.BullsCounter(turnNumberArray, secretNumberArray) == 4)
                { MessageBox.Show("Congratulations!!!You win");

                    textBox1.Enabled = false;
                    GuessButton.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Not correct input.Try again.");
                textBox1.Clear();
            }
        }
    }
}
