using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeModel
{
    public class GetAiMove
    {
        private List<Action> mediumDifficultyAi_ComputerPlaysFirst;
        private List<Action> unbeatableDifficultyAi_ComputerPlaysFirst;
        private List<Action> mediumDifficultyAi_ComputerPlaysSecond;
        private List<Action> unbeatableDifficultyAi_ComputerPlaysSecond;
        private Game game;
        private int[] fourCorners = { 0, 2, 6, 8 };
        
        public GetAiMove(Game game)
        {
            this.game = game;
            mediumDifficultyAi_ComputerPlaysSecond = new List<Action>();
            unbeatableDifficultyAi_ComputerPlaysSecond = new List<Action>();
            mediumDifficultyAi_ComputerPlaysSecond.Add(() => checkForWin());
            mediumDifficultyAi_ComputerPlaysSecond.Add(() => checkForBlock());
            mediumDifficultyAi_ComputerPlaysSecond.Add(() => checkForCenter());
            mediumDifficultyAi_ComputerPlaysSecond.Add(() => getRandomMove());
            unbeatableDifficultyAi_ComputerPlaysSecond.Add(() => checkForWin());
            unbeatableDifficultyAi_ComputerPlaysSecond.Add(() => checkForBlock());
            unbeatableDifficultyAi_ComputerPlaysSecond.Add(() => game.Fork.CheckForWinningFork());
            unbeatableDifficultyAi_ComputerPlaysSecond.Add(() => game.Fork.CheckForForkBlock());
            unbeatableDifficultyAi_ComputerPlaysSecond.Add(() => checkForCenter());
            unbeatableDifficultyAi_ComputerPlaysSecond.Add(() => checkForCorner());
            unbeatableDifficultyAi_ComputerPlaysSecond.Add(() => getRandomMove());
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
                    playAiMove(mediumDifficultyAi_ComputerPlaysSecond);
                    break;
                case "unbeatable":
                    playAiMove(unbeatableDifficultyAi_ComputerPlaysSecond);
                    break;
                default:
                    playAiMove(unbeatableDifficultyAi_ComputerPlaysSecond);
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
