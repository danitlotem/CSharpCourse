using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B21_Ex05_TicTacToeGame
{
    public class BoardButton : Button
    {
        ////DATA MEMBERS
        private short m_RowInBoard;
        private short m_ColumnInBoard;

        ////CTOR
        public BoardButton(short i_RowInBoard, short i_ColumnInBoard)
        {
            m_RowInBoard = i_RowInBoard;
            m_ColumnInBoard = i_ColumnInBoard;
        }

        //// PROPERTIES
        public short Row
        {
            get
            {
                return m_RowInBoard;
            }

            set
            {
                m_RowInBoard = value;
            }
        }

        public short Column
        {
            get
            {
                return m_ColumnInBoard;
            }

            set
            {
                m_ColumnInBoard = value;
            }
        }
    }
}