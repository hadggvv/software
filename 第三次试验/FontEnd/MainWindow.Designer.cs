namespace project
{
    partial class MainWindow
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
        /// 
        public void InitSubView()
        {
            // SubView
            // 
            this.SubView.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.SubView.BackgroundImage = global::project.Properties.Resources.QQ图片20200613002257;
            this.SubView.Controls.Add(this.QuesModeBtn);
            this.SubView.Controls.Add(this.ParaModeBtn);
            this.SubView.Controls.Add(this.WordModeBtn);
            this.SubView.Controls.Add(this.button1);
            this.SubView.Controls.Add(this.richTextBox1);
            this.SubView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubView.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SubView.Location = new System.Drawing.Point(0, 32);
            this.SubView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SubView.Name = "SubView";
            this.SubView.Size = new System.Drawing.Size(1239, 830);
            this.SubView.TabIndex = 1;
        }
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.StudyModeStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.背单词ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.爱阅读ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.练真题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.个人信息管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.个人信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.学习记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于我们ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.安全退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.回到主页ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SubView = new System.Windows.Forms.Panel();
            this.QuesModeBtn = new System.Windows.Forms.Button();
            this.ParaModeBtn = new System.Windows.Forms.Button();
            this.WordModeBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SubView.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StudyModeStripMenuItem1,
            this.个人信息管理ToolStripMenuItem,
            this.系统管理ToolStripMenuItem,
            this.回到主页ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1378, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // StudyModeStripMenuItem1
            // 
            this.StudyModeStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.背单词ToolStripMenuItem,
            this.爱阅读ToolStripMenuItem,
            this.练真题ToolStripMenuItem});
            this.StudyModeStripMenuItem1.Image = global::project.Properties.Resources.检查;
            this.StudyModeStripMenuItem1.Name = "StudyModeStripMenuItem1";
            this.StudyModeStripMenuItem1.Size = new System.Drawing.Size(122, 28);
            this.StudyModeStripMenuItem1.Text = "开始学习";
            // 
            // 背单词ToolStripMenuItem
            // 
            this.背单词ToolStripMenuItem.Image = global::project.Properties.Resources.任务;
            this.背单词ToolStripMenuItem.Name = "背单词ToolStripMenuItem";
            this.背单词ToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.背单词ToolStripMenuItem.Text = "背单词";
            this.背单词ToolStripMenuItem.Click += new System.EventHandler(this.背单词ToolStripMenuItem_Click);
            // 
            // 爱阅读ToolStripMenuItem
            // 
            this.爱阅读ToolStripMenuItem.Image = global::project.Properties.Resources.日志;
            this.爱阅读ToolStripMenuItem.Name = "爱阅读ToolStripMenuItem";
            this.爱阅读ToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.爱阅读ToolStripMenuItem.Text = "爱阅读";
            this.爱阅读ToolStripMenuItem.Click += new System.EventHandler(this.爱阅读ToolStripMenuItem_Click);
            // 
            // 练真题ToolStripMenuItem
            // 
            this.练真题ToolStripMenuItem.Checked = true;
            this.练真题ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.练真题ToolStripMenuItem.Image = global::project.Properties.Resources.盘点;
            this.练真题ToolStripMenuItem.Name = "练真题ToolStripMenuItem";
            this.练真题ToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.练真题ToolStripMenuItem.Text = "练真题";
            this.练真题ToolStripMenuItem.Click += new System.EventHandler(this.练真题ToolStripMenuItem_Click);
            // 
            // 个人信息管理ToolStripMenuItem
            // 
            this.个人信息管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.个人信息ToolStripMenuItem,
            this.学习记录ToolStripMenuItem,
            this.修改密码ToolStripMenuItem});
            this.个人信息管理ToolStripMenuItem.Image = global::project.Properties.Resources.交接班;
            this.个人信息管理ToolStripMenuItem.Name = "个人信息管理ToolStripMenuItem";
            this.个人信息管理ToolStripMenuItem.Size = new System.Drawing.Size(122, 28);
            this.个人信息管理ToolStripMenuItem.Text = "我的信息";
            // 
            // 个人信息ToolStripMenuItem
            // 
            this.个人信息ToolStripMenuItem.Image = global::project.Properties.Resources.商品编辑;
            this.个人信息ToolStripMenuItem.Name = "个人信息ToolStripMenuItem";
            this.个人信息ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.个人信息ToolStripMenuItem.Text = "我的单词";
            this.个人信息ToolStripMenuItem.Click += new System.EventHandler(this.我的单词ToolStripMenuItem_Click);
            // 
            // 学习记录ToolStripMenuItem
            // 
            this.学习记录ToolStripMenuItem.Image = global::project.Properties.Resources.任务1;
            this.学习记录ToolStripMenuItem.Name = "学习记录ToolStripMenuItem";
            this.学习记录ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.学习记录ToolStripMenuItem.Text = "学习记录";
            this.学习记录ToolStripMenuItem.Click += new System.EventHandler(this.学习记录ToolStripMenuItem_Click);
            // 
            // 修改密码ToolStripMenuItem
            // 
            this.修改密码ToolStripMenuItem.Image = global::project.Properties.Resources.帮助;
            this.修改密码ToolStripMenuItem.Name = "修改密码ToolStripMenuItem";
            this.修改密码ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.修改密码ToolStripMenuItem.Text = "修改密码";
            this.修改密码ToolStripMenuItem.Click += new System.EventHandler(this.修改密码ToolStripMenuItem_Click);
            // 
            // 系统管理ToolStripMenuItem
            // 
            this.系统管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于我们ToolStripMenuItem,
            this.安全退出ToolStripMenuItem});
            this.系统管理ToolStripMenuItem.Image = global::project.Properties.Resources.设置;
            this.系统管理ToolStripMenuItem.Name = "系统管理ToolStripMenuItem";
            this.系统管理ToolStripMenuItem.Size = new System.Drawing.Size(122, 28);
            this.系统管理ToolStripMenuItem.Text = "系统管理";
            // 
            // 关于我们ToolStripMenuItem
            // 
            this.关于我们ToolStripMenuItem.Image = global::project.Properties.Resources.人员管理;
            this.关于我们ToolStripMenuItem.Name = "关于我们ToolStripMenuItem";
            this.关于我们ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.关于我们ToolStripMenuItem.Text = "关于我们";
            // 
            // 安全退出ToolStripMenuItem
            // 
            this.安全退出ToolStripMenuItem.Image = global::project.Properties.Resources.预付卡;
            this.安全退出ToolStripMenuItem.Name = "安全退出ToolStripMenuItem";
            this.安全退出ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.安全退出ToolStripMenuItem.Text = "安全退出";
            this.安全退出ToolStripMenuItem.Click += new System.EventHandler(this.安全退出ToolStripMenuItem_Click);
            // 
            // 回到主页ToolStripMenuItem
            // 
            this.回到主页ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.回到主页ToolStripMenuItem.Image = global::project.Properties.Resources.退货;
            this.回到主页ToolStripMenuItem.Name = "回到主页ToolStripMenuItem";
            this.回到主页ToolStripMenuItem.Size = new System.Drawing.Size(122, 28);
            this.回到主页ToolStripMenuItem.Text = "回到主页";
            this.回到主页ToolStripMenuItem.Click += new System.EventHandler(this.回到主页ToolStripMenuItem_Click);
            // 
            // SubView
            // 
            this.SubView.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.SubView.BackgroundImage = global::project.Properties.Resources.QQ图片20200613002257;
            this.SubView.Controls.Add(this.QuesModeBtn);
            this.SubView.Controls.Add(this.ParaModeBtn);
            this.SubView.Controls.Add(this.WordModeBtn);
            this.SubView.Controls.Add(this.button1);
            this.SubView.Controls.Add(this.richTextBox1);
            this.SubView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubView.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SubView.Location = new System.Drawing.Point(0, 32);
            this.SubView.Margin = new System.Windows.Forms.Padding(4);
            this.SubView.Name = "SubView";
            this.SubView.Size = new System.Drawing.Size(1378, 1018);
            this.SubView.TabIndex = 1;
            // 
            // QuesModeBtn
            // 
            this.QuesModeBtn.BackgroundImage = global::project.Properties.Resources.预付卡;
            this.QuesModeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.QuesModeBtn.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QuesModeBtn.Location = new System.Drawing.Point(556, 692);
            this.QuesModeBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.QuesModeBtn.Name = "QuesModeBtn";
            this.QuesModeBtn.Size = new System.Drawing.Size(268, 70);
            this.QuesModeBtn.TabIndex = 5;
            this.QuesModeBtn.Text = "练真题";
            this.QuesModeBtn.UseVisualStyleBackColor = true;
            this.QuesModeBtn.Click += new System.EventHandler(this.QuesModeBtn_Click);
            // 
            // ParaModeBtn
            // 
            this.ParaModeBtn.BackgroundImage = global::project.Properties.Resources.退货;
            this.ParaModeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ParaModeBtn.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ParaModeBtn.Location = new System.Drawing.Point(556, 548);
            this.ParaModeBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ParaModeBtn.Name = "ParaModeBtn";
            this.ParaModeBtn.Size = new System.Drawing.Size(268, 64);
            this.ParaModeBtn.TabIndex = 4;
            this.ParaModeBtn.Text = "爱阅读";
            this.ParaModeBtn.UseVisualStyleBackColor = true;
            this.ParaModeBtn.Click += new System.EventHandler(this.ParaModeBtn_Click);
            // 
            // WordModeBtn
            // 
            this.WordModeBtn.BackgroundImage = global::project.Properties.Resources.商品编辑;
            this.WordModeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WordModeBtn.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WordModeBtn.Location = new System.Drawing.Point(556, 413);
            this.WordModeBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WordModeBtn.Name = "WordModeBtn";
            this.WordModeBtn.Size = new System.Drawing.Size(268, 74);
            this.WordModeBtn.TabIndex = 3;
            this.WordModeBtn.Text = "背单词";
            this.WordModeBtn.UseVisualStyleBackColor = true;
            this.WordModeBtn.Click += new System.EventHandler(this.WordModeBtn_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::project.Properties.Resources.检查;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(626, 234);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(452, 112);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(474, 50);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 1050);
            this.Controls.Add(this.SubView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1400, 1400);
            this.MinimumSize = new System.Drawing.Size(946, 0);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "MainWindow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.SubView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem StudyModeStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 背单词ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 爱阅读ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 练真题ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 个人信息管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 个人信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 学习记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改密码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于我们ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 安全退出ToolStripMenuItem;
        public System.Windows.Forms.Panel SubView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem 回到主页ToolStripMenuItem;
        private System.Windows.Forms.Button QuesModeBtn;
        private System.Windows.Forms.Button ParaModeBtn;
        private System.Windows.Forms.Button WordModeBtn;
    }
}