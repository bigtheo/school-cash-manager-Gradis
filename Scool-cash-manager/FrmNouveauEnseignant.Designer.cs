namespace Scool_cash_manager
{
    partial class FrmNouveauEnseignant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNouveauEnseignant));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.nup_salaire_brut = new System.Windows.Forms.NumericUpDown();
            this.cbx_section_id = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxGenre = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxFonction = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoms = new System.Windows.Forms.TextBox();
            this.PanelBarreDeTitre = new System.Windows.Forms.Panel();
            this.BtnFermer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnEnregistrer = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_salaire_brut)).BeginInit();
            this.PanelBarreDeTitre.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.nup_salaire_brut);
            this.panel1.Controls.Add(this.cbx_section_id);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbxGenre);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbxFonction);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNoms);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 248);
            this.panel1.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 17);
            this.label6.TabIndex = 52;
            this.label6.Text = "salaire brut";
            // 
            // nup_salaire_brut
            // 
            this.nup_salaire_brut.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nup_salaire_brut.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nup_salaire_brut.Location = new System.Drawing.Point(90, 188);
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
            // cbx_section_id
            // 
            this.cbx_section_id.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_section_id.FormattingEnabled = true;
            this.cbx_section_id.Items.AddRange(new object[] {
            "Maternelle",
            "Primaire",
            "Secondaire"});
            this.cbx_section_id.Location = new System.Drawing.Point(90, 153);
            this.cbx_section_id.Name = "cbx_section_id";
            this.cbx_section_id.Size = new System.Drawing.Size(232, 25);
            this.cbx_section_id.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 49;
            this.label2.Text = "Section";
            // 
            // cbxGenre
            // 
            this.cbxGenre.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxGenre.FormattingEnabled = true;
            this.cbxGenre.Items.AddRange(new object[] {
            "F",
            "M"});
            this.cbxGenre.Location = new System.Drawing.Point(90, 86);
            this.cbxGenre.Name = "cbxGenre";
            this.cbxGenre.Size = new System.Drawing.Size(232, 25);
            this.cbxGenre.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(44, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(250, 21);
            this.label7.TabIndex = 46;
            this.label7.Text = "Veuillez completer le formulaire";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 43;
            this.label5.Text = "Genre";
            // 
            // cbxFonction
            // 
            this.cbxFonction.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFonction.FormattingEnabled = true;
            this.cbxFonction.Items.AddRange(new object[] {
            "Administratif",
            "Enseignant",
            "Ouvrier"});
            this.cbxFonction.Location = new System.Drawing.Point(90, 122);
            this.cbxFonction.Name = "cbxFonction";
            this.cbxFonction.Size = new System.Drawing.Size(232, 25);
            this.cbxFonction.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 40;
            this.label4.Text = "Fonction";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 39;
            this.label3.Text = "Noms";
            // 
            // txtNoms
            // 
            this.txtNoms.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoms.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoms.Location = new System.Drawing.Point(90, 55);
            this.txtNoms.Name = "txtNoms";
            this.txtNoms.Size = new System.Drawing.Size(233, 25);
            this.txtNoms.TabIndex = 10;
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
            this.PanelBarreDeTitre.Size = new System.Drawing.Size(373, 43);
            this.PanelBarreDeTitre.TabIndex = 50;
            this.PanelBarreDeTitre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelBarreDeTitre_MouseDown);
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
            this.BtnFermer.Click += new System.EventHandler(this.BtnFermer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enregistrement des agents";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.BtnEnregistrer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 291);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(373, 60);
            this.panel2.TabIndex = 51;
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
            // FrmNouveauEnseignant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(373, 351);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanelBarreDeTitre);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmNouveauEnseignant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmNouveauEnseignant";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_salaire_brut)).EndInit();
            this.PanelBarreDeTitre.ResumeLayout(false);
            this.PanelBarreDeTitre.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbxGenre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxFonction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNoms;
        private System.Windows.Forms.Panel PanelBarreDeTitre;
        private System.Windows.Forms.Button BtnFermer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnEnregistrer;
        private System.Windows.Forms.ComboBox cbx_section_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nup_salaire_brut;
        private System.Windows.Forms.Label label6;
    }
}