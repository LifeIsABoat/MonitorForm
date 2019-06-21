using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using ThridLibray;

namespace PrinterMonitor
{
    public partial class CameraIPConfigForm : Form
    {
        //select camera index
        int selectCameraIndex;

        public CameraIPConfigForm(int idx)
        {
            InitializeComponent();

            selectCameraIndex = idx;

            string macAddr, ipAddr, subMask, gateway;
            Enumerator.GigeInterfaceInfo(selectCameraIndex, out macAddr, out ipAddr, out subMask, out gateway);
            textBox_IFMacAddr.Text = macAddr;
            textBox_IFIPAddr.Text = ipAddr;
            textBox_IFSubnetMask.Text = subMask;
            textBox_IFDefualtGateway.Text = gateway;

            Enumerator.GigeCameraNetInfo(selectCameraIndex, out macAddr, out ipAddr, out subMask, out gateway);
            textBox_DevMacAddr.Text = macAddr;
            textBox_DevIPAddr.Text = ipAddr;
            textBox_DevSubnetMask.Text = subMask;
            textBox_DevDefualtGateway.Text = gateway;
        }

        private void button_IPConfigOK_Click(object sender, EventArgs e)
        {
            IPAddress ip, submask, gateway;
            if (   !IPAddress.TryParse(textBox_DevIPAddr.Text, out ip)
                || textBox_DevIPAddr.Text.Split(new char[] {'.'}).Length != 4)
            {
                MessageBox.Show("请输入正确IP！");
                return;
            }
            if (   !IPAddress.TryParse(textBox_DevSubnetMask.Text, out submask)
                || textBox_DevSubnetMask.Text.Split(new char[] { '.' }).Length != 4)
            {
                MessageBox.Show("请输入正确子网掩码！");
                return;
            }
            if (   !IPAddress.TryParse(textBox_DevDefualtGateway.Text, out gateway)
                || textBox_DevDefualtGateway.Text.Split(new char[] { '.' }).Length != 4)
            {
                MessageBox.Show("请输入正确网关地址！");
                return;
            }

            Enumerator.GigeForceIP(selectCameraIndex, textBox_DevIPAddr.Text, textBox_DevSubnetMask.Text, textBox_DevDefualtGateway.Text);
            Close();
        }

        private void button_IPConfigCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
