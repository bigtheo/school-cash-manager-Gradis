namespace Scool_cash_manager
{
    partial class FrmNouveauEleveDAP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNouveauEleveDAP));
            this.BtnQuitter = new System.Windows.Forms.Button();
            this.panelBarreDeTitre = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNoms = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbx_classe = new System.Windows.Forms.ComboBox();
            this.rtxtDescription = new System.Windows.Forms.RichTextBox();
            this.nupMontant = new System.Windows.Forms.NumericUpDown();
            this.panelBarreDeTitre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupMontant)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnQuitter
            // 
            this.BtnQuitter.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnQuitter.FlatAppearance.BorderSize = 0;
            this.BtnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQuitter.ForeColor = System.Drawing.Color.White;
            this.BtnQuitter.Location = new System.Drawing.Point(571, 0);
            this.BtnQuitter.Name = "BtnQuitter";
            this.BtnQuitter.Size = new System.Drawing.Size(37, 45);
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
            this.panelBarreDeTitre.Name = "panelBarreDeTitre";
            this.panelBarreDeTitre.Size = new System.Drawing.Size(608, 45);
            this.panelBarreDeTitre.TabIndex = 0;
            this.panelBarreDeTitre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelBarreDeTitre_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(39, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Nouveau élève && DAP";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.btnEnregistrer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 358);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 63);
            this.panel1.TabIndex = 1;
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(201)))));
            this.btnEnregistrer.FlatAppearance.BorderSize = 0;
            this.btnEnregistrer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(107)))), ((int)(((byte)(153)))));
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.ForeColor = System.Drawing.Color.White;
            this.btnEnregistrer.Location = new System.Drawing.Point(241, 10);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(126, 42);
            this.btnEnregistrer.TabIndex = 21;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.BtnEnregistrer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(495, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Veuillez saisir les information de l\'éleve et sa dette des années passées";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Noms";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Classe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Montant";
            // 
            // txtNoms
            // 
            this.txtNoms.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoms.Location = new System.Drawing.Point(181, 115);
            this.txtNoms.Name = "txtNoms";
            this.txtNoms.Size = new System.Drawing.Size(354, 29);
            this.txtNoms.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "Description";
            // 
            // cbx_classe
            // 
            this.cbx_classe.FormattingEnabled = true;
            this.cbx_classe.Location = new System.Drawing.Point(181, 152);
            this.cbx_classe.Name = "cbx_classe";
            this.cbx_classe.Size = new System.Drawing.Size(156, 29);
            this.cbx_classe.TabIndex = 8;
            // 
            // rtxtDescription
            // 
            this.rtxtDescription.Location = new System.Drawing.Point(181, 233);
            this.rtxtDescription.Name = "rtxtDescription";
            this.rtxtDescription.Size = new System.Drawing.Size(354, 76);
            this.rtxtDescription.TabIndex = 10;
            this.rtxtDescription.Text = "";
            // 
            // nupMontant
            // 
            this.nupMontant.DecimalPlaces = 2;
            this.nupMontant.Increment = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nupMontant.Location = new System.Drawing.Point(181, 189);
            this.nupMontant.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nupMontant.Name = "nupMontant";
            this.nupMontant.Size = new System.Drawing.Size(156, 29);
            this.nupMontant.TabIndex = 11;
            this.nupMontant.ThousandsSeparator = true;
            // 
            // FrmNouveauEleveDAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(608, 421);
            this.Controls.Add(this.nupMontant);
            this.Controls.Add(this.rtxtDescription);
            this.Controls.Add(this.cbx_classe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNoms);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBarreDeTitre);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmNouveauEleveDAP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nouveu élève DAP";
            this.panelBarreDeTitre.ResumeLayout(false);
            this.panelBarreDeTitre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupMontant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnQuitter;
        private System.Windows.Forms.Panel panelBarreDeTitre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNoms;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbx_classe;
        private System.Windows.Forms.RichTextBox rtxtDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown nupMontant;
    }
}