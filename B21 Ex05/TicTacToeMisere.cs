using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B21_Ex05_TicTacToeGame
{
    public partial class TicTacToeMisere : Form
    {
        //// DATA MEMBERS
        private const short k_ButtonSize = 50;
        private const short k_SpaceBetweenButtons = 7;
        private const short k_Margin = 10;
        private const short k_LowerBound = 30;
        private const short k_LowBanner = 45;
        private const short k_WidthMargin = 15;
        private const short k_LabelTopFromBottom = 70;
        private const string k_Player1NameLabel = "Player1";
        private const string k_Player2NameLabel = "Player2";
        private const string k_Player1ScoreLabel = "Player1Score";
        private const string k_Player2ScoreLabel = "Player2Score";
        private BoardButton[,] m_UIBoard;
        private TicTacToeGame m_Game;
        private short m_UIBoardSize;

        ////CTOR
        public TicTacToeMisere(GameSettings i_GameSettings)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            UIBoardSize = i_GameSettings.BoardSize;
            buildBoard(UIBoardSize, i_GameSettings.FirstPlayerName, i_GameSettings.SecondPlayerName, i_GameSettings.IsComputerPlaying);
            Game = new TicTacToeGame(UIBoardSize, !i_GameSettings.IsComputerPlaying);
            markPlayerTurnOnBoard();
        }

        ////BOARD INITIALIZATION 
        private void initBoardBoundaries(short i_RowsNumeric, short i_ColsNumeric)
        {
            UIBoardSize = i_RowsNumeric;
            UIBoard = new BoardButton[i_RowsNumeric, i_ColsNumeric];
            Height = BoardMargin + LowerBound + (ButtonSize * i_RowsNumeric) + (SpaceBetweenButtons * (i_RowsNumeric - 1)) + LowBanner;
            Width = (2 * BoardMargin) + (ButtonSize * i_ColsNumeric) + (SpaceBetweenButtons * (i_ColsNumeric - 1)) + WidthMargin;

            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void addButtonsToBoard()
        {
            for (short i = 0; i < UIBoardSize; i++)
            {
                for (short j = 0; j < UIBoardSize; j++)
                {
                    UIBoard[i, j] = new BoardButton(i, j);
                    UIBoard[i, j].Height = ButtonSize;
                    UIBoard[i, j].Width = ButtonSize;
                    UIBoard[i, j].Font = new Font("Arial", 20, FontStyle.Bold);
                    UIBoard[i, j].TabStop = false;
                    UIBoard[i, j].Top = BoardMargin + (i * (ButtonSize + SpaceBetweenButtons));
                    UIBoard[i, j].Left = BoardMargin + (j * (ButtonSize + SpaceBetweenButtons));
                    UIBoard[i, j].Click += new EventHandler(playOneTurn);
                    Controls.Add(UIBoard[i, j]);
                }
            }
        }

        private void createPlayerOneLabels(string i_Player1Text, out int o_Player1ScoreRight)
        {
            Label player1 = new Label();
            Label player1Score = new Label();
            float middle = Width / 2;

            player1.Text = string.Format("{0}:", i_Player1Text);
            player1.Top = Bottom - LabelTopFromBottom;
            player1.AutoSize = true;
            player1.Left = 0;
            player1.Name = Player1NameLabel;
            Controls.Add(player1);

            player1Score.Text = "0";
            player1Score.Top = Bottom - LabelTopFromBottom;
            player1Score.AutoSize = true;
            player1Score.Left = player1.Right;
            player1Score.Name = Player1ScoreLabel;
            Controls.Add(player1Score);

            o_Player1ScoreRight = player1Score.Right;
        }

        private void createPlayerTwoLabels(string i_Player2Text, int i_Player1ScoreRight, bool i_IsHumanPlayer)
        {
            Label player2 = new Label();
            Label player2Score = new Label();

            player2Score.Text = "0";

            player2.Text = i_IsHumanPlayer == true
                               ? string.Format("{0}:", i_Player2Text)
                               : string.Format("Computer:");

            player2.Top = Bottom - 70;
            player2.AutoSize = true;
            player2.Left = i_Player1ScoreRight;
            player2.Name = Player2NameLabel;
            Controls.Add(player2);

            player2Score.Top = Bottom - 70;
            player2Score.AutoSize = true;
            player2Score.Left = player2.Right;
            player2Score.Name = Player2ScoreLabel;
            Controls.Add(player2Score);

            updateLabelsLocation();
        }

        private void updateLabelsLocation()
        {
            int midString = (this.Controls[Player2NameLabel].Right - this.Controls[Player1NameLabel].Left) / 2;
            this.Controls[Player1NameLabel].Left = (int)((this.Width / 2) - 5 - midString) - 5;
            this.Controls[Player1ScoreLabel].Left = this.Controls[Player1NameLabel].Right;
            this.Controls[Player2NameLabel].Left = this.Controls[Player1ScoreLabel].Right + 5;
            this.Controls[Player2ScoreLabel].Left = this.Controls[Player2NameLabel].Right;

            this.Controls[Player1NameLabel].Refresh();
            this.Controls[Player1ScoreLabel].Refresh();
            this.Controls[Player2NameLabel].Refresh();
            this.Controls[Player2ScoreLabel].Refresh();
        }

        private void buildBoard(short i_BoardSize, string i_Player1Text, string i_Player2Text, bool i_IsHumanPlayer)
        {
            initBoardBoundaries(i_BoardSize, i_BoardSize);
            addButtonsToBoard();
            createPlayerOneLabels(i_Player1Text, out int player1ScoreRight);
            createPlayerTwoLabels(i_Player2Text, player1ScoreRight, i_IsHumanPlayer);
        }

        public void TicTacToeMisere_Load(object sender, EventArgs e)
        {
        }

        ////PROPERTY
        public TicTacToeGame Game
        {
            get
            {
                return m_Game;
            }

            set
            {
                m_Game = value;
            }
        }

        public short UIBoardSize
        {
            get
            {
                return m_UIBoardSize;
            }

            set
            {
                m_UIBoardSize = value;
            }
        }

        public short LowBanner 
        {
            get
            {
                return k_LowBanner;
            }
        } 

        public short WidthMargin 
        {
            get
            {
                return k_WidthMargin;
            }
        }

        public short LowerBound
        {
            get
            {
                return k_LowerBound;
            }
        }

        public short SpaceBetweenButtons
        {
            get
            {
                return k_SpaceBetweenButtons;
            }
        }

        public short ButtonSize
        {
            get
            {
                return k_ButtonSize;
            }
        }

        public short BoardMargin
        {
            get
            {
                return k_Margin;
            }
        }

        public short LabelTopFromBottom
        {
            get
            {
                return k_LabelTopFromBottom;
            }
        }

        public BoardButton[,] UIBoard
        {
            get
            {
                return m_UIBoard;
            }

            set
            {
                m_UIBoard = value;
            }
        }

        public BoardButton this[int i_Row, int i_Col]
        {
            get
            {
                return m_UIBoard[i_Row, i_Col];
            }

            set
            {
                m_UIBoard[i_Row, i_Col] = value;
            }
        }

        public string Player1NameLabel
        {
            get
            {
                return k_Player1NameLabel;
            }
        }

        public string Player2NameLabel
        {
            get
            {
                return k_Player2NameLabel;
            }
        }

        public string Player1ScoreLabel
        {
            get
            {
                return k_Player1ScoreLabel;
            }
        }

        public string Player2ScoreLabel
        {
            get
            {
                return k_Player2ScoreLabel;
            }
        }

        //// METHODS
        private void clearUIBoard()
        {
            for (short i = 0; i < UIBoardSize; i++)
            {
                for (short j = 0; j < UIBoardSize; j++)
                {
                    UIBoard[i, j].Text = " ";
                    UIBoard[i, j].Enabled = true;
                }
            }
        }

        private void initGame()
        {
            Game.Board.ClearBoard();
            clearUIBoard();
            Game.ListOfFreeCellsInBoard.Clear();
            Game.CreateListOfEmptyCells();
            Game.IsGameOver = false;
            Game.IsQuit = false;
            Game.Winner = null;
            markPlayerTurnOnBoard();
        }

        private void playComputerTurn()
        {
            short row = 0, col = 0;

            if (Game.Board.BoardSize == 3)
            {
                Game.CheckBestMove(out row, out col); ////AI
            }
            else
            {
                Game.ChooseRandom(out row, out col); ////Random
            }

            Game.Board.MarkSquare(UIBoard[row, col].Row, UIBoard[row, col].Column, Game.CurrentPlayer.Sign);
            UIBoard[row, col].Text = Game.CurrentPlayer.Sign.ToString();
            UIBoard[row, col].Enabled = false;
            Game.UpdateListOfEmptyCells(UIBoard[row, col].Row, UIBoard[row, col].Column);
            Game.Winner = Game.DetermineIfTheGameIsOver();
            determineEndOfRound();
            changePlayer();
        }

        private void changePlayer()
        {
            Game.DetermineCurrentPlayer();
            markPlayerTurnOnBoard();
        }

        private void determineEndOfRound()
        {
            if (Game.Winner != null)
            {
                Game.Winner.Score++;
                Control lbl = Game.Winner == Game.FirstPlayer ? this.Controls[Player1ScoreLabel] : this.Controls[Player2ScoreLabel];
                lbl.Text = Game.Winner.Score.ToString();
                showWinningMsg();
            }
            else if (Game.IsGameOver == true)
            {
                showTieMsg();
            }
        }

        private void markLabel(string i_RegularNameLabel, string i_RegularScoreLabel, string i_BoldNameLabel, string i_BoldScoreLabel)
        {
            this.Controls[i_RegularNameLabel].Font = new Font(this.Controls[i_RegularNameLabel].Font, FontStyle.Regular);
            this.Controls[i_RegularScoreLabel].Font = new Font(this.Controls[i_RegularScoreLabel].Font, FontStyle.Regular);

            this.Controls[i_BoldNameLabel].Font = new Font(this.Controls[i_BoldNameLabel].Font, FontStyle.Bold);
            this.Controls[i_BoldScoreLabel].Font = new Font(this.Controls[i_BoldScoreLabel].Font, FontStyle.Bold);
        }

        private void markPlayerTurnOnBoard()
        {
            if (Game.CurrentPlayer == Game.FirstPlayer)
            {
                markLabel(Player2NameLabel, Player2ScoreLabel, Player1NameLabel, Player1ScoreLabel);
            }
            else
            {
                markLabel(Player1NameLabel, Player1ScoreLabel, Player2NameLabel, Player2ScoreLabel);
            }
            
            this.Refresh();
        }

        private void playHumanPlayerTurn(BoardButton i_PressedButton)
        {
            Game.Board.MarkSquare(i_PressedButton.Row, i_PressedButton.Column, Game.CurrentPlayer.Sign);
            i_PressedButton.Text = Game.CurrentPlayer.Sign.ToString();
            Game.UpdateListOfEmptyCells(i_PressedButton.Row, i_PressedButton.Column);
            i_PressedButton.Enabled = false;
            Game.Winner = Game.DetermineIfTheGameIsOver();
            determineEndOfRound();
            changePlayer();
        }

        private void playOneTurn(object sender, EventArgs e)
        {
            BoardButton pressedButton = sender as BoardButton;

            if (Game.CurrentPlayer.IsHuman == true)
            {
                playHumanPlayerTurn(pressedButton);
                System.Threading.Thread.Sleep(500);
            }

            if (Game.CurrentPlayer.IsHuman == false)
            {
                playComputerTurn();
            }
        }

        private void showTieMsg()
        {
            string messageText = string.Format(
    @"Tie!
would you like to play another round?");
            DialogResult tieMessageResult = MessageBox.Show(
                messageText,
                "A Tie!",
                MessageBoxButtons.YesNo);

            if (tieMessageResult == DialogResult.Yes)
            {
                initGame();
            }
            else
            {
                endGame();
            }
        }

        private string getWinnerName()
        {
            Control lbl = (Game.Winner == Game.FirstPlayer) ? this.Controls[Player1NameLabel] : this.Controls[Player2NameLabel];
            return lbl.Text.Remove(lbl.Text.Length - 1, 1);
        }

        private void endGame()
        {
            MessageBox.Show(
                @"Bye bye and have a nice day!",
                "Exit",
                MessageBoxButtons.OK);
            this.Close();
            Environment.Exit(1);
        }

        private void showWinningMsg()
        {
            string winnerName = getWinnerName();
            string messageText = string.Format(
    @"The winner is {0}!
would you like to play another round?", winnerName);
            DialogResult tieMessageResult = MessageBox.Show(
                messageText,
                "A Win!",
                MessageBoxButtons.YesNo);

            if (tieMessageResult == DialogResult.Yes)
            {
                initGame();
            }
            else
            {
                endGame();
            }
        }
    }
}