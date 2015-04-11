using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToeModel;

namespace GameOptionsWindow
{
    public class GameOptionsViewModel : INotifyPropertyChanged
    {
        private Game game;
        private string lblOpacity;
        private string actualDifficultyLevel;
        private bool isPlayComputer;
        private bool isEasyDifficulty;
        private bool isMediumDifficulty;
        private bool isUnbeatableDifficulty;
        private string difficultyLevel;

        public GameOptionsViewModel(Game game)
        {
            this.game = game;
            IsPlayComputer = true;
            IsEasyDifficulty = true;
            game.IsOnePlayerGame = true;
            game.DifficultyLevel = "easy";
        }

        public bool IsPlayComputer
        {
            get { return isPlayComputer; }
            set
            {
                isPlayComputer = value;
                OnPropertyChanged("IsPlayComputer");
                DimLbl();
            }
        }
        public bool IsEasyDifficulty
        {
            get { return isEasyDifficulty; }
            set
            {
                isEasyDifficulty = value;
                if (value)
                {
                    difficultyLevel = "easy";
                }
                OnPropertyChanged("IsEasyDifficulty");
            }
        }
        public bool IsMediumDifficulty
        {
            get { return isMediumDifficulty; }
            set
            {
                isMediumDifficulty = value;
                if (value)
                {
                    difficultyLevel = "medium";
                }
                OnPropertyChanged("IsMediumDifficulty");
            }
        }
        public bool IsUnbeatableDifficulty
        {
            get { return isUnbeatableDifficulty; }
            set
            {
                isUnbeatableDifficulty = value;
                if (value)
                {
                    difficultyLevel = "unbeatable";
                }
                OnPropertyChanged("IsUnbeatableDifficulty");
            }
        }
        public string LblOpacity
        {
            get { return lblOpacity; }
            set
            {
                lblOpacity = value;
                OnPropertyChanged("LblOpacity");
            }
        }
        private ICommand _ClickCommand;
        public ICommand ClickCommand
        {
            get
            {
                if (_ClickCommand == null)
                    _ClickCommand = new RelayCommand(param => Click_CommandExecute(param));
                return _ClickCommand;
            }
        }

        private void Click_CommandExecute(object parameter)
        {
            if (parameter.ToString() == "Easy")
            {
                IsEasyDifficulty = true;
            }
            if (parameter.ToString() == "Medium")
            {
                IsMediumDifficulty = true;
            }
            if (parameter.ToString() == "Unbeatable")
            {
                IsUnbeatableDifficulty = true;
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

        private void DimLbl()
        {
            if (IsPlayComputer)
            {
                LblOpacity = "1";
            }
            else
            {
                LblOpacity = ".5";
            }
        }

        public void SetGameProperties()
        {
            actualDifficultyLevel = difficultyLevel;
            game.DifficultyLevel = difficultyLevel;
            game.IsOnePlayerGame = IsPlayComputer;
        }

        public void ResetOptionsPropertiesToGameProperties()
        {
            IsPlayComputer = game.IsOnePlayerGame;
            actualDifficultyLevel = game.DifficultyLevel;
        }
    }
}
