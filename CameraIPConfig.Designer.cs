namespace PrinterMonitor
{
    partial class CameraIPConfigForm
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
            this.groupBox_DeviceInfo = new System.Windows.Forms.GroupBox();
            this.textBox_DevMacAddr = new System.Windows.Forms.TextBox();
            this.label_DevMacAddr = new System.Windows.Forms.Label();
            this.label_DevIPAddr = new System.Windows.Forms.Label();
            this.label_DevSubnetMask = new System.Windows.Forms.Label();
            this.label_DevDefualtGateway = new System.Windows.Forms.Label();
            this.groupBox_InterfaceInfo = new System.Windows.Forms.GroupBox();
            this.textBox_IFDefualtGateway = new System.Windows.Forms.TextBox();
            this.textBox_IFSubnetMask = new System.Windows.Forms.TextBox();
            this.textBox_IFIPAddr = new System.Windows.Forms.TextBox();
            this.textBox_IFMacAddr = new System.Windows.Forms.TextBox();
            this.label_IFDefualtGateway = new System.Windows.Forms.Label();
            this.label_IFSubnetMask = new System.Windows.Forms.Label();
            this.label_IFIPAddr = new System.Windows.Forms.Label();
            this.label_IFMacAddr = new System.Windows.Forms.Label();
            this.button_IPConfigOK = new System.Windows.Forms.Button();
            this.button_IPConfigCancel = new System.Windows.Forms.Button();
            this.textBox_DevIPAddr = new System.Windows.Forms.TextBox();
            this.textBox_DevSubnetMask = new System.Windows.Forms.TextBox();
            this.textBox_DevDefualtGateway = new System.Windows.Forms.TextBox();
            this.groupBox_DeviceInfo.SuspendLayout();
            this.groupBox_InterfaceInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_DeviceInfo
            // 
            this.groupBox_DeviceInfo.Controls.Add(this.textBox_DevDefualtGateway);
            this.groupBox_DeviceInfo.Controls.Add(this.textBox_DevSubnetMask);
            this.groupBox_DeviceInfo.Controls.Add(this.textBox_DevIPAddr);
            this.groupBox_DeviceInfo.Controls.Add(this.textBox_DevMacAddr);
            this.groupBox_DeviceInfo.Controls.Add(this.label_DevMacAddr);
            this.groupBox_DeviceInfo.Controls.Add(this.label_DevIPAddr);
            this.groupBox_DeviceInfo.Controls.Add(this.label_DevSubnetMask);
            this.groupBox_DeviceInfo.Controls.Add(this.label_DevDefualtGateway);
            this.groupBox_DeviceInfo.Location = new System.Drawing.Point(12, 152);
            this.groupBox_DeviceInfo.Name = "groupBox_DeviceInfo";
            this.groupBox_DeviceInfo.Size = new System.Drawing.Size(228, 123);
            this.groupBox_DeviceInfo.TabIndex = 1;
            this.groupBox_DeviceInfo.TabStop = false;
            this.groupBox_DeviceInfo.Text = "Device Info";
            // 
            // textBox_DevMacAddr
            // 
            this.textBox_DevMacAddr.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_DevMacAddr.Location = new System.Drawing.Point(112, 14);
            this.textBox_DevMacAddr.Name = "textBox_DevMacAddr";
            this.textBox_DevMacAddr.ReadOnly = true;
            this.textBox_DevMacAddr.Size = new System.Drawing.Size(108, 20);
            this.textBox_DevMacAddr.TabIndex = 14;
            this.textBox_DevMacAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_DevMacAddr
            // 
            this.label_DevMacAddr.AutoSize = true;
            this.label_DevMacAddr.Location = new System.Drawing.Point(6, 17);
            this.label_DevMacAddr.Name = "label_DevMacAddr";
            this.label_DevMacAddr.Size = new System.Drawing.Size(76, 12);
            this.label_DevMacAddr.TabIndex = 8;
            this.label_DevMacAddr.Text = "MAC Address";
            // 
            // label_DevIPAddr
            // 
            this.label_DevIPAddr.AutoSize = true;
            this.label_DevIPAddr.Location = new System.Drawing.Point(6, 44);
            this.label_DevIPAddr.Name = "label_DevIPAddr";
            this.label_DevIPAddr.Size = new System.Drawing.Size(61, 12);
            this.label_DevIPAddr.TabIndex = 9;
            this.label_DevIPAddr.Text = "IP Address";
            // 
            // label_DevSubnetMask
            // 
            this.label_DevSubnetMask.AutoSize = true;
            this.label_DevSubnetMask.Location = new System.Drawing.Point(6, 71);
            this.label_DevSubnetMask.Name = "label_DevSubnetMask";
            this.label_DevSubnetMask.Size = new System.Drawing.Size(71, 12);
            this.label_DevSubnetMask.TabIndex = 10;
            this.label_DevSubnetMask.Text = "Subnet Mask";
            // 
            // label_DevDefualtGateway
            // 
            this.label_DevDefualtGateway.Location = new System.Drawing.Point(6, 98);
            this.label_DevDefualtGateway.Name = "label_DevDefualtGateway";
            this.label_DevDefualtGateway.Size = new System.Drawing.Size(90, 12);
            this.label_DevDefualtGateway.TabIndex = 11;
            this.label_DevDefualtGateway.Text = "Default Gateway";
            // 
            // groupBox_InterfaceInfo
            // 
            this.groupBox_InterfaceInfo.Controls.Add(this.textBox_IFDefualtGateway);
            this.groupBox_InterfaceInfo.Controls.Add(this.textBox_IFSubnetMask);
            this.groupBox_InterfaceInfo.Controls.Add(this.textBox_IFIPAddr);
            this.groupBox_InterfaceInfo.Controls.Add(this.textBox_IFMacAddr);
            this.groupBox_InterfaceInfo.Controls.Add(this.label_IFDefualtGateway);
            this.groupBox_InterfaceInfo.Controls.Add(this.label_IFSubnetMask);
            this.groupBox_InterfaceInfo.Controls.Add(this.label_IFIPAddr);
            this.groupBox_InterfaceInfo.Controls.Add(this.label_IFMacAddr);
            this.groupBox_InterfaceInfo.Location = new System.Drawing.Point(12, 13);
            this.groupBox_InterfaceInfo.Name = "groupBox_InterfaceInfo";
            this.groupBox_InterfaceInfo.Size = new System.Drawing.Size(228, 123);
            this.groupBox_InterfaceInfo.TabIndex = 2;
            this.groupBox_InterfaceInfo.TabStop = false;
            this.groupBox_InterfaceInfo.Text = "Interface Info";
            // 
            // textBox_IFDefualtGateway
            // 
            this.textBox_IFDefualtGateway.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_IFDefualtGateway.Location = new System.Drawing.Point(112, 95);
            this.textBox_IFDefualtGateway.Name = "textBox_IFDefualtGateway";
            this.textBox_IFDefualtGateway.ReadOnly = true;
            this.textBox_IFDefualtGateway.Size = new System.Drawing.Size(108, 20);
            this.textBox_IFDefualtGateway.TabIndex = 4;
            this.textBox_IFDefualtGateway.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_IFSubnetMask
            // 
            this.textBox_IFSubnetMask.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_IFSubnetMask.Location = new System.Drawing.Point(112, 68);
            this.textBox_IFSubnetMask.Name = "textBox_IFSubnetMask";
            this.textBox_IFSubnetMask.ReadOnly = true;
            this.textBox_IFSubnetMask.Size = new System.Drawing.Size(108, 20);
            this.textBox_IFSubnetMask.TabIndex = 4;
            this.textBox_IFSubnetMask.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_IFIPAddr
            // 
            this.textBox_IFIPAddr.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_IFIPAddr.Location = new System.Drawing.Point(112, 41);
            this.textBox_IFIPAddr.Name = "textBox_IFIPAddr";
            this.textBox_IFIPAddr.ReadOnly = true;
            this.textBox_IFIPAddr.Size = new System.Drawing.Size(108, 20);
            this.textBox_IFIPAddr.TabIndex = 4;
            this.textBox_IFIPAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_IFMacAddr
            // 
            this.textBox_IFMacAddr.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_IFMacAddr.Location = new System.Drawing.Point(112, 14);
            this.textBox_IFMacAddr.Name = "textBox_IFMacAddr";
            this.textBox_IFMacAddr.ReadOnly = true;
            this.textBox_IFMacAddr.Size = new System.Drawing.Size(108, 20);
            this.textBox_IFMacAddr.TabIndex = 4;
            this.textBox_IFMacAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_IFDefualtGateway
            // 
            this.label_IFDefualtGateway.AutoSize = true;
            this.label_IFDefualtGateway.Location = new System.Drawing.Point(6, 98);
            this.label_IFDefualtGateway.Name = "label_IFDefualtGateway";
            this.label_IFDefualtGateway.Size = new System.Drawing.Size(90, 12);
            this.label_IFDefualtGateway.TabIndex = 3;
            this.label_IFDefualtGateway.Text = "Default Gateway";
            // 
            // label_IFSubnetMask
            // 
            this.label_IFSubnetMask.AutoSize = true;
            this.label_IFSubnetMask.Location = new System.Drawing.Point(6, 71);
            this.label_IFSubnetMask.Name = "label_IFSubnetMask";
            this.label_IFSubnetMask.Size = new System.Drawing.Size(71, 12);
            this.label_IFSubnetMask.TabIndex = 2;
            this.label_IFSubnetMask.Text = "Subnet Mask";
            // 
            // label_IFIPAddr
            // 
            this.label_IFIPAddr.AutoSize = true;
            this.label_IFIPAddr.Location = new System.Drawing.Point(6, 44);
            this.label_IFIPAddr.Name = "label_IFIPAddr";
            this.label_IFIPAddr.Size = new System.Drawing.Size(61, 12);
            this.label_IFIPAddr.TabIndex = 1;
            this.label_IFIPAddr.Text = "IP Address";
            // 
            // label_IFMacAddr
            // 
            this.label_IFMacAddr.AutoSize = true;
            this.label_IFMacAddr.Location = new System.Drawing.Point(6, 17);
            this.label_IFMacAddr.Name = "label_IFMacAddr";
            this.label_IFMacAddr.Size = new System.Drawing.Size(76, 12);
            this.label_IFMacAddr.TabIndex = 0;
            this.label_IFMacAddr.Text = "MAC Address";
            // 
            // button_IPConfigOK
            // 
            this.button_IPConfigOK.Location = new System.Drawing.Point(12, 282);
            this.button_IPConfigOK.Name = "button_IPConfigOK";
            this.button_IPConfigOK.Size = new System.Drawing.Size(75, 23);
            this.button_IPConfigOK.TabIndex = 3;
            this.button_IPConfigOK.Text = "OK";
            this.button_IPConfigOK.UseVisualStyleBackColor = true;
            this.button_IPConfigOK.Click += new System.EventHandler(this.button_IPConfigOK_Click);
            // 
            // button_IPConfigCancel
            // 
            this.button_IPConfigCancel.Location = new System.Drawing.Point(165, 282);
            this.button_IPConfigCancel.Name = "button_IPConfigCancel";
            this.button_IPConfigCancel.Size = new System.Drawing.Size(75, 23);
            this.button_IPConfigCancel.TabIndex = 4;
            this.button_IPConfigCancel.Text = "Cancel";
            this.button_IPConfigCancel.UseVisualStyleBackColor = true;
            this.button_IPConfigCancel.Click += new System.EventHandler(this.button_IPConfigCancel_Click);
            // 
            // textBox_DevIPAddr
            // 
            this.textBox_DevIPAddr.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_DevIPAddr.Location = new System.Drawing.Point(112, 40);
            this.textBox_DevIPAddr.Name = "textBox_DevIPAddr";
            this.textBox_DevIPAddr.Size = new System.Drawing.Size(108, 20);
            this.textBox_DevIPAddr.TabIndex = 14;
            this.textBox_DevIPAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_DevSubnetMask
            // 
            this.textBox_DevSubnetMask.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_DevSubnetMask.Location = new System.Drawing.Point(112, 66);
            this.textBox_DevSubnetMask.Name = "textBox_DevSubnetMask";
            this.textBox_DevSubnetMask.Size = new System.Drawing.Size(108, 20);
            this.textBox_DevSubnetMask.TabIndex = 14;
            this.textBox_DevSubnetMask.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_DevDefualtGateway
            // 
            this.textBox_DevDefualtGateway.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_DevDefualtGateway.Location = new System.Drawing.Point(112, 92);
            this.textBox_DevDefualtGateway.Name = "textBox_DevDefualtGateway";
            this.textBox_DevDefualtGateway.Size = new System.Drawing.Size(108, 20);
            this.textBox_DevDefualtGateway.TabIndex = 14;
            this.textBox_DevDefualtGateway.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CameraIPConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 323);
            this.Controls.Add(this.button_IPConfigCancel);
            this.Controls.Add(this.button_IPConfigOK);
            this.Controls.Add(this.groupBox_InterfaceInfo);
            this.Controls.Add(this.groupBox_DeviceInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CameraIPConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CameraIPConfig";
            this.groupBox_DeviceInfo.ResumeLayout(false);
            this.groupBox_DeviceInfo.PerformLayout();
            this.groupBox_InterfaceInfo.ResumeLayout(false);
            this.groupBox_InterfaceInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox_DeviceInfo;
        private System.Windows.Forms.GroupBox groupBox_InterfaceInfo;
        private System.Windows.Forms.Label label_IFDefualtGateway;
        private System.Windows.Forms.Label label_IFSubnetMask;
        private System.Windows.Forms.Label label_IFIPAddr;
        private System.Windows.Forms.Label label_IFMacAddr;
        private System.Windows.Forms.Button button_IPConfigOK;
        private System.Windows.Forms.Button button_IPConfigCancel;
        private System.Windows.Forms.Label label_DevMacAddr;
        private System.Windows.Forms.Label label_DevIPAddr;
        private System.Windows.Forms.Label label_DevSubnetMask;
        private System.Windows.Forms.Label label_DevDefualtGateway;
        private System.Windows.Forms.TextBox textBox_IFDefualtGateway;
        private System.Windows.Forms.TextBox textBox_IFSubnetMask;
        private System.Windows.Forms.TextBox textBox_IFIPAddr;
        private System.Windows.Forms.TextBox textBox_IFMacAddr;
        private System.Windows.Forms.TextBox textBox_DevMacAddr;
        private System.Windows.Forms.TextBox textBox_DevDefualtGateway;
        private System.Windows.Forms.TextBox textBox_DevSubnetMask;
        private System.Windows.Forms.TextBox textBox_DevIPAddr;
    }
}
