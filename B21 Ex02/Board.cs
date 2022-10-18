using System;
using System.Text;

namespace B21_Ex02_TicTacToeGame
{
    public class Board
    {
        ////DATA MEMBERS
        private char[,] m_Board;
        private short m_BoardSize;
        private short m_NumberOfEmptyCells;

        ////CTOR
        public Board(short i_BoardSize)
        {
            BoardSize = i_BoardSize;
            GameBoard = new char[BoardSize, BoardSize];
            ClearBoard();
            NumberOfEmptyCells = (short)(BoardSize * BoardSize);
        }

        ////PROPERTIES
        public char[,] GameBoard
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

        public char this[int i_Row, int i_Col]
        {
            get
            {
                return m_Board[i_Row, i_Col];
            }

            set
            {
                m_Board[i_Row, i_Col] = value;
            }
        }

        public short BoardSize
        {
            get
            {
                return m_BoardSize;
            }

            set
            {
                m_BoardSize = value;
            }
        }

        public short NumberOfEmptyCells
        {
            get
            {
                return m_NumberOfEmptyCells;
            }

            set
            {
                m_NumberOfEmptyCells = value;
            }
        }

        ////METHODS
        public void ClearBoard()
        {
            for (short i = 0; i < BoardSize; i++)
            {
                for (short j = 0; j < BoardSize; j++)
                {
                    GameBoard[i, j] = (char)Player.ePlayerSign.Empty;
                }
            }

            NumberOfEmptyCells = (short)(BoardSize * BoardSize);
        }

        public void MarkSquare(short i_RowIndex, short i_ColIndex, Player.ePlayerSign i_Sign)
        {
            GameBoard[i_RowIndex - 1, i_ColIndex - 1] = (char)i_Sign;
            NumberOfEmptyCells--;
        }

        public class Point
        {
            private short m_Row;
            private short m_Col;

            public Point(short i_Row, short i_Col)
            {
                m_Row = i_Row;
                m_Col = i_Col;
            }

            ////PROPERTIES
            public short Row
            {
                get
                {
                    return m_Row;
                }

                set
                {
                    m_Row = value;
                }
            }

            public short Col
            {
                get
                {
                    return m_Col;
                }

                set
                {
                    m_Col = value;
                }
            }
        }
    }
}
