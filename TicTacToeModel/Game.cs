using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeModel
{
    public class Game
    {
        public Game()
        {
            Score = new ScoreSituationSetter(this);
            Fork = new CheckForFork(this);
            Ai = new GetAiMove(this);
            CurrentScoreSituation = ScoreSituation.Continue;
            SquaresPlayed = new List<string>() { "", "", "", "", "", "", "", "", "" };
        }

        public int CurrentSquare { get; set; }
        public int TurnNumber { get; set; }
        public string LetterOfCurrentPlayerSide { get; set; }
        public string LetterOfOpposingPlayerSide { get; set; }
        public string DifficultyLevel { get; set; }
        public bool IsOnePlayerGame { get; set; }
        public bool IsComputerPlaysFirst { get; set; }
        public bool IsStartingPlayerRandom { get; set; }
        public ScoreSituation CurrentScoreSituation { get; set; }
        public List<string> SquaresPlayed { get; set; }
        public ScoreSituationSetter Score { get; set; }
        public CheckForFork Fork { get; set; }
        public GetAiMove Ai { get; set; }
        
        public void squareSelectionAttempt()
        {
            if (IsValidPlay())
            {
                playSquare();
                if (NeedAimove())
                {
                    playAiMove();
                }
            }
        }

        public void playAiMove()
        {
            Ai.getAiMove();
            playSquare();
        }

        private bool IsValidPlay()
        {
            return SquaresPlayed[CurrentSquare] == "" && CurrentScoreSituation == ScoreSituation.Continue;
        }

        private bool NeedAimove()
        {
            return IsOnePlayerGame && CurrentScoreSituation == ScoreSituation.Continue;
        }

        public void playSquare()
        {
            SquaresPlayed[CurrentSquare] = LetterOfCurrentPlayerSide;
            CurrentScoreSituation = Score.SetCurrentScoreSituation();
            if (CurrentScoreSituation == ScoreSituation.Continue)
            {
                LetterOfCurrentPlayerSide = switchPlayerSide(LetterOfCurrentPlayerSide);
                TurnNumber++;
            }
        }
        
        public string switchPlayerSide(string playerSide)
        {
            var nextPlayerSide = "";
            if (playerSide == "X")
            {
                nextPlayerSide = "O";
            }
            else
            {
                nextPlayerSide = "X";
            }
            return nextPlayerSide;
        }

        public void getFirstPlayer()
        {
            Random rnd = new Random();
            if (rnd.Next(0, 2) == 0)
            {
                IsComputerPlaysFirst = true;
            }
            else
            {
                IsComputerPlaysFirst = false;
            }
        }
    }
}
