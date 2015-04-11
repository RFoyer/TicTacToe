using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicTacToeModel;

namespace GameOptionsWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameOptionsMainWindow : Window
    {
        public GameOptionsMainWindow()
        {
            InitializeComponent();
        }

        public GameOptionsMainWindow(Game game)
            : this()
        {
            OptionsViewModel = new GameOptionsViewModel(game);
            this.DataContext = OptionsViewModel;
        }

        public GameOptionsViewModel OptionsViewModel { get; set; }

        public void OptionsWindow_Closing(object sender, CancelEventArgs e)
        {
            OptionsViewModel.ResetOptionsPropertiesToGameProperties();
            e.Cancel = true;
            this.Hide();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            OptionsViewModel.SetGameProperties();
            this.Hide();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            OptionsViewModel.ResetOptionsPropertiesToGameProperties();
            this.Hide();
        }

        private void Button_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                OptionsViewModel.SetGameProperties();
                this.Hide();
            }
        }
    }
}
