using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Tic_tac_Toe_Game_by_Rahul_Semwal
{
    public partial class Form1 : Form
    {

        public enum Player
        {

            X, O

        }



        Player CurrentPlayer;
        Random random = new Random();
        int PlayerWinCount = 0;
        int CpuWinCount = 0;
        List<Button> buttons;


        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

  
        
        private void CPUmove(object sender, EventArgs e)
        {
            
            if (buttons.Count > 0)
            {
               
               int index = random.Next(buttons.Count);
                buttons[index].Enabled = false;
                CurrentPlayer = Player.O;
                buttons[index].Text = CurrentPlayer.ToString();
                buttons[index].BackColor = Color.Crimson;
                buttons.RemoveAt(index);
                CheckGame();
                CpuTimer.Stop();

            }

            else  { 
                    MessageBox.Show("Match Draw","Rahul Says");
                    RestartGame();
             
            }
        }

        

        
        private void PlayerclickButton(object sender, EventArgs e)
        {
          
            
            var button = (Button)sender;
            CurrentPlayer = Player.X;
            button.Text = CurrentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.CornflowerBlue;
            buttons.Remove(button);
              CheckGame();
              CpuTimer.Start();


            



        }
        

        private void GameRestart(object sender, EventArgs e)
        {
            RestartGame();
        }

        
        private void CheckGame()
        {

            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X" 
                ||button4.Text == "X" && button5.Text == "X" && button6.Text == "X" 
                ||button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
                ||button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
                ||button3.Text == "X" && button5.Text == "X" && button7.Text == "X"
                ||button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
                ||button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
                ||button3.Text == "X" && button6.Text == "X" && button9.Text == "X"  )
   
            {

                CpuTimer.Stop();
                MessageBox.Show("Player wins ", "Rahul  Says");
                PlayerWinCount++;
                label1.Text = "Player Wins "  +PlayerWinCount;
                RestartGame();

            }

           else  if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
                     ||button4.Text == "O" && button5.Text == "O" && button6.Text == "O" 
                     ||button7.Text == "O" && button8.Text == "O" && button9.Text == "O" 
                     ||button1.Text == "O" && button5.Text == "O" && button9.Text == "O" 
                     ||button3.Text == "O" && button5.Text == "O" && button7.Text == "O"
                     ||button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
                     ||button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
                     ||button3.Text == "O" && button6.Text == "O" && button9.Text == "O" )


            {
                CpuTimer.Stop();
                MessageBox.Show("CPU wins ", "Rahul Says");
                CpuWinCount++;
                label2.Text = "CPU Wins " + CpuWinCount;
                RestartGame();


            }


        }
        

      
        
        private void RestartGame()
        {

            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9};

            foreach (Button x in buttons)
            {
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;


            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Reset(object sender, EventArgs e)
        {
           this.PlayerWinCount = 0;
           this. CpuWinCount = 0;

            label1.Text = "Player Wins:";
            label2.Text = "CPU Wins:";

            RestartGame();
        }
    }
}