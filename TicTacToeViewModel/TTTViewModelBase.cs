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
            TicTacToeBase.difficultyLevel = "easy";
            game = new Game();
        }
        
        public static Game game { get; set; }

        public string btn0
        {
            get { return game.squaresPlayed[0]; }
            set { game.squaresPlayed[0] = value; }
        }

        public string btn1
        {
            get { return game.squaresPlayed[1]; }
            set { game.squaresPlayed[1] = value; }
        }

        public string btn2
        {
            get { return game.squaresPlayed[2]; }
            set { game.squaresPlayed[2] = value; }
        }

        public string btn3
        {
            get { return game.squaresPlayed[3]; }
            set { game.squaresPlayed[3] = value; }
        }

        public string btn4
        {
            get { return game.squaresPlayed[4]; }
            set { game.squaresPlayed[4] = value; }
        }

        public string btn5
        {
            get { return game.squaresPlayed[5]; }
            set { game.squaresPlayed[5] = value; }
        }

        public string btn6
        {
            get { return game.squaresPlayed[6]; }
            set { game.squaresPlayed[6] = value; }
        }

        public string btn7
        {
            get { return game.squaresPlayed[7]; }
            set { game.squaresPlayed[7] = value; }
        }

        public string btn8
        {
            get { return game.squaresPlayed[8]; }
            set { game.squaresPlayed[8] = value; }
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
            get { return TicTacToeBase.isOnePlayerGame; }
            set { TicTacToeBase.isOnePlayerGame = value; }
        }

        public bool isUnbeatableDifficulty
        {
            get { return TicTacToeBase.difficultyLevel == "unbeatable"; }
            set
            {
                if (value)
                    TicTacToeBase.difficultyLevel = "unbeatable";
                else
                    TicTacToeBase.difficultyLevel = "easy";
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
