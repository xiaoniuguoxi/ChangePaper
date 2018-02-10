namespace ChangePaper
{
    partial class SpokenForm
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
            this.txt_paper = new System.Windows.Forms.TextBox();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.btn_paper = new System.Windows.Forms.Button();
            this.btn_code = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_change = new System.Windows.Forms.Button();
            this.btn_changeResult = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_sign = new System.Windows.Forms.Button();
            this.btn_result = new System.Windows.Forms.Button();
            this.txt_sign = new System.Windows.Forms.TextBox();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // txt_paper
            // 
            this.txt_paper.Location = new System.Drawing.Point(112, 28);
            this.txt_paper.Name = "txt_paper";
            this.txt_paper.Size = new System.Drawing.Size(392, 21);
            this.txt_paper.TabIndex = 0;
            // 
            // txt_code
            // 
            this.txt_code.Location = new System.Drawing.Point(112, 54);
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new System.Drawing.Size(392, 21);
            this.txt_code.TabIndex = 1;
            // 
            // btn_paper
            // 
            this.btn_paper.Location = new System.Drawing.Point(510, 27);
            this.btn_paper.Name = "btn_paper";
            this.btn_paper.Size = new System.Drawing.Size(75, 23);
            this.btn_paper.TabIndex = 2;
            this.btn_paper.Text = "浏览";
            this.btn_paper.UseVisualStyleBackColor = true;
            this.btn_paper.Click += new System.EventHandler(this.btn_paper_Click);
            // 
            // btn_code
            // 
            this.btn_code.Location = new System.Drawing.Point(510, 53);
            this.btn_code.Name = "btn_code";
            this.btn_code.Size = new System.Drawing.Size(75, 23);
            this.btn_code.TabIndex = 3;
            this.btn_code.Text = "浏览";
            this.btn_code.UseVisualStyleBackColor = true;
            this.btn_code.Click += new System.EventHandler(this.btn_code_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "试卷包路径：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "授权码路径：";
            // 
            // btn_change
            // 
            this.btn_change.Location = new System.Drawing.Point(606, 53);
            this.btn_change.Name = "btn_change";
            this.btn_change.Size = new System.Drawing.Size(82, 23);
            this.btn_change.TabIndex = 6;
            this.btn_change.Text = "解 开";
            this.btn_change.UseVisualStyleBackColor = true;
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            // 
            // btn_changeResult
            // 
            this.btn_changeResult.Location = new System.Drawing.Point(606, 124);
            this.btn_changeResult.Name = "btn_changeResult";
            this.btn_changeResult.Size = new System.Drawing.Size(82, 23);
            this.btn_changeResult.TabIndex = 13;
            this.btn_changeResult.Text = "解 开";
            this.btn_changeResult.UseVisualStyleBackColor = true;
            this.btn_changeResult.Click += new System.EventHandler(this.btn_changeResult_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "签名包路径：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "结果包路径：";
            // 
            // btn_sign
            // 
            this.btn_sign.Location = new System.Drawing.Point(510, 124);
            this.btn_sign.Name = "btn_sign";
            this.btn_sign.Size = new System.Drawing.Size(75, 23);
            this.btn_sign.TabIndex = 10;
            this.btn_sign.Text = "浏览";
            this.btn_sign.UseVisualStyleBackColor = true;
            this.btn_sign.Click += new System.EventHandler(this.btn_sign_Click);
            // 
            // btn_result
            // 
            this.btn_result.Location = new System.Drawing.Point(510, 98);
            this.btn_result.Name = "btn_result";
            this.btn_result.Size = new System.Drawing.Size(75, 23);
            this.btn_result.TabIndex = 9;
            this.btn_result.Text = "浏览";
            this.btn_result.UseVisualStyleBackColor = true;
            this.btn_result.Click += new System.EventHandler(this.btn_result_Click);
            // 
            // txt_sign
            // 
            this.txt_sign.Location = new System.Drawing.Point(112, 125);
            this.txt_sign.Name = "txt_sign";
            this.txt_sign.Size = new System.Drawing.Size(392, 21);
            this.txt_sign.TabIndex = 8;
            // 
            // txt_result
            // 
            this.txt_result.Location = new System.Drawing.Point(112, 99);
            this.txt_result.Name = "txt_result";
            this.txt_result.Size = new System.Drawing.Size(392, 21);
            this.txt_result.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(690, 162);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "人机对话";
            // 
            // SpokenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 190);
            this.Controls.Add(this.btn_changeResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_sign);
            this.Controls.Add(this.btn_result);
            this.Controls.Add(this.txt_sign);
            this.Controls.Add(this.txt_result);
            this.Controls.Add(this.btn_change);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_code);
            this.Controls.Add(this.btn_paper);
            this.Controls.Add(this.txt_code);
            this.Controls.Add(this.txt_paper);
            this.Controls.Add(this.groupBox1);
            this.Name = "SpokenForm";
            this.Text = "人机对话试卷格式转换工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_paper;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Button btn_paper;
        private System.Windows.Forms.Button btn_code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_change;
        private System.Windows.Forms.Button btn_changeResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_sign;
        private System.Windows.Forms.Button btn_result;
        private System.Windows.Forms.TextBox txt_sign;
        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

