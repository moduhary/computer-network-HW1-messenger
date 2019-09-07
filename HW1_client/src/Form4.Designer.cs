namespace WindowsFormsApp1
{
    partial class Form4
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
            this.ID_label = new System.Windows.Forms.Label();
            this.Password_label = new System.Windows.Forms.Label();
            this.ID_text = new System.Windows.Forms.TextBox();
            this.Password_text = new System.Windows.Forms.TextBox();
            this.Signup_button = new System.Windows.Forms.Button();
            this.duplicate_check_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ID_label
            // 
            this.ID_label.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ID_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ID_label.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_label.Location = new System.Drawing.Point(239, 123);
            this.ID_label.Name = "ID_label";
            this.ID_label.Size = new System.Drawing.Size(109, 28);
            this.ID_label.TabIndex = 0;
            this.ID_label.Text = "ID";
            this.ID_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Password_label
            // 
            this.Password_label.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Password_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Password_label.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_label.Location = new System.Drawing.Point(239, 176);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(109, 28);
            this.Password_label.TabIndex = 1;
            this.Password_label.Text = "Password";
            this.Password_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ID_text
            // 
            this.ID_text.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_text.Location = new System.Drawing.Point(365, 123);
            this.ID_text.Multiline = true;
            this.ID_text.Name = "ID_text";
            this.ID_text.Size = new System.Drawing.Size(188, 28);
            this.ID_text.TabIndex = 2;
            // 
            // Password_text
            // 
            this.Password_text.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_text.Location = new System.Drawing.Point(365, 178);
            this.Password_text.Multiline = true;
            this.Password_text.Name = "Password_text";
            this.Password_text.Size = new System.Drawing.Size(188, 28);
            this.Password_text.TabIndex = 3;
            // 
            // Signup_button
            // 
            this.Signup_button.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Signup_button.Location = new System.Drawing.Point(347, 247);
            this.Signup_button.Name = "Signup_button";
            this.Signup_button.Size = new System.Drawing.Size(93, 31);
            this.Signup_button.TabIndex = 4;
            this.Signup_button.Text = "sign up";
            this.Signup_button.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Signup_button.UseVisualStyleBackColor = true;
            this.Signup_button.Click += new System.EventHandler(this.Signup_button_Click);
            // 
            // duplicate_check_button
            // 
            this.duplicate_check_button.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duplicate_check_button.Location = new System.Drawing.Point(569, 123);
            this.duplicate_check_button.Name = "duplicate_check_button";
            this.duplicate_check_button.Size = new System.Drawing.Size(96, 27);
            this.duplicate_check_button.TabIndex = 5;
            this.duplicate_check_button.Text = "Check";
            this.duplicate_check_button.UseVisualStyleBackColor = true;
            this.duplicate_check_button.Click += new System.EventHandler(this.duplicate_check_button_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.duplicate_check_button);
            this.Controls.Add(this.Signup_button);
            this.Controls.Add(this.Password_text);
            this.Controls.Add(this.ID_text);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.ID_label);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ID_label;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.TextBox ID_text;
        private System.Windows.Forms.TextBox Password_text;
        private System.Windows.Forms.Button Signup_button;
        private System.Windows.Forms.Button duplicate_check_button;
    }
}