namespace llibrary
{
    partial class infor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(infor));
            this.qrCodeGraphicControl1 = new Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeGraphicControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // qrCodeGraphicControl1
            // 
            this.qrCodeGraphicControl1.ErrorCorrectLevel = Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M;
            this.qrCodeGraphicControl1.Location = new System.Drawing.Point(83, 61);
            this.qrCodeGraphicControl1.Name = "qrCodeGraphicControl1";
            this.qrCodeGraphicControl1.QuietZoneModule = Gma.QrCodeNet.Encoding.Windows.Render.QuietZoneModules.Two;
            this.qrCodeGraphicControl1.Size = new System.Drawing.Size(151, 153);
            this.qrCodeGraphicControl1.TabIndex = 0;
            this.qrCodeGraphicControl1.Text = "https://xiphoray.github.io/404";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "书名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "作者";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(313, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "出版社";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "ISBN号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "搜索次数";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(301, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "借阅次数";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(482, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "借阅状态";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(509, 335);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "快速借阅";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(12, 376);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "*扫描二维码可进入豆瓣页面";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 402);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(734, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(135, 17);
            this.toolStripStatusLabel1.Text = "copyright © Xiphoray";
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(434, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 19);
            this.label9.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(434, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 19);
            this.label10.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(434, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 19);
            this.label11.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(434, 184);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 19);
            this.label12.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(194, 260);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 19);
            this.label13.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(375, 260);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 19);
            this.label14.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(553, 260);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 19);
            this.label15.TabIndex = 17;
            // 
            // infor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 424);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.qrCodeGraphicControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "infor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "information";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeGraphicControl qrCodeGraphicControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}