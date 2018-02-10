namespace ChangePaper
{
    partial class UpdatePaper
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_decode = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_netsPaper = new System.Windows.Forms.TextBox();
            this.txt_netsCode = new System.Windows.Forms.TextBox();
            this.btn_netsPaper = new System.Windows.Forms.Button();
            this.btn_netsCode = new System.Windows.Forms.Button();
            this.btn_work = new System.Windows.Forms.Button();
            this.txt_work = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.btn_more = new System.Windows.Forms.Button();
            this.txt_paperNO = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_decode
            // 
            this.btn_decode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_decode.Location = new System.Drawing.Point(341, 157);
            this.btn_decode.Name = "btn_decode";
            this.btn_decode.Size = new System.Drawing.Size(108, 23);
            this.btn_decode.TabIndex = 6;
            this.btn_decode.Text = "1.解析";
            this.btn_decode.UseVisualStyleBackColor = true;
            this.btn_decode.Click += new System.EventHandler(this.btn_decode_Click);
            // 
            // btn_update
            // 
            this.btn_update.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_update.Location = new System.Drawing.Point(488, 157);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(102, 23);
            this.btn_update.TabIndex = 18;
            this.btn_update.Text = "2.更新";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(461, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "→";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "nets试卷包路径：";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "nets授权码路径：";
            // 
            // txt_netsPaper
            // 
            this.txt_netsPaper.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_netsPaper.Location = new System.Drawing.Point(295, 59);
            this.txt_netsPaper.Name = "txt_netsPaper";
            this.txt_netsPaper.Size = new System.Drawing.Size(392, 21);
            this.txt_netsPaper.TabIndex = 14;
            // 
            // txt_netsCode
            // 
            this.txt_netsCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_netsCode.Location = new System.Drawing.Point(295, 85);
            this.txt_netsCode.Name = "txt_netsCode";
            this.txt_netsCode.Size = new System.Drawing.Size(392, 21);
            this.txt_netsCode.TabIndex = 15;
            // 
            // btn_netsPaper
            // 
            this.btn_netsPaper.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_netsPaper.Location = new System.Drawing.Point(693, 58);
            this.btn_netsPaper.Name = "btn_netsPaper";
            this.btn_netsPaper.Size = new System.Drawing.Size(75, 23);
            this.btn_netsPaper.TabIndex = 16;
            this.btn_netsPaper.Text = "浏览";
            this.btn_netsPaper.UseVisualStyleBackColor = true;
            this.btn_netsPaper.Click += new System.EventHandler(this.btn_netsPaper_Click);
            // 
            // btn_netsCode
            // 
            this.btn_netsCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_netsCode.Location = new System.Drawing.Point(693, 84);
            this.btn_netsCode.Name = "btn_netsCode";
            this.btn_netsCode.Size = new System.Drawing.Size(75, 23);
            this.btn_netsCode.TabIndex = 17;
            this.btn_netsCode.Text = "浏览";
            this.btn_netsCode.UseVisualStyleBackColor = true;
            this.btn_netsCode.Click += new System.EventHandler(this.btn_netsCode_Click);
            // 
            // btn_work
            // 
            this.btn_work.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_work.Location = new System.Drawing.Point(693, 16);
            this.btn_work.Name = "btn_work";
            this.btn_work.Size = new System.Drawing.Size(75, 23);
            this.btn_work.TabIndex = 22;
            this.btn_work.Text = "浏览";
            this.btn_work.UseVisualStyleBackColor = true;
            this.btn_work.Click += new System.EventHandler(this.btn_work_Click);
            // 
            // txt_work
            // 
            this.txt_work.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_work.Location = new System.Drawing.Point(295, 17);
            this.txt_work.Name = "txt_work";
            this.txt_work.Size = new System.Drawing.Size(392, 21);
            this.txt_work.TabIndex = 21;
            this.txt_work.Text = "E:\\mac\\评分管理\\人机对话制卷";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "spoken工作区目录：";
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.treeView1.Location = new System.Drawing.Point(488, 218);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(334, 406);
            this.treeView1.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(605, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "人机对话试卷结构";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(241, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "NETS试卷结构";
            // 
            // treeView2
            // 
            this.treeView2.AllowDrop = true;
            this.treeView2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.treeView2.Location = new System.Drawing.Point(120, 218);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(334, 406);
            this.treeView2.TabIndex = 25;
            // 
            // btn_more
            // 
            this.btn_more.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_more.Location = new System.Drawing.Point(693, 157);
            this.btn_more.Name = "btn_more";
            this.btn_more.Size = new System.Drawing.Size(75, 23);
            this.btn_more.TabIndex = 27;
            this.btn_more.Text = "更多功能";
            this.btn_more.UseVisualStyleBackColor = true;
            this.btn_more.Click += new System.EventHandler(this.btn_more_Click);
            // 
            // txt_paperNO
            // 
            this.txt_paperNO.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_paperNO.Location = new System.Drawing.Point(295, 123);
            this.txt_paperNO.Name = "txt_paperNO";
            this.txt_paperNO.Size = new System.Drawing.Size(392, 21);
            this.txt_paperNO.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(204, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 29;
            this.label7.Text = "nets试卷代码：";
            // 
            // UpdatePaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 636);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_paperNO);
            this.Controls.Add(this.btn_more);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btn_work);
            this.Controls.Add(this.txt_work);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_netsCode);
            this.Controls.Add(this.btn_netsPaper);
            this.Controls.Add(this.txt_netsCode);
            this.Controls.Add(this.txt_netsPaper);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_decode);
            this.Name = "UpdatePaper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改人机对话试卷xml数据";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_decode;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_netsPaper;
        private System.Windows.Forms.TextBox txt_netsCode;
        private System.Windows.Forms.Button btn_netsPaper;
        private System.Windows.Forms.Button btn_netsCode;
        private System.Windows.Forms.Button btn_work;
        private System.Windows.Forms.TextBox txt_work;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Button btn_more;
        private System.Windows.Forms.TextBox txt_paperNO;
        private System.Windows.Forms.Label label7;
    }
}

