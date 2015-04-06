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
            game.currentSquare = Convert.ToInt32(parameter);
            game.squareSelectionAttempt();
            updateLblContent();
            updateContentOfAllSquares();
            checkIfContinue();
        }

        private void NewGameCommand()
        {
            game = new Game();
            isContinue = true;
            optionsEnabled = false;
            game.letterOfCurrentPlayerSide = "X";
            updateLblContent();
            updateContentOfAllSquares();
        }

        private void updateLblContent()
        {
            if (game.currentScoreSituation == ScoreSituation.Continue && !isOnePlayerGame)
            {
                if (game.letterOfCurrentPlayerSide == "X")
                {
                    lblContent = "X's Turn!";
                    return;
                }
                lblContent = "O's Turn!";
                return;
            }
            else if (game.currentScoreSituation == ScoreSituation.Continue && isOnePlayerGame)
            {
                lblContent = "Your Turn!";
                return;
            }
            if (game.currentScoreSituation == ScoreSituation.Win)
            {
                lblContent = string.Format("{0} Wins!", game.letterOfCurrentPlayerSide);
                return;
            }
            if (game.currentScoreSituation == ScoreSituation.Draw)
            {
                lblContent = "Cat!";
                return;
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
