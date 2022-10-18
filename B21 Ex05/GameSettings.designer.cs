namespace B21_Ex05_TicTacToeGame
{
    partial class GameSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameSettings));
            this.PlayersLabel = new System.Windows.Forms.Label();
            this.Player1Label = new System.Windows.Forms.Label();
            this.boardSizeLabel = new System.Windows.Forms.Label();
            this.rowsLabel = new System.Windows.Forms.Label();
            this.colsLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.Player1TextBox = new System.Windows.Forms.TextBox();
            this.isHumanPlayer = new System.Windows.Forms.CheckBox();
            this.Player2TextBox = new System.Windows.Forms.TextBox();
            this.RowsNumeric = new System.Windows.Forms.NumericUpDown();
            this.ColsNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.RowsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColsNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayersLabel
            // 
            this.PlayersLabel.AutoSize = true;
            this.PlayersLabel.Location = new System.Drawing.Point(22, 19);
            this.PlayersLabel.Name = "PlayersLabel";
            this.PlayersLabel.Size = new System.Drawing.Size(44, 13);
            this.PlayersLabel.TabIndex = 0;
            this.PlayersLabel.Text = "Players:";
            // 
            // Player1Label
            // 
            this.Player1Label.AutoSize = true;
            this.Player1Label.Location = new System.Drawing.Point(22, 47);
            this.Player1Label.Name = "Player1Label";
            this.Player1Label.Size = new System.Drawing.Size(48, 13);
            this.Player1Label.TabIndex = 1;
            this.Player1Label.Text = "Player 1:";
            // 
            // boardSizeLabel
            // 
            this.boardSizeLabel.AutoSize = true;
            this.boardSizeLabel.Location = new System.Drawing.Point(22, 110);
            this.boardSizeLabel.Name = "boardSizeLabel";
            this.boardSizeLabel.Size = new System.Drawing.Size(61, 13);
            this.boardSizeLabel.TabIndex = 2;
            this.boardSizeLabel.Text = "Board Size:";
            // 
            // rowsLabel
            // 
            this.rowsLabel.AutoSize = true;
            this.rowsLabel.Location = new System.Drawing.Point(22, 140);
            this.rowsLabel.Name = "rowsLabel";
            this.rowsLabel.Size = new System.Drawing.Size(37, 13);
            this.rowsLabel.TabIndex = 3;
            this.rowsLabel.Text = "Rows:";
            // 
            // colsLabel
            // 
            this.colsLabel.AutoSize = true;
            this.colsLabel.Location = new System.Drawing.Point(127, 140);
            this.colsLabel.Name = "colsLabel";
            this.colsLabel.Size = new System.Drawing.Size(30, 13);
            this.colsLabel.TabIndex = 4;
            this.colsLabel.Text = "Cols:";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(25, 164);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(175, 23);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "Start!";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Player1TextBox
            // 
            this.Player1TextBox.Location = new System.Drawing.Point(90, 44);
            this.Player1TextBox.MaxLength = 10;
            this.Player1TextBox.Name = "Player1TextBox";
            this.Player1TextBox.Size = new System.Drawing.Size(100, 20);
            this.Player1TextBox.TabIndex = 8;
            this.Player1TextBox.TextChanged += new System.EventHandler(this.Player1TextBox_TextChanged);
            // 
            // isHumanPlayer
            // 
            this.isHumanPlayer.AutoSize = true;
            this.isHumanPlayer.Location = new System.Drawing.Point(25, 79);
            this.isHumanPlayer.Name = "isHumanPlayer";
            this.isHumanPlayer.Size = new System.Drawing.Size(67, 17);
            this.isHumanPlayer.TabIndex = 9;
            this.isHumanPlayer.Text = "Player 2:";
            this.isHumanPlayer.UseVisualStyleBackColor = true;
            this.isHumanPlayer.CheckedChanged += new System.EventHandler(this.isHumanPlayer_CheckedChanged);
            // 
            // Player2TextBox
            // 
            this.Player2TextBox.Enabled = false;
            this.Player2TextBox.Location = new System.Drawing.Point(90, 76);
            this.Player2TextBox.MaxLength = 10;
            this.Player2TextBox.Name = "Player2TextBox";
            this.Player2TextBox.Size = new System.Drawing.Size(100, 20);
            this.Player2TextBox.TabIndex = 10;
            this.Player2TextBox.Text = "[Computer]";
            this.Player2TextBox.TextChanged += new System.EventHandler(this.Player2TextBox_TextChanged);
            // 
            // RowsNumeric
            // 
            this.RowsNumeric.Location = new System.Drawing.Point(65, 138);
            this.RowsNumeric.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.RowsNumeric.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.RowsNumeric.Name = "RowsNumeric";
            this.RowsNumeric.Size = new System.Drawing.Size(40, 20);
            this.RowsNumeric.TabIndex = 11;
            this.RowsNumeric.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.RowsNumeric.ValueChanged += new System.EventHandler(this.RowsNumeric_ValueChanged);
            // 
            // ColsNumeric
            // 
            this.ColsNumeric.Location = new System.Drawing.Point(160, 138);
            this.ColsNumeric.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.ColsNumeric.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.ColsNumeric.Name = "ColsNumeric";
            this.ColsNumeric.Size = new System.Drawing.Size(40, 20);
            this.ColsNumeric.TabIndex = 12;
            this.ColsNumeric.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.ColsNumeric.ValueChanged += new System.EventHandler(this.ColsNumeric_ValueChanged);
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 199);
            this.Controls.Add(this.ColsNumeric);
            this.Controls.Add(this.RowsNumeric);
            this.Controls.Add(this.Player2TextBox);
            this.Controls.Add(this.isHumanPlayer);
            this.Controls.Add(this.Player1TextBox);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.colsLabel);
            this.Controls.Add(this.rowsLabel);
            this.Controls.Add(this.boardSizeLabel);
            this.Controls.Add(this.Player1Label);
            this.Controls.Add(this.PlayersLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameSettings";
            this.Text = "Game Settings";
            this.Load += new System.EventHandler(this.UIForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RowsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColsNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PlayersLabel;
        private System.Windows.Forms.Label Player1Label;
        private System.Windows.Forms.Label boardSizeLabel;
        private System.Windows.Forms.Label rowsLabel;
        private System.Windows.Forms.Label colsLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox Player1TextBox;
        private System.Windows.Forms.CheckBox isHumanPlayer;
        private System.Windows.Forms.TextBox Player2TextBox;
        private System.Windows.Forms.NumericUpDown RowsNumeric;
        private System.Windows.Forms.NumericUpDown ColsNumeric;
    }
}