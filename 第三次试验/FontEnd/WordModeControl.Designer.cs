namespace project
{
    partial class WordModeControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.WordAmount = new System.Windows.Forms.NumericUpDown();
            this.EasyModeBtn = new System.Windows.Forms.Button();
            this.WordSource = new System.Windows.Forms.DomainUpDown();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.ReviewMode = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.WordAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // WordAmount
            // 
            this.WordAmount.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.WordAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WordAmount.Location = new System.Drawing.Point(510, 97);
            this.WordAmount.Margin = new System.Windows.Forms.Padding(4);
            this.WordAmount.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.WordAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WordAmount.Name = "WordAmount";
            this.WordAmount.Size = new System.Drawing.Size(180, 28);
            this.WordAmount.TabIndex = 6;
            this.WordAmount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.WordAmount.ValueChanged += new System.EventHandler(this.WordAmount_ValueChanged);
            // 
            // EasyModeBtn
            // 
            this.EasyModeBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.EasyModeBtn.BackgroundImage = global::project.Properties.Resources.盘点;
            this.EasyModeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EasyModeBtn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EasyModeBtn.Location = new System.Drawing.Point(374, 250);
            this.EasyModeBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EasyModeBtn.Name = "EasyModeBtn";
            this.EasyModeBtn.Size = new System.Drawing.Size(240, 52);
            this.EasyModeBtn.TabIndex = 7;
            this.EasyModeBtn.Text = "背词模式";
            this.EasyModeBtn.UseVisualStyleBackColor = false;
            this.EasyModeBtn.Click += new System.EventHandler(this.EasyModeBtn_Click);
            // 
            // WordSource
            // 
            this.WordSource.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.WordSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WordSource.Items.Add("四级词汇");
            this.WordSource.Items.Add("六级词汇");
            this.WordSource.Location = new System.Drawing.Point(737, 97);
            this.WordSource.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WordSource.Name = "WordSource";
            this.WordSource.ReadOnly = true;
            this.WordSource.Size = new System.Drawing.Size(120, 28);
            this.WordSource.TabIndex = 0;
            // 
            // ReviewMode
            // 
            this.ReviewMode.BackgroundImage = global::project.Properties.Resources.商品编辑;
            this.ReviewMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ReviewMode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ReviewMode.Location = new System.Drawing.Point(374, 373);
            this.ReviewMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReviewMode.Name = "ReviewMode";
            this.ReviewMode.Size = new System.Drawing.Size(240, 52);
            this.ReviewMode.TabIndex = 8;
            this.ReviewMode.Text = "深度复习";
            this.ReviewMode.UseVisualStyleBackColor = true;
            this.ReviewMode.Click += new System.EventHandler(this.ReviewMode_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::project.Properties.Resources._34;
            this.pictureBox2.Location = new System.Drawing.Point(34, 53);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(429, 116);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // WordModeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BackgroundImage = global::project.Properties.Resources.QQ图片20200613002257;
            this.Controls.Add(this.WordSource);
            this.Controls.Add(this.ReviewMode);
            this.Controls.Add(this.EasyModeBtn);
            this.Controls.Add(this.WordAmount);
            this.Controls.Add(this.pictureBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "WordModeControl";
            this.Size = new System.Drawing.Size(946, 620);
            ((System.ComponentModel.ISupportInitialize)(this.WordAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.NumericUpDown WordAmount;
        private System.Windows.Forms.Button EasyModeBtn;
        private System.Windows.Forms.DomainUpDown WordSource;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Button ReviewMode;
    }
}
