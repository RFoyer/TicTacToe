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
        private string lLblOpacity;

        public GameOptionsViewModel(Game game)
        {
            this.game = game;
            IsPlayComputer = true;
            IsEasyDifficulty = true;
        }

        public bool IsPlayComputer
        {
            get { return game.IsOnePlayerGame; }
            set
            {
                game.IsOnePlayerGame = value;
                OnPropertyChanged("IsPlayComputer");
                DimLbl();
            }
        }
        public bool IsEasyDifficulty
        {
            get { return game.DifficultyLevel == "easy"; }
            set
            {
                if (value)
                {
                    game.DifficultyLevel = "easy";
                }
                OnPropertyChanged("IsEasyDifficulty");
            }
        }
        public bool IsMediumDifficulty
        {
            get { return game.DifficultyLevel == "medium"; }
            set
            {
                if (value)
                {
                    game.DifficultyLevel = "medium";
                }
                OnPropertyChanged("IsMediumDifficulty");
            }
        }
        public bool IsUnbeatableDifficulty
        {
            get { return game.DifficultyLevel == "unbeatable"; }
            set
            {
                if (value)
                {
                    game.DifficultyLevel = "unbeatable";
                }
                OnPropertyChanged("IsUnbeatableDifficulty");
            }
        }
        public string LblOpacity
        {
            get { return lLblOpacity; }
            set
            {
                lLblOpacity = value;
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
    }
}
