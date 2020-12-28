using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace GameOfLife.UI
{
    public partial class MainWindow : Window
    {
        private static void Start()
        {
            var board = new Board();

            board.FillBoard();

            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar))
            {
                board.Advance();
                Thread.Sleep(100);
            }
        }

        

        public MainWindow()
        {
            Start();
        }
    }
}