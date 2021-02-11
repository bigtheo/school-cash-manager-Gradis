namespace Scool_cash_manager
{
    partial class FrmNouveauPaiementManuels
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNouveauPaiementManuels));
            this.panelBarreDeTitre = new System.Windows.Forms.Panel();
            this.btnFermer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_prix_total = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nup_Quantite = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_montant = new System.Windows.Forms.TextBox();
            this.txt_Intitule = new System.Windows.Forms.RichTextBox();
            this.nupd_id_manuel = new System.Windows.Forms.NumericUpDown();
            this.nupdown_id = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_classe = new System.Windows.Forms.TextBox();
            this.txt_noms = new System.Windows.Forms.TextBox();
            this.lbl_frais_mensuel_id = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.panelBarreDeTitre.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_Quantite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupd_id_manuel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdown_id)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBarreDeTitre
            // 
            this.panelBarreDeTitre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(107)))), ((int)(((byte)(153)))));
            this.panelBarreDeTitre.Controls.Add(this.btnFermer);
            this.panelBarreDeTitre.Controls.Add(this.label1);
            this.panelBarreDeTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarreDeTitre.Location = new System.Drawing.Point(0, 0);
            this.panelBarreDeTitre.Name = "panelBarreDeTitre";
            this.panelBarreDeTitre.Size = new System.Drawing.Size(597, 37);
            this.panelBarreDeTitre.TabIndex = 8;
            this.panelBarreDeTitre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelBarreDeTitre_MouseDown);
            // 
            // btnFermer
            // 
            this.btnFermer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFermer.FlatAppearance.BorderSize = 0;
            this.btnFermer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFermer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFermer.ForeColor = System.Drawing.Color.White;
            this.btnFermer.Location = new System.Drawing.Point(557, 5);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(28, 27);
            this.btnFermer.TabIndex = 1;
            this.btnFermer.Text = "x";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.BtnFermer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Achat des Manuels";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txt_prix_total);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.nup_Quantite);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txt_montant);
            this.panel2.Controls.Add(this.txt_Intitule);
            this.panel2.Controls.Add(this.nupd_id_manuel);
            this.panel2.Controls.Add(this.nupdown_id);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txt_classe);
            this.panel2.Controls.Add(this.txt_noms);
            this.panel2.Controls.Add(this.lbl_frais_mensuel_id);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(597, 375);
            this.panel2.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(275, 285);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 17);
            this.label7.TabIndex = 55;
            this.label7.Text = "Prix Total";
            // 
            // txt_prix_total
            // 
            this.txt_prix_total.Location = new System.Drawing.Point(345, 283);
            this.txt_prix_total.Name = "txt_prix_total";
            this.txt_prix_total.Size = new System.Drawing.Size(204, 23);
            this.txt_prix_total.TabIndex = 54;
            this.txt_prix_total.Text = "0";
            this.txt_prix_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 53;
            this.label6.Text = "Quantité";
            // 
            // nup_Quantite
            // 
            this.nup_Quantite.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nup_Quantite.Location = new System.Drawing.Point(187, 280);
            this.nup_Quantite.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nup_Quantite.Name = "nup_Quantite";
            this.nup_Quantite.Size = new System.Drawing.Size(82, 26);
            this.nup_Quantite.TabIndex = 52;
            this.nup_Quantite.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nup_Quantite.ValueChanged += new System.EventHandler(this.Nup_Quantite_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(108, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 17);
            this.label5.TabIndex = 51;
            this.label5.Text = "Montant";
            // 
            // txt_montant
            // 
            this.txt_montant.Location = new System.Drawing.Point(187, 251);
            this.txt_montant.Name = "txt_montant";
            this.txt_montant.Size = new System.Drawing.Size(362, 23);
            this.txt_montant.TabIndex = 50;
            this.txt_montant.Text = "0";
            this.txt_montant.TextChanged += new System.EventHandler(this.Txt_montant_TextChanged);
            // 
            // txt_Intitule
            // 
            this.txt_Intitule.Location = new System.Drawing.Point(187, 158);
            this.txt_Intitule.Name = "txt_Intitule";
            this.txt_Intitule.Size = new System.Drawing.Size(362, 55);
            this.txt_Intitule.TabIndex = 49;
            this.txt_Intitule.Text = "0";
            // 
            // nupd_id_manuel
            // 
            this.nupd_id_manuel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupd_id_manuel.Location = new System.Drawing.Point(188, 219);
            this.nupd_id_manuel.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nupd_id_manuel.Name = "nupd_id_manuel";
            this.nupd_id_manuel.Size = new System.Drawing.Size(362, 26);
            this.nupd_id_manuel.TabIndex = 48;
            this.nupd_id_manuel.ValueChanged += new System.EventHandler(this.Nupd_id_manuel_ValueChanged);
            // 
            // nupdown_id
            // 
            this.nupdown_id.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupdown_id.Location = new System.Drawing.Point(188, 68);
            this.nupdown_id.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nupdown_id.Name = "nupdown_id";
            this.nupdown_id.Size = new System.Drawing.Size(362, 26);
            this.nupdown_id.TabIndex = 46;
            this.nupdown_id.ValueChanged += new System.EventHandler(this.Nupdown_id_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(112, 73);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 17);
            this.label15.TabIndex = 45;
            this.label15.Text = "Id élève";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 17);
            this.label4.TabIndex = 43;
            this.label4.Text = "Intitulé du manuel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 42;
            this.label3.Text = "Classe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 41;
            this.label2.Text = "Noms";
            // 
            // txt_classe
            // 
            this.txt_classe.Location = new System.Drawing.Point(188, 129);
            this.txt_classe.Name = "txt_classe";
            this.txt_classe.Size = new System.Drawing.Size(362, 23);
            this.txt_classe.TabIndex = 40;
            this.txt_classe.Text = "0";
            // 
            // txt_noms
            // 
            this.txt_noms.Location = new System.Drawing.Point(188, 100);
            this.txt_noms.Name = "txt_noms";
            this.txt_noms.Size = new System.Drawing.Size(362, 23);
            this.txt_noms.TabIndex = 39;
            this.txt_noms.Text = "0";
            // 
            // lbl_frais_mensuel_id
            // 
            this.lbl_frais_mensuel_id.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_frais_mensuel_id.AutoSize = true;
            this.lbl_frais_mensuel_id.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_frais_mensuel_id.Location = new System.Drawing.Point(87, 221);
            this.lbl_frais_mensuel_id.Name = "lbl_frais_mensuel_id";
            this.lbl_frais_mensuel_id.Size = new System.Drawing.Size(84, 20);
            this.lbl_frais_mensuel_id.TabIndex = 37;
            this.lbl_frais_mensuel_id.Text = "Id Manuel";
            this.lbl_frais_mensuel_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.btnEnregistrer);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 334);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(597, 41);
            this.panel3.TabIndex = 26;
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(201)))));
            this.btnEnregistrer.FlatAppearance.BorderSize = 0;
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.ForeColor = System.Drawing.Color.White;
            this.btnEnregistrer.Location = new System.Drawing.Point(12, 6);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(81, 29);
            this.btnEnregistrer.TabIndex = 0;
            this.btnEnregistrer.Text = "Enregsitrer";
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.BtnEnregistrer_Click);
            // 
            // frmNouveauPaiementManuels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 375);
            this.Controls.Add(this.panelBarreDeTitre);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNouveauPaiementManuels";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmNouveauPaiementManuels";
            this.Load += new System.EventHandler(this.FrmNouveauPaiementManuels_Load);
            this.panelBarreDeTitre.ResumeLayout(false);
            this.panelBarreDeTitre.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_Quantite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupd_id_manuel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdown_id)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBarreDeTitre;
        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_frais_mensuel_id;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.NumericUpDown nupdown_id;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_classe;
        private System.Windows.Forms.TextBox txt_noms;
        private System.Windows.Forms.NumericUpDown nupd_id_manuel;
        private System.Windows.Forms.RichTextBox txt_Intitule;
        private System.Windows.Forms.TextBox txt_montant;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nup_Quantite;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_prix_total;
    }
}