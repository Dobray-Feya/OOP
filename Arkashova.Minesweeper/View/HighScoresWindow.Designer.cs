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
            this.label1 = new System.Windows.Forms.Label();
            this.gameModeLabel = new System.Windows.Forms.Label();
            this.highScoresTable = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Режим игры:";
            // 
            // gameModeLabel
            // 
            this.gameModeLabel.AutoSize = true;
            this.gameModeLabel.Location = new System.Drawing.Point(144, 15);
            this.gameModeLabel.Name = "gameModeLabel";
            this.gameModeLabel.Size = new System.Drawing.Size(0, 15);
            this.gameModeLabel.TabIndex = 1;
            // 
            // highScoresTable
            // 
            this.highScoresTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.highScoresTable.ColumnCount = 3;
            this.highScoresTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.highScoresTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.highScoresTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.highScoresTable.Location = new System.Drawing.Point(45, 73);
            this.highScoresTable.Name = "highScoresTable";
            this.highScoresTable.RowCount = 2;
            this.highScoresTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.highScoresTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.highScoresTable.Size = new System.Drawing.Size(337, 431);
            this.highScoresTable.TabIndex = 2;
            // 
            // HighScoresWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(459, 516);
            this.Controls.Add(this.highScoresTable);
            this.Controls.Add(this.gameModeLabel);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "HighScoresWindow";
            this.Text = "Победители";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label gameModeLabel;
        private TableLayoutPanel highScoresTable;
    }
}