namespace Arkashova.TemperatureTask
{
    partial class View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            this.convertButton = new System.Windows.Forms.Button();
            this.temperatureFromGroup = new System.Windows.Forms.GroupBox();
            this.sourceScalesListBox = new System.Windows.Forms.ListBox();
            this.temperatureFromField = new System.Windows.Forms.TextBox();
            this.temperatureToGroup = new System.Windows.Forms.GroupBox();
            this.temperatuteToField = new System.Windows.Forms.TextBox();
            this.resultScalesListBox = new System.Windows.Forms.ListBox();
            this.temperatureFromGroup.SuspendLayout();
            this.temperatureToGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(130, 65);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(80, 49);
            this.convertButton.TabIndex = 1;
            this.convertButton.Text = "Перевести -------->";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // temperatureFromGroup
            // 
            this.temperatureFromGroup.Controls.Add(this.sourceScalesListBox);
            this.temperatureFromGroup.Controls.Add(this.temperatureFromField);
            this.temperatureFromGroup.Location = new System.Drawing.Point(20, 56);
            this.temperatureFromGroup.Name = "temperatureFromGroup";
            this.temperatureFromGroup.Size = new System.Drawing.Size(100, 160);
            this.temperatureFromGroup.TabIndex = 10;
            this.temperatureFromGroup.TabStop = false;
            this.temperatureFromGroup.Text = "Из:";
            // 
            // sourceScalesListBox
            // 
            this.sourceScalesListBox.FormattingEnabled = true;
            this.sourceScalesListBox.ItemHeight = 15;
            this.sourceScalesListBox.Location = new System.Drawing.Point(10, 65);
            this.sourceScalesListBox.Name = "sourceScalesListBox";
            this.sourceScalesListBox.Size = new System.Drawing.Size(75, 79);
            this.sourceScalesListBox.TabIndex = 5;
            // 
            // temperatureFromField
            // 
            this.temperatureFromField.Location = new System.Drawing.Point(10, 25);
            this.temperatureFromField.Name = "temperatureFromField";
            this.temperatureFromField.Size = new System.Drawing.Size(75, 23);
            this.temperatureFromField.TabIndex = 0;
            this.temperatureFromField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // temperatureToGroup
            // 
            this.temperatureToGroup.Controls.Add(this.resultScalesListBox);
            this.temperatureToGroup.Controls.Add(this.temperatuteToField);
            this.temperatureToGroup.Location = new System.Drawing.Point(220, 56);
            this.temperatureToGroup.Name = "temperatureToGroup";
            this.temperatureToGroup.Size = new System.Drawing.Size(100, 160);
            this.temperatureToGroup.TabIndex = 11;
            this.temperatureToGroup.TabStop = false;
            this.temperatureToGroup.Text = "В:";
            // 
            // temperatuteToField
            // 
            this.temperatuteToField.Enabled = false;
            this.temperatuteToField.Location = new System.Drawing.Point(10, 25);
            this.temperatuteToField.Name = "temperatuteToField";
            this.temperatuteToField.Size = new System.Drawing.Size(75, 23);
            this.temperatuteToField.TabIndex = 11;
            this.temperatuteToField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // resultScalesListBox
            // 
            this.resultScalesListBox.FormattingEnabled = true;
            this.resultScalesListBox.ItemHeight = 15;
            this.resultScalesListBox.Location = new System.Drawing.Point(10, 65);
            this.resultScalesListBox.Name = "resultScalesListBox";
            this.resultScalesListBox.Size = new System.Drawing.Size(75, 79);
            this.resultScalesListBox.TabIndex = 12;
            // 
            // View
            // 
            this.AcceptButton = this.convertButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 281);
            this.Controls.Add(this.temperatureToGroup);
            this.Controls.Add(this.temperatureFromGroup);
            this.Controls.Add(this.convertButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(360, 320);
            this.Name = "View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Перевод температур";
            this.temperatureFromGroup.ResumeLayout(false);
            this.temperatureFromGroup.PerformLayout();
            this.temperatureToGroup.ResumeLayout(false);
            this.temperatureToGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button convertButton;
        private GroupBox temperatureFromGroup;
        private TextBox temperatureFromField;
        private GroupBox temperatureToGroup;
        private TextBox temperatuteToField;
        private ListBox sourceScalesListBox;
        private ListBox resultScalesListBox;
    }
}