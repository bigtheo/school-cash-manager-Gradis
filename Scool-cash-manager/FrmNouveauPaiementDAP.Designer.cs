namespace Scool_cash_manager
{
    partial class FrmNouveauPaiementDAP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNouveauPaiementDAP));
            this.BtnQuitter = new System.Windows.Forms.Button();
            this.panelBarreDeTitre = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.rtxtDescription = new System.Windows.Forms.RichTextBox();
            this.nupMontantDapPaye = new System.Windows.Forms.NumericUpDown();
            this.cbx_classe = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNoms = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nupId = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nupDAP = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nupReste = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.nupMontant = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.panelBarreDeTitre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupMontantDapPaye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupDAP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupReste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMontant)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnQuitter
            // 
            this.BtnQuitter.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnQuitter.FlatAppearance.BorderSize = 0;
            this.BtnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQuitter.ForeColor = System.Drawing.Color.White;
            this.BtnQuitter.Location = new System.Drawing.Point(654, 0);
            this.BtnQuitter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnQuitter.Name = "BtnQuitter";
            this.BtnQuitter.Size = new System.Drawing.Size(49, 59);
            this.BtnQuitter.TabIndex = 0;
            this.BtnQuitter.Text = "X";
            this.BtnQuitter.UseVisualStyleBackColor = true;
            this.BtnQuitter.Click += new System.EventHandler(this.BtnQuitter_Click);
            // 
            // panelBarreDeTitre
            // 
            this.panelBarreDeTitre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(107)))), ((int)(((byte)(153)))));
            this.panelBarreDeTitre.Controls.Add(this.pictureBox1);
            this.panelBarreDeTitre.Controls.Add(this.label6);
            this.panelBarreDeTitre.Controls.Add(this.BtnQuitter);
            this.panelBarreDeTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarreDeTitre.Location = new System.Drawing.Point(0, 0);
            this.panelBarreDeTitre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelBarreDeTitre.Name = "panelBarreDeTitre";
            this.panelBarreDeTitre.Size = new System.Drawing.Size(703, 59);
            this.panelBarreDeTitre.TabIndex = 11;
            this.panelBarreDeTitre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelBarreDeTitre_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(52, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Paiements D.A.P";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.btnEnregistrer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 429);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(703, 76);
            this.panel1.TabIndex = 12;
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(201)))));
            this.btnEnregistrer.FlatAppearance.BorderSize = 0;
            this.btnEnregistrer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(107)))), ((int)(((byte)(153)))));
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.ForeColor = System.Drawing.Color.White;
            this.btnEnregistrer.Location = new System.Drawing.Point(267, 17);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(168, 45);
            this.btnEnregistrer.TabIndex = 21;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.BtnEnregistrer_Click);
            // 
            // rtxtDescription
            // 
            this.rtxtDescription.Enabled = false;
            this.rtxtDescription.Location = new System.Drawing.Point(174, 297);
            this.rtxtDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtxtDescription.Name = "rtxtDescription";
            this.rtxtDescription.Size = new System.Drawing.Size(450, 62);
            this.rtxtDescription.TabIndex = 21;
            this.rtxtDescription.Text = "";
            // 
            // nupMontantDapPaye
            // 
            this.nupMontantDapPaye.BackColor = System.Drawing.Color.White;
            this.nupMontantDapPaye.Enabled = false;
            this.nupMontantDapPaye.Location = new System.Drawing.Point(445, 221);
            this.nupMontantDapPaye.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nupMontantDapPaye.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nupMontantDapPaye.Name = "nupMontantDapPaye";
            this.nupMontantDapPaye.Size = new System.Drawing.Size(180, 27);
            this.nupMontantDapPaye.TabIndex = 20;
            this.nupMontantDapPaye.ThousandsSeparator = true;
            // 
            // cbx_classe
            // 
            this.cbx_classe.Enabled = false;
            this.cbx_classe.FormattingEnabled = true;
            this.cbx_classe.Location = new System.Drawing.Point(174, 220);
            this.cbx_classe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_classe.Name = "cbx_classe";
            this.cbx_classe.Size = new System.Drawing.Size(156, 28);
            this.cbx_classe.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 300);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Description";
            // 
            // txtNoms
            // 
            this.txtNoms.Enabled = false;
            this.txtNoms.Location = new System.Drawing.Point(174, 183);
            this.txtNoms.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNoms.Name = "txtNoms";
            this.txtNoms.Size = new System.Drawing.Size(450, 27);
            this.txtNoms.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 223);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Montant Payé";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 223);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Classe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 186);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Noms";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(495, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "Veuillez saisir l\'Id de l\'éleve -EAP et sa dette des années passées";
            // 
            // nupId
            // 
            this.nupId.Location = new System.Drawing.Point(174, 146);
            this.nupId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nupId.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nupId.Name = "nupId";
            this.nupId.Size = new System.Drawing.Size(208, 27);
            this.nupId.TabIndex = 22;
            this.nupId.ValueChanged += new System.EventHandler(this.NupId_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(102, 148);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Id EAP";
            // 
            // nupDAP
            // 
            this.nupDAP.BackColor = System.Drawing.Color.White;
            this.nupDAP.Enabled = false;
            this.nupDAP.Location = new System.Drawing.Point(445, 148);
            this.nupDAP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nupDAP.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nupDAP.Name = "nupDAP";
            this.nupDAP.Size = new System.Drawing.Size(180, 27);
            this.nupDAP.TabIndex = 25;
            this.nupDAP.ThousandsSeparator = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(390, 150);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "DAP";
            // 
            // nupReste
            // 
            this.nupReste.BackColor = System.Drawing.Color.White;
            this.nupReste.Enabled = false;
            this.nupReste.Location = new System.Drawing.Point(174, 260);
            this.nupReste.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nupReste.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nupReste.Name = "nupReste";
            this.nupReste.Size = new System.Drawing.Size(450, 27);
            this.nupReste.TabIndex = 27;
            this.nupReste.ThousandsSeparator = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(56, 262);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 20);
            this.label9.TabIndex = 26;
            this.label9.Text = "Reste à payer";
            // 
            // nupMontant
            // 
            this.nupMontant.BackColor = System.Drawing.Color.LightGray;
            this.nupMontant.Increment = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nupMontant.Location = new System.Drawing.Point(174, 369);
            this.nupMontant.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nupMontant.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nupMontant.Name = "nupMontant";
            this.nupMontant.Size = new System.Drawing.Size(208, 27);
            this.nupMontant.TabIndex = 29;
            this.nupMontant.ThousandsSeparator = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(89, 371);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 20);
            this.label10.TabIndex = 28;
            this.label10.Text = "Montant";
            // 
            // FrmNouveauPaiementDAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(703, 505);
            this.Controls.Add(this.nupMontant);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.nupReste);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nupDAP);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nupId);
            this.Controls.Add(this.panelBarreDeTitre);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rtxtDescription);
            this.Controls.Add(this.nupMontantDapPaye);
            this.Controls.Add(this.cbx_classe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNoms);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmNouveauPaiementDAP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "paimentDAP";
            this.panelBarreDeTitre.ResumeLayout(false);
            this.panelBarreDeTitre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupMontantDapPaye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupDAP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupReste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMontant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnQuitter;
        private System.Windows.Forms.Panel panelBarreDeTitre;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.RichTextBox rtxtDescription;
        private System.Windows.Forms.NumericUpDown nupMontantDapPaye;
        private System.Windows.Forms.ComboBox cbx_classe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNoms;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nupId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nupDAP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nupReste;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nupMontant;
        private System.Windows.Forms.Label label10;
    }
}