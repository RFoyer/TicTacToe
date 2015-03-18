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
        public string difficultyLevel { get; set; }
        public bool IsOnePlayerGame { get; set; }
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
        private ScoreSituation _currentScoreSituation;
        
        public ScoreSituation currentScoreSituation()
        {
            _currentScoreSituation = ScoreSituation.Continue;
            checkForWin();
            checkForDraw();

            return _currentScoreSituation;
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
                        _currentScoreSituation = ScoreSituation.Win;
                    }
                }
            }
        }

        private void checkForDraw()
        {
            if (turnNumber == 8)
            {
                _currentScoreSituation = ScoreSituation.Draw;
            }
        }

    }
}
