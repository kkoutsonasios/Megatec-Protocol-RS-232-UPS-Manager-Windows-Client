namespace UPS_Manager
{
    partial class CostEst
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
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.labelCurrentPS = new System.Windows.Forms.Label();
            this.labelWattage = new System.Windows.Forms.Label();
            this.labelCostEST = new System.Windows.Forms.Label();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // labelCurrentPS
            // 
            this.labelCurrentPS.AutoSize = true;
            this.labelCurrentPS.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentPS.ForeColor = System.Drawing.Color.White;
            this.labelCurrentPS.Location = new System.Drawing.Point(-1, 0);
            this.labelCurrentPS.Name = "labelCurrentPS";
            this.labelCurrentPS.Size = new System.Drawing.Size(22, 24);
            this.labelCurrentPS.TabIndex = 0;
            this.labelCurrentPS.Text = "%";
            // 
            // labelWattage
            // 
            this.labelWattage.AutoSize = true;
            this.labelWattage.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWattage.ForeColor = System.Drawing.Color.White;
            this.labelWattage.Location = new System.Drawing.Point(-1, 24);
            this.labelWattage.Name = "labelWattage";
            this.labelWattage.Size = new System.Drawing.Size(58, 24);
            this.labelWattage.TabIndex = 1;
            this.labelWattage.Text = "Watt";
            // 
            // labelCostEST
            // 
            this.labelCostEST.AutoSize = true;
            this.labelCostEST.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCostEST.ForeColor = System.Drawing.Color.White;
            this.labelCostEST.Location = new System.Drawing.Point(-1, 48);
            this.labelCostEST.Name = "labelCostEST";
            this.labelCostEST.Size = new System.Drawing.Size(58, 24);
            this.labelCostEST.TabIndex = 2;
            this.labelCostEST.Text = "Cost";
            // 
            // labelTemperature
            // 
            this.labelTemperature.AutoSize = true;
            this.labelTemperature.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemperature.ForeColor = System.Drawing.Color.White;
            this.labelTemperature.Location = new System.Drawing.Point(63, 0);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(58, 24);
            this.labelTemperature.TabIndex = 3;
            this.labelTemperature.Text = "Temp";
            // 
            // CostEst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(152, 72);
            this.ControlBox = false;
            this.Controls.Add(this.labelTemperature);
            this.Controls.Add(this.labelCostEST);
            this.Controls.Add(this.labelWattage);
            this.Controls.Add(this.labelCurrentPS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CostEst";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.CostEst_Load);
            this.DoubleClick += new System.EventHandler(this.CostEst_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label labelCurrentPS;
        private System.Windows.Forms.Label labelWattage;
        private System.Windows.Forms.Label labelCostEST;
        private System.Windows.Forms.Label labelTemperature;
    }
}