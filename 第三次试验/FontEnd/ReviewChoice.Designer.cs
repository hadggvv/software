namespace project
{
    partial class ReviewChoice
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
            this.VoiceMode = new System.Windows.Forms.Button();
            this.FullFillMode = new System.Windows.Forms.Button();
            this.QuestionMode = new System.Windows.Forms.Button();
            this.WordGroup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VoiceMode
            // 
            this.VoiceMode.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.VoiceMode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VoiceMode.Location = new System.Drawing.Point(252, 109);
            this.VoiceMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.VoiceMode.Name = "VoiceMode";
            this.VoiceMode.Size = new System.Drawing.Size(108, 50);
            this.VoiceMode.TabIndex = 2;
            this.VoiceMode.Text = "听音选词";
            this.VoiceMode.UseVisualStyleBackColor = false;
            this.VoiceMode.Click += new System.EventHandler(this.GapFillMode_Click);
            // 
            // FullFillMode
            // 
            this.FullFillMode.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.FullFillMode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FullFillMode.Location = new System.Drawing.Point(83, 109);
            this.FullFillMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FullFillMode.Name = "FullFillMode";
            this.FullFillMode.Size = new System.Drawing.Size(108, 50);
            this.FullFillMode.TabIndex = 3;
            this.FullFillMode.Text = "全拼拼写";
            this.FullFillMode.UseVisualStyleBackColor = false;
            this.FullFillMode.Click += new System.EventHandler(this.FullFillMode_Click);
            // 
            // QuestionMode
            // 
            this.QuestionMode.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.QuestionMode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QuestionMode.Location = new System.Drawing.Point(252, 302);
            this.QuestionMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.QuestionMode.Name = "QuestionMode";
            this.QuestionMode.Size = new System.Drawing.Size(108, 50);
            this.QuestionMode.TabIndex = 4;
            this.QuestionMode.Text = "题目练习";
            this.QuestionMode.UseVisualStyleBackColor = false;
            this.QuestionMode.Click += new System.EventHandler(this.QuestionMode_Click);
            // 
            // WordGroup
            // 
            this.WordGroup.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.WordGroup.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WordGroup.Location = new System.Drawing.Point(83, 302);
            this.WordGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WordGroup.Name = "WordGroup";
            this.WordGroup.Size = new System.Drawing.Size(108, 50);
            this.WordGroup.TabIndex = 5;
            this.WordGroup.Text = "词组搭配";
            this.WordGroup.UseVisualStyleBackColor = false;
            this.WordGroup.Click += new System.EventHandler(this.WordGroup_Click);
            // 
            // ReviewChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BackgroundImage = global::project.Properties.Resources.QQ图片20200613002257;
            this.ClientSize = new System.Drawing.Size(487, 461);
            this.Controls.Add(this.WordGroup);
            this.Controls.Add(this.QuestionMode);
            this.Controls.Add(this.FullFillMode);
            this.Controls.Add(this.VoiceMode);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ReviewChoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "复习模式";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button VoiceMode;
        private System.Windows.Forms.Button FullFillMode;
        private System.Windows.Forms.Button QuestionMode;
        private System.Windows.Forms.Button WordGroup;
    }
}