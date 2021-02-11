namespace Scool_cash_manager
{
    partial class frmNouvelleAvanceSalaire
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNouvelleAvanceSalaire));
            this.BtnEnregistrer = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.nup_salaire_brut = new System.Windows.Forms.NumericUpDown();
            this.cbx_section = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnFermer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelBarreDeTitre = new System.Windows.Forms.Panel();
            this.cbx_fonction = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtNoms = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nup_matricule = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.nup_montant = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxMois = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nup_salaire_brut)).BeginInit();
            this.PanelBarreDeTitre.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_matricule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nup_montant)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnEnregistrer
            // 
            this.BtnEnregistrer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnEnregistrer.FlatAppearance.BorderSize = 0;
            this.BtnEnregistrer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(107)))), ((int)(((byte)(153)))));
            this.BtnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEnregistrer.ForeColor = System.Drawing.Color.White;
            this.BtnEnregistrer.Location = new System.Drawing.Point(137, 20);
            this.BtnEnregistrer.MaximumSize = new System.Drawing.Size(127, 31);
            this.BtnEnregistrer.Name = "BtnEnregistrer";
            this.BtnEnregistrer.Size = new System.Drawing.Size(98, 28);
            this.BtnEnregistrer.TabIndex = 60;
            this.BtnEnregistrer.Text = "Enregistrer";
            this.BtnEnregistrer.UseVisualStyleBackColor = false;
            this.BtnEnregistrer.Click += new System.EventHandler(this.BtnEnregistrer_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 17);
            this.label6.TabIndex = 52;
            this.label6.Text = "salaire brut";
            // 
            // nup_salaire_brut
            // 
            this.nup_salaire_brut.Enabled = false;
            this.nup_salaire_brut.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nup_salaire_brut.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nup_salaire_brut.Location = new System.Drawing.Point(99, 228);
            this.nup_salaire_brut.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nup_salaire_brut.Name = "nup_salaire_brut";
            this.nup_salaire_brut.Size = new System.Drawing.Size(231, 27);
            this.nup_salaire_brut.TabIndex = 50;
            this.nup_salaire_brut.ThousandsSeparator = true;
            // 
            // cbx_section
            // 
            this.cbx_section.Enabled = false;
            this.cbx_section.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_section.FormatString = "C2";
            this.cbx_section.FormattingEnabled = true;
            this.cbx_section.Items.AddRange(new object[] {
            "Maternelle",
            "Primaire",
            "Secondaire"});
            this.cbx_section.Location = new System.Drawing.Point(99, 193);
            this.cbx_section.Name = "cbx_section";
            this.cbx_section.Size = new System.Drawing.Size(232, 25);
            this.cbx_section.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 49;
            this.label2.Text = "Section";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(323, 21);
            this.label7.TabIndex = 46;
            this.label7.Text = "Veuillez saisir le matricule de l\'enseignant";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 43;
            this.label5.Text = "Mois";
            // 
            // BtnFermer
            // 
            this.BtnFermer.BackColor = System.Drawing.Color.Transparent;
            this.BtnFermer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnFermer.FlatAppearance.BorderSize = 0;
            this.BtnFermer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(107)))), ((int)(((byte)(153)))));
            this.BtnFermer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFermer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFermer.ForeColor = System.Drawing.Color.White;
            this.BtnFermer.Location = new System.Drawing.Point(334, 7);
            this.BtnFermer.MaximumSize = new System.Drawing.Size(127, 31);
            this.BtnFermer.Name = "BtnFermer";
            this.BtnFermer.Size = new System.Drawing.Size(36, 31);
            this.BtnFermer.TabIndex = 7;
            this.BtnFermer.Text = "X";
            this.BtnFermer.UseVisualStyleBackColor = false;
            this.BtnFermer.Click += new System.EventHandler(this.BtnFermer_Click_1);
            this.BtnFermer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelBarreDeTitre_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enregistrement des avances";
            // 
            // PanelBarreDeTitre
            // 
            this.PanelBarreDeTitre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.PanelBarreDeTitre.Controls.Add(this.BtnFermer);
            this.PanelBarreDeTitre.Controls.Add(this.label1);
            this.PanelBarreDeTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelBarreDeTitre.Location = new System.Drawing.Point(0, 0);
            this.PanelBarreDeTitre.Margin = new System.Windows.Forms.Padding(4);
            this.PanelBarreDeTitre.Name = "PanelBarreDeTitre";
            this.PanelBarreDeTitre.Size = new System.Drawing.Size(383, 43);
            this.PanelBarreDeTitre.TabIndex = 53;
            this.PanelBarreDeTitre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelBarreDeTitre_MouseDown);
            // 
            // cbx_fonction
            // 
            this.cbx_fonction.Enabled = false;
            this.cbx_fonction.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_fonction.FormattingEnabled = true;
            this.cbx_fonction.Items.AddRange(new object[] {
            "Administratif",
            "Enseignant",
            "Ouvrier"});
            this.cbx_fonction.Location = new System.Drawing.Point(99, 162);
            this.cbx_fonction.Name = "cbx_fonction";
            this.cbx_fonction.Size = new System.Drawing.Size(232, 25);
            this.cbx_fonction.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 40;
            this.label4.Text = "Fonction";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 39;
            this.label3.Text = "Noms";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.BtnEnregistrer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 384);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(383, 60);
            this.panel2.TabIndex = 54;
            // 
            // txtNoms
            // 
            this.txtNoms.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoms.Enabled = false;
            this.txtNoms.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoms.Location = new System.Drawing.Point(99, 95);
            this.txtNoms.Name = "txtNoms";
            this.txtNoms.Size = new System.Drawing.Size(233, 25);
            this.txtNoms.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.cbxMois);
            this.panel1.Controls.Add(this.nup_matricule);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.nup_montant);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.nup_salaire_brut);
            this.panel1.Controls.Add(this.cbx_section);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbx_fonction);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNoms);
            this.panel1.Location = new System.Drawing.Point(7, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 327);
            this.panel1.TabIndex = 55;
            // 
            // nup_matricule
            // 
            this.nup_matricule.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nup_matricule.Location = new System.Drawing.Point(101, 63);
            this.nup_matricule.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nup_matricule.Name = "nup_matricule";
            this.nup_matricule.Size = new System.Drawing.Size(231, 27);
            this.nup_matricule.TabIndex = 56;
            this.nup_matricule.ValueChanged += new System.EventHandler(this.Nup_matricule_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(31, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 17);
            this.label9.TabIndex = 55;
            this.label9.Text = "Matricule";
            // 
            // nup_montant
            // 
            this.nup_montant.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nup_montant.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nup_montant.Location = new System.Drawing.Point(99, 262);
            this.nup_montant.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nup_montant.Name = "nup_montant";
            this.nup_montant.Size = new System.Drawing.Size(231, 27);
            this.nup_montant.TabIndex = 54;
            this.nup_montant.ThousandsSeparator = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(44, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 17);
            this.label8.TabIndex = 53;
            this.label8.Text = "Avance";
            // 
            // cbxMois
            // 
            this.cbxMois.Enabled = false;
            this.cbxMois.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMois.FormattingEnabled = true;
            this.cbxMois.Items.AddRange(new object[] {
            "Administratif",
            "Enseignant",
            "Ouvrier"});
            this.cbxMois.Location = new System.Drawing.Point(98, 126);
            this.cbxMois.Name = "cbxMois";
            this.cbxMois.Size = new System.Drawing.Size(232, 25);
            this.cbxMois.TabIndex = 57;
            // 
            // frmNouvelleAvanceSalaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 444);
            this.Controls.Add(this.PanelBarreDeTitre);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNouvelleAvanceSalaire";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAvanceSalaire";
            ((System.ComponentModel.ISupportInitialize)(this.nup_salaire_brut)).EndInit();
            this.PanelBarreDeTitre.ResumeLayout(false);
            this.PanelBarreDeTitre.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_matricule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nup_montant)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnEnregistrer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nup_salaire_brut;
        private System.Windows.Forms.ComboBox cbx_section;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnFermer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PanelBarreDeTitre;
        private System.Windows.Forms.ComboBox cbx_fonction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtNoms;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nup_montant;
        private System.Windows.Forms.NumericUpDown nup_matricule;
        private System.Windows.Forms.ComboBox cbxMois;
    }
}