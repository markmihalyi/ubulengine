namespace UbulEngine
{
    partial class Home
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
            this.summonerName = new System.Windows.Forms.Label();
            this.summonerLvl = new System.Windows.Forms.Label();
            this.summonerLvlAfter = new System.Windows.Forms.Label();
            this.summonerXpStatus = new System.Windows.Forms.Label();
            this.summonerIcon = new System.Windows.Forms.PictureBox();
            this.summonerBe = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.summonerRp = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.progressBarBackground = new System.Windows.Forms.Panel();
            this.summonerLvlProgress = new System.Windows.Forms.Panel();
            this.btn_changeicon = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.idInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.summonerIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.progressBarBackground.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idInput)).BeginInit();
            this.SuspendLayout();
            // 
            // summonerName
            // 
            this.summonerName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.summonerName.Font = new System.Drawing.Font("Yu Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.summonerName.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.summonerName.Location = new System.Drawing.Point(14, 137);
            this.summonerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.summonerName.Name = "summonerName";
            this.summonerName.Size = new System.Drawing.Size(570, 46);
            this.summonerName.TabIndex = 0;
            this.summonerName.Text = "idéző";
            this.summonerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // summonerLvl
            // 
            this.summonerLvl.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.summonerLvl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.summonerLvl.Location = new System.Drawing.Point(14, 194);
            this.summonerLvl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.summonerLvl.Name = "summonerLvl";
            this.summonerLvl.Size = new System.Drawing.Size(210, 27);
            this.summonerLvl.TabIndex = 0;
            this.summonerLvl.Text = "0";
            this.summonerLvl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // summonerLvlAfter
            // 
            this.summonerLvlAfter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.summonerLvlAfter.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.summonerLvlAfter.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.summonerLvlAfter.Location = new System.Drawing.Point(371, 184);
            this.summonerLvlAfter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.summonerLvlAfter.Name = "summonerLvlAfter";
            this.summonerLvlAfter.Size = new System.Drawing.Size(210, 27);
            this.summonerLvlAfter.TabIndex = 0;
            this.summonerLvlAfter.Text = "1";
            this.summonerLvlAfter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // summonerXpStatus
            // 
            this.summonerXpStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.summonerXpStatus.Font = new System.Drawing.Font("Bahnschrift Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.summonerXpStatus.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.summonerXpStatus.Location = new System.Drawing.Point(231, 213);
            this.summonerXpStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.summonerXpStatus.Name = "summonerXpStatus";
            this.summonerXpStatus.Size = new System.Drawing.Size(133, 27);
            this.summonerXpStatus.TabIndex = 0;
            this.summonerXpStatus.Text = "0 / 0";
            this.summonerXpStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // summonerIcon
            // 
            this.summonerIcon.ImageLocation = "";
            this.summonerIcon.Location = new System.Drawing.Point(247, 22);
            this.summonerIcon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.summonerIcon.Name = "summonerIcon";
            this.summonerIcon.Size = new System.Drawing.Size(100, 113);
            this.summonerIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.summonerIcon.TabIndex = 0;
            this.summonerIcon.TabStop = false;
            // 
            // summonerBe
            // 
            this.summonerBe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.summonerBe.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.summonerBe.ForeColor = System.Drawing.Color.White;
            this.summonerBe.Location = new System.Drawing.Point(31, 9);
            this.summonerBe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.summonerBe.Name = "summonerBe";
            this.summonerBe.Size = new System.Drawing.Size(144, 37);
            this.summonerBe.TabIndex = 11;
            this.summonerBe.Text = "0";
            this.summonerBe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UbulEngine.Properties.Resources.BE_icon;
            this.pictureBox1.Location = new System.Drawing.Point(172, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // summonerRp
            // 
            this.summonerRp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.summonerRp.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.summonerRp.ForeColor = System.Drawing.Color.White;
            this.summonerRp.Location = new System.Drawing.Point(35, 9);
            this.summonerRp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.summonerRp.Name = "summonerRp";
            this.summonerRp.Size = new System.Drawing.Size(144, 37);
            this.summonerRp.TabIndex = 9;
            this.summonerRp.Text = "0";
            this.summonerRp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::UbulEngine.Properties.Resources.RP_icon;
            this.pictureBox2.Location = new System.Drawing.Point(10, 15);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.summonerRp);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(22, 21);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 58);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.summonerBe);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(376, 21);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(206, 58);
            this.panel2.TabIndex = 13;
            // 
            // progressBarBackground
            // 
            this.progressBarBackground.BackColor = System.Drawing.Color.Gray;
            this.progressBarBackground.Controls.Add(this.summonerLvlProgress);
            this.progressBarBackground.Location = new System.Drawing.Point(231, 200);
            this.progressBarBackground.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBarBackground.Name = "progressBarBackground";
            this.progressBarBackground.Size = new System.Drawing.Size(133, 17);
            this.progressBarBackground.TabIndex = 14;
            // 
            // summonerLvlProgress
            // 
            this.summonerLvlProgress.BackColor = System.Drawing.SystemColors.Highlight;
            this.summonerLvlProgress.Location = new System.Drawing.Point(0, 0);
            this.summonerLvlProgress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.summonerLvlProgress.Name = "summonerLvlProgress";
            this.summonerLvlProgress.Size = new System.Drawing.Size(0, 17);
            this.summonerLvlProgress.TabIndex = 15;
            // 
            // btn_changeicon
            // 
            this.btn_changeicon.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_changeicon.Location = new System.Drawing.Point(32, 69);
            this.btn_changeicon.Name = "btn_changeicon";
            this.btn_changeicon.Size = new System.Drawing.Size(140, 37);
            this.btn_changeicon.TabIndex = 15;
            this.btn_changeicon.Text = "Ikon változtatás";
            this.btn_changeicon.UseVisualStyleBackColor = true;
            this.btn_changeicon.Click += new System.EventHandler(this.btn_changeicon_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.idInput);
            this.panel3.Controls.Add(this.btn_changeicon);
            this.panel3.Location = new System.Drawing.Point(195, 365);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(207, 118);
            this.panel3.TabIndex = 18;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(67, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 21);
            this.button2.TabIndex = 18;
            this.button2.Text = "ID lista";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // idInput
            // 
            this.idInput.Location = new System.Drawing.Point(67, 13);
            this.idInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.idInput.Name = "idInput";
            this.idInput.Size = new System.Drawing.Size(69, 23);
            this.idInput.TabIndex = 19;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(598, 505);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.progressBarBackground);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.summonerXpStatus);
            this.Controls.Add(this.summonerLvlAfter);
            this.Controls.Add(this.summonerLvl);
            this.Controls.Add(this.summonerName);
            this.Controls.Add(this.summonerIcon);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Home";
            this.Text = "Home";
            ((System.ComponentModel.ISupportInitialize)(this.summonerIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.progressBarBackground.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.idInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox summonerIcon;
        public System.Windows.Forms.Label summonerName;
        public System.Windows.Forms.Label summonerLvl;
        public System.Windows.Forms.Label summonerLvlAfter;
        public System.Windows.Forms.Label summonerXpStatus;
        public System.Windows.Forms.Label summonerBe;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label summonerRp;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel progressBarBackground;
        public System.Windows.Forms.Panel summonerLvlProgress;
        private System.Windows.Forms.Button btn_changeicon;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown idInput;
    }
}