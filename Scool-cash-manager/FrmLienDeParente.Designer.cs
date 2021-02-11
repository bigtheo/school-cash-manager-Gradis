namespace Scool_cash_manager
{
    partial class FrmLienDeParente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLienDeParente));
            this.PanelBarreDeTitre = new System.Windows.Forms.Panel();
            this.BtnFermer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnEnregistrer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nnup_id_eleve = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNom_eleve = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnom_enseignant = new System.Windows.Forms.TextBox();
            this.nupMatricule_enseignant = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PanelBarreDeTitre.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nnup_id_eleve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMatricule_enseignant)).BeginInit();
            this.SuspendLayout();
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
            this.PanelBarreDeTitre.TabIndex = 54;
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
            this.BtnFermer.Location = new System.Drawing.Point(332, 7);
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
            this.label1.Size = new System.Drawing.Size(254, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lien de parenté élève && enseignant";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.BtnEnregistrer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 207);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(383, 68);
            this.panel2.TabIndex = 55;
            // 
            // BtnEnregistrer
            // 
            this.BtnEnregistrer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnEnregistrer.FlatAppearance.BorderSize = 0;
            this.BtnEnregistrer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(107)))), ((int)(((byte)(153)))));
            this.BtnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEnregistrer.ForeColor = System.Drawing.Color.White;
            this.BtnEnregistrer.Location = new System.Drawing.Point(143, 18);
            this.BtnEnregistrer.MaximumSize = new System.Drawing.Size(127, 31);
            this.BtnEnregistrer.Name = "BtnEnregistrer";
            this.BtnEnregistrer.Size = new System.Drawing.Size(111, 28);
            this.BtnEnregistrer.TabIndex = 47;
            this.BtnEnregistrer.Text = "Enregistrer";
            this.BtnEnregistrer.UseVisualStyleBackColor = false;
            this.BtnEnregistrer.Click += new System.EventHandler(this.BtnEnregistrer_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.nnup_id_eleve);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtNom_eleve);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtnom_enseignant);
            this.panel1.Controls.Add(this.nupMatricule_enseignant);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 275);
            this.panel1.TabIndex = 56;
            // 
            // nnup_id_eleve
            // 
            this.nnup_id_eleve.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nnup_id_eleve.Location = new System.Drawing.Point(182, 132);
            this.nnup_id_eleve.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nnup_id_eleve.Name = "nnup_id_eleve";
            this.nnup_id_eleve.Size = new System.Drawing.Size(169, 25);
            this.nnup_id_eleve.TabIndex = 53;
            this.nnup_id_eleve.ValueChanged += new System.EventHandler(this.Nnup_id_eleve_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(100, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 52;
            this.label5.Text = "Nom élève";
            // 
            // txtNom_eleve
            // 
            this.txtNom_eleve.Enabled = false;
            this.txtNom_eleve.Location = new System.Drawing.Point(182, 163);
            this.txtNom_eleve.Name = "txtNom_eleve";
            this.txtNom_eleve.Size = new System.Drawing.Size(169, 20);
            this.txtNom_eleve.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 50;
            this.label2.Text = "Nom enseignant";
            // 
            // txtnom_enseignant
            // 
            this.txtnom_enseignant.Enabled = false;
            this.txtnom_enseignant.Location = new System.Drawing.Point(182, 106);
            this.txtnom_enseignant.Name = "txtnom_enseignant";
            this.txtnom_enseignant.Size = new System.Drawing.Size(169, 20);
            this.txtnom_enseignant.TabIndex = 49;
            // 
            // nupMatricule_enseignant
            // 
            this.nupMatricule_enseignant.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupMatricule_enseignant.Location = new System.Drawing.Point(182, 75);
            this.nupMatricule_enseignant.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nupMatricule_enseignant.Name = "nupMatricule_enseignant";
            this.nupMatricule_enseignant.Size = new System.Drawing.Size(169, 25);
            this.nupMatricule_enseignant.TabIndex = 48;
            this.nupMatricule_enseignant.ValueChanged += new System.EventHandler(this.NupMatricule_enseignant_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(73, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(250, 21);
            this.label7.TabIndex = 46;
            this.label7.Text = "Veuillez completer le formulaire";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(76, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 40;
            this.label4.Text = "matricule élève";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 17);
            this.label3.TabIndex = 39;
            this.label3.Text = "Matricule enseignant";
            // 
            // FrmLienDeParente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 275);
            this.Controls.Add(this.PanelBarreDeTitre);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLienDeParente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLienDeParente";
            this.PanelBarreDeTitre.ResumeLayout(false);
            this.PanelBarreDeTitre.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nnup_id_eleve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMatricule_enseignant)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelBarreDeTitre;
        private System.Windows.Forms.Button BtnFermer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnEnregistrer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown nnup_id_eleve;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNom_eleve;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtnom_enseignant;
        private System.Windows.Forms.NumericUpDown nupMatricule_enseignant;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}