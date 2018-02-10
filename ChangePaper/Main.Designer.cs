namespace ChangePaper
{
    partial class Main
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_brw_nets_paper = new System.Windows.Forms.Button();
            this.txt_nets_paper = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_save = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_brw_nets_result = new System.Windows.Forms.Button();
            this.txt_nets_result = new System.Windows.Forms.TextBox();
            this.txt_spoken_paper = new System.Windows.Forms.TextBox();
            this.btn_brw_spoken_paper = new System.Windows.Forms.Button();
            this.btn_change = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "NETS结果包路径：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "NETS试卷路径：";
            // 
            // btn_brw_nets_paper
            // 
            this.btn_brw_nets_paper.Location = new System.Drawing.Point(584, 51);
            this.btn_brw_nets_paper.Name = "btn_brw_nets_paper";
            this.btn_brw_nets_paper.Size = new System.Drawing.Size(75, 23);
            this.btn_brw_nets_paper.TabIndex = 8;
            this.btn_brw_nets_paper.Text = "浏览";
            this.btn_brw_nets_paper.UseVisualStyleBackColor = true;
            this.btn_brw_nets_paper.Click += new System.EventHandler(this.btn_brw_nets_paper_Click);
            // 
            // txt_nets_paper
            // 
            this.txt_nets_paper.Location = new System.Drawing.Point(186, 52);
            this.txt_nets_paper.Name = "txt_nets_paper";
            this.txt_nets_paper.Size = new System.Drawing.Size(392, 21);
            this.txt_nets_paper.TabIndex = 6;
            this.txt_nets_paper.Text = "C:\\Users\\Administrator\\Desktop\\岸草宁波口语试卷（NETS，人机对话制卷）\\宁波模式试卷模板调整版-口语_all---NETS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "转换后路径：";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(584, 163);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 14;
            this.btn_save.Text = "浏览";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_save
            // 
            this.txt_save.Location = new System.Drawing.Point(186, 164);
            this.txt_save.Name = "txt_save";
            this.txt_save.Size = new System.Drawing.Size(392, 21);
            this.txt_save.TabIndex = 12;
            this.txt_save.Text = "C:\\changePath";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btn_brw_nets_result);
            this.groupBox1.Controls.Add(this.txt_nets_result);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_spoken_paper);
            this.groupBox1.Controls.Add(this.btn_brw_spoken_paper);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(24, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(665, 183);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数设定";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "SPOKEN试卷路径：";
            // 
            // btn_brw_nets_result
            // 
            this.btn_brw_nets_result.Location = new System.Drawing.Point(560, 79);
            this.btn_brw_nets_result.Name = "btn_brw_nets_result";
            this.btn_brw_nets_result.Size = new System.Drawing.Size(75, 23);
            this.btn_brw_nets_result.TabIndex = 18;
            this.btn_brw_nets_result.Text = "浏览";
            this.btn_brw_nets_result.UseVisualStyleBackColor = true;
            this.btn_brw_nets_result.Click += new System.EventHandler(this.btn_brw_nets_result_Click);
            // 
            // txt_nets_result
            // 
            this.txt_nets_result.Location = new System.Drawing.Point(162, 80);
            this.txt_nets_result.Name = "txt_nets_result";
            this.txt_nets_result.Size = new System.Drawing.Size(392, 21);
            this.txt_nets_result.TabIndex = 17;
            // 
            // txt_spoken_paper
            // 
            this.txt_spoken_paper.Location = new System.Drawing.Point(162, 54);
            this.txt_spoken_paper.Name = "txt_spoken_paper";
            this.txt_spoken_paper.Size = new System.Drawing.Size(392, 21);
            this.txt_spoken_paper.TabIndex = 7;
            this.txt_spoken_paper.Text = "C:\\Users\\Administrator\\Desktop\\岸草宁波口语试卷（NETS，人机对话制卷）\\人机会话系统制卷";
            // 
            // btn_brw_spoken_paper
            // 
            this.btn_brw_spoken_paper.Location = new System.Drawing.Point(560, 53);
            this.btn_brw_spoken_paper.Name = "btn_brw_spoken_paper";
            this.btn_brw_spoken_paper.Size = new System.Drawing.Size(75, 23);
            this.btn_brw_spoken_paper.TabIndex = 9;
            this.btn_brw_spoken_paper.Text = "浏览";
            this.btn_brw_spoken_paper.UseVisualStyleBackColor = true;
            this.btn_brw_spoken_paper.Click += new System.EventHandler(this.btn_brw_spoken_paper_Click);
            // 
            // btn_change
            // 
            this.btn_change.Location = new System.Drawing.Point(584, 277);
            this.btn_change.Name = "btn_change";
            this.btn_change.Size = new System.Drawing.Size(75, 23);
            this.btn_change.TabIndex = 19;
            this.btn_change.Text = "转换";
            this.btn_change.UseVisualStyleBackColor = true;
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(24, 226);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(665, 22);
            this.progressBar1.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(22, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(305, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "注意：NETS与人机对话试卷路径下的文件名须一一对应！";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(450, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 333);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_change);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_brw_nets_paper);
            this.Controls.Add(this.txt_nets_paper);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NETS试卷包、考试结果包【转】人机对话工具";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_brw_nets_paper;
        private System.Windows.Forms.TextBox txt_nets_paper;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox txt_save;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_change;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_brw_nets_result;
        private System.Windows.Forms.TextBox txt_nets_result;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_spoken_paper;
        private System.Windows.Forms.Button btn_brw_spoken_paper;
        private System.Windows.Forms.Button button1;

    }
}