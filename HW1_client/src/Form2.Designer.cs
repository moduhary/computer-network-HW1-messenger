namespace WindowsFormsApp1
{
    partial class Form2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.프로그램ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.친구요청ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.친구요청관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Friend_view = new System.Windows.Forms.TreeView();
            this.chatbox = new System.Windows.Forms.ListBox();
            this.sendtext = new System.Windows.Forms.TextBox();
            this.sendbutton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.프로그램ToolStripMenuItem,
            this.친구요청ToolStripMenuItem,
            this.updateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1269, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 프로그램ToolStripMenuItem
            // 
            this.프로그램ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.종료ToolStripMenuItem});
            this.프로그램ToolStripMenuItem.Name = "프로그램ToolStripMenuItem";
            this.프로그램ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.프로그램ToolStripMenuItem.Text = "program";
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.종료ToolStripMenuItem.Text = "Exit";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // 친구요청ToolStripMenuItem
            // 
            this.친구요청ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.친구요청관리ToolStripMenuItem});
            this.친구요청ToolStripMenuItem.Name = "친구요청ToolStripMenuItem";
            this.친구요청ToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.친구요청ToolStripMenuItem.Text = "friends";
            // 
            // 친구요청관리ToolStripMenuItem
            // 
            this.친구요청관리ToolStripMenuItem.Name = "친구요청관리ToolStripMenuItem";
            this.친구요청관리ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.친구요청관리ToolStripMenuItem.Text = "manage request";
            this.친구요청관리ToolStripMenuItem.Click += new System.EventHandler(this.친구요청관리ToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateAllToolStripMenuItem});
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.updateToolStripMenuItem.Text = "update";
            // 
            // updateAllToolStripMenuItem
            // 
            this.updateAllToolStripMenuItem.Name = "updateAllToolStripMenuItem";
            this.updateAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.updateAllToolStripMenuItem.Text = "update all";
            this.updateAllToolStripMenuItem.Click += new System.EventHandler(this.updateAllToolStripMenuItem_Click);
            // 
            // Friend_view
            // 
            this.Friend_view.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Friend_view.Location = new System.Drawing.Point(1031, 27);
            this.Friend_view.Name = "Friend_view";
            this.Friend_view.Size = new System.Drawing.Size(226, 538);
            this.Friend_view.TabIndex = 3;
            this.Friend_view.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Friend_view_AfterSelect);
            // 
            // chatbox
            // 
            this.chatbox.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatbox.FormattingEnabled = true;
            this.chatbox.ItemHeight = 21;
            this.chatbox.Location = new System.Drawing.Point(12, 27);
            this.chatbox.Name = "chatbox";
            this.chatbox.Size = new System.Drawing.Size(1013, 487);
            this.chatbox.TabIndex = 4;
            this.chatbox.SelectedIndexChanged += new System.EventHandler(this.chatbox_SelectedIndexChanged);
            // 
            // sendtext
            // 
            this.sendtext.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendtext.Location = new System.Drawing.Point(12, 529);
            this.sendtext.Multiline = true;
            this.sendtext.Name = "sendtext";
            this.sendtext.Size = new System.Drawing.Size(950, 36);
            this.sendtext.TabIndex = 5;
            this.sendtext.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // sendbutton
            // 
            this.sendbutton.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendbutton.Location = new System.Drawing.Point(968, 528);
            this.sendbutton.Name = "sendbutton";
            this.sendbutton.Size = new System.Drawing.Size(56, 36);
            this.sendbutton.TabIndex = 6;
            this.sendbutton.Text = "Send";
            this.sendbutton.UseVisualStyleBackColor = true;
            this.sendbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 637);
            this.Controls.Add(this.sendbutton);
            this.Controls.Add(this.sendtext);
            this.Controls.Add(this.chatbox);
            this.Controls.Add(this.Friend_view);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 프로그램ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 친구요청ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 친구요청관리ToolStripMenuItem;
        private System.Windows.Forms.TreeView Friend_view;
        private System.Windows.Forms.ListBox chatbox;
        private System.Windows.Forms.TextBox sendtext;
        private System.Windows.Forms.Button sendbutton;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateAllToolStripMenuItem;
    }
}