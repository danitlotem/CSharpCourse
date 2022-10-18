using System;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace B21_Ex02_TicTacToeGame
{
    public class UI
    {
        ////DATA MEMBERS
        private TicTacToeGame m_Game;

        ////CTOR
        public UI()
        {
            m_Game = null;
        }

        ////PROPERTY
        public TicTacToeGame Game ////PROPERTY GAME
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

        ////METHODS

        ////INPUT

        private static void printTieMsg()
        {
            Console.WriteLine("There is a tie");
        }


        private void getRowFromUser(string rowString, out short i_Row)
        {
            while (!short.TryParse(rowString, out i_Row))
            {
                if (isPlayerEnteredQ(ref rowString) == false)
                {
                    Console.WriteLine("Your ROW coordinate is not valid. Please enter a square coordinate - ROW then press 'ENTER' and then insert COL");
                    Console.Write("ROW: ");
                    rowString = Console.ReadLine();
                }
            }
        }
        private void getColFromUser(string colString, out short i_Col)
        {
            while (!short.TryParse(colString, out i_Col))
            {
                if (isPlayerEnteredQ(ref colString) == false)
                {
                    Console.WriteLine("Your COL coordinate is not valid. Please enter your COL coordinate again");
                    Console.Write("COL: ");
                    colString = Console.ReadLine();
                }
            }
        }
        private void getSquareFromUser(ref short i_Row, ref short i_Col)
        {
            bool isSquareValidFlag = false;

            while (isSquareValidFlag == false)
            {
                Console.WriteLine("Please enter a square coordinate - ROW then press 'ENTER' and then insert COL");
                Console.Write("ROW: ");
                string rowString = Console.ReadLine();
                getRowFromUser(rowString, out i_Row);////--------------------
                Console.Write("COL: ");
                string colString = Console.ReadLine();
                getColFromUser(colString, out i_Col);////--------------------
                isSquareValidFlag = isSquareValid(ref i_Row, ref i_Col);
            }
        }
        //private void getSquareFromUser(ref short i_Row, ref short i_Col)
        //{
        //    bool isSquareValidFlag = false;

        //    while (isSquareValidFlag == false)
        //    {
        //        Console.WriteLine("Please enter a square coordinate - ROW then press 'ENTER' and then insert COL");
        //        Console.Write("ROW: ");
        //        string rowString = Console.ReadLine();

        //while (!short.TryParse(rowString, out i_Row))
        //{
        //    if (isPlayerEnteredQ(ref rowString) == false)
        //    {
        //        Console.WriteLine("Your ROW coordinate is not valid. Please enter a square coordinate - ROW then press 'ENTER' and then insert COL");
        //        Console.Write("ROW: ");
        //        rowString = Console.ReadLine();
        //    }
        //}
        //        Console.Write("COL: ");
        //        string colString = Console.ReadLine();

        //        while (!short.TryParse(colString, out i_Col))
        //        {
        //            if (isPlayerEnteredQ(ref colString) == false)
        //            {
        //                Console.WriteLine("Your COL coordinate is not valid. Please enter your COL coordinate again");
        //                Console.Write("COL: ");
        //                colString = Console.ReadLine();
        //            }
        //        }

        //        isSquareValidFlag = isSquareValid(ref i_Row, ref i_Col);
        //    }
        //}

        private short getBoardSizeFromUser()
        {
            Console.WriteLine("Please Enter the wanted board size (between 3-9)");
            Console.Write("Your choice: ");
            string sizeString = Console.ReadLine();
            short boardSize = isBoardSizeValid(ref sizeString);
            Console.Write(Environment.NewLine);

            return boardSize;
        }

        private bool checkIfPlayerWantsAnotherRound()
        {
            Console.WriteLine("Do you want to play another round? (y - yes / n - no)");
            string anotherRound = Console.ReadLine();

            while (!anotherRound.Equals("y") && !anotherRound.Equals("n"))
            {
                if (!isPlayerEnteredQ(ref anotherRound))
                {
                    Console.WriteLine("Input is not valid. Do you want to play another round? (y - yes / n - no)");
                    anotherRound = Console.ReadLine();
                }
            }

            return anotherRound.Equals("y");
        }

        private bool getGameModeFromUser()
        {
            short inputGameMode;
            StringBuilder gameModeString = new StringBuilder();

            gameModeString.Append("Please enter the wanted game mode:");
            gameModeString.Append(Environment.NewLine);
            gameModeString.Append("- For player vs. player - press 1");
            gameModeString.Append(Environment.NewLine);
            gameModeString.Append("- For player vs. computer - press 2");
            Console.WriteLine(gameModeString);
            string inputGameModeString = Console.ReadLine();
            isGameModeValid(out inputGameMode, ref inputGameModeString);

            return inputGameMode == 2 ? true : false;
        }

        ////OUTPUT

        private void appendColumnsNumbersToString(ref StringBuilder io_BoardString)
        {
            io_BoardString.Append("   ");
            for (short i = 0; i < Game.Board.BoardSize; i++)
            {
                io_BoardString.Append((i + 1).ToString());
                io_BoardString.Append("   ");
            }

            io_BoardString.Append(Environment.NewLine);
        }

        private void appendLineToString(ref StringBuilder io_BoardString)
        {
            io_BoardString.Append(" =");
            for (short j = 0; j < Game.Board.BoardSize; j++)
            {
                io_BoardString.Append("====");
            }

            io_BoardString.Append(Environment.NewLine);
        }

        private void appendRowToString(ref StringBuilder io_BoardString, short i_RowNumber)
        {
            io_BoardString.Append((i_RowNumber + 1).ToString());
            io_BoardString.Append("|");
            for (short j = 0; j < Game.Board.BoardSize; j++)
            {
                io_BoardString.Append(" ");
                io_BoardString.Append(Game.Board[i_RowNumber, j].ToString());
                io_BoardString.Append(" |");
            }

            io_BoardString.Append(Environment.NewLine);
        }

        private void printBoard()
        {
            StringBuilder boardString = new StringBuilder();

            Ex02.ConsoleUtils.Screen.Clear();
            appendColumnsNumbersToString(ref boardString);
            for (short i = 0; i < Game.Board.BoardSize; i++)
            {
                appendRowToString(ref boardString, i);
                appendLineToString(ref boardString);
            }

            Console.WriteLine(boardString);
        }

        private void printWinnerMsg(Player.ePlayerSign i_WinnerSign)
        {
            StringBuilder endGameMsg = new StringBuilder();

            endGameMsg.Append("The Winner is: '");
            endGameMsg.Append(i_WinnerSign.ToString());
            endGameMsg.Append("' player");
            endGameMsg.Append(". SCORE: ");
            endGameMsg.Append(Game.Winner.Score.ToString());
            Console.WriteLine(endGameMsg);
        }

        ////MANAGE GAME
        private void initGame()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Game.Board.ClearBoard();
            Game.ListOfFreeCellsInBoard.Clear();
            Game.CreateListOfEmptyCells();
            Game.IsGameOver = false;
            Game.IsQuit = false;
            Game.Winner = null;
        }

        private void runGame()
        {
            while (!Game.IsQuit && !Game.IsGameOver)
            {
                playOneTurn();
                printBoard();
                Game.DetermineCurrentPlayer();
            }

            endRound();
        }

        public void StartGame()
        {
            bool finishGame = false;
            short boardSize = getBoardSizeFromUser();
            bool gameMode = getGameModeFromUser();

            Game = new TicTacToeGame(boardSize, gameMode);
            printBoard();
            while (finishGame == false)
            {
                runGame();
                if (checkIfPlayerWantsAnotherRound() == true)
                {
                    initGame();
                    printBoard();
                }
                else
                {
                    finishGame = true;
                    string msg = string.Format(
                        @"The final scores:
player '{0}' has {1} points 
player '{2}' has {3} points

GoodBye!",
                        Game.FirstPlayer.Sign, Game.FirstPlayer.Score, Game.SecondPlayer.Sign, Game.SecondPlayer.Score);
                    Console.WriteLine(msg);
                    System.Threading.Thread.Sleep(1000);
                    System.Environment.Exit(1);
                }
            }
        }

        private void playOneTurn()
        {
            short row = 0, col = 0;

            if (Game.CurrentPlayer.IsHuman == true)
            {
                Console.WriteLine("It's '" + Game.CurrentPlayer.Sign + "' turn..");
                getSquareFromUser(ref row, ref col);
            }
            else
            {
                Console.WriteLine("The computer is taking a move..");
                System.Threading.Thread.Sleep(1000);
                if (Game.Board.BoardSize == 3)
                {
                    Game.CheckBestMove(out row, out col);
                }
                else
                {
                    Game.ChooseRandom(out row, out col);
                }
            }

            Game.Board.MarkSquare(row, col, Game.CurrentPlayer.Sign);
            Game.UpdateListOfEmptyCells(row, col);
            Game.Winner = Game.DetermineIfTheGameIsOver();

            if (Game.Winner != null)
            {
                Game.Winner.Score++;
            }
        }

        private void endRound()
        {
            if (Game.Winner == null)
            {
                printTieMsg();
            }
            else
            {
                printWinnerMsg(Game.Winner.Sign);
            }
        }

        ////VALIDITY CHECK
        private void isGameModeValid(out short io_InputGameMode, ref string io_InputGameModeString)
        {
            while ((!short.TryParse(io_InputGameModeString, out io_InputGameMode)) || (io_InputGameMode != 1 && io_InputGameMode != 2))
            {
                if (isPlayerEnteredQ(ref io_InputGameModeString) == false)
                {
                    StringBuilder gameModeString = new StringBuilder();
                    gameModeString.Append("Invalid game mode");
                    gameModeString.Append(Environment.NewLine);
                    gameModeString.Append("Please enter the wanted game mode:");
                    gameModeString.Append(Environment.NewLine);
                    gameModeString.Append("- For player vs. player - press 1");
                    gameModeString.Append(Environment.NewLine);
                    gameModeString.Append("- For player vs. computer - press 2");
                    Console.WriteLine(gameModeString);
                    io_InputGameModeString = Console.ReadLine();
                }
            }
        }

        private short isBoardSizeValid(ref string io_SizeString)
        {
            short boardSize;

            while ((!short.TryParse(io_SizeString, out boardSize)) || (boardSize > 9 || boardSize < 3))
            {
                if (isPlayerEnteredQ(ref io_SizeString) == false)
                {
                    StringBuilder boardSizeString = new StringBuilder();
                    boardSizeString.Append(Environment.NewLine);
                    boardSizeString.Append("Invalid board size.");
                    boardSizeString.Append(Environment.NewLine);
                    boardSizeString.Append("Please enter the board size again. Valid choices are between 3-9");
                    boardSizeString.Append(Environment.NewLine);
                    boardSizeString.Append("Your choice: ");
                    Console.WriteLine(boardSizeString);
                    io_SizeString = Console.ReadLine();
                }
            }

            return boardSize;
        }

        private bool isSquareValid(ref short io_Row, ref short io_Col)
        {
            bool isSquareValidFlag = true;
            StringBuilder boardSizeString;

            if (io_Row > Game.Board.BoardSize || io_Row < 1 || io_Col > Game.Board.BoardSize || io_Col < 1)
            {
                boardSizeString = new StringBuilder();
                boardSizeString.Append("The square is not within the board boundaries");
                Console.WriteLine(boardSizeString);
                isSquareValidFlag = false;
            }

            if (isSquareValidFlag == true && Game.Board[io_Row - 1, io_Col - 1] != (char)Player.ePlayerSign.Empty)
            {
                boardSizeString = new StringBuilder();
                boardSizeString.Append("This square is already marked.");
                Console.WriteLine(boardSizeString);
                isSquareValidFlag = false;
            }

            return isSquareValidFlag;
        }

        private bool isPlayerEnteredQ(ref string i_Input)
        {
            bool isQuit = false;
            string msg;

            if (string.Equals(i_Input, "Q"))
            {
                isQuit = true;
                if (Game != null)
                {
                    msg = string.Format("Player '{0}' " + "quit" + " from this game", Game.CurrentPlayer.Sign);
                }
                else
                {
                    msg = string.Format("You decided to quit - goodbye!");
                }

                Console.WriteLine(msg);
                System.Threading.Thread.Sleep(1000);
                System.Environment.Exit(1);
            }
            else
            {
                isQuit = false;
            }

            return isQuit;
        }
    }
}