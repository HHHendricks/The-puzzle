namespace 大作业1
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnl_picture = new System.Windows.Forms.Panel();
            this.btn_endchallenge = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_challenge = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_change = new System.Windows.Forms.Button();
            this.btn_import = new System.Windows.Forms.Button();
            this.original_pic = new System.Windows.Forms.PictureBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.original_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnl_picture);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_endchallenge);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.btn_challenge);
            this.splitContainer1.Panel2.Controls.Add(this.btn_reset);
            this.splitContainer1.Panel2.Controls.Add(this.btn_change);
            this.splitContainer1.Panel2.Controls.Add(this.btn_import);
            this.splitContainer1.Panel2.Controls.Add(this.original_pic);
            this.splitContainer1.Panel2.Controls.Add(this.numericUpDown1);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1220, 886);
            this.splitContainer1.SplitterDistance = 913;
            this.splitContainer1.TabIndex = 0;
            // 
            // pnl_picture
            // 
            this.pnl_picture.Location = new System.Drawing.Point(14, 14);
            this.pnl_picture.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnl_picture.Name = "pnl_picture";
            this.pnl_picture.Size = new System.Drawing.Size(886, 857);
            this.pnl_picture.TabIndex = 0;
            this.pnl_picture.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_picture_Paint);
            // 
            // btn_endchallenge
            // 
            this.btn_endchallenge.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_endchallenge.Location = new System.Drawing.Point(89, 714);
            this.btn_endchallenge.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_endchallenge.Name = "btn_endchallenge";
            this.btn_endchallenge.Size = new System.Drawing.Size(94, 48);
            this.btn_endchallenge.TabIndex = 12;
            this.btn_endchallenge.Text = "结束挑战";
            this.btn_endchallenge.UseVisualStyleBackColor = true;
            this.btn_endchallenge.Visible = false;
            this.btn_endchallenge.Click += new System.EventHandler(this.btn_endchallenge_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(150, 382);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 30);
            this.label6.TabIndex = 11;
            this.label6.Text = "0";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(183, 462);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 30);
            this.label5.TabIndex = 10;
            this.label5.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(196, 382);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 30);
            this.label4.TabIndex = 9;
            this.label4.Text = "s";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(43, 462);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 26);
            this.label3.TabIndex = 8;
            this.label3.Text = "移动步数：";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(53, 384);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 52);
            this.label2.TabIndex = 7;
            this.label2.Text = "时间：";
            this.label2.Visible = false;
            // 
            // btn_challenge
            // 
            this.btn_challenge.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_challenge.Location = new System.Drawing.Point(166, 626);
            this.btn_challenge.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_challenge.Name = "btn_challenge";
            this.btn_challenge.Size = new System.Drawing.Size(94, 48);
            this.btn_challenge.TabIndex = 6;
            this.btn_challenge.Text = "挑战模式";
            this.btn_challenge.UseVisualStyleBackColor = true;
            this.btn_challenge.Click += new System.EventHandler(this.btn_challenge_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_reset.Location = new System.Drawing.Point(47, 626);
            this.btn_reset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(94, 48);
            this.btn_reset.TabIndex = 5;
            this.btn_reset.Text = "图片重排";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_change
            // 
            this.btn_change.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_change.Location = new System.Drawing.Point(166, 542);
            this.btn_change.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_change.Name = "btn_change";
            this.btn_change.Size = new System.Drawing.Size(94, 48);
            this.btn_change.TabIndex = 4;
            this.btn_change.Text = "切换图片";
            this.btn_change.UseVisualStyleBackColor = true;
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            // 
            // btn_import
            // 
            this.btn_import.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_import.Location = new System.Drawing.Point(47, 542);
            this.btn_import.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(94, 48);
            this.btn_import.TabIndex = 3;
            this.btn_import.Text = "试玩新图";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // original_pic
            // 
            this.original_pic.Location = new System.Drawing.Point(30, 122);
            this.original_pic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.original_pic.Name = "original_pic";
            this.original_pic.Size = new System.Drawing.Size(231, 226);
            this.original_pic.TabIndex = 2;
            this.original_pic.TabStop = false;
            this.original_pic.Click += new System.EventHandler(this.original_pic_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(138, 65);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(119, 28);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "难度等级：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1220, 886);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "拼图游戏";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.original_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnl_picture;
        private System.Windows.Forms.Button btn_endchallenge;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_challenge;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_change;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.PictureBox original_pic;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}

