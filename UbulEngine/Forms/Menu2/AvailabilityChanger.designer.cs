using System.Windows.Forms;

namespace UbulEngine
{
    partial class AvailabilityChanger
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_AutoAccept = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 24);
            this.label1.TabIndex = 21;
            this.label1.Text = "> tools/availability_changer";
            // 
            // comboBox
            // 
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "Online",
            "Away",
            "Mobile",
            "Offline"});
            this.comboBox.Location = new System.Drawing.Point(11, 10);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(121, 23);
            this.comboBox.TabIndex = 0;
            this.comboBox.DropDownClosed += new System.EventHandler(this.comboBox_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.panel1.Controls.Add(this.comboBox);
            this.panel1.Location = new System.Drawing.Point(221, 221);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 43);
            this.panel1.TabIndex = 22;
            // 
            // lbl_AutoAccept
            // 
            this.lbl_AutoAccept.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_AutoAccept.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl_AutoAccept.Location = new System.Drawing.Point(13, 190);
            this.lbl_AutoAccept.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_AutoAccept.Name = "lbl_AutoAccept";
            this.lbl_AutoAccept.Size = new System.Drawing.Size(572, 31);
            this.lbl_AutoAccept.TabIndex = 15;
            this.lbl_AutoAccept.Text = "Válaszd ki milyen állapotra váltanál!";
            this.lbl_AutoAccept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AvailabilityChanger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(598, 526);
            this.Controls.Add(this.lbl_AutoAccept);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "AvailabilityChanger";
            this.Text = "AvailabilityChanger";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private ComboBox comboBox;
        private Panel panel1;
        private Label lbl_AutoAccept;
    }
}