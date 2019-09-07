namespace WindowsFormsApp1
{
    partial class Form5
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
            this.button1 = new System.Windows.Forms.Button();
            this.friend_id_label = new System.Windows.Forms.Label();
            this.friend_box = new System.Windows.Forms.TextBox();
            this.request_button = new System.Windows.Forms.Button();
            this.exist_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(487, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Find";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // friend_id_label
            // 
            this.friend_id_label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.friend_id_label.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friend_id_label.Location = new System.Drawing.Point(214, 167);
            this.friend_id_label.Name = "friend_id_label";
            this.friend_id_label.Size = new System.Drawing.Size(86, 29);
            this.friend_id_label.TabIndex = 1;
            this.friend_id_label.Text = "ID";
            this.friend_id_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // friend_box
            // 
            this.friend_box.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friend_box.Location = new System.Drawing.Point(327, 167);
            this.friend_box.Name = "friend_box";
            this.friend_box.Size = new System.Drawing.Size(131, 29);
            this.friend_box.TabIndex = 2;
            // 
            // request_button
            // 
            this.request_button.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.request_button.Location = new System.Drawing.Point(278, 275);
            this.request_button.Name = "request_button";
            this.request_button.Size = new System.Drawing.Size(239, 29);
            this.request_button.TabIndex = 3;
            this.request_button.Text = "Send Request";
            this.request_button.UseVisualStyleBackColor = true;
            this.request_button.Click += new System.EventHandler(this.request_button_Click);
            // 
            // exist_label
            // 
            this.exist_label.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.exist_label.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exist_label.Location = new System.Drawing.Point(600, 167);
            this.exist_label.Name = "exist_label";
            this.exist_label.Size = new System.Drawing.Size(86, 29);
            this.exist_label.TabIndex = 4;
            this.exist_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exist_label);
            this.Controls.Add(this.request_button);
            this.Controls.Add(this.friend_box);
            this.Controls.Add(this.friend_id_label);
            this.Controls.Add(this.button1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label friend_id_label;
        private System.Windows.Forms.TextBox friend_box;
        private System.Windows.Forms.Button request_button;
        private System.Windows.Forms.Label exist_label;
    }
}