using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeModel;

namespace TicTacToeViewModel
{
    public abstract class TTTViewModelBase : INotifyPropertyChanged
    {
        public TTTViewModelBase()
        {
            TicTacToeBase.DifficultyLevel = "easy";
            game = new Game();
        }
        
        public static Game game { get; set; }

        public string btn0
        {
            get { return game.SquaresPlayed[0]; }
            set { game.SquaresPlayed[0] = value; }
        }

        public string btn1
        {
            get { return game.SquaresPlayed[1]; }
            set { game.SquaresPlayed[1] = value; }
        }

        public string btn2
        {
            get { return game.SquaresPlayed[2]; }
            set { game.SquaresPlayed[2] = value; }
        }

        public string btn3
        {
            get { return game.SquaresPlayed[3]; }
            set { game.SquaresPlayed[3] = value; }
        }

        public string btn4
        {
            get { return game.SquaresPlayed[4]; }
            set { game.SquaresPlayed[4] = value; }
        }

        public string btn5
        {
            get { return game.SquaresPlayed[5]; }
            set { game.SquaresPlayed[5] = value; }
        }

        public string btn6
        {
            get { return game.SquaresPlayed[6]; }
            set { game.SquaresPlayed[6] = value; }
        }

        public string btn7
        {
            get { return game.SquaresPlayed[7]; }
            set { game.SquaresPlayed[7] = value; }
        }

        public string btn8
        {
            get { return game.SquaresPlayed[8]; }
            set { game.SquaresPlayed[8] = value; }
        }

        private string _lblContent;
        public string lblContent
        {
            get { return _lblContent; }
            set
            {
                _lblContent = value;
                OnPropertyChanged("lblContent");
            }
        }

        private bool _isContinue;
        public bool isContinue
        {
            get { return _isContinue; }
            set
            {
                _isContinue = value;
                OnPropertyChanged("isContinue");
            }
        }

        private bool _optionsEnabled = true;
        public bool optionsEnabled
        {
            get { return _optionsEnabled; }
            set
            {
                _optionsEnabled = value;
                OnPropertyChanged("optionsEnabled");
            }
        }

        public bool isOnePlayerGame
        {
            get { return TicTacToeBase.IsOnePlayerGame; }
            set { TicTacToeBase.IsOnePlayerGame = value; }
        }

        public bool isUnbeatableDifficulty
        {
            get { return TicTacToeBase.DifficultyLevel == "unbeatable"; }
            set
            {
                if (value)
                    TicTacToeBase.DifficultyLevel = "unbeatable";
                else
                    TicTacToeBase.DifficultyLevel = "easy";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
