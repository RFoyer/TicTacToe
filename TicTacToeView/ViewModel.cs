using GameOptionsWindow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToeModel;

namespace TicTacToeView
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Game game;
        private string lblContent;
        private bool isContinue;
        private bool optionsEnabled = true;
        
        public ViewModel(Game game)
        {
            this.game = game;
            game.DifficultyLevel = "easy";
        }

        public string Btn0
        {
            get { return game.SquaresPlayed[0]; }
            set { game.SquaresPlayed[0] = value; }
        }
        public string Btn1
        {
            get { return game.SquaresPlayed[1]; }
            set { game.SquaresPlayed[1] = value; }
        }
        public string Btn2
        {
            get { return game.SquaresPlayed[2]; }
            set { game.SquaresPlayed[2] = value; }
        }
        public string Btn3
        {
            get { return game.SquaresPlayed[3]; }
            set { game.SquaresPlayed[3] = value; }
        }
        public string Btn4
        {
            get { return game.SquaresPlayed[4]; }
            set { game.SquaresPlayed[4] = value; }
        }
        public string Btn5
        {
            get { return game.SquaresPlayed[5]; }
            set { game.SquaresPlayed[5] = value; }
        }
        public string Btn6
        {
            get { return game.SquaresPlayed[6]; }
            set { game.SquaresPlayed[6] = value; }
        }
        public string Btn7
        {
            get { return game.SquaresPlayed[7]; }
            set { game.SquaresPlayed[7] = value; }
        }
        public string Btn8
        {
            get { return game.SquaresPlayed[8]; }
            set { game.SquaresPlayed[8] = value; }
        }
        public string LblContent
        {
            get { return lblContent; }
            set
            {
                lblContent = value;
                OnPropertyChanged("LblContent");
            }
        }
        public bool IsContinue
        {
            get { return isContinue; }
            set
            {
                isContinue = value;
                OnPropertyChanged("IsContinue");
            }
        }
        public bool OptionsEnabled
        {
            get { return optionsEnabled; }
            set
            {
                optionsEnabled = value;
                OnPropertyChanged("OptionsEnabled");
            }
        }
        public bool IsOnePlayerGame
        {
            get { return game.IsOnePlayerGame; }
            set { game.IsOnePlayerGame = value; }
        }
        public bool IsUnbeatableDifficulty
        {
            get { return game.DifficultyLevel == "unbeatable"; }
            set
            {
                if (value)
                    game.DifficultyLevel = "unbeatable";
                else
                    game.DifficultyLevel = "easy";
            }
        }
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
        private ICommand _GameOptionsWindowCommand;
        public ICommand GameOptionsWindowCommand
        {
            get
            {
                if (_GameOptionsWindowCommand == null)
                    _GameOptionsWindowCommand = new RelayCommand(param => GameOptionsWindow_CommandExecute(param));
                return _GameOptionsWindowCommand;
            }
        }

        private void GameOptionsWindow_CommandExecute(object param)
        {
            GameOptionsMainWindow gomw = new GameOptionsMainWindow();
            gomw.ShowDialog();
        }

        public void BtnClick_CommandExecute(object parameter)
        {
            if (parameter.ToString() == "New Game")
            {
                NewGameCommand();
            }
            else
            {
                PlaySquareCommand(parameter);
            }
        }

        private void PlaySquareCommand(object parameter)
        {
            game.CurrentSquare = Convert.ToInt32(parameter);
            game.squareSelectionAttempt();
            UpdateLblContent();
            UpdateContentOfAllSquares();
            CheckIfContinue();
        }

        private void NewGameCommand()
        {
            ResetGameProperties();
            IsContinue = true;
            OptionsEnabled = false;
            UpdateLblContent();
            UpdateContentOfAllSquares();
        }

        private void ResetGameProperties()
        {
            game.LetterOfCurrentPlayerSide = "X";
            game.CurrentScoreSituation = ScoreSituation.Continue;
            game.TurnNumber = 0;
            game.SquaresPlayed = new List<string>() { "", "", "", "", "", "", "", "", "" };
        }

        private void UpdateLblContent()
        {
            if (game.CurrentScoreSituation == ScoreSituation.Continue && !IsOnePlayerGame)
            {
                if (game.LetterOfCurrentPlayerSide == "X")
                {
                    LblContent = "X's Turn!";
                    return;
                }
                LblContent = "O's Turn!";
                return;
            }
            else if (game.CurrentScoreSituation == ScoreSituation.Continue && IsOnePlayerGame)
            {
                LblContent = "Your Turn!";
                return;
            }
            if (game.CurrentScoreSituation == ScoreSituation.Win)
            {
                LblContent = string.Format("{0} Wins!", game.LetterOfCurrentPlayerSide);
                return;
            }
            if (game.CurrentScoreSituation == ScoreSituation.Draw)
            {
                LblContent = "Cat!";
                return;
            }
        }

        private void CheckIfContinue()
        {
            if (game.CurrentScoreSituation != ScoreSituation.Continue)
            {
                IsContinue = false;
                OptionsEnabled = true;
            }
        }

        private void UpdateContentOfAllSquares()
        {
            OnPropertyChanged("Btn0");
            OnPropertyChanged("Btn1");
            OnPropertyChanged("Btn2");
            OnPropertyChanged("Btn3");
            OnPropertyChanged("Btn4");
            OnPropertyChanged("Btn5");
            OnPropertyChanged("Btn6");
            OnPropertyChanged("Btn7");
            OnPropertyChanged("Btn8");
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
