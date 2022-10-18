using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B21_Ex05_TicTacToeGame
{
    public partial class GameSettings : Form
    {
        ////DATA MEMBERS
        private short m_BoardSize;
        private bool m_IsComputerPlaying;
        private string m_FirstPlayerName;
        private string m_SecondPlayerName;

        ////CTOR
        public GameSettings()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            m_BoardSize = 3; //// Default value
            m_IsComputerPlaying = true;
            m_FirstPlayerName = null;
            m_SecondPlayerName = null;
        }

        ////PROPERTIES
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

        public string FirstPlayerName
        {
            get
            {
                return m_FirstPlayerName;
            }

            set
            {
                m_FirstPlayerName = value;
            }
        }

        public string SecondPlayerName
        {
            get
            {
                return m_SecondPlayerName;
            }

            set
            {
                m_SecondPlayerName = value;
            }
        }

        //// METHODS
        public bool IsPlayerNameValid(string i_PlayerName)
        {
            return !string.IsNullOrEmpty(i_PlayerName) && i_PlayerName.Length <= 10;
        }

        private void UIForm_Load(object sender, EventArgs e)
        {
        }

        private void isHumanPlayer_CheckedChanged(object sender, EventArgs e)
        {
            Player2TextBox.Enabled = true;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!IsPlayerNameValid(Player1TextBox.Text))
            {
                MessageBox.Show(
                    @"Player 1's name is not valid.
Player's name must not be empty (up to 10 letters)",
                    "Authentication Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else if (!IsPlayerNameValid(Player2TextBox.Text))
            {
                MessageBox.Show(
    @"Player 2's name is not valid.
Player's name must not be empty (up to 10 letters)",
    "Authentication Error",
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning);
            }
            else
            {
                BoardSize = (short)RowsNumeric.Value;
                IsComputerPlaying = isHumanPlayer.Checked;
                FirstPlayerName = Player1TextBox.Text;
                SecondPlayerName = Player2TextBox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void RowsNumeric_ValueChanged(object sender, EventArgs e)
        {
            ColsNumeric.Value = RowsNumeric.Value;
        }

        private void ColsNumeric_ValueChanged(object sender, EventArgs e)
        {
            RowsNumeric.Value = ColsNumeric.Value;
        }

        private void Player1TextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void Player2TextBox_TextChanged(object sender, EventArgs e)
        {
        }
    }
}