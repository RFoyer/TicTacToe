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
            e.Cancel = true;
            this.Hide();
        }
    }
}
