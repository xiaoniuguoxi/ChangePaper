namespace ChangePaper
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
            this.btn_mp3ToWav = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_browserMp3 = new System.Windows.Forms.Button();
            this.txt_mp3 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_spokenChange = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_spokenCode = new System.Windows.Forms.Button();
            this.btn_spokenPaper = new System.Windows.Forms.Button();
            this.txt_spokenCode = new System.Windows.Forms.TextBox();
            this.txt_spokenPaper = new System.Windows.Forms.TextBox();
            this.btn_spoken_result_change = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_spoken_brw_sign = new System.Windows.Forms.Button();
            this.btn_spoken_brw_result = new System.Windows.Forms.Button();
            this.txt_spoken_sign = new System.Windows.Forms.TextBox();
            this.txt_spoken_result = new System.Windows.Forms.TextBox();
            this.btn_encrypt = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_paper
            // 
            this.txt_paper.Location = new System.Drawing.Point(112, 43);
            this.txt_paper.Name = "txt_paper";
            this.txt_paper.Size = new System.Drawing.Size(392, 21);
            this.txt_paper.TabIndex = 0;
            // 
            // txt_code
            // 
            this.txt_code.Location = new System.Drawing.Point(112, 69);
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new System.Drawing.Size(392, 21);
            this.txt_code.TabIndex = 1;
            // 
            // btn_paper
            // 
            this.btn_paper.Location = new System.Drawing.Point(510, 42);
            this.btn_paper.Name = "btn_paper";
            this.btn_paper.Size = new System.Drawing.Size(75, 23);
            this.btn_paper.TabIndex = 2;
            this.btn_paper.Text = "浏览";
            this.btn_paper.UseVisualStyleBackColor = true;
            this.btn_paper.Click += new System.EventHandler(this.btn_paper_Click);
            // 
            // btn_code
            // 
            this.btn_code.Location = new System.Drawing.Point(510, 68);
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
            this.label1.Location = new System.Drawing.Point(29, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "试卷包路径：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "授权码路径：";
            // 
            // btn_change
            // 
            this.btn_change.Location = new System.Drawing.Point(606, 68);
            this.btn_change.Name = "btn_change";
            this.btn_change.Size = new System.Drawing.Size(82, 23);
            this.btn_change.TabIndex = 6;
            this.btn_change.Text = "解 密";
            this.btn_change.UseVisualStyleBackColor = true;
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            // 
            // btn_changeResult
            // 
            this.btn_changeResult.Location = new System.Drawing.Point(606, 135);
            this.btn_changeResult.Name = "btn_changeResult";
            this.btn_changeResult.Size = new System.Drawing.Size(82, 23);
            this.btn_changeResult.TabIndex = 13;
            this.btn_changeResult.Text = "解 密";
            this.btn_changeResult.UseVisualStyleBackColor = true;
            this.btn_changeResult.Click += new System.EventHandler(this.btn_changeResult_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "签名包路径：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "结果包路径：";
            // 
            // btn_sign
            // 
            this.btn_sign.Location = new System.Drawing.Point(510, 135);
            this.btn_sign.Name = "btn_sign";
            this.btn_sign.Size = new System.Drawing.Size(75, 23);
            this.btn_sign.TabIndex = 10;
            this.btn_sign.Text = "浏览";
            this.btn_sign.UseVisualStyleBackColor = true;
            this.btn_sign.Click += new System.EventHandler(this.btn_sign_Click);
            // 
            // btn_result
            // 
            this.btn_result.Location = new System.Drawing.Point(510, 109);
            this.btn_result.Name = "btn_result";
            this.btn_result.Size = new System.Drawing.Size(75, 23);
            this.btn_result.TabIndex = 9;
            this.btn_result.Text = "浏览";
            this.btn_result.UseVisualStyleBackColor = true;
            this.btn_result.Click += new System.EventHandler(this.btn_result_Click);
            // 
            // txt_sign
            // 
            this.txt_sign.Location = new System.Drawing.Point(112, 136);
            this.txt_sign.Name = "txt_sign";
            this.txt_sign.Size = new System.Drawing.Size(392, 21);
            this.txt_sign.TabIndex = 8;
            // 
            // txt_result
            // 
            this.txt_result.Location = new System.Drawing.Point(112, 110);
            this.txt_result.Name = "txt_result";
            this.txt_result.Size = new System.Drawing.Size(392, 21);
            this.txt_result.TabIndex = 7;
            // 
            // btn_mp3ToWav
            // 
            this.btn_mp3ToWav.Location = new System.Drawing.Point(606, 178);
            this.btn_mp3ToWav.Name = "btn_mp3ToWav";
            this.btn_mp3ToWav.Size = new System.Drawing.Size(82, 23);
            this.btn_mp3ToWav.TabIndex = 17;
            this.btn_mp3ToWav.Text = "mp3转wav";
            this.btn_mp3ToWav.UseVisualStyleBackColor = true;
            this.btn_mp3ToWav.Click += new System.EventHandler(this.btn_mp3ToWav_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "MP3路径：";
            // 
            // btn_browserMp3
            // 
            this.btn_browserMp3.Location = new System.Drawing.Point(510, 179);
            this.btn_browserMp3.Name = "btn_browserMp3";
            this.btn_browserMp3.Size = new System.Drawing.Size(75, 23);
            this.btn_browserMp3.TabIndex = 15;
            this.btn_browserMp3.Text = "浏览";
            this.btn_browserMp3.UseVisualStyleBackColor = true;
            this.btn_browserMp3.Click += new System.EventHandler(this.btn_browserMp3_Click);
            // 
            // txt_mp3
            // 
            this.txt_mp3.Location = new System.Drawing.Point(112, 180);
            this.txt_mp3.Name = "txt_mp3";
            this.txt_mp3.Size = new System.Drawing.Size(392, 21);
            this.txt_mp3.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(690, 207);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "nets";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_encrypt);
            this.groupBox2.Controls.Add(this.btn_spokenChange);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btn_spokenCode);
            this.groupBox2.Controls.Add(this.btn_spokenPaper);
            this.groupBox2.Controls.Add(this.txt_spokenCode);
            this.groupBox2.Controls.Add(this.txt_spokenPaper);
            this.groupBox2.Controls.Add(this.btn_spoken_result_change);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btn_spoken_brw_sign);
            this.groupBox2.Controls.Add(this.btn_spoken_brw_result);
            this.groupBox2.Controls.Add(this.txt_spoken_sign);
            this.groupBox2.Controls.Add(this.txt_spoken_result);
            this.groupBox2.Location = new System.Drawing.Point(12, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(690, 168);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "spoken";
            // 
            // btn_spokenChange
            // 
            this.btn_spokenChange.Location = new System.Drawing.Point(594, 56);
            this.btn_spokenChange.Name = "btn_spokenChange";
            this.btn_spokenChange.Size = new System.Drawing.Size(82, 23);
            this.btn_spokenChange.TabIndex = 27;
            this.btn_spokenChange.Text = "解 密";
            this.btn_spokenChange.UseVisualStyleBackColor = true;
            this.btn_spokenChange.Click += new System.EventHandler(this.btn_spokenChange_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 26;
            this.label8.Text = "授权码路径：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 25;
            this.label9.Text = "试卷包路径：";
            // 
            // btn_spokenCode
            // 
            this.btn_spokenCode.Location = new System.Drawing.Point(498, 56);
            this.btn_spokenCode.Name = "btn_spokenCode";
            this.btn_spokenCode.Size = new System.Drawing.Size(75, 23);
            this.btn_spokenCode.TabIndex = 24;
            this.btn_spokenCode.Text = "浏览";
            this.btn_spokenCode.UseVisualStyleBackColor = true;
            this.btn_spokenCode.Click += new System.EventHandler(this.btn_spokenCode_Click);
            // 
            // btn_spokenPaper
            // 
            this.btn_spokenPaper.Location = new System.Drawing.Point(498, 30);
            this.btn_spokenPaper.Name = "btn_spokenPaper";
            this.btn_spokenPaper.Size = new System.Drawing.Size(75, 23);
            this.btn_spokenPaper.TabIndex = 23;
            this.btn_spokenPaper.Text = "浏览";
            this.btn_spokenPaper.UseVisualStyleBackColor = true;
            this.btn_spokenPaper.Click += new System.EventHandler(this.btn_spokenPaper_Click);
            // 
            // txt_spokenCode
            // 
            this.txt_spokenCode.Location = new System.Drawing.Point(100, 57);
            this.txt_spokenCode.Name = "txt_spokenCode";
            this.txt_spokenCode.Size = new System.Drawing.Size(392, 21);
            this.txt_spokenCode.TabIndex = 22;
            // 
            // txt_spokenPaper
            // 
            this.txt_spokenPaper.Location = new System.Drawing.Point(100, 31);
            this.txt_spokenPaper.Name = "txt_spokenPaper";
            this.txt_spokenPaper.Size = new System.Drawing.Size(392, 21);
            this.txt_spokenPaper.TabIndex = 21;
            // 
            // btn_spoken_result_change
            // 
            this.btn_spoken_result_change.Location = new System.Drawing.Point(594, 97);
            this.btn_spoken_result_change.Name = "btn_spoken_result_change";
            this.btn_spoken_result_change.Size = new System.Drawing.Size(82, 23);
            this.btn_spoken_result_change.TabIndex = 20;
            this.btn_spoken_result_change.Text = "解 密";
            this.btn_spoken_result_change.UseVisualStyleBackColor = true;
            this.btn_spoken_result_change.Click += new System.EventHandler(this.btn_spoken_result_change_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "签名包路径：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "结果包路径：";
            // 
            // btn_spoken_brw_sign
            // 
            this.btn_spoken_brw_sign.Location = new System.Drawing.Point(498, 124);
            this.btn_spoken_brw_sign.Name = "btn_spoken_brw_sign";
            this.btn_spoken_brw_sign.Size = new System.Drawing.Size(75, 23);
            this.btn_spoken_brw_sign.TabIndex = 17;
            this.btn_spoken_brw_sign.Text = "浏览";
            this.btn_spoken_brw_sign.UseVisualStyleBackColor = true;
            this.btn_spoken_brw_sign.Click += new System.EventHandler(this.btn_spoken_brw_sign_Click);
            // 
            // btn_spoken_brw_result
            // 
            this.btn_spoken_brw_result.Location = new System.Drawing.Point(498, 98);
            this.btn_spoken_brw_result.Name = "btn_spoken_brw_result";
            this.btn_spoken_brw_result.Size = new System.Drawing.Size(75, 23);
            this.btn_spoken_brw_result.TabIndex = 16;
            this.btn_spoken_brw_result.Text = "浏览";
            this.btn_spoken_brw_result.UseVisualStyleBackColor = true;
            this.btn_spoken_brw_result.Click += new System.EventHandler(this.btn_spoken_brw_result_Click);
            // 
            // txt_spoken_sign
            // 
            this.txt_spoken_sign.Location = new System.Drawing.Point(100, 125);
            this.txt_spoken_sign.Name = "txt_spoken_sign";
            this.txt_spoken_sign.Size = new System.Drawing.Size(392, 21);
            this.txt_spoken_sign.TabIndex = 15;
            // 
            // txt_spoken_result
            // 
            this.txt_spoken_result.Location = new System.Drawing.Point(100, 99);
            this.txt_spoken_result.Name = "txt_spoken_result";
            this.txt_spoken_result.Size = new System.Drawing.Size(392, 21);
            this.txt_spoken_result.TabIndex = 14;
            // 
            // btn_encrypt
            // 
            this.btn_encrypt.Location = new System.Drawing.Point(594, 123);
            this.btn_encrypt.Name = "btn_encrypt";
            this.btn_encrypt.Size = new System.Drawing.Size(82, 23);
            this.btn_encrypt.TabIndex = 28;
            this.btn_encrypt.Text = "加 密";
            this.btn_encrypt.UseVisualStyleBackColor = true;
            this.btn_encrypt.Click += new System.EventHandler(this.btn_encrypt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 432);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_mp3ToWav);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_browserMp3);
            this.Controls.Add(this.txt_mp3);
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
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "人机对话试卷格式转换工具";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Button btn_mp3ToWav;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_browserMp3;
        private System.Windows.Forms.TextBox txt_mp3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_spoken_result_change;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_spoken_brw_sign;
        private System.Windows.Forms.Button btn_spoken_brw_result;
        private System.Windows.Forms.TextBox txt_spoken_sign;
        private System.Windows.Forms.TextBox txt_spoken_result;
        private System.Windows.Forms.Button btn_spokenChange;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_spokenCode;
        private System.Windows.Forms.Button btn_spokenPaper;
        private System.Windows.Forms.TextBox txt_spokenCode;
        private System.Windows.Forms.TextBox txt_spokenPaper;
        private System.Windows.Forms.Button btn_encrypt;
    }
}

