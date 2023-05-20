namespace Arkashova.Minesweeper.View
{
    partial class AboutWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutWindow));
            this.ProgramIconPictureBox = new System.Windows.Forms.PictureBox();
            this.programNameLabel = new System.Windows.Forms.Label();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.DataLabel = new System.Windows.Forms.Label();
            this.AcademItSchoolLinkLabel = new System.Windows.Forms.LinkLabel();
            this.extraInfoTextBox = new System.Windows.Forms.TextBox();
            this.rulesTextBox = new System.Windows.Forms.TextBox();
            this.rulesHeaderLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ProgramIconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ProgramIconPictureBox
            // 
            this.ProgramIconPictureBox.Image = global::Arkashova.Minesweeper.Properties.Resources.mine_140x1401;
            this.ProgramIconPictureBox.Location = new System.Drawing.Point(64, 88);
            this.ProgramIconPictureBox.Name = "ProgramIconPictureBox";
            this.ProgramIconPictureBox.Size = new System.Drawing.Size(140, 140);
            this.ProgramIconPictureBox.TabIndex = 0;
            this.ProgramIconPictureBox.TabStop = false;
            // 
            // programNameLabel
            // 
            this.programNameLabel.AutoSize = true;
            this.programNameLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.programNameLabel.Location = new System.Drawing.Point(64, 21);
            this.programNameLabel.Name = "programNameLabel";
            this.programNameLabel.Size = new System.Drawing.Size(85, 32);
            this.programNameLabel.TabIndex = 2;
            this.programNameLabel.Text = "Сапёр";
            // 
            // authorTextBox
            // 
            this.authorTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.authorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.authorTextBox.Location = new System.Drawing.Point(64, 244);
            this.authorTextBox.Multiline = true;
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.Size = new System.Drawing.Size(215, 67);
            this.authorTextBox.TabIndex = 3;
            this.authorTextBox.TabStop = false;
            this.authorTextBox.Text = "Выполнила Аркашова Полина\r\nна курсе ООП на C#\r\nв школе программирования\r\nAcadem I" +
    "T School.";
            // 
            // DataLabel
            // 
            this.DataLabel.AutoSize = true;
            this.DataLabel.Location = new System.Drawing.Point(64, 62);
            this.DataLabel.Name = "DataLabel";
            this.DataLabel.Size = new System.Drawing.Size(87, 15);
            this.DataLabel.TabIndex = 4;
            this.DataLabel.Text = "Дата: май 2023";
            // 
            // AcademItSchoolLinkLabel
            // 
            this.AcademItSchoolLinkLabel.AutoSize = true;
            this.AcademItSchoolLinkLabel.Location = new System.Drawing.Point(64, 306);
            this.AcademItSchoolLinkLabel.Name = "AcademItSchoolLinkLabel";
            this.AcademItSchoolLinkLabel.Size = new System.Drawing.Size(155, 15);
            this.AcademItSchoolLinkLabel.TabIndex = 5;
            this.AcademItSchoolLinkLabel.TabStop = true;
            this.AcademItSchoolLinkLabel.Text = "https://academ-it-school.ru";
            // 
            // extraInfoTextBox
            // 
            this.extraInfoTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.extraInfoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.extraInfoTextBox.Location = new System.Drawing.Point(64, 333);
            this.extraInfoTextBox.Multiline = true;
            this.extraInfoTextBox.Name = "extraInfoTextBox";
            this.extraInfoTextBox.Size = new System.Drawing.Size(215, 48);
            this.extraInfoTextBox.TabIndex = 6;
            this.extraInfoTextBox.Text = "(картинки для игры позаимствовала \r\nна сайте https://minesweeper.online)";
            // 
            // rulesTextBox
            // 
            this.rulesTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.rulesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rulesTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rulesTextBox.Location = new System.Drawing.Point(345, 88);
            this.rulesTextBox.Multiline = true;
            this.rulesTextBox.Name = "rulesTextBox";
            this.rulesTextBox.Size = new System.Drawing.Size(338, 181);
            this.rulesTextBox.TabIndex = 7;
            this.rulesTextBox.TabStop = false;
            this.rulesTextBox.Text = resources.GetString("rulesTextBox.Text");
            // 
            // rulesHeaderLabel
            // 
            this.rulesHeaderLabel.AutoSize = true;
            this.rulesHeaderLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rulesHeaderLabel.Location = new System.Drawing.Point(345, 28);
            this.rulesHeaderLabel.Name = "rulesHeaderLabel";
            this.rulesHeaderLabel.Size = new System.Drawing.Size(145, 25);
            this.rulesHeaderLabel.TabIndex = 0;
            this.rulesHeaderLabel.Text = "Правила игры";
            // 
            // AboutWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 401);
            this.Controls.Add(this.rulesHeaderLabel);
            this.Controls.Add(this.rulesTextBox);
            this.Controls.Add(this.extraInfoTextBox);
            this.Controls.Add(this.AcademItSchoolLinkLabel);
            this.Controls.Add(this.DataLabel);
            this.Controls.Add(this.authorTextBox);
            this.Controls.Add(this.programNameLabel);
            this.Controls.Add(this.ProgramIconPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(750, 440);
            this.Name = "AboutWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "О программе";
            ((System.ComponentModel.ISupportInitialize)(this.ProgramIconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox ProgramIconPictureBox;
        private Label programNameLabel;
        private TextBox authorTextBox;
        private Label DataLabel;
        private LinkLabel AcademItSchoolLinkLabel;
        private TextBox extraInfoTextBox;
        private TextBox rulesTextBox;
        private Label rulesHeaderLabel;
    }
}