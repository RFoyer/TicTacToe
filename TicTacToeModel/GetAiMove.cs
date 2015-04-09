using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeModel
{
    public class GetAiMove
    {
        private List<Action> mediumDifficultyAi;
        private List<Action> unbeatableDifficultyAi;
        private Game game;
        private int[] fourCorners = { 0, 2, 6, 8 };
        
        public GetAiMove(Game game)
        {
            this.game = game;
            mediumDifficultyAi = new List<Action>();
            unbeatableDifficultyAi = new List<Action>();
            mediumDifficultyAi.Add(() => checkForWin());
            mediumDifficultyAi.Add(() => checkForBlock());
            mediumDifficultyAi.Add(() => checkForCenter());
            mediumDifficultyAi.Add(() => getRandomMove());
            unbeatableDifficultyAi.Add(() => checkForWin());
            unbeatableDifficultyAi.Add(() => checkForBlock());
            unbeatableDifficultyAi.Add(() => game.Fork.CheckForWinningFork());
            unbeatableDifficultyAi.Add(() => game.Fork.CheckForForkBlock());
            unbeatableDifficultyAi.Add(() => checkForCenter());
            unbeatableDifficultyAi.Add(() => checkForCorner());
            unbeatableDifficultyAi.Add(() => getRandomMove());
        }

        public List<int> AiMoveCandidates { get; set; }
        
        public void getAiMove()
        {
            switch (game.DifficultyLevel)
            {
                case "easy":
                    getRandomMove();
                    break;
                case "medium":
                    playAiMove(mediumDifficultyAi);
                    break;
                case "unbeatable":
                    playAiMove(unbeatableDifficultyAi);
                    break;
                default:
                    playAiMove(unbeatableDifficultyAi);
                    break;
            }
        }

        private void playAiMove(List<Action> currentDifficultyLevelAlgorithm)
        {
            game.LetterOfOpposingPlayerSide = game.switchPlayerSide(game.LetterOfCurrentPlayerSide);

            foreach (var a in currentDifficultyLevelAlgorithm)
            {
                AiMoveCandidates = new List<int>();
                a.Invoke();
                if (AiMoveCandidates.Count > 0)
                {
                    chooseMoveCandidate();
                    return;
                }
            }
        }

        private void checkForWin()
        {
            foreach (var w in game.Score.WinningIndexSequences)
            {
                if (game.SquaresPlayed[w[0]] + game.SquaresPlayed[w[1]] + game.SquaresPlayed[w[2]] == game.LetterOfCurrentPlayerSide + game.LetterOfCurrentPlayerSide)
                {
                    foreach (var s in w)
                    {
                        if (game.SquaresPlayed[s] == "")
                        {
                            AiMoveCandidates.Add(s);
                        }
                    }
                }

            }
        }

        private void checkForBlock()
        {
            foreach (var w in game.Score.WinningIndexSequences)
            {
                if (game.SquaresPlayed[w[0]] + game.SquaresPlayed[w[1]] + game.SquaresPlayed[w[2]]
                    == game.LetterOfOpposingPlayerSide + game.LetterOfOpposingPlayerSide)
                {
                    foreach (var s in w)
                    {
                        if (game.SquaresPlayed[s] == "")
                        {
                            AiMoveCandidates.Add(s);
                        }
                    }
                }
            }
        }

        private void checkForCenter()
        {
            if (game.SquaresPlayed[4] == "")
            {
                AiMoveCandidates.Add(4);
            }
        }

        private void checkForCorner()
        {
            foreach (var c in fourCorners)
            {
                if (game.SquaresPlayed[c] == "")
                {
                    AiMoveCandidates.Add(c);
                }
            }
        }

        private int getRandomIndex(int numberOfIndices)
        {
            Random rnd = new Random();
            int randomindex = rnd.Next(0, numberOfIndices);
            return randomindex;
        }

        private void chooseMoveCandidate()
        {
            if (AiMoveCandidates.Count == 1)
            {
                game.CurrentSquare = AiMoveCandidates[0];
            }
            if (AiMoveCandidates.Count > 1)
            {
                game.CurrentSquare = AiMoveCandidates[getRandomIndex(AiMoveCandidates.Count)];
            }
        }

        private void getRandomMove()
        {
            do
            {
                game.CurrentSquare = getRandomIndex(9);
            } while (game.SquaresPlayed[game.CurrentSquare] != "");
        }
    }
}
