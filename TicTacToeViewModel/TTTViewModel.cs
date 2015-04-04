using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToeModel;

namespace TicTacToeViewModel
{
    public class TTTViewModel : INotifyPropertyChanged
    {
        public TTTViewModel()
        {
            game.difficultyLevel = "unbeatable";
        }

        private Game game = new Game();

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

        public bool isOnePlayerGame { get; set; }

        public bool isUnbeatableDifficulty { get; set; }

        private ICommand _BtnClickCommand;
        public ICommand BtnClickCommand
        {
            get
            {
                if (_BtnClickCommand == null)
                    _BtnClickCommand = new RelayCommand(param => BtnClick_CommandExecute(param));
                return _BtnClickCommand;
            }
        }

        private ICommand _NewGameCommand;
        public ICommand NewGameCommand
        {
            get
            {
                if (_NewGameCommand == null)
                    _NewGameCommand = new RelayCommand(param => NewGame_CommandExecute(param));
                return _NewGameCommand;
            }
        }

        public void BtnClick_CommandExecute(object parameter)
        {
            game.currentSquare = Convert.ToInt32(parameter);
            game.squareSelectionAttempt();
            updateLblContent();
            updateContentOfAllSquares();
            checkIfContinue();
        }

        private void updateLblContent()
        {
            if (game.currentScoreSituation == ScoreSituation.Win)
            {
                lblContent = string.Format("{0} Wins!", game.letterOfCurrentPlayerSide);
            }
            if (game.currentScoreSituation == ScoreSituation.Draw)
            {
                lblContent = "Cat!";
            }
        }

        public void NewGame_CommandExecute(object parameter)
        {
            game = new Game();
            game.setCurrentScoreSituation();
            isContinue = true;
            lblContent = "Your Move!";
            optionsEnabled = false;
            setOptions();
            game.letterOfCurrentPlayerSide = "X";
            updateContentOfAllSquares();
        }

        private void setOptions()
        {
            game.isOnePlayerGame = isOnePlayerGame;
            if (!isUnbeatableDifficulty)
            {
                game.difficultyLevel = "easy";
            }
            else
            {
                game.difficultyLevel = "unbeatable";
            }
        }

        private void checkIfContinue()
        {
            if (game.currentScoreSituation != ScoreSituation.Continue)
            {
                isContinue = false;
                optionsEnabled = true;
            }
        }

        private void updateContentOfAllSquares()
        {
            OnPropertyChanged("btn0");
            OnPropertyChanged("btn1");
            OnPropertyChanged("btn2");
            OnPropertyChanged("btn3");
            OnPropertyChanged("btn4");
            OnPropertyChanged("btn5");
            OnPropertyChanged("btn6");
            OnPropertyChanged("btn7");
            OnPropertyChanged("btn8");
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
