namespace Arkashova.Minesweeper
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gameTable = new System.Windows.Forms.TableLayoutPanel();
            this.startGameButton = new System.Windows.Forms.Button();
            this.borderPanel = new System.Windows.Forms.Panel();
            this.gameModesListBox = new System.Windows.Forms.ListBox();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.widthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.gameModeSelectorPanel = new System.Windows.Forms.Panel();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.minesCountTextBox = new System.Windows.Forms.TextBox();
            this.MinesCountlabel = new System.Windows.Forms.Label();
            this.borderPanel.SuspendLayout();
            this.gameModeSelectorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameTable
            // 
            this.gameTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gameTable.BackColor = System.Drawing.SystemColors.Control;
            this.gameTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.gameTable.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gameTable.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.gameTable.Location = new System.Drawing.Point(0, 0);
            this.gameTable.Margin = new System.Windows.Forms.Padding(0);
            this.gameTable.Name = "gameTable";
            this.gameTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.gameTable.Size = new System.Drawing.Size(20, 0);
            this.gameTable.TabIndex = 0;
            // 
            // startGameButton
            // 
            this.startGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startGameButton.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startGameButton.Location = new System.Drawing.Point(262, 10);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(60, 60);
            this.startGameButton.TabIndex = 1;
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // borderPanel
            // 
            this.borderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.borderPanel.Controls.Add(this.gameTable);
            this.borderPanel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.borderPanel.Location = new System.Drawing.Point(99, 125);
            this.borderPanel.Margin = new System.Windows.Forms.Padding(0);
            this.borderPanel.Name = "borderPanel";
            this.borderPanel.Size = new System.Drawing.Size(440, 409);
            this.borderPanel.TabIndex = 2;
            this.borderPanel.Visible = false;
            // 
            // gameModesListBox
            // 
            this.gameModesListBox.FormattingEnabled = true;
            this.gameModesListBox.ItemHeight = 15;
            this.gameModesListBox.Location = new System.Drawing.Point(13, 10);
            this.gameModesListBox.Name = "gameModesListBox";
            this.gameModesListBox.Size = new System.Drawing.Size(99, 79);
            this.gameModesListBox.TabIndex = 3;
            this.gameModesListBox.SelectedIndexChanged += new System.EventHandler(this.modesListBox_SelectedIndexChanged);
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(182, 40);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(40, 23);
            this.heightTextBox.TabIndex = 5;
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(125, 10);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(55, 15);
            this.widthLabel.TabIndex = 6;
            this.widthLabel.Text = "ширина:";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(131, 40);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(49, 15);
            this.heightLabel.TabIndex = 7;
            this.heightLabel.Text = "высота:";
            // 
            // gameModeSelectorPanel
            // 
            this.gameModeSelectorPanel.Controls.Add(this.widthTextBox);
            this.gameModeSelectorPanel.Controls.Add(this.startGameButton);
            this.gameModeSelectorPanel.Controls.Add(this.minesCountTextBox);
            this.gameModeSelectorPanel.Controls.Add(this.MinesCountlabel);
            this.gameModeSelectorPanel.Controls.Add(this.heightLabel);
            this.gameModeSelectorPanel.Controls.Add(this.widthLabel);
            this.gameModeSelectorPanel.Controls.Add(this.heightTextBox);
            this.gameModeSelectorPanel.Controls.Add(this.gameModesListBox);
            this.gameModeSelectorPanel.Location = new System.Drawing.Point(80, 12);
            this.gameModeSelectorPanel.Name = "gameModeSelectorPanel";
            this.gameModeSelectorPanel.Size = new System.Drawing.Size(459, 99);
            this.gameModeSelectorPanel.TabIndex = 8;
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(182, 10);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(40, 23);
            this.widthTextBox.TabIndex = 11;
            this.widthTextBox.TextChanged += new System.EventHandler(this.widthTextBox_TextChanged);
            // 
            // minesCountTextBox
            // 
            this.minesCountTextBox.Location = new System.Drawing.Point(182, 70);
            this.minesCountTextBox.Name = "minesCountTextBox";
            this.minesCountTextBox.Size = new System.Drawing.Size(40, 23);
            this.minesCountTextBox.TabIndex = 9;
            // 
            // MinesCountlabel
            // 
            this.MinesCountlabel.AutoSize = true;
            this.MinesCountlabel.Location = new System.Drawing.Point(138, 70);
            this.MinesCountlabel.Name = "MinesCountlabel";
            this.MinesCountlabel.Size = new System.Drawing.Size(42, 15);
            this.MinesCountlabel.TabIndex = 8;
            this.MinesCountlabel.Text = "мины:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 861);
            this.Controls.Add(this.borderPanel);
            this.Controls.Add(this.gameModeSelectorPanel);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "MainWindow";
            this.Text = "Сапёр";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.borderPanel.ResumeLayout(false);
            this.gameModeSelectorPanel.ResumeLayout(false);
            this.gameModeSelectorPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel gameTable;
        private Button startGameButton;
        private Panel borderPanel;
        private ListBox gameModesListBox;
        private TextBox heightTextBox;
        private Label widthLabel;
        private Label heightLabel;
        private Panel gameModeSelectorPanel;
        private TextBox minesCountTextBox;
        private Label MinesCountlabel;
        private TextBox widthTextBox;
    }
}