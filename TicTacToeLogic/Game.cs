﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeModel
{
    public class Game : GetAiMove
    {
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
            getAiMove();
            playSquare();
        }

        private bool IsValidPlay()
        {
            return squaresPlayed[currentSquare] == "" && currentScoreSituation() == ScoreSituation.Continue;
        }

        private bool NeedAimove()
        {
            return IsOnePlayerGame && currentScoreSituation() == ScoreSituation.Continue;
        }

        public void playSquare()
        {
            squaresPlayed[currentSquare] = letterOfCurrentPlayerSide;
            turnNumber++;
            letterOfCurrentPlayerSide = switchPlayerSide(letterOfCurrentPlayerSide);
        }

        public void getFirstPlayer()
        {
            Random rnd = new Random();
            if (rnd.Next(0, 2) == 0)
            {
                firstPlayer = "player 1";
            }
            else
            {
                firstPlayer = "player 2";
            }
        }
    }
}