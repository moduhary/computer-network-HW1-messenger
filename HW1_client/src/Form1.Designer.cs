namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Signin_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.Signup_button = new System.Windows.Forms.Button();
            this.ID_label = new System.Windows.Forms.Label();
            this.Password_label = new System.Windows.Forms.Label();
            this.ID_text = new System.Windows.Forms.TextBox();
            this.Password_text = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Signin_button
            // 
            this.Signin_button.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Signin_button.Location = new System.Drawing.Point(248, 333);
            this.Signin_button.Name = "Signin_button";
            this.Signin_button.Size = new System.Drawing.Size(88, 36);
            this.Signin_button.TabIndex = 0;
            this.Signin_button.Text = "Sign in";
            this.Signin_button.UseVisualStyleBackColor = true;
            this.Signin_button.Click += new System.EventHandler(this.Signin_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_button.Location = new System.Drawing.Point(427, 333);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(85, 36);
            this.cancel_button.TabIndex = 1;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // Signup_button
            // 
            this.Signup_button.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Signup_button.Location = new System.Drawing.Point(339, 394);
            this.Signup_button.Name = "Signup_button";
            this.Signup_button.Size = new System.Drawing.Size(86, 36);
            this.Signup_button.TabIndex = 2;
            this.Signup_button.Text = "Sign up";
            this.Signup_button.UseVisualStyleBackColor = true;
            this.Signup_button.Click += new System.EventHandler(this.Signup_button_Click);
            // 
            // ID_label
            // 
            this.ID_label.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ID_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ID_label.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_label.Location = new System.Drawing.Point(237, 131);
            this.ID_label.Name = "ID_label";
            this.ID_label.Size = new System.Drawing.Size(128, 37);
            this.ID_label.TabIndex = 3;
            this.ID_label.Text = "ID";
            this.ID_label.Click += new System.EventHandler(this.label1_Click);
            // 
            // Password_label
            // 
            this.Password_label.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Password_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Password_label.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_label.Location = new System.Drawing.Point(237, 181);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(128, 37);
            this.Password_label.TabIndex = 4;
            this.Password_label.Text = "Password";
            this.Password_label.Click += new System.EventHandler(this.Password_label_Click);
            // 
            // ID_text
            // 
            this.ID_text.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_text.Location = new System.Drawing.Point(389, 131);
            this.ID_text.Name = "ID_text";
            this.ID_text.Size = new System.Drawing.Size(137, 39);
            this.ID_text.TabIndex = 5;
            this.ID_text.TextChanged += new System.EventHandler(this.ID_text_TextChanged);
            // 
            // Password_text
            // 
            this.Password_text.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_text.Location = new System.Drawing.Point(389, 179);
            this.Password_text.Name = "Password_text";
            this.Password_text.Size = new System.Drawing.Size(137, 39);
            this.Password_text.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Password_text);
            this.Controls.Add(this.ID_text);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.ID_label);
            this.Controls.Add(this.Signup_button);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.Signin_button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Signin_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button Signup_button;
        private System.Windows.Forms.Label ID_label;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.TextBox ID_text;
        private System.Windows.Forms.TextBox Password_text;
    }
}

