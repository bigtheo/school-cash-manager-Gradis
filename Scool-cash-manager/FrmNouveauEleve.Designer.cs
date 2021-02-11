namespace Scool_cash_manager
{
    partial class FrmNouveauEleve
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNouveauEleve));
            this.panelBarreDeTitre = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFermer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.nupMontant = new System.Windows.Forms.NumericUpDown();
            this.btnNettoyerPhoto = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.dtp_date_naissance = new System.Windows.Forms.DateTimePicker();
            this.txt_telephone_mere = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.cbx_classe = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbx_section = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_telephone_pere = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbx_genre = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_adresse = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_nom_mere = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_nom_pere = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbx_lieu_naissance = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_prenom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_postnom = new System.Windows.Forms.TextBox();
            this.txt_nom = new System.Windows.Forms.TextBox();
            this.pbxPhoto = new System.Windows.Forms.PictureBox();
            this.panelBarreDeTitre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupMontant)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBarreDeTitre
            // 
            this.panelBarreDeTitre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(107)))), ((int)(((byte)(153)))));
            this.panelBarreDeTitre.Controls.Add(this.pictureBox1);
            this.panelBarreDeTitre.Controls.Add(this.btnFermer);
            this.panelBarreDeTitre.Controls.Add(this.label1);
            this.panelBarreDeTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarreDeTitre.Location = new System.Drawing.Point(0, 0);
            this.panelBarreDeTitre.Name = "panelBarreDeTitre";
            this.panelBarreDeTitre.Size = new System.Drawing.Size(667, 51);
            this.panelBarreDeTitre.TabIndex = 0;
            this.panelBarreDeTitre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelBarreDeTitre_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnFermer
            // 
            this.btnFermer.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFermer.FlatAppearance.BorderSize = 0;
            this.btnFermer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFermer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFermer.ForeColor = System.Drawing.Color.White;
            this.btnFermer.Location = new System.Drawing.Point(630, 0);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(37, 51);
            this.btnFermer.TabIndex = 1;
            this.btnFermer.Text = "x";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.BtnFermer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(32, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inscription de l\'élève";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.nupMontant);
            this.panel2.Controls.Add(this.btnNettoyerPhoto);
            this.panel2.Controls.Add(this.BtnClear);
            this.panel2.Controls.Add(this.dtp_date_naissance);
            this.panel2.Controls.Add(this.txt_telephone_mere);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.cbx_classe);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.cbx_section);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txt_telephone_pere);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.cbx_genre);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txt_adresse);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txt_nom_mere);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txt_nom_pere);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cbx_lieu_naissance);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txt_prenom);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txt_postnom);
            this.panel2.Controls.Add(this.txt_nom);
            this.panel2.Controls.Add(this.pbxPhoto);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(667, 469);
            this.panel2.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(268, 358);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 17);
            this.label15.TabIndex = 34;
            this.label15.Text = "Montant";
            // 
            // nupMontant
            // 
            this.nupMontant.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupMontant.Location = new System.Drawing.Point(344, 352);
            this.nupMontant.Maximum = new decimal(new int[] {
            500000000,
            0,
            0,
            0});
            this.nupMontant.Name = "nupMontant";
            this.nupMontant.Size = new System.Drawing.Size(268, 27);
            this.nupMontant.TabIndex = 33;
            // 
            // btnNettoyerPhoto
            // 
            this.btnNettoyerPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNettoyerPhoto.Location = new System.Drawing.Point(36, 318);
            this.btnNettoyerPhoto.Name = "btnNettoyerPhoto";
            this.btnNettoyerPhoto.Size = new System.Drawing.Size(201, 28);
            this.btnNettoyerPhoto.TabIndex = 32;
            this.btnNettoyerPhoto.Text = "Nettoyer la photo";
            this.btnNettoyerPhoto.UseVisualStyleBackColor = true;
            this.btnNettoyerPhoto.Click += new System.EventHandler(this.BtnNettoyerPhoto_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClear.Location = new System.Drawing.Point(36, 289);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(201, 28);
            this.BtnClear.TabIndex = 31;
            this.BtnClear.Text = "Parcourir la racine...";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnParcourir_Click);
            // 
            // dtp_date_naissance
            // 
            this.dtp_date_naissance.CustomFormat = "";
            this.dtp_date_naissance.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_date_naissance.Location = new System.Drawing.Point(496, 153);
            this.dtp_date_naissance.Name = "dtp_date_naissance";
            this.dtp_date_naissance.Size = new System.Drawing.Size(116, 23);
            this.dtp_date_naissance.TabIndex = 9;
            // 
            // txt_telephone_mere
            // 
            this.txt_telephone_mere.Location = new System.Drawing.Point(343, 294);
            this.txt_telephone_mere.Name = "txt_telephone_mere";
            this.txt_telephone_mere.Size = new System.Drawing.Size(270, 23);
            this.txt_telephone_mere.TabIndex = 14;
            this.txt_telephone_mere.Text = "+243";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(264, 295);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 17);
            this.label14.TabIndex = 27;
            this.label14.Text = "Tél. mère";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.btnEnregistrer);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 398);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(667, 71);
            this.panel3.TabIndex = 26;
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(201)))));
            this.btnEnregistrer.FlatAppearance.BorderSize = 0;
            this.btnEnregistrer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(107)))), ((int)(((byte)(153)))));
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.ForeColor = System.Drawing.Color.White;
            this.btnEnregistrer.Location = new System.Drawing.Point(253, 14);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(126, 42);
            this.btnEnregistrer.TabIndex = 20;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.BtnEnregistrer_Click);
            // 
            // cbx_classe
            // 
            this.cbx_classe.FormattingEnabled = true;
            this.cbx_classe.Location = new System.Drawing.Point(496, 321);
            this.cbx_classe.Name = "cbx_classe";
            this.cbx_classe.Size = new System.Drawing.Size(117, 25);
            this.cbx_classe.TabIndex = 16;
            this.cbx_classe.SelectedIndexChanged += new System.EventHandler(this.Cbx_classe_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(441, 329);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 17);
            this.label13.TabIndex = 24;
            this.label13.Text = "Classe";
            // 
            // cbx_section
            // 
            this.cbx_section.FormattingEnabled = true;
            this.cbx_section.Items.AddRange(new object[] {
            "Maternelle",
            "Primaire",
            "Secondaire",
            "Professionelle"});
            this.cbx_section.Location = new System.Drawing.Point(344, 321);
            this.cbx_section.Name = "cbx_section";
            this.cbx_section.Size = new System.Drawing.Size(91, 25);
            this.cbx_section.TabIndex = 15;
            this.cbx_section.SelectedIndexChanged += new System.EventHandler(this.Cbx_section_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(265, 323);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 17);
            this.label12.TabIndex = 22;
            this.label12.Text = "Section";
            // 
            // txt_telephone_pere
            // 
            this.txt_telephone_pere.Location = new System.Drawing.Point(344, 265);
            this.txt_telephone_pere.Name = "txt_telephone_pere";
            this.txt_telephone_pere.Size = new System.Drawing.Size(270, 23);
            this.txt_telephone_pere.TabIndex = 13;
            this.txt_telephone_pere.Text = "+243";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(265, 266);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 17);
            this.label11.TabIndex = 20;
            this.label11.Text = "Tél. père";
            // 
            // cbx_genre
            // 
            this.cbx_genre.FormattingEnabled = true;
            this.cbx_genre.Items.AddRange(new object[] {
            "F",
            "M"});
            this.cbx_genre.Location = new System.Drawing.Point(344, 120);
            this.cbx_genre.Name = "cbx_genre";
            this.cbx_genre.Size = new System.Drawing.Size(270, 25);
            this.cbx_genre.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(265, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "Genre";
            // 
            // txt_adresse
            // 
            this.txt_adresse.Location = new System.Drawing.Point(344, 236);
            this.txt_adresse.Name = "txt_adresse";
            this.txt_adresse.Size = new System.Drawing.Size(270, 23);
            this.txt_adresse.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(265, 237);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "Adresse";
            // 
            // txt_nom_mere
            // 
            this.txt_nom_mere.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_nom_mere.Location = new System.Drawing.Point(344, 208);
            this.txt_nom_mere.Name = "txt_nom_mere";
            this.txt_nom_mere.Size = new System.Drawing.Size(270, 23);
            this.txt_nom_mere.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(265, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Mère";
            // 
            // txt_nom_pere
            // 
            this.txt_nom_pere.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_nom_pere.Location = new System.Drawing.Point(344, 180);
            this.txt_nom_pere.Name = "txt_nom_pere";
            this.txt_nom_pere.Size = new System.Drawing.Size(270, 23);
            this.txt_nom_pere.TabIndex = 10;
            this.txt_nom_pere.TextChanged += new System.EventHandler(this.Txt_nom_pere_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(265, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "père";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(467, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = ",le";
            // 
            // cbx_lieu_naissance
            // 
            this.cbx_lieu_naissance.FormattingEnabled = true;
            this.cbx_lieu_naissance.Items.AddRange(new object[] {
            "Lubumbashi",
            "Kinshasa",
            "Mbuji mayi",
            "Kananga",
            "kongolo",
            "bukavu",
            "Goma",
            "Kolwezi",
            "Likasi",
            "Kipushi",
            "Kasumbalesa"});
            this.cbx_lieu_naissance.Location = new System.Drawing.Point(344, 150);
            this.cbx_lieu_naissance.Name = "cbx_lieu_naissance";
            this.cbx_lieu_naissance.Size = new System.Drawing.Size(110, 25);
            this.cbx_lieu_naissance.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(265, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Né(e) à";
            // 
            // txt_prenom
            // 
            this.txt_prenom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txt_prenom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_prenom.Location = new System.Drawing.Point(344, 92);
            this.txt_prenom.Name = "txt_prenom";
            this.txt_prenom.Size = new System.Drawing.Size(270, 23);
            this.txt_prenom.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Prénom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Post-nom";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nom";
            // 
            // txt_postnom
            // 
            this.txt_postnom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txt_postnom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_postnom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_postnom.Location = new System.Drawing.Point(344, 64);
            this.txt_postnom.Name = "txt_postnom";
            this.txt_postnom.Size = new System.Drawing.Size(270, 23);
            this.txt_postnom.TabIndex = 2;
            // 
            // txt_nom
            // 
            this.txt_nom.AccessibleDescription = "Le nom du client";
            this.txt_nom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txt_nom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_nom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_nom.Location = new System.Drawing.Point(344, 36);
            this.txt_nom.Name = "txt_nom";
            this.txt_nom.Size = new System.Drawing.Size(270, 23);
            this.txt_nom.TabIndex = 1;
            // 
            // pbxPhoto
            // 
            this.pbxPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxPhoto.Location = new System.Drawing.Point(36, 46);
            this.pbxPhoto.Name = "pbxPhoto";
            this.pbxPhoto.Size = new System.Drawing.Size(201, 240);
            this.pbxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxPhoto.TabIndex = 0;
            this.pbxPhoto.TabStop = false;
            this.pbxPhoto.Click += new System.EventHandler(this.PbxPhoto_Click);
            // 
            // frmNouveauEleve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 520);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelBarreDeTitre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNouveauEleve";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nouveau élève";
            this.Load += new System.EventHandler(this.FrmNouveauEleve_Load);
            this.panelBarreDeTitre.ResumeLayout(false);
            this.panelBarreDeTitre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupMontant)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBarreDeTitre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbxPhoto;
        private System.Windows.Forms.TextBox txt_postnom;
        private System.Windows.Forms.TextBox txt_nom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_prenom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbx_lieu_naissance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_nom_mere;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_nom_pere;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_adresse;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbx_genre;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.ComboBox cbx_classe;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbx_section;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_telephone_pere;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_telephone_mere;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtp_date_naissance;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Button btnNettoyerPhoto;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nupMontant;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}