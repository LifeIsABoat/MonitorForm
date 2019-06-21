namespace ESMachineMonitorForm
{
    partial class MonitorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorForm));
            this.pictureBox_FrameShow = new System.Windows.Forms.PictureBox();
            this.tabPage_MachineParam = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel_MachineKeyBoard = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox_MachineCfg = new System.Windows.Forms.TextBox();
            this.button_MachineCfgBrowse = new System.Windows.Forms.Button();
            this.label_MachineCfg = new System.Windows.Forms.Label();
            this.tabControl_ParamSetting = new System.Windows.Forms.TabControl();
            this.label_DevList = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FrameShow)).BeginInit();
            this.tabPage_MachineParam.SuspendLayout();
            this.tabControl_ParamSetting.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_FrameShow
            // 
            this.pictureBox_FrameShow.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_FrameShow.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_FrameShow.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_FrameShow.MaximumSize = new System.Drawing.Size(730, 400);
            this.pictureBox_FrameShow.Name = "pictureBox_FrameShow";
            this.pictureBox_FrameShow.Size = new System.Drawing.Size(280, 132);
            this.pictureBox_FrameShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_FrameShow.TabIndex = 0;
            this.pictureBox_FrameShow.TabStop = false;
            this.pictureBox_FrameShow.WaitOnLoad = true;
            // 
            // tabPage_MachineParam
            // 
            this.tabPage_MachineParam.Controls.Add(this.textBox1);
            this.tabPage_MachineParam.Controls.Add(this.sendButton);
            this.tabPage_MachineParam.Controls.Add(this.label2);
            this.tabPage_MachineParam.Controls.Add(this.label1);
            this.tabPage_MachineParam.Controls.Add(this.flowLayoutPanel_MachineKeyBoard);
            this.tabPage_MachineParam.Controls.Add(this.textBox_MachineCfg);
            this.tabPage_MachineParam.Controls.Add(this.button_MachineCfgBrowse);
            this.tabPage_MachineParam.Controls.Add(this.label_MachineCfg);
            this.tabPage_MachineParam.Location = new System.Drawing.Point(4, 22);
            this.tabPage_MachineParam.Name = "tabPage_MachineParam";
            this.tabPage_MachineParam.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_MachineParam.Size = new System.Drawing.Size(726, 307);
            this.tabPage_MachineParam.TabIndex = 1;
            this.tabPage_MachineParam.Text = "MachineParam";
            this.tabPage_MachineParam.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(493, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(89, 19);
            this.textBox1.TabIndex = 3;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(588, 6);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 10;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(432, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "KeyName:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "[Key]";
            // 
            // flowLayoutPanel_MachineKeyBoard
            // 
            this.flowLayoutPanel_MachineKeyBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel_MachineKeyBoard.Location = new System.Drawing.Point(6, 49);
            this.flowLayoutPanel_MachineKeyBoard.Name = "flowLayoutPanel_MachineKeyBoard";
            this.flowLayoutPanel_MachineKeyBoard.Size = new System.Drawing.Size(710, 263);
            this.flowLayoutPanel_MachineKeyBoard.TabIndex = 6;
            // 
            // textBox_MachineCfg
            // 
            this.textBox_MachineCfg.Location = new System.Drawing.Point(65, 8);
            this.textBox_MachineCfg.Name = "textBox_MachineCfg";
            this.textBox_MachineCfg.ReadOnly = true;
            this.textBox_MachineCfg.Size = new System.Drawing.Size(270, 19);
            this.textBox_MachineCfg.TabIndex = 2;
            // 
            // button_MachineCfgBrowse
            // 
            this.button_MachineCfgBrowse.Location = new System.Drawing.Point(341, 6);
            this.button_MachineCfgBrowse.Name = "button_MachineCfgBrowse";
            this.button_MachineCfgBrowse.Size = new System.Drawing.Size(75, 23);
            this.button_MachineCfgBrowse.TabIndex = 1;
            this.button_MachineCfgBrowse.Text = "Browse";
            this.button_MachineCfgBrowse.UseVisualStyleBackColor = true;
            this.button_MachineCfgBrowse.Click += new System.EventHandler(this.button_MachineCfgBrowse_Click);
            // 
            // label_MachineCfg
            // 
            this.label_MachineCfg.AutoSize = true;
            this.label_MachineCfg.Location = new System.Drawing.Point(6, 11);
            this.label_MachineCfg.Name = "label_MachineCfg";
            this.label_MachineCfg.Size = new System.Drawing.Size(59, 12);
            this.label_MachineCfg.TabIndex = 0;
            this.label_MachineCfg.Text = "ConfigFile:";
            // 
            // tabControl_ParamSetting
            // 
            this.tabControl_ParamSetting.Controls.Add(this.tabPage_MachineParam);
            this.tabControl_ParamSetting.Location = new System.Drawing.Point(12, 314);
            this.tabControl_ParamSetting.Name = "tabControl_ParamSetting";
            this.tabControl_ParamSetting.SelectedIndex = 0;
            this.tabControl_ParamSetting.Size = new System.Drawing.Size(734, 333);
            this.tabControl_ParamSetting.TabIndex = 34;
            // 
            // label_DevList
            // 
            this.label_DevList.Location = new System.Drawing.Point(20, 18);
            this.label_DevList.Name = "label_DevList";
            this.label_DevList.Size = new System.Drawing.Size(65, 21);
            this.label_DevList.TabIndex = 20;
            this.label_DevList.Text = "LCD界面";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "截图";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox_FrameShow);
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 260);
            this.panel1.TabIndex = 35;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(208, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(270, 19);
            this.textBox2.TabIndex = 36;
            this.textBox2.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(484, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 37;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 659);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl_ParamSetting);
            this.Controls.Add(this.label_DevList);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MonitorForm";
            this.Text = "ESMonitor";
            this.Shown += new System.EventHandler(this.MonitorForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FrameShow)).EndInit();
            this.tabPage_MachineParam.ResumeLayout(false);
            this.tabPage_MachineParam.PerformLayout();
            this.tabControl_ParamSetting.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_FrameShow;
        private System.Windows.Forms.TabPage tabPage_MachineParam;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_MachineKeyBoard;
        private System.Windows.Forms.TextBox textBox_MachineCfg;
        private System.Windows.Forms.Button button_MachineCfgBrowse;
        private System.Windows.Forms.Label label_MachineCfg;
        private System.Windows.Forms.TabControl tabControl_ParamSetting;
        private System.Windows.Forms.Label label_DevList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
    }
}

