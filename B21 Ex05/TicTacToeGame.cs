using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace B21_Ex05_TicTacToeGame
{
    public class TicTacToeGame
    {
        ////DATA MEMBERS
        private readonly Player r_FirstPlayer;
        private readonly Player r_SecondPlayer;
        private readonly Random r_RandIndex = new Random();
        private bool m_IsComputerPlaying;
        private Board m_Board;
        private Player m_CurrentPlayer;
        private Player m_Winner;
        private bool m_IsGameOver;
        private bool m_IsQuit;
        private List<Board.Point> m_ListOfFreeCellsInBoard;

        ////CTOR
        public TicTacToeGame(short i_BoardSize, bool i_IsComputerPlaying)
        {
            r_FirstPlayer = new Player(Player.ePlayerSign.X, true);
            r_SecondPlayer = i_IsComputerPlaying == true ? new Player(Player.ePlayerSign.O, false) : new Player(Player.ePlayerSign.O, true);
            Board = new Board(i_BoardSize);
            CurrentPlayer = r_FirstPlayer;
            Winner = null;
            IsComputerPlaying = i_IsComputerPlaying;
            IsGameOver = false;
            IsQuit = false;
            ListOfFreeCellsInBoard = new List<Board.Point>();
            CreateListOfEmptyCells();
        }

        ////PROPERTIES
        public Board Board
        {
            get
            {
                return m_Board;
            }

            set
            {
                m_Board = value;
            }
        }

        public Player FirstPlayer
        {
            get
            {
                return r_FirstPlayer;
            }
        }

        public Player SecondPlayer
        {
            get
            {
                return r_SecondPlayer;
            }
        }

        public Player Winner
        {
            get
            {
                return m_Winner;
            }

            set
            {
                m_Winner = value;
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }

            set
            {
                m_CurrentPlayer = value;
            }
        }

        public bool IsComputerPlaying
        {
            get
            {
                return m_IsComputerPlaying;
            }

            set
            {
                m_IsComputerPlaying = value;
            }
        }

        public bool IsGameOver
        {
            get
            {
                return m_IsGameOver;
            }

            set
            {
                m_IsGameOver = value;
            }
        }

        public bool IsQuit
        {
            get
            {
                return m_IsQuit;
            }

            set
            {
                m_IsQuit = value;
            }
        }

        public List<Board.Point> ListOfFreeCellsInBoard
        {
            get
            {
                return m_ListOfFreeCellsInBoard;
            }

            set
            {
                m_ListOfFreeCellsInBoard = value;
            }
        }

        public Random RandIndex
        {
            get
            {
                return r_RandIndex;
            }
        }

        ////METHODS
        public void DetermineCurrentPlayer()
        {
            CurrentPlayer = CurrentPlayer.Sign == FirstPlayer.Sign ? SecondPlayer : FirstPlayer;
        }

        private Player findWinner(char i_Sign)
        {
            return (char)r_FirstPlayer.Sign == i_Sign ? r_SecondPlayer : r_FirstPlayer;
        }

        private Player whoWon()
        {
            char sign = (char)Player.ePlayerSign.Empty;
            Player winner = null;

            if (checkWinInRowsAndCols(ref sign) == true)
            {
                winner = findWinner(sign);
            }
            else if (checkWinInMainAndSecondaryDiagonal(ref sign) == true)
            {
                winner = findWinner(sign);
            }

            return winner;
        }

        public Player DetermineIfTheGameIsOver()
        {
            Player winner = whoWon();

            if (winner != null)
            {
                Winner = winner;
                IsGameOver = true;
            }
            else
            {
                IsGameOver = Board.NumberOfEmptyCells == 0 ? true : false;
            }

            return winner;
        }

        private void countSignsInRowAndCol(ref short io_CountRow, ref short io_CountCol, short i_Index, char i_RowSign, char i_ColSign)
        {
            for (short j = 0; j < Board.BoardSize; j++)
            {
                if (Board[i_Index, j] == i_RowSign)
                {
                    io_CountRow++;
                }

                if (Board[j, i_Index] == i_ColSign)
                {
                    io_CountCol++;
                }
            }
        }

        private bool checkWinInRowsAndCols(ref char o_Sign)
        {
            bool rowFlag = false, colFlag = false;
            short countCol = 0, countRow = 0;

            for (short i = 0; i < Board.BoardSize; i++)
            {
                char rowSign = Board[i, 0];
                char colSign = Board[0, i];

                countSignsInRowAndCol(ref countRow, ref countCol, i, rowSign, colSign);

                if (rowSign != (char)Player.ePlayerSign.Empty && countRow == Board.BoardSize)
                {
                    rowFlag = true;
                    o_Sign = rowSign;
                    break;
                }

                if (colSign != (char)Player.ePlayerSign.Empty && countCol == Board.BoardSize)
                {
                    colFlag = true;
                    o_Sign = colSign;
                    break;
                }

                countCol = 0;
                countRow = 0;
            }

            return rowFlag || colFlag;
        }

        private void countSignsInMainAndSecondaryDiagonal(ref short io_CountMain, ref short io_CountSec, char io_MainSign, char io_SecSign)
        {
            for (short i = 0, j = (short)(Board.BoardSize - 1); i < Board.BoardSize && j >= 0; i++, j--)
            {
                if (Board[i, i] == io_MainSign)
                {
                    io_CountMain++;
                }

                if (Board[i, j] == io_SecSign)
                {
                    io_CountSec++;
                }
            }
        }

        private bool checkWinInMainAndSecondaryDiagonal(ref char o_Sign)
        {
            short countMain = 0, countSec = 0;
            bool mainFlag = false, secFlag = false;
            char mainSign = Board[0, 0], secSign = Board[0, Board.BoardSize - 1];

            countSignsInMainAndSecondaryDiagonal(ref countMain, ref countSec, mainSign, secSign);
            if (mainSign != (char)Player.ePlayerSign.Empty && countMain == Board.BoardSize)
            {
                mainFlag = true;
                o_Sign = mainSign;
            }
            else if (secSign != (char)Player.ePlayerSign.Empty && countSec == Board.BoardSize)
            {
                secFlag = true;
                o_Sign = secSign;
            }

            return secFlag || mainFlag;
        }

        ////RANDOM
        public void CreateListOfEmptyCells()
        {
            for (short i = 0; i < Board.BoardSize; i++)
            {
                for (short j = 0; j < Board.BoardSize; j++)
                {
                    if (Board[i, j] == (char)Player.ePlayerSign.Empty)
                    {
                        ListOfFreeCellsInBoard.Add(new Board.Point((short)i, (short)j));
                    }
                }
            }
        }

        public void ChooseRandom(out short o_Row, out short o_Col)
        {
            short listLen = (short)ListOfFreeCellsInBoard.Count;
            short listItemIndex = (short)RandIndex.Next(0, listLen);

            o_Row = ListOfFreeCellsInBoard[listItemIndex].Row;
            o_Col = ListOfFreeCellsInBoard[listItemIndex].Col;
        }

        public void UpdateListOfEmptyCells(short i_Row, short i_Col)
        {
            Board.Point point = new Board.Point(i_Row, i_Col);
            int pointIndex = ListOfFreeCellsInBoard.FindIndex(p => p.Row == i_Row && p.Col == i_Col);
            ListOfFreeCellsInBoard.RemoveAt(pointIndex);
        }

        ////AI
        public void CheckBestMove(out short o_Row, out short o_Col)
        {
            short[] move = new short[2];
            int bestScore = int.MinValue;

            o_Row = -1;
            o_Col = -1;

            if (Board.NumberOfEmptyCells == Board.BoardSize * Board.BoardSize)
            {
                move[0] = (short)(Board.BoardSize / 2);
                move[1] = (short)(Board.BoardSize / 2);
            }
            else
            {
                for (short row = 0; row < Board.BoardSize; row++)
                {
                    for (short col = 0; col < Board.BoardSize; col++)
                    {
                        if (Board[row, col] == (char)Player.ePlayerSign.Empty)
                        {
                            Board[row, col] = (char)CurrentPlayer.Sign;
                            int score = MiniMax(Board, 0, false);
                            Board[row, col] = (char)Player.ePlayerSign.Empty;
                            if (score > bestScore)
                            {
                                bestScore = score;
                                move[0] = row;
                                move[1] = col;
                            }
                        }
                    }
                }
            }

            o_Row = (short)move[0];
            o_Col = (short)move[1];
        }

        public int MiniMax(Board i_Board, int i_Level, bool i_IsMaximizing)
        {
            Player winner = whoWon();
            int bestVal;

            if (winner != null)
            {
                bestVal = winner.Sign == Player.ePlayerSign.X ? 1 : -1;
            }
            else if (i_IsMaximizing == true)
            {
                int bestScore = int.MinValue;

                for (short row = 0; row < i_Board.BoardSize; row++)
                {
                    for (short col = 0; col < i_Board.BoardSize; col++)
                    {
                        if (i_Board[row, col] == (char)Player.ePlayerSign.Empty)
                        {
                            i_Board[row, col] = (char)CurrentPlayer.Sign;
                            int score = MiniMax(i_Board, i_Level + 1, false);
                            i_Board[row, col] = (char)Player.ePlayerSign.Empty;
                            bestScore = Math.Min(bestScore, score);
                        }
                    }
                }

                bestVal = bestScore;
            }
            else
            {
                int bestScore = int.MaxValue;

                for (int row = 0; row < i_Board.BoardSize; row++)
                {
                    for (int col = 0; col < i_Board.BoardSize; col++)
                    {
                        if (i_Board[row, col] == (char)Player.ePlayerSign.Empty)
                        {
                            i_Board[row, col] = (char)CurrentPlayer.Sign;
                            int score = MiniMax(i_Board, i_Level + 1, true);
                            i_Board[row, col] = (char)Player.ePlayerSign.Empty;
                            bestScore = Math.Max(bestScore, score);
                        }
                    }
                }

                bestVal = bestScore;
            }

            return bestVal;
        }
    }
}