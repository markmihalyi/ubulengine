namespace UbulEngine
{
    partial class Instalock
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
            this.lbl_AutoAccept = new System.Windows.Forms.Label();
            this.btn_toggleAuto = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_champName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_hint = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_AutoAccept
            // 
            this.lbl_AutoAccept.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_AutoAccept.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl_AutoAccept.Location = new System.Drawing.Point(232, 190);
            this.lbl_AutoAccept.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_AutoAccept.Name = "lbl_AutoAccept";
            this.lbl_AutoAccept.Size = new System.Drawing.Size(131, 31);
            this.lbl_AutoAccept.TabIndex = 15;
            this.lbl_AutoAccept.Text = "Instalock";
            this.lbl_AutoAccept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_toggleAuto
            // 
            this.btn_toggleAuto.Location = new System.Drawing.Point(10, 35);
            this.btn_toggleAuto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_toggleAuto.Name = "btn_toggleAuto";
            this.btn_toggleAuto.Size = new System.Drawing.Size(131, 32);
            this.btn_toggleAuto.TabIndex = 17;
            this.btn_toggleAuto.Text = "Bekapcsolás";
            this.btn_toggleAuto.UseVisualStyleBackColor = true;
            this.btn_toggleAuto.Click += new System.EventHandler(this.btn_toggleAuto_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.panel1.Controls.Add(this.tb_champName);
            this.panel1.Controls.Add(this.btn_toggleAuto);
            this.panel1.Location = new System.Drawing.Point(224, 221);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 75);
            this.panel1.TabIndex = 20;
            // 
            // tb_champName
            // 
            this.tb_champName.Location = new System.Drawing.Point(30, 10);
            this.tb_champName.Name = "tb_champName";
            this.tb_champName.PlaceholderText = "Karakter neve";
            this.tb_champName.Size = new System.Drawing.Size(91, 23);
            this.tb_champName.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 24);
            this.label1.TabIndex = 21;
            this.label1.Text = "> tools/instalock";
            // 
            // lbl_hint
            // 
            this.lbl_hint.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_hint.Location = new System.Drawing.Point(12, 304);
            this.lbl_hint.Name = "lbl_hint";
            this.lbl_hint.Size = new System.Drawing.Size(574, 23);
            this.lbl_hint.TabIndex = 22;
            this.lbl_hint.Text = "Ha a karakter neve több szóból áll, akkor egybe írd!";
            this.lbl_hint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Instalock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(598, 526);
            this.Controls.Add(this.lbl_hint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_AutoAccept);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Instalock";
            this.Text = "Instalock";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_AutoAccept;
        private System.Windows.Forms.Button btn_toggleAuto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_champName;
        private System.Windows.Forms.Label lbl_hint;
    }
}