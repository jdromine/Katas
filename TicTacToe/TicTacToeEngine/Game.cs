using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeEngine
{
    public enum GameState
    {   
        Active = 1,
        PlayerXWins,
        PlayerOWins,
        Draw
    }

    public class Game
    {
        public List<Space> Board { get; set; }
        public Player PlayerX { get; set; }
        public Player PlayerO { get; set; }

        public Player ActivePlayer { get; set; }

        public int State;

        public Game(Player x, Player o)
        {
            this.PlayerX = x;
            this.PlayerO = o;
        }

        public void ResetGame()
        {
            this.Board = new List<Space>(){
                new Space(1,1),
                new Space(1,2),
                new Space(1,3),
                new Space(2,1),
                new Space(2,2),
                new Space(2,3),
                new Space(3,1),
                new Space(3,2),
                new Space(3,3)
            };

            this.ActivePlayer = this.PlayerX;
            this.State = (int)GameState.Active;
        }

        public void Play(int space)
        {
            if (this.Board[space].SpaceHolder != null)
            {
                throw new ArgumentOutOfRangeException("The requested space is occupied.  Please try again.");
            }
            else
            {
                this.Board[space].SpaceHolder = this.ActivePlayer;
                this.UpdateGameState();
                this.TransitionTurn();
            }
            
        }

        public void TransitionTurn()
        {
            if (this.ActivePlayer == this.PlayerO)
            {
                this.ActivePlayer = this.PlayerX;
            }
            else
            {
                this.ActivePlayer = this.PlayerO;
            }
        }

        public string GetActivePlayerName()
        {
            return this.ActivePlayer.Name;
        }
            
        private void UpdateGameState(){
            Player Winner = GetWinner();

            if (Winner != null)
            {
                if (Winner == this.PlayerX)
                {
                    this.State = (int)GameState.PlayerXWins;
                }
                else
                {
                    this.State = (int)GameState.PlayerOWins;
                }
            }
            else
            {
                if (this.isDraw())
                {
                    this.State = (int)GameState.Draw;
                }
                else
                {
                    this.State = (int)GameState.Active;
                }
            }
        }

        private Player GetWinner()
        {
            /* 
             * There may be a more elegant way to check for winners, but with the game board 
             * containing only nine spaces, this approach simplifie the logic required to determine
             * if there is a winner.
             */

            //Check for any horizontal winners
            Player winner = GetHorizontalWinner();

            //Check for any diagonal winners
            if (winner == null)
            {
                winner = GetDiagonalWinner();
            }

            //Check for any vertical winners
            if (winner == null)
            {
                winner = GetVerticalWinner();
            }

            return winner;
        }

        private Player GetDiagonalWinner()
        {
            Player winner = null;

            //Check diagonal from space 1
            List<Space> spaces = new List<Space>(){
                    GetSpace(1,1),
                    GetSpace(2,2),
                    GetSpace(3,3)
                };

            if (AllSpacesContainTheSamePlayer(spaces) == true)
            {
                winner = spaces[0].SpaceHolder;
            }
            //Check diagonal from space 3
            else
            {
                spaces = new List<Space>(){
                    GetSpace(3,1),
                    GetSpace(2,2),
                    GetSpace(1,3)
                };

                if (AllSpacesContainTheSamePlayer(spaces) == true)
                {
                    winner = spaces[0].SpaceHolder;
                }
            }

            return winner;
        }

        private Player GetHorizontalWinner()
        {
            Player winner = null;
            for (int y = 1; y < 4; y++)
            {
                List<Space> spaces = new List<Space>(){
                    GetSpace(1,y),
                    GetSpace(2,y),
                    GetSpace(3,y)
                };

                if (AllSpacesContainTheSamePlayer(spaces))
                {
                    winner = spaces[0].SpaceHolder;
                    break;
                }
            }

            return winner;
        }


        private Player GetVerticalWinner()
        {
            Player winner = null;
            for (int x = 1; x < 4; x++)
            {
                List<Space> spaces = new List<Space>(){
                    GetSpace(x,1),
                    GetSpace(x,2),
                    GetSpace(x,3)
                };

                if (AllSpacesContainTheSamePlayer(spaces))
                {
                    winner = spaces[0].SpaceHolder;
                    break;
                }
            }

            return winner;
        }

        private Space GetSpace(int x, int y)
        {
            var spaces = from s in this.Board
                         where s.X == x && s.Y == y
                         select s;

            return spaces.First();
        }

        private bool AllSpacesContainTheSamePlayer(List<Space> Spaces)
        {
            bool equal = false;

            if(Spaces.Count>1){
                for (int i = 1; i < Spaces.Count; i++)
                {
                    if (Spaces[i].SpaceHolder != null && Spaces[i-1].SpaceHolder != null && Spaces[i].SpaceHolder == Spaces[i - 1].SpaceHolder)
                    {
                        equal = true;
                    }
                    else
                    {
                        equal = false;
                        break;
                    }
                } 
            }

            return equal;
        }

        private bool isDraw()
        {
            int blankSpaceCount = 0;

            if (GetWinner() == null)
            {
                //check if there are any open spaces
                foreach (Space s in this.Board)
                {
                    if (s.SpaceHolder == null)
                    {
                        blankSpaceCount++;
                        break;
                    }
                }

                if (blankSpaceCount > 0)
                {
                    return false; // game is not over
                }
                else
                {
                    return true; // game ends in draw
                }
            }
            else
            {
                return false;
            }
        }

    }
}
