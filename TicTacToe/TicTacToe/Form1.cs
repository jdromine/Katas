using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeEngine;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private Game TicTacToeGame;
        private string ActivePlayerName;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Player x = new Player("X");
            Player o = new Player("O");
            TicTacToeGame = new Game(x, o);
            this.ResetGame();
        }

        private void SetPlayer()
        {
            this.ActivePlayerName = this.TicTacToeGame.GetActivePlayerName(); 
            this.lblActiveTurn.Text = this.ActivePlayerName;
        }

        private void ResetGame()
        {
            this.TicTacToeGame.ResetGame();
            this.lblWinner.Text = "";
            this.btnSpace1.Text = "";
            this.btnSpace2.Text = "";
            this.btnSpace3.Text = "";
            this.btnSpace4.Text = "";
            this.btnSpace5.Text = "";
            this.btnSpace6.Text = "";
            this.btnSpace7.Text = "";
            this.btnSpace8.Text = "";
            this.btnSpace9.Text = "";
            this.SetPlayer();
        }

        private void Play(int space, object sender)
        {
            if (TicTacToeGame.State == (int)GameState.Active)
            {
                try
                {
                    this.TicTacToeGame.Play(space);

                    if (sender.GetType() == typeof(Button))
                    {
                        Button btn = (Button)sender;
                        btn.Text = this.ActivePlayerName;
                    }

                    this.CheckGameState();
                    this.SetPlayer();
                }
                catch
                {
                    MessageBox.Show("The space you selected is invalid.  Please try again.");
                }
            }
            else
            {
                MessageBox.Show("I am sorry this is not an active game.  Press reset to start a new game.");
            }

        }
        private void CheckGameState()
        {
            if (this.TicTacToeGame.State == (int)GameState.PlayerXWins){
                this.lblWinner.Text = this.TicTacToeGame.PlayerX.Name + " wins!";
            } else if(this.TicTacToeGame.State == (int)GameState.PlayerOWins){
                this.lblWinner.Text = this.TicTacToeGame.PlayerO.Name;
            }
        }


        private void btnSpace1_Click(object sender, EventArgs e)
        {
            this.Play(0, sender);
        }

        private void btnSpace2_Click(object sender, EventArgs e)
        {
            this.Play(1, sender);
        }

        private void btnSpace3_Click(object sender, EventArgs e)
        {
            this.Play(2, sender);
        }

        private void btnSpace4_Click(object sender, EventArgs e)
        {
            this.Play(3, sender);
        }

        private void btnSpace5_Click(object sender, EventArgs e)
        {
            this.Play(4, sender);
        }

        private void btnSpace6_Click(object sender, EventArgs e)
        {
            this.Play(5, sender);
        }

        private void btnSpace7_Click(object sender, EventArgs e)
        {
            this.Play(6, sender);
        }

        private void btnSpace8_Click(object sender, EventArgs e)
        {
            this.Play(7, sender);
        }

        private void btnSpace9_Click(object sender, EventArgs e)
        {
            this.Play(8, sender);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.ResetGame();
        }

    }
}
