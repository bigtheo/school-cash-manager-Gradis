namespace Scool_cash_manager
{
    partial class FrmApercuAvantImpression
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmApercuAvantImpression));
            this.axFoxitCtl1 = new AxFOXITREADERLib.AxFoxitCtl();
            ((System.ComponentModel.ISupportInitialize)(this.axFoxitCtl1)).BeginInit();
            this.SuspendLayout();
            // 
            // axFoxitCtl1
            // 
            this.axFoxitCtl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axFoxitCtl1.Enabled = true;
            this.axFoxitCtl1.Location = new System.Drawing.Point(0, 0);
            this.axFoxitCtl1.Name = "axFoxitCtl1";
            this.axFoxitCtl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axFoxitCtl1.OcxState")));
            this.axFoxitCtl1.Size = new System.Drawing.Size(562, 502);
            this.axFoxitCtl1.TabIndex = 1;
            // 
            // FrmApercuAvantImpression
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 502);
            this.Controls.Add(this.axFoxitCtl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmApercuAvantImpression";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Impression";
            ((System.ComponentModel.ISupportInitialize)(this.axFoxitCtl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private AxFOXITREADERLib.AxFoxitCtl axFoxitCtl1;
    }
}