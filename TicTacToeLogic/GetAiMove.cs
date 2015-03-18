using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeModel
{
    public class GetAiMove : CheckForFork
    {

        private int[] _fourCorners = { 0, 2, 6, 8 };
        private List<Action> _mediumDifficultyAlgorithm = new List<Action>();
        private List<Action> _unbeatableDifficultyAlgorithm = new List<Action>();

        public GetAiMove()
        {
            _mediumDifficultyAlgorithm.Add(() => checkForWin());
            _mediumDifficultyAlgorithm.Add(() => checkForBlock());
            _mediumDifficultyAlgorithm.Add(() => checkForCenter());
            _mediumDifficultyAlgorithm.Add(() => getRandomMove());
            _unbeatableDifficultyAlgorithm.Add(() => checkForWin());
            _unbeatableDifficultyAlgorithm.Add(() => checkForBlock());
            _unbeatableDifficultyAlgorithm.Add(() => checkForWinningFork());
            _unbeatableDifficultyAlgorithm.Add(() => checkForForkBlock());
            _unbeatableDifficultyAlgorithm.Add(() => checkForCenter());
            _unbeatableDifficultyAlgorithm.Add(() => checkForCorner());
            _unbeatableDifficultyAlgorithm.Add(() => getRandomMove());
            
        }

        public void getAiMove()
        {
            switch (difficultyLevel)
            {
                case "easy":
                    getRandomMove();
                    break;
                case "medium":
                    playAiMove(_mediumDifficultyAlgorithm);
                    break;
                case "unbeatable":
                    playAiMove(_unbeatableDifficultyAlgorithm);
                    break;
                default:
                    playAiMove(_unbeatableDifficultyAlgorithm);
                    break;
            }
        }

        private void playAiMove(List<Action> currentDifficultyLevelAlgorithm)
        {
            letterOfOpposingPlayerSide = switchPlayerSide(letterOfCurrentPlayerSide);

            foreach (var a in currentDifficultyLevelAlgorithm)
            {
                aiMoveCandidates = new List<int>();
                a.Invoke();
                if (aiMoveCandidates.Count > 0)
                {
                    chooseMoveCandidate();
                    return;
                }
            }
        }

        private void checkForWin()
        {
            foreach (var w in winningIndexSequences)
            {
                if (squaresPlayed[w[0]] + squaresPlayed[w[1]] + squaresPlayed[w[2]] == letterOfCurrentPlayerSide + letterOfCurrentPlayerSide)
                {
                    foreach (var s in w)
                    {
                        if (squaresPlayed[s] == "")
                        {
                            aiMoveCandidates.Add(s);
                        }
                    }
                }

            }
        }

        private void checkForBlock()
        {
            foreach (var w in winningIndexSequences)
            {
                if (squaresPlayed[w[0]] + squaresPlayed[w[1]] + squaresPlayed[w[2]]
                    == letterOfOpposingPlayerSide + letterOfOpposingPlayerSide)
                {
                    foreach (var s in w)
                    {
                        if (squaresPlayed[s] == "")
                        {
                            aiMoveCandidates.Add(s);
                        }
                    }
                }
            }
        }

        private void checkForCenter()
        {
            if (squaresPlayed[4] == "")
            {
                aiMoveCandidates.Add(4);
            }
        }

        private void checkForCorner()
        {
            foreach (var c in _fourCorners)
            {
                if (squaresPlayed[c] == "")
                {
                    aiMoveCandidates.Add(c);
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
            if (aiMoveCandidates.Count == 1)
            {
                currentSquare = aiMoveCandidates[0];
            }
            if (aiMoveCandidates.Count > 1)
            {
                currentSquare = aiMoveCandidates[getRandomIndex(aiMoveCandidates.Count)];
            }
        }

        private void getRandomMove()
        {
            do
            {
                currentSquare = getRandomIndex(9);
            } while (squaresPlayed[currentSquare] != "");
        }

        public string switchPlayerSide(string playerSide)
        {
            var nextPlayerSide = "";
            if (nextPlayerSide == "X")
            {
                nextPlayerSide = "O";
            }
            else
            {
                nextPlayerSide = "X";
            }
            return nextPlayerSide;
        }
    }
}
