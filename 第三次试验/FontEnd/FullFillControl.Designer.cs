namespace project
{
    partial class FullFillControl
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
            this.lblTrans = new System.Windows.Forms.Label();
            this.lblStc = new System.Windows.Forms.Label();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.btnSure = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTrans
            // 
            this.lblTrans.AutoSize = true;
            this.lblTrans.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTrans.Location = new System.Drawing.Point(201, 349);
            this.lblTrans.Name = "lblTrans";
            this.lblTrans.Size = new System.Drawing.Size(75, 28);
            this.lblTrans.TabIndex = 1;
            this.lblTrans.Text = "label1";
            // 
            // lblStc
            // 
            this.lblStc.AutoSize = true;
            this.lblStc.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStc.Location = new System.Drawing.Point(201, 426);
            this.lblStc.Name = "lblStc";
            this.lblStc.Size = new System.Drawing.Size(75, 28);
            this.lblStc.TabIndex = 2;
            this.lblStc.Text = "label2";
            // 
            // tbInput
            // 
            this.tbInput.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbInput.Location = new System.Drawing.Point(193, 477);
            this.tbInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbInput.MaximumSize = new System.Drawing.Size(235, 40);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(235, 39);
            this.tbInput.TabIndex = 3;
            // 
            // btnSure
            // 
            this.btnSure.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSure.Location = new System.Drawing.Point(446, 477);
            this.btnSure.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(116, 30);
            this.btnSure.TabIndex = 4;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.BtnSure_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = global::project.Properties.Resources.empty;
            this.pictureBox1.Location = new System.Drawing.Point(206, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(356, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(21, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = ">>";
            this.label1.Click += new System.EventHandler(this.RetnBtn_Click);
            // 
            // FullFillControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.lblStc);
            this.Controls.Add(this.lblTrans);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FullFillControl";
            this.Size = new System.Drawing.Size(791, 536);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTrans;
        private System.Windows.Forms.Label lblStc;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.Label label1;
    }
}
