namespace UPS_Manager
{
    partial class Settings
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxAutoStart = new System.Windows.Forms.CheckBox();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.checkBoxAutoMaxMin = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxControlerName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxUPSPort = new System.Windows.Forms.ComboBox();
            this.numericUpDownChargingVoltageMin = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownChargingVoltageMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownVoltageMin = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownVoltageMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChargingVoltageMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChargingVoltageMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVoltageMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVoltageMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "UPS Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Interval:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Voltage Max:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Voltage Min:";
            // 
            // checkBoxAutoStart
            // 
            this.checkBoxAutoStart.AutoSize = true;
            this.checkBoxAutoStart.Location = new System.Drawing.Point(15, 226);
            this.checkBoxAutoStart.Name = "checkBoxAutoStart";
            this.checkBoxAutoStart.Size = new System.Drawing.Size(70, 17);
            this.checkBoxAutoStart.TabIndex = 8;
            this.checkBoxAutoStart.Text = "AutoStart";
            this.checkBoxAutoStart.UseVisualStyleBackColor = true;
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Location = new System.Drawing.Point(12, 249);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(219, 23);
            this.buttonSaveSettings.TabIndex = 9;
            this.buttonSaveSettings.Text = "Save Settings";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // checkBoxAutoMaxMin
            // 
            this.checkBoxAutoMaxMin.AutoSize = true;
            this.checkBoxAutoMaxMin.Location = new System.Drawing.Point(132, 226);
            this.checkBoxAutoMaxMin.Name = "checkBoxAutoMaxMin";
            this.checkBoxAutoMaxMin.Size = new System.Drawing.Size(85, 17);
            this.checkBoxAutoMaxMin.TabIndex = 10;
            this.checkBoxAutoMaxMin.Text = "AutoMaxMin";
            this.checkBoxAutoMaxMin.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Charging Voltage Max:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Charging  Voltage Min:";
            // 
            // textBoxControlerName
            // 
            this.textBoxControlerName.Location = new System.Drawing.Point(15, 147);
            this.textBoxControlerName.Name = "textBoxControlerName";
            this.textBoxControlerName.Size = new System.Drawing.Size(217, 20);
            this.textBoxControlerName.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Controler Name:";
            // 
            // comboBoxUPSPort
            // 
            this.comboBoxUPSPort.FormattingEnabled = true;
            this.comboBoxUPSPort.Location = new System.Drawing.Point(132, 23);
            this.comboBoxUPSPort.Name = "comboBoxUPSPort";
            this.comboBoxUPSPort.Size = new System.Drawing.Size(100, 21);
            this.comboBoxUPSPort.TabIndex = 17;
            // 
            // numericUpDownChargingVoltageMin
            // 
            this.numericUpDownChargingVoltageMin.DecimalPlaces = 1;
            this.numericUpDownChargingVoltageMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownChargingVoltageMin.Location = new System.Drawing.Point(132, 199);
            this.numericUpDownChargingVoltageMin.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownChargingVoltageMin.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownChargingVoltageMin.Name = "numericUpDownChargingVoltageMin";
            this.numericUpDownChargingVoltageMin.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownChargingVoltageMin.TabIndex = 18;
            this.numericUpDownChargingVoltageMin.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDownChargingVoltageMax
            // 
            this.numericUpDownChargingVoltageMax.DecimalPlaces = 1;
            this.numericUpDownChargingVoltageMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownChargingVoltageMax.Location = new System.Drawing.Point(132, 173);
            this.numericUpDownChargingVoltageMax.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownChargingVoltageMax.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownChargingVoltageMax.Name = "numericUpDownChargingVoltageMax";
            this.numericUpDownChargingVoltageMax.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownChargingVoltageMax.TabIndex = 19;
            this.numericUpDownChargingVoltageMax.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDownVoltageMin
            // 
            this.numericUpDownVoltageMin.DecimalPlaces = 1;
            this.numericUpDownVoltageMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownVoltageMin.Location = new System.Drawing.Point(132, 103);
            this.numericUpDownVoltageMin.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownVoltageMin.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownVoltageMin.Name = "numericUpDownVoltageMin";
            this.numericUpDownVoltageMin.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownVoltageMin.TabIndex = 20;
            this.numericUpDownVoltageMin.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericUpDownVoltageMax
            // 
            this.numericUpDownVoltageMax.DecimalPlaces = 1;
            this.numericUpDownVoltageMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownVoltageMax.Location = new System.Drawing.Point(132, 77);
            this.numericUpDownVoltageMax.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownVoltageMax.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownVoltageMax.Name = "numericUpDownVoltageMax";
            this.numericUpDownVoltageMax.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownVoltageMax.TabIndex = 21;
            this.numericUpDownVoltageMax.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.DecimalPlaces = 1;
            this.numericUpDownInterval.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownInterval.Location = new System.Drawing.Point(132, 51);
            this.numericUpDownInterval.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownInterval.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownInterval.TabIndex = 22;
            this.numericUpDownInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 277);
            this.Controls.Add(this.numericUpDownInterval);
            this.Controls.Add(this.numericUpDownVoltageMax);
            this.Controls.Add(this.numericUpDownVoltageMin);
            this.Controls.Add(this.numericUpDownChargingVoltageMax);
            this.Controls.Add(this.numericUpDownChargingVoltageMin);
            this.Controls.Add(this.comboBoxUPSPort);
            this.Controls.Add(this.textBoxControlerName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBoxAutoMaxMin);
            this.Controls.Add(this.buttonSaveSettings);
            this.Controls.Add(this.checkBoxAutoStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChargingVoltageMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChargingVoltageMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVoltageMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVoltageMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxAutoStart;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.CheckBox checkBoxAutoMaxMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxControlerName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxUPSPort;
        private System.Windows.Forms.NumericUpDown numericUpDownChargingVoltageMin;
        private System.Windows.Forms.NumericUpDown numericUpDownChargingVoltageMax;
        private System.Windows.Forms.NumericUpDown numericUpDownVoltageMin;
        private System.Windows.Forms.NumericUpDown numericUpDownVoltageMax;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
    }
}