namespace addScore
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.update_button = new System.Windows.Forms.Button();
            this.autostartBtn = new System.Windows.Forms.Button();
            this.autoendBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Autoload_lbl = new System.Windows.Forms.Label();
            this.autotime_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.round_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(260, 20);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // update_button
            // 
            this.update_button.Location = new System.Drawing.Point(12, 117);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(260, 23);
            this.update_button.TabIndex = 2;
            this.update_button.Text = "手動更新";
            this.update_button.UseVisualStyleBackColor = true;
            this.update_button.Click += new System.EventHandler(this.Update_button_ClickAsync);
            // 
            // autostartBtn
            // 
            this.autostartBtn.Location = new System.Drawing.Point(12, 146);
            this.autostartBtn.Name = "autostartBtn";
            this.autostartBtn.Size = new System.Drawing.Size(105, 71);
            this.autostartBtn.TabIndex = 3;
            this.autostartBtn.Text = "自動更新開始";
            this.autostartBtn.UseVisualStyleBackColor = true;
            this.autostartBtn.Click += new System.EventHandler(this.AutostartBtn_Click);
            // 
            // autoendBtn
            // 
            this.autoendBtn.Location = new System.Drawing.Point(167, 146);
            this.autoendBtn.Name = "autoendBtn";
            this.autoendBtn.Size = new System.Drawing.Size(105, 71);
            this.autoendBtn.TabIndex = 4;
            this.autoendBtn.Text = "自動更新終了";
            this.autoendBtn.UseVisualStyleBackColor = true;
            this.autoendBtn.Click += new System.EventHandler(this.AutoendBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(12, 223);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(260, 23);
            this.resetBtn.TabIndex = 5;
            this.resetBtn.Text = "新しいラウンド＆リセット";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Autoload_lbl
            // 
            this.Autoload_lbl.AutoSize = true;
            this.Autoload_lbl.Location = new System.Drawing.Point(10, 90);
            this.Autoload_lbl.Name = "Autoload_lbl";
            this.Autoload_lbl.Size = new System.Drawing.Size(76, 12);
            this.Autoload_lbl.TabIndex = 6;
            this.Autoload_lbl.Text = "自動更新：オフ";
            // 
            // autotime_lbl
            // 
            this.autotime_lbl.AutoSize = true;
            this.autotime_lbl.Location = new System.Drawing.Point(86, 72);
            this.autotime_lbl.Name = "autotime_lbl";
            this.autotime_lbl.Size = new System.Drawing.Size(0, 12);
            this.autotime_lbl.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "最終更新時";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "現在のラウンド";
            // 
            // round_lbl
            // 
            this.round_lbl.AutoSize = true;
            this.round_lbl.Location = new System.Drawing.Point(91, 54);
            this.round_lbl.Name = "round_lbl";
            this.round_lbl.Size = new System.Drawing.Size(11, 12);
            this.round_lbl.TabIndex = 10;
            this.round_lbl.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(284, 258);
            this.Controls.Add(this.round_lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.autotime_lbl);
            this.Controls.Add(this.Autoload_lbl);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.autoendBtn);
            this.Controls.Add(this.autostartBtn);
            this.Controls.Add(this.update_button);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "EORマッピングシステム";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button update_button;
        private System.Windows.Forms.Button autostartBtn;
        private System.Windows.Forms.Button autoendBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label Autoload_lbl;
        private System.Windows.Forms.Label autotime_lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label round_lbl;
    }
}

