using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeModel
{
    public class ScoreSituationSetter
    {
        private Game game;
        private ScoreSituation _currentScoreSituation;
        private int[][] winningIndexSequences = new int[][] {
                new int[] { 0, 1, 2 },
                new int[] { 3, 4, 5 },
                new int[] { 6, 7, 8 },
                new int[] { 0, 3, 6 },
                new int[] { 1, 4, 7 },
                new int[] { 2, 5, 8 },
                new int[] { 0, 4, 8 },
                new int[] { 2, 4, 6 }
            };

        public ScoreSituationSetter(Game game)
        {
            this.game = game;
        }

        public int[][] WinningIndexSequences
        {
            get { return winningIndexSequences; }
        }

        public ScoreSituation SetCurrentScoreSituation()
        {
            _currentScoreSituation = ScoreSituation.Continue;
            checkForWin();
            checkForDraw();
            return _currentScoreSituation;
        }

        private void checkForWin()
        {
            if (game.TurnNumber >= 4)
            {
                foreach (var w in winningIndexSequences)
                {
                    if (game.SquaresPlayed[w[0]] + game.SquaresPlayed[w[1]] + game.SquaresPlayed[w[2]]
                        == game.LetterOfCurrentPlayerSide + game.LetterOfCurrentPlayerSide + game.LetterOfCurrentPlayerSide)
                    {
                        _currentScoreSituation = ScoreSituation.Win;
                    }
                }
            }
        }

        private void checkForDraw()
        {
            if (game.TurnNumber == 8 && _currentScoreSituation == ScoreSituation.Continue)
            {
                _currentScoreSituation = ScoreSituation.Draw;
            }
        }
    }
}
