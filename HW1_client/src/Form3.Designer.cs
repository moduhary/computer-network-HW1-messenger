namespace WindowsFormsApp1
{
    partial class Form3
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
            this.friends_request = new System.Windows.Forms.CheckedListBox();
            this.Accept_Button = new System.Windows.Forms.Button();
            this.Decline_Button = new System.Windows.Forms.Button();
            this.Newrequest_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // friends_request
            // 
            this.friends_request.CheckOnClick = true;
            this.friends_request.FormattingEnabled = true;
            this.friends_request.Location = new System.Drawing.Point(12, 12);
            this.friends_request.MultiColumn = true;
            this.friends_request.Name = "friends_request";
            this.friends_request.Size = new System.Drawing.Size(776, 388);
            this.friends_request.Sorted = true;
            this.friends_request.TabIndex = 0;
            this.friends_request.Tag = "";
            this.friends_request.SelectedIndexChanged += new System.EventHandler(this.friends_request_SelectedIndexChanged);
            // 
            // Accept_Button
            // 
            this.Accept_Button.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Accept_Button.Location = new System.Drawing.Point(204, 406);
            this.Accept_Button.Name = "Accept_Button";
            this.Accept_Button.Size = new System.Drawing.Size(99, 47);
            this.Accept_Button.TabIndex = 1;
            this.Accept_Button.Text = "Accept";
            this.Accept_Button.UseVisualStyleBackColor = true;
            this.Accept_Button.Click += new System.EventHandler(this.Accept_Button_Click);
            // 
            // Decline_Button
            // 
            this.Decline_Button.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Decline_Button.Location = new System.Drawing.Point(347, 406);
            this.Decline_Button.Name = "Decline_Button";
            this.Decline_Button.Size = new System.Drawing.Size(99, 47);
            this.Decline_Button.TabIndex = 2;
            this.Decline_Button.Text = "Decline";
            this.Decline_Button.UseVisualStyleBackColor = true;
            this.Decline_Button.Click += new System.EventHandler(this.Decline_Button_Click);
            // 
            // Newrequest_Button
            // 
            this.Newrequest_Button.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Newrequest_Button.Location = new System.Drawing.Point(487, 406);
            this.Newrequest_Button.Name = "Newrequest_Button";
            this.Newrequest_Button.Size = new System.Drawing.Size(99, 47);
            this.Newrequest_Button.TabIndex = 3;
            this.Newrequest_Button.Text = "Request";
            this.Newrequest_Button.UseVisualStyleBackColor = true;
            this.Newrequest_Button.Click += new System.EventHandler(this.Newrequest_Button_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 457);
            this.Controls.Add(this.Newrequest_Button);
            this.Controls.Add(this.Decline_Button);
            this.Controls.Add(this.Accept_Button);
            this.Controls.Add(this.friends_request);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox friends_request;
        private System.Windows.Forms.Button Accept_Button;
        private System.Windows.Forms.Button Decline_Button;
        private System.Windows.Forms.Button Newrequest_Button;
    }
}