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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.gameTable = new System.Windows.Forms.TableLayoutPanel();
            this.startGameButton = new System.Windows.Forms.Button();
            this.borderPanel = new System.Windows.Forms.Panel();
            this.gameModesListBox = new System.Windows.Forms.ListBox();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.widthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.toolsPanel = new System.Windows.Forms.Panel();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.startLabel = new System.Windows.Forms.Label();
            this.gameModeLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.highScoresButton = new System.Windows.Forms.Button();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.aboutButton = new System.Windows.Forms.Button();
            this.minesCountTextBox = new System.Windows.Forms.TextBox();
            this.MinesCountlabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.borderPanel.SuspendLayout();
            this.toolsPanel.SuspendLayout();
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
            this.startGameButton.Location = new System.Drawing.Point(260, 32);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(50, 50);
            this.startGameButton.TabIndex = 4;
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // borderPanel
            // 
            this.borderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.borderPanel.Controls.Add(this.gameTable);
            this.borderPanel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.borderPanel.Location = new System.Drawing.Point(80, 180);
            this.borderPanel.Margin = new System.Windows.Forms.Padding(0);
            this.borderPanel.Name = "borderPanel";
            this.borderPanel.Size = new System.Drawing.Size(456, 409);
            this.borderPanel.TabIndex = 2;
            this.borderPanel.Visible = false;
            // 
            // gameModesListBox
            // 
            this.gameModesListBox.FormattingEnabled = true;
            this.gameModesListBox.ItemHeight = 15;
            this.gameModesListBox.Location = new System.Drawing.Point(19, 28);
            this.gameModesListBox.Name = "gameModesListBox";
            this.gameModesListBox.Size = new System.Drawing.Size(99, 79);
            this.gameModesListBox.TabIndex = 0;
            this.gameModesListBox.SelectedIndexChanged += new System.EventHandler(this.modesListBox_SelectedIndexChanged);
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(184, 47);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(40, 23);
            this.heightTextBox.TabIndex = 2;
            this.heightTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(125, 13);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(55, 15);
            this.widthLabel.TabIndex = 6;
            this.widthLabel.Text = "Ширина:";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(130, 50);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(50, 15);
            this.heightLabel.TabIndex = 7;
            this.heightLabel.Text = "Высота:";
            // 
            // toolsPanel
            // 
            this.toolsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolsPanel.Controls.Add(this.timeTextBox);
            this.toolsPanel.Controls.Add(this.startLabel);
            this.toolsPanel.Controls.Add(this.gameModeLabel);
            this.toolsPanel.Controls.Add(this.exitButton);
            this.toolsPanel.Controls.Add(this.highScoresButton);
            this.toolsPanel.Controls.Add(this.widthTextBox);
            this.toolsPanel.Controls.Add(this.aboutButton);
            this.toolsPanel.Controls.Add(this.startGameButton);
            this.toolsPanel.Controls.Add(this.minesCountTextBox);
            this.toolsPanel.Controls.Add(this.MinesCountlabel);
            this.toolsPanel.Controls.Add(this.heightLabel);
            this.toolsPanel.Controls.Add(this.widthLabel);
            this.toolsPanel.Controls.Add(this.heightTextBox);
            this.toolsPanel.Controls.Add(this.gameModesListBox);
            this.toolsPanel.Location = new System.Drawing.Point(80, 30);
            this.toolsPanel.Name = "toolsPanel";
            this.toolsPanel.Size = new System.Drawing.Size(480, 120);
            this.toolsPanel.TabIndex = 8;
            // 
            // timeTextBox
            // 
            this.timeTextBox.Location = new System.Drawing.Point(266, 84);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(40, 23);
            this.timeTextBox.TabIndex = 14;
            this.timeTextBox.Text = "0";
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.startLabel.Location = new System.Drawing.Point(258, 9);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(52, 19);
            this.startLabel.TabIndex = 13;
            this.startLabel.Text = "Старт!";
            // 
            // gameModeLabel
            // 
            this.gameModeLabel.AutoSize = true;
            this.gameModeLabel.Location = new System.Drawing.Point(19, 10);
            this.gameModeLabel.Name = "gameModeLabel";
            this.gameModeLabel.Size = new System.Drawing.Size(48, 15);
            this.gameModeLabel.TabIndex = 12;
            this.gameModeLabel.Text = "Режим:";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(356, 84);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(100, 23);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "Выход";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // highScoresButton
            // 
            this.highScoresButton.Location = new System.Drawing.Point(356, 10);
            this.highScoresButton.Name = "highScoresButton";
            this.highScoresButton.Size = new System.Drawing.Size(100, 23);
            this.highScoresButton.TabIndex = 5;
            this.highScoresButton.Text = "Победители";
            this.highScoresButton.UseVisualStyleBackColor = true;
            this.highScoresButton.Click += new System.EventHandler(this.highScoresButton_Click);
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(184, 10);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(40, 23);
            this.widthTextBox.TabIndex = 1;
            this.widthTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(356, 47);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(100, 23);
            this.aboutButton.TabIndex = 6;
            this.aboutButton.Text = "О программе";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // minesCountTextBox
            // 
            this.minesCountTextBox.Location = new System.Drawing.Point(184, 84);
            this.minesCountTextBox.Name = "minesCountTextBox";
            this.minesCountTextBox.Size = new System.Drawing.Size(40, 23);
            this.minesCountTextBox.TabIndex = 3;
            this.minesCountTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // MinesCountlabel
            // 
            this.MinesCountlabel.AutoSize = true;
            this.MinesCountlabel.Location = new System.Drawing.Point(136, 87);
            this.MinesCountlabel.Name = "MinesCountlabel";
            this.MinesCountlabel.Size = new System.Drawing.Size(44, 15);
            this.MinesCountlabel.TabIndex = 8;
            this.MinesCountlabel.Text = "Мины:";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 861);
            this.Controls.Add(this.borderPanel);
            this.Controls.Add(this.toolsPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "MainWindow";
            this.Text = "Сапёр";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.borderPanel.ResumeLayout(false);
            this.toolsPanel.ResumeLayout(false);
            this.toolsPanel.PerformLayout();
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
        private Panel toolsPanel;
        private TextBox minesCountTextBox;
        private Label MinesCountlabel;
        private TextBox widthTextBox;
        private Label gameModeLabel;
        private Button exitButton;
        private Button highScoresButton;
        private Button aboutButton;
        private Label startLabel;
        private TextBox timeTextBox;
        private System.Windows.Forms.Timer timer;
    }
}