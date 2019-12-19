namespace NHLdatabaze
{
    partial class Menu
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
            this.BtnCreateMatch = new System.Windows.Forms.Button();
            this.loggedas = new System.Windows.Forms.Label();
            this.BtnZaloha = new System.Windows.Forms.Button();
            this.BtnObnovit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCreateMatch
            // 
            this.BtnCreateMatch.Location = new System.Drawing.Point(12, 68);
            this.BtnCreateMatch.Name = "BtnCreateMatch";
            this.BtnCreateMatch.Size = new System.Drawing.Size(128, 32);
            this.BtnCreateMatch.TabIndex = 0;
            this.BtnCreateMatch.Text = "Vytvořit zápas";
            this.BtnCreateMatch.UseVisualStyleBackColor = true;
            this.BtnCreateMatch.Click += new System.EventHandler(this.Button1_Click);
            // 
            // loggedas
            // 
            this.loggedas.AutoSize = true;
            this.loggedas.Location = new System.Drawing.Point(393, 9);
            this.loggedas.Name = "loggedas";
            this.loggedas.Size = new System.Drawing.Size(35, 13);
            this.loggedas.TabIndex = 1;
            this.loggedas.Text = "label1";
            // 
            // BtnZaloha
            // 
            this.BtnZaloha.Location = new System.Drawing.Point(30, 29);
            this.BtnZaloha.Name = "BtnZaloha";
            this.BtnZaloha.Size = new System.Drawing.Size(110, 23);
            this.BtnZaloha.TabIndex = 2;
            this.BtnZaloha.Text = "Zálohovat databázi";
            this.BtnZaloha.UseVisualStyleBackColor = true;
            this.BtnZaloha.Click += new System.EventHandler(this.BtnZaloha_Click);
            // 
            // BtnObnovit
            // 
            this.BtnObnovit.Location = new System.Drawing.Point(30, 58);
            this.BtnObnovit.Name = "BtnObnovit";
            this.BtnObnovit.Size = new System.Drawing.Size(110, 23);
            this.BtnObnovit.TabIndex = 3;
            this.BtnObnovit.Text = "Obnovit databázi";
            this.BtnObnovit.UseVisualStyleBackColor = true;
            this.BtnObnovit.Click += new System.EventHandler(this.BtnObnovit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "Menu";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnObnovit);
            this.groupBox1.Controls.Add(this.BtnZaloha);
            this.groupBox1.Location = new System.Drawing.Point(366, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 91);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Backup databáze";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "Upravit hráče";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 235);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loggedas);
            this.Controls.Add(this.BtnCreateMatch);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCreateMatch;
        private System.Windows.Forms.Label loggedas;
        private System.Windows.Forms.Button BtnZaloha;
        private System.Windows.Forms.Button BtnObnovit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
    }
}