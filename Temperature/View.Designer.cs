namespace TemperatureTask
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
            this.temperatureToInKelvin = new System.Windows.Forms.RadioButton();
            this.temperatureToInFahrenheit = new System.Windows.Forms.RadioButton();
            this.temperatureToInCelsius = new System.Windows.Forms.RadioButton();
            this.temperatureFromGroup = new System.Windows.Forms.GroupBox();
            this.temperatureFromInCelsius = new System.Windows.Forms.RadioButton();
            this.temperatureFromField = new System.Windows.Forms.TextBox();
            this.temperatureFromInFahrenheit = new System.Windows.Forms.RadioButton();
            this.temperatureFromInKelvin = new System.Windows.Forms.RadioButton();
            this.temperatureToGroup = new System.Windows.Forms.GroupBox();
            this.temperatuteToField = new System.Windows.Forms.TextBox();
            this.temperatureFromGroup.SuspendLayout();
            this.temperatureToGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(130, 157);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(80, 49);
            this.convertButton.TabIndex = 1;
            this.convertButton.Text = "Перевести -------->";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // temperatureToInKelvin
            // 
            this.temperatureToInKelvin.AutoSize = true;
            this.temperatureToInKelvin.Location = new System.Drawing.Point(10, 70);
            this.temperatureToInKelvin.Name = "temperatureToInKelvin";
            this.temperatureToInKelvin.Size = new System.Drawing.Size(37, 19);
            this.temperatureToInKelvin.TabIndex = 8;
            this.temperatureToInKelvin.TabStop = true;
            this.temperatureToInKelvin.Text = "°K";
            this.temperatureToInKelvin.UseVisualStyleBackColor = true;
            // 
            // temperatureToInFahrenheit
            // 
            this.temperatureToInFahrenheit.AutoSize = true;
            this.temperatureToInFahrenheit.Location = new System.Drawing.Point(10, 45);
            this.temperatureToInFahrenheit.Name = "temperatureToInFahrenheit";
            this.temperatureToInFahrenheit.Size = new System.Drawing.Size(36, 19);
            this.temperatureToInFahrenheit.TabIndex = 7;
            this.temperatureToInFahrenheit.TabStop = true;
            this.temperatureToInFahrenheit.Text = "°F";
            this.temperatureToInFahrenheit.UseVisualStyleBackColor = true;
            // 
            // temperatureToInCelsius
            // 
            this.temperatureToInCelsius.AutoSize = true;
            this.temperatureToInCelsius.Location = new System.Drawing.Point(10, 20);
            this.temperatureToInCelsius.Name = "temperatureToInCelsius";
            this.temperatureToInCelsius.Size = new System.Drawing.Size(38, 19);
            this.temperatureToInCelsius.TabIndex = 6;
            this.temperatureToInCelsius.TabStop = true;
            this.temperatureToInCelsius.Text = "°C";
            this.temperatureToInCelsius.UseVisualStyleBackColor = true;
            // 
            // temperatureFromGroup
            // 
            this.temperatureFromGroup.Controls.Add(this.temperatureFromInCelsius);
            this.temperatureFromGroup.Controls.Add(this.temperatureFromField);
            this.temperatureFromGroup.Controls.Add(this.temperatureFromInFahrenheit);
            this.temperatureFromGroup.Controls.Add(this.temperatureFromInKelvin);
            this.temperatureFromGroup.Location = new System.Drawing.Point(20, 56);
            this.temperatureFromGroup.Name = "temperatureFromGroup";
            this.temperatureFromGroup.Size = new System.Drawing.Size(100, 150);
            this.temperatureFromGroup.TabIndex = 10;
            this.temperatureFromGroup.TabStop = false;
            this.temperatureFromGroup.Text = "Из:";
            // 
            // temperatureFromInCelsius
            // 
            this.temperatureFromInCelsius.AutoSize = true;
            this.temperatureFromInCelsius.Location = new System.Drawing.Point(10, 20);
            this.temperatureFromInCelsius.Name = "temperatureFromInCelsius";
            this.temperatureFromInCelsius.Size = new System.Drawing.Size(38, 19);
            this.temperatureFromInCelsius.TabIndex = 2;
            this.temperatureFromInCelsius.TabStop = true;
            this.temperatureFromInCelsius.Text = "°C";
            this.temperatureFromInCelsius.UseVisualStyleBackColor = true;
            // 
            // temperatureFromField
            // 
            this.temperatureFromField.Location = new System.Drawing.Point(10, 110);
            this.temperatureFromField.Name = "temperatureFromField";
            this.temperatureFromField.Size = new System.Drawing.Size(75, 23);
            this.temperatureFromField.TabIndex = 0;
            this.temperatureFromField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // temperatureFromInFahrenheit
            // 
            this.temperatureFromInFahrenheit.AutoSize = true;
            this.temperatureFromInFahrenheit.Location = new System.Drawing.Point(10, 45);
            this.temperatureFromInFahrenheit.Name = "temperatureFromInFahrenheit";
            this.temperatureFromInFahrenheit.Size = new System.Drawing.Size(36, 19);
            this.temperatureFromInFahrenheit.TabIndex = 3;
            this.temperatureFromInFahrenheit.TabStop = true;
            this.temperatureFromInFahrenheit.Text = "°F";
            this.temperatureFromInFahrenheit.UseVisualStyleBackColor = true;
            // 
            // temperatureFromInKelvin
            // 
            this.temperatureFromInKelvin.AutoSize = true;
            this.temperatureFromInKelvin.Location = new System.Drawing.Point(10, 70);
            this.temperatureFromInKelvin.Name = "temperatureFromInKelvin";
            this.temperatureFromInKelvin.Size = new System.Drawing.Size(37, 19);
            this.temperatureFromInKelvin.TabIndex = 4;
            this.temperatureFromInKelvin.TabStop = true;
            this.temperatureFromInKelvin.Text = "°K";
            this.temperatureFromInKelvin.UseVisualStyleBackColor = true;
            // 
            // temperatureToGroup
            // 
            this.temperatureToGroup.Controls.Add(this.temperatuteToField);
            this.temperatureToGroup.Controls.Add(this.temperatureToInCelsius);
            this.temperatureToGroup.Controls.Add(this.temperatureToInKelvin);
            this.temperatureToGroup.Controls.Add(this.temperatureToInFahrenheit);
            this.temperatureToGroup.Location = new System.Drawing.Point(220, 56);
            this.temperatureToGroup.Name = "temperatureToGroup";
            this.temperatureToGroup.Size = new System.Drawing.Size(100, 150);
            this.temperatureToGroup.TabIndex = 11;
            this.temperatureToGroup.TabStop = false;
            this.temperatureToGroup.Text = "В:";
            // 
            // temperatuteToField
            // 
            this.temperatuteToField.Enabled = false;
            this.temperatuteToField.Location = new System.Drawing.Point(10, 110);
            this.temperatuteToField.Name = "temperatuteToField";
            this.temperatuteToField.Size = new System.Drawing.Size(75, 23);
            this.temperatuteToField.TabIndex = 11;
            this.temperatuteToField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
        private RadioButton temperatureToInKelvin;
        private RadioButton temperatureToInFahrenheit;
        private RadioButton temperatureToInCelsius;
        private GroupBox temperatureFromGroup;
        private RadioButton temperatureFromInCelsius;
        private TextBox temperatureFromField;
        private RadioButton temperatureFromInFahrenheit;
        private RadioButton temperatureFromInKelvin;
        private GroupBox temperatureToGroup;
        private TextBox temperatuteToField;
    }
}