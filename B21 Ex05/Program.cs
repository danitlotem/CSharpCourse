using System.Windows.Forms;
using System;
using System.Text;
using B21_Ex05_TicTacToeGame;

namespace B21_Ex05_TicTacToeGame
{
    public class Program
    {
        public static void Main()
        {
            GameSettings gameSettings = new GameSettings();
            gameSettings.StartPosition = FormStartPosition.CenterScreen;
            gameSettings.ShowDialog();

            if (gameSettings.DialogResult == DialogResult.OK)
            {
                TicTacToeMisere game = new TicTacToeMisere(gameSettings);
                gameSettings.Close();
                game.ShowDialog();
            }
        }
    }
}