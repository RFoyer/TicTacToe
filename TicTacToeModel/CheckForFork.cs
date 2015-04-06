using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeModel
{
    public abstract class CheckForFork : TicTacToeBase
    {
        public string letterOfOpposingPlayerSide { get; set; }
        private List<int> _aiMoveCandidates = new List<int>();
        private int[] _fourCenterEdges = { 1, 3, 5, 7 };
        public int[] fourCenterEdges
        {
            get { return _fourCenterEdges; }
        }
        public List<int> aiMoveCandidates
        {
            get { return _aiMoveCandidates; }
            set { _aiMoveCandidates = value; }
        }
        private string _letterOfForkingSide;
        private List<int[]> potentialForkSequences = new List<int[]>();
        private List<int[][]> _forkSequencesForEachBoardIndex = new List<int[][]>()
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

        public void checkForWinningFork()
        {
            if (turnNumber >= 4)
            {
                _letterOfForkingSide = letterOfCurrentPlayerSide;
                foreach (var s in _forkSequencesForEachBoardIndex)
                {
                    checkForkSequencesForEachBoardIndex(s);
                }
            }
        }

        public void checkForForkBlock()
        {
            if (turnNumber >= 3)
            {
                _letterOfForkingSide = letterOfOpposingPlayerSide;
                foreach (var s in _forkSequencesForEachBoardIndex)
                {
                    checkForkSequencesForEachBoardIndex(s);
                }
                checkforDoubleForkSituation();
            }
        }

        private void checkForkSequencesForEachBoardIndex(int[][] forkSequencesAtCurrentIndex)
        {
            potentialForkSequences = new List<int[]>();

            foreach (var t in forkSequencesAtCurrentIndex)
            {
                if (squaresPlayed[t[0]] == "")
                {
                    checkSequenceForPotentialFork(t);
                    checkPotentialForksForActualFork(t[0]);
                }
            }
        }

        private void checkSequenceForPotentialFork(int[] sequenceToCheck)
        {
            if (IsPotentialForkSequence(sequenceToCheck))
            {
                potentialForkSequences.Add(sequenceToCheck);
            }

        }

        private bool IsPotentialForkSequence(int[] sequenceToCheck)
        {
            return squaresPlayed[sequenceToCheck[0]] + squaresPlayed[sequenceToCheck[1]] + squaresPlayed[sequenceToCheck[2]]
                == _letterOfForkingSide;
        }

        private void checkPotentialForksForActualFork(int potentialForkIndex)
        {
            if (potentialForkSequences.Count == 2)
            {
                addUniqueAiMoveCandidate(potentialForkIndex);
            }
        }

        private void checkforDoubleForkSituation()
        {
            if (_aiMoveCandidates.Count == 2)
            {
                _aiMoveCandidates = new List<int>();
                checkForEdge();
            }
        }

        public void checkForEdge()
        {
            foreach (var e in fourCenterEdges)
            {
                if (squaresPlayed[e] == "")
                {
                    aiMoveCandidates.Add(e);
                }
            }
        }

        public void addUniqueAiMoveCandidate(int potentialAiMoveCandidate)
        {
            if (aiMoveCandidates.Contains(potentialAiMoveCandidate) == false)
            {
                aiMoveCandidates.Add(potentialAiMoveCandidate);
            }
        }
    }
}
