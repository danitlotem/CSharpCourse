using System;

namespace B21_Ex05_TicTacToeGame
{
    public class Player
    {
        ////DATA MEMBERS
        private ePlayerSign m_Sign;
        private int m_Score;
        private bool m_IsHuman;

        public enum ePlayerSign
        {
            X = 'X',
            O = 'O',
            Empty = ' '
        }

        public Player(ePlayerSign i_Sign, bool i_IsHuman)
        {
            Sign = i_Sign;
            Score = 0;
            IsHuman = i_IsHuman;
        }

        ////PROPERTIES

        public ePlayerSign Sign
        {
            get
            {
                return m_Sign;
            }

            set
            {
                m_Sign = value;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }

            set
            {
                m_Score = value;
            }
        }

        public bool IsHuman
        {
            get
            {
                return m_IsHuman;
            }

            set
            {
                m_IsHuman = value;
            }
        }
    }
}