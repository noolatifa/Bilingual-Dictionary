namespace projet
{
    partial class login
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.kryptonMaskedTextBox2 = new ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox();
            this.kryptonMaskedTextBox3 = new ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox();
            this.user = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::projet.Properties.Resources.translate;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(701, 228);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 135);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pass
            // 
            this.pass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pass.Location = new System.Drawing.Point(251, 251);
            this.pass.Name = "pass";
            this.pass.PasswordChar = '*';
            this.pass.Size = new System.Drawing.Size(182, 27);
            this.pass.TabIndex = 62;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 33);
            this.label2.TabIndex = 60;
            this.label2.Text = "Mot de passe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cascadia Code SemiBold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MintCream;
            this.label1.Location = new System.Drawing.Point(13, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 33);
            this.label1.TabIndex = 59;
            this.label1.Text = "Utilisateur";
           // this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // kryptonMaskedTextBox2
            // 
            this.kryptonMaskedTextBox2.Enabled = false;
            this.kryptonMaskedTextBox2.Location = new System.Drawing.Point(247, 180);
            this.kryptonMaskedTextBox2.Name = "kryptonMaskedTextBox2";
            this.kryptonMaskedTextBox2.ReadOnly = true;
            this.kryptonMaskedTextBox2.Size = new System.Drawing.Size(190, 38);
            this.kryptonMaskedTextBox2.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonMaskedTextBox2.StateCommon.Border.Color1 = System.Drawing.Color.Silver;
            this.kryptonMaskedTextBox2.StateCommon.Border.Color2 = System.Drawing.Color.Silver;
            this.kryptonMaskedTextBox2.StateCommon.Border.ColorAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Control;
            this.kryptonMaskedTextBox2.StateCommon.Border.ColorAngle = 1F;
            this.kryptonMaskedTextBox2.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonMaskedTextBox2.StateCommon.Border.Rounding = 5;
            this.kryptonMaskedTextBox2.StateCommon.Border.Width = 1;
            this.kryptonMaskedTextBox2.StateCommon.Content.Color1 = System.Drawing.Color.Navy;
            this.kryptonMaskedTextBox2.StateCommon.Content.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonMaskedTextBox2.StateCommon.Content.Padding = new System.Windows.Forms.Padding(6);
            this.kryptonMaskedTextBox2.TabIndex = 63;
            // 
            // kryptonMaskedTextBox3
            // 
            this.kryptonMaskedTextBox3.Enabled = false;
            this.kryptonMaskedTextBox3.Location = new System.Drawing.Point(246, 245);
            this.kryptonMaskedTextBox3.Name = "kryptonMaskedTextBox3";
            this.kryptonMaskedTextBox3.ReadOnly = true;
            this.kryptonMaskedTextBox3.Size = new System.Drawing.Size(190, 38);
            this.kryptonMaskedTextBox3.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonMaskedTextBox3.StateCommon.Border.Color1 = System.Drawing.Color.Silver;
            this.kryptonMaskedTextBox3.StateCommon.Border.Color2 = System.Drawing.Color.Silver;
            this.kryptonMaskedTextBox3.StateCommon.Border.ColorAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Control;
            this.kryptonMaskedTextBox3.StateCommon.Border.ColorAngle = 1F;
            this.kryptonMaskedTextBox3.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonMaskedTextBox3.StateCommon.Border.Rounding = 5;
            this.kryptonMaskedTextBox3.StateCommon.Border.Width = 1;
            this.kryptonMaskedTextBox3.StateCommon.Content.Color1 = System.Drawing.Color.Navy;
            this.kryptonMaskedTextBox3.StateCommon.Content.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonMaskedTextBox3.StateCommon.Content.Padding = new System.Windows.Forms.Padding(6);
            this.kryptonMaskedTextBox3.TabIndex = 64;
            // 
            // user
            // 
            this.user.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.user.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.Location = new System.Drawing.Point(253, 186);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(180, 27);
            this.user.TabIndex = 61;
            this.user.TextChanged += new System.EventHandler(this.user_TextChanged);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Cascadia Code SemiBold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.button3.Location = new System.Drawing.Point(96, 378);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(238, 55);
            this.button3.TabIndex = 65;
            this.button3.Text = "SE CONNECTER";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::projet.Properties.Resources.Untitled_design__12_;
            this.button1.Font = new System.Drawing.Font("Cascadia Code SemiBold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(585, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(352, 80);
            this.button1.TabIndex = 66;
            this.button1.Text = "CONTINUER EN TANT QU\'INVITE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Crimson;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(896, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(41, 34);
            this.button5.TabIndex = 68;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::projet.Properties.Resources.digger_job__14_;
            this.pictureBox2.Location = new System.Drawing.Point(34, 62);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(475, 54);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 72;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::projet.Properties.Resources.digger_job__19_;
            this.pictureBox3.Location = new System.Drawing.Point(617, 24);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(302, 306);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 73;
            this.pictureBox3.TabStop = false;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::projet.Properties.Resources.Untitled_design__12_;
            this.ClientSize = new System.Drawing.Size(966, 507);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.user);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kryptonMaskedTextBox2);
            this.Controls.Add(this.kryptonMaskedTextBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Name = "login";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox pass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox kryptonMaskedTextBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox kryptonMaskedTextBox3;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}