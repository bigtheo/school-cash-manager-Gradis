namespace Scool_cash_manager
{
    partial class FrmConfigurationApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfigurationApplication));
            this.panelBarreDeTitre = new System.Windows.Forms.Panel();
            this.btnFermer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_nom_entite = new System.Windows.Forms.TextBox();
            this.pbx_logo = new System.Windows.Forms.PictureBox();
            this.btnParcourir = new System.Windows.Forms.Button();
            this.rt_devise = new System.Windows.Forms.RichTextBox();
            this.txt_adresse = new System.Windows.Forms.TextBox();
            this.txt_telephone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnClear = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.nud_jour_mois = new System.Windows.Forms.NumericUpDown();
            this.panelBarreDeTitre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_logo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_jour_mois)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBarreDeTitre
            // 
            this.panelBarreDeTitre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(107)))), ((int)(((byte)(153)))));
            this.panelBarreDeTitre.Controls.Add(this.btnFermer);
            this.panelBarreDeTitre.Controls.Add(this.label1);
            this.panelBarreDeTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarreDeTitre.Location = new System.Drawing.Point(0, 0);
            this.panelBarreDeTitre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelBarreDeTitre.Name = "panelBarreDeTitre";
            this.panelBarreDeTitre.Size = new System.Drawing.Size(701, 34);
            this.panelBarreDeTitre.TabIndex = 7;
            this.panelBarreDeTitre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelBarreDeTitre_MouseDown);
            // 
            // btnFermer
            // 
            this.btnFermer.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFermer.FlatAppearance.BorderSize = 0;
            this.btnFermer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFermer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFermer.ForeColor = System.Drawing.Color.White;
            this.btnFermer.Location = new System.Drawing.Point(673, 0);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(28, 34);
            this.btnFermer.TabIndex = 2;
            this.btnFermer.Text = "x";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.BtnFermer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configuration de base de l\'application";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nom de l\'entité";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Adresse";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(292, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Dévise de l\'écôle";
            // 
            // txt_nom_entite
            // 
            this.txt_nom_entite.Location = new System.Drawing.Point(419, 79);
            this.txt_nom_entite.Name = "txt_nom_entite";
            this.txt_nom_entite.Size = new System.Drawing.Size(239, 27);
            this.txt_nom_entite.TabIndex = 11;
            // 
            // pbx_logo
            // 
            this.pbx_logo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbx_logo.Location = new System.Drawing.Point(40, 79);
            this.pbx_logo.Name = "pbx_logo";
            this.pbx_logo.Size = new System.Drawing.Size(235, 244);
            this.pbx_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbx_logo.TabIndex = 12;
            this.pbx_logo.TabStop = false;
            this.pbx_logo.DoubleClick += new System.EventHandler(this.Pbx_logo_DoubleClick);
            // 
            // btnParcourir
            // 
            this.btnParcourir.Location = new System.Drawing.Point(40, 329);
            this.btnParcourir.Name = "btnParcourir";
            this.btnParcourir.Size = new System.Drawing.Size(235, 29);
            this.btnParcourir.TabIndex = 13;
            this.btnParcourir.Text = "Parcourir logo...";
            this.btnParcourir.UseVisualStyleBackColor = true;
            this.btnParcourir.Click += new System.EventHandler(this.BtnParcourir_Click);
            // 
            // rt_devise
            // 
            this.rt_devise.Location = new System.Drawing.Point(419, 237);
            this.rt_devise.Name = "rt_devise";
            this.rt_devise.Size = new System.Drawing.Size(239, 75);
            this.rt_devise.TabIndex = 14;
            this.rt_devise.Text = "";
            // 
            // txt_adresse
            // 
            this.txt_adresse.Location = new System.Drawing.Point(419, 115);
            this.txt_adresse.Multiline = true;
            this.txt_adresse.Name = "txt_adresse";
            this.txt_adresse.Size = new System.Drawing.Size(239, 80);
            this.txt_adresse.TabIndex = 15;
            // 
            // txt_telephone
            // 
            this.txt_telephone.Location = new System.Drawing.Point(419, 201);
            this.txt_telephone.Name = "txt_telephone";
            this.txt_telephone.Size = new System.Drawing.Size(239, 27);
            this.txt_telephone.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Télephone";
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnuler.Location = new System.Drawing.Point(603, 2);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(75, 28);
            this.btnAnnuler.TabIndex = 18;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnregistrer.Location = new System.Drawing.Point(508, 2);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(89, 28);
            this.btnEnregistrer.TabIndex = 20;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.BtnEnregistrer_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btnEnregistrer);
            this.panel1.Controls.Add(this.btnAnnuler);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 421);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 32);
            this.panel1.TabIndex = 21;
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(40, 362);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(235, 28);
            this.BtnClear.TabIndex = 21;
            this.BtnClear.Text = "Nettoyer le logo";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(292, 315);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(258, 47);
            this.label6.TabIndex = 23;
            this.label6.Text = "Le jour du mois à partir duquel l\'élève ne paie pas le mois en cours";
            // 
            // nud_jour_mois
            // 
            this.nud_jour_mois.Location = new System.Drawing.Point(577, 329);
            this.nud_jour_mois.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.nud_jour_mois.Name = "nud_jour_mois";
            this.nud_jour_mois.Size = new System.Drawing.Size(80, 27);
            this.nud_jour_mois.TabIndex = 24;
            // 
            // FrmConfigurationApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(701, 453);
            this.Controls.Add(this.nud_jour_mois);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_telephone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_adresse);
            this.Controls.Add(this.rt_devise);
            this.Controls.Add(this.btnParcourir);
            this.Controls.Add(this.pbx_logo);
            this.Controls.Add(this.txt_nom_entite);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelBarreDeTitre);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmConfigurationApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "School cash manager";
            this.panelBarreDeTitre.ResumeLayout(false);
            this.panelBarreDeTitre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_logo)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_jour_mois)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBarreDeTitre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_nom_entite;
        private System.Windows.Forms.PictureBox pbx_logo;
        private System.Windows.Forms.Button btnParcourir;
        private System.Windows.Forms.RichTextBox rt_devise;
        private System.Windows.Forms.TextBox txt_adresse;
        private System.Windows.Forms.TextBox txt_telephone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nud_jour_mois;
    }
}