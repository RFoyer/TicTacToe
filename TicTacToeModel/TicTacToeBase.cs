using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeModel
{
    public enum ScoreSituation { Win, Draw, Continue };

    public abstract class TicTacToeBase
    {
        public int currentSquare { get; set; }
        public int turnNumber { get; set; }
        public string letterOfCurrentPlayerSide { get; set; }
        public static string difficultyLevel { get; set; }
        public static bool isOnePlayerGame { get; set; }
        public string firstPlayer { get; set; }
        private List<string> _squaresPlayed = new List<string>() { "", "", "", "", "", "", "", "", "" };
        public List<string> squaresPlayed
        {
            get { return _squaresPlayed; }
            set { _squaresPlayed = value; }
        }
        private int[][] _winningIndexSequences = new int[][] {
                new int[] { 0, 1, 2 },
                new int[] { 3, 4, 5 },
                new int[] { 6, 7, 8 },
                new int[] { 0, 3, 6 },
                new int[] { 1, 4, 7 },
                new int[] { 2, 5, 8 },
                new int[] { 0, 4, 8 },
                new int[] { 2, 4, 6 }
            };
        public int[][] winningIndexSequences
        {
            get { return _winningIndexSequences; }
        }
        public ScoreSituation currentScoreSituation { get; set; }

        public void setCurrentScoreSituation()
        {
            currentScoreSituation = ScoreSituation.Continue;
            checkForWin();
            checkForDraw();
        }

        private void checkForWin()
        {
            if (turnNumber >= 4)
            {
                foreach (var w in winningIndexSequences)
                {
                    if (squaresPlayed[w[0]] + squaresPlayed[w[1]] + squaresPlayed[w[2]]
                        == letterOfCurrentPlayerSide + letterOfCurrentPlayerSide + letterOfCurrentPlayerSide)
                    {
                        currentScoreSituation = ScoreSituation.Win;
                    }
                }
            }
        }

        private void checkForDraw()
        {
            if (turnNumber == 8 && currentScoreSituation == ScoreSituation.Continue)
            {
                currentScoreSituation = ScoreSituation.Draw;
            }
        }

    }
}
