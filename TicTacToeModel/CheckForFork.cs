using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeModel
{
    public class CheckForFork
    {
        private Game game;
        private string letterOfForkingSide;
        private int[] fourCenterEdges = { 1, 3, 5, 7 };
        private List<int[]> potentialForkSequences = new List<int[]>();
        private List<int[][]> forkSequencesForEachBoardIndex = new List<int[][]>()
        {
            new int[][] { new int[] { 0, 1, 2 }, new int[] { 0, 3, 6 }, new int[] { 0, 4, 8 } },
            new int[][] { new int[] { 1, 0, 2 }, new int[] { 1, 4, 7 } },
            new int[][] { new int[] { 2, 1, 0 }, new int[] { 2, 5, 8 }, new int[] { 2, 4, 6 } },
            new int[][] { new int[] { 3, 4, 5 }, new int[] { 3, 0, 6 } },
            new int[][] { new int[] { 4, 3, 5 }, new int[] { 4, 1, 7 }, new int[] { 4, 0, 8 }, new int[] { 4, 2, 6 } },
            new int[][] { new int[] { 5, 3, 4 }, new int[] { 5, 2, 8 } },
            new int[][] { new int[] { 6, 7, 8 }, new int[] { 6, 0, 3 }, new int[] { 6, 2, 4 } },
            new int[][] { new int[] { 7, 6, 8 }, new int[] { 7, 1, 4 } },
            new int[][] { new int[] { 8, 6, 7 }, new int[] { 8, 2, 5 }, new int[] { 8, 0, 4 } }
        };
        
        public CheckForFork(Game game)
        {
            this.game = game;
        }

        public void CheckForWinningFork()
        {
            if (game.TurnNumber >= 4)
            {
                letterOfForkingSide = game.LetterOfCurrentPlayerSide;
                foreach (var s in forkSequencesForEachBoardIndex)
                {
                    CheckForkSequencesForEachBoardIndex(s);
                }
            }
        }

        public void CheckForForkBlock()
        {
            if (game.TurnNumber >= 3)
            {
                letterOfForkingSide = game.LetterOfOpposingPlayerSide;
                foreach (var s in forkSequencesForEachBoardIndex)
                {
                    CheckForkSequencesForEachBoardIndex(s);
                }
                CheckforDoubleForkSituation();
            }
        }

        private void CheckForkSequencesForEachBoardIndex(int[][] forkSequencesAtCurrentIndex)
        {
            potentialForkSequences = new List<int[]>();

            foreach (var t in forkSequencesAtCurrentIndex)
            {
                if (game.SquaresPlayed[t[0]] == "")
                {
                    CheckSequenceForPotentialFork(t);
                    CheckPotentialForksForActualFork(t[0]);
                }
            }
        }

        private void CheckSequenceForPotentialFork(int[] sequenceToCheck)
        {
            if (IsPotentialForkSequence(sequenceToCheck))
            {
                potentialForkSequences.Add(sequenceToCheck);
            }

        }

        private bool IsPotentialForkSequence(int[] sequenceToCheck)
        {
            return game.SquaresPlayed[sequenceToCheck[0]] + game.SquaresPlayed[sequenceToCheck[1]] + game.SquaresPlayed[sequenceToCheck[2]]
                == letterOfForkingSide;
        }

        private void CheckPotentialForksForActualFork(int potentialForkIndex)
        {
            if (potentialForkSequences.Count == 2)
            {
                AddUniqueAiMoveCandidate(potentialForkIndex);
            }
        }

        private void CheckforDoubleForkSituation()
        {
            if (game.Ai.AiMoveCandidates.Count == 2)
            {
                game.Ai.AiMoveCandidates = new List<int>();
                CheckForEdge();
            }
        }

        public void CheckForEdge()
        {
            foreach (var e in fourCenterEdges)
            {
                if (game.SquaresPlayed[e] == "")
                {
                    game.Ai.AiMoveCandidates.Add(e);
                }
            }
        }

        public void AddUniqueAiMoveCandidate(int potentialAiMoveCandidate)
        {
            if (game.Ai.AiMoveCandidates.Contains(potentialAiMoveCandidate) == false)
            {
                game.Ai.AiMoveCandidates.Add(potentialAiMoveCandidate);
            }
        }
    }
}
