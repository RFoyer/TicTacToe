using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToeModel;

namespace TicTacToeViewModel
{
    public class CommandLogic : TTTViewModelBase
    {
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

        public void NewGame_CommandExecute(object parameter)
        {
            game = new Game();
            isContinue = true;
            lblContent = "Your Move!";
            optionsEnabled = false;
            game.letterOfCurrentPlayerSide = "X";
            updateContentOfAllSquares();
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
    }
}
