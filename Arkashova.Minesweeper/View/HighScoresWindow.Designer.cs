namespace Arkashova.Minesweeper.View
{
    partial class HighScoresWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HighScoresWindow));
            this.labelForGameModeLabel = new System.Windows.Forms.Label();
            this.gameModeLabel = new System.Windows.Forms.Label();
            this.highScoresTable = new System.Windows.Forms.TableLayoutPanel();
            this.noWinnersLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelForGameModeLabel
            // 
            this.labelForGameModeLabel.AutoSize = true;
            this.labelForGameModeLabel.Location = new System.Drawing.Point(45, 15);
            this.labelForGameModeLabel.Name = "labelForGameModeLabel";
            this.labelForGameModeLabel.Size = new System.Drawing.Size(79, 15);
            this.labelForGameModeLabel.TabIndex = 0;
            this.labelForGameModeLabel.Text = "Режим игры:";
            // 
            // gameModeLabel
            // 
            this.gameModeLabel.AutoSize = true;
            this.gameModeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gameModeLabel.Location = new System.Drawing.Point(124, 15);
            this.gameModeLabel.Name = "gameModeLabel";
            this.gameModeLabel.Size = new System.Drawing.Size(104, 15);
            this.gameModeLabel.TabIndex = 1;
            this.gameModeLabel.Text = "название режима";
            // 
            // highScoresTable
            // 
            this.highScoresTable.AutoScroll = true;
            this.highScoresTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.highScoresTable.ColumnCount = 3;
            this.highScoresTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.highScoresTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.highScoresTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.highScoresTable.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.highScoresTable.Location = new System.Drawing.Point(45, 73);
            this.highScoresTable.Name = "highScoresTable";
            this.highScoresTable.RowCount = 1;
            this.highScoresTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.highScoresTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.highScoresTable.Size = new System.Drawing.Size(337, 415);
            this.highScoresTable.TabIndex = 2;
            // 
            // noWinnersLabel
            // 
            this.noWinnersLabel.AutoSize = true;
            this.noWinnersLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.noWinnersLabel.Location = new System.Drawing.Point(45, 40);
            this.noWinnersLabel.Name = "noWinnersLabel";
            this.noWinnersLabel.Size = new System.Drawing.Size(138, 15);
            this.noWinnersLabel.TabIndex = 3;
            this.noWinnersLabel.Text = "Пока нет победителей";
            this.noWinnersLabel.Visible = false;
            // 
            // HighScoresWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(459, 516);
            this.Controls.Add(this.noWinnersLabel);
            this.Controls.Add(this.highScoresTable);
            this.Controls.Add(this.gameModeLabel);
            this.Controls.Add(this.labelForGameModeLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(475, 1000);
            this.MinimumSize = new System.Drawing.Size(475, 400);
            this.Name = "HighScoresWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Победители";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelForGameModeLabel;
        private Label gameModeLabel;
        private TableLayoutPanel highScoresTable;
        private Label noWinnersLabel;
    }
}