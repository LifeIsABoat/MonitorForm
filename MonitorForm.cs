using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Diagnostics;
using System.Windows.Forms;
using ThridLibray;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace ESMachineMonitorForm
{
    public partial class MonitorForm : Form
    {
        private ESMachine es_machine;
        int TcCount = 0;//define TcCount
        Bitmap image;
        public MonitorForm()
        {
            InitializeComponent();
            es_machine = new ESMachine();
            DelectDir(@"D:\FTBAutoTest\ES\Output\QL\QL-820\");
        }
        private void MonitorForm_Shown(object sender, EventArgs e)
        {
            //textBox_MachineCfg.Enabled = false;
            //button_MachineCfgBrowse.Enabled = false;
            //sendButton.Enabled = false;
            //textBox_MachineCfg.Enabled = false;
            //textBox1.Enabled = false;
        }
        private void button_MachineCfgBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Please select Machine Config File";
            dlg.InitialDirectory = Application.StartupPath;
            dlg.Filter = "Text File|*.ini|ALL|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textBox_MachineCfg.Text = dlg.FileName;
                    //es_machine.InitMachine(dlg.FileName);
                }
                catch
                {
                    MessageBox.Show(@"请选择正确的文件类型！");
                    return;
                }
                List<string> keyStrList = es_machine.getKeyList();
                if (keyStrList.Count != 0)
                {
                    flowLayoutPanel_MachineKeyBoard.Controls.Clear();
                    foreach (string keyStr in keyStrList)
                    {
                        Button keyButton = new Button();
                        keyButton.Size = new Size(75, 23);
                        keyButton.Name = @"keyButton_ " + keyStr;
                        keyButton.Text = keyStr;
                        keyButton.Click += button_KeyBoard_key_Click;
                        flowLayoutPanel_MachineKeyBoard.Controls.Add(keyButton);
                    }
                }
            }
        }
        private void button_KeyBoard_key_Click(object sender, EventArgs e)
        {
            string saveBinPath = null;
            Button keyButton = sender as Button;
            if (keyButton.Text != null)
            {
                try
                {
                    es_machine.doCommand("KeyClick", keyButton.Text);
                    FormBorderStyle = FormBorderStyle.None;
                    //get Image
                    while (true)
                    {
                        string path = @"D:\FTBAutoTest\ES\Input\QL\QL-820\";
                        saveBinPath = path + TcCount.ToString() + @".bin";
                        DateTime dt1 = DateTime.Now;
                        pictureBox_FrameShow.Image = es_machine.getScreen(saveBinPath);
                        DateTime dt2 = DateTime.Now;
                        TimeSpan ts = dt2.Subtract(dt1);
                        Console.WriteLine("image {0}", ts.TotalMilliseconds);
                        TcCount++;
                        break;
                    }
                }
                catch { MessageBox.Show("KeyClick keyButton failed!"); }
            }
        }

        public static string getScreenImageFileName(int count)
        {
            string saveBmpPath = null;
            string path = @"D:\FTBAutoTest\ES\Input\QL\QL-820\";
            while (true)
            {
                saveBmpPath = path + count.ToString() + @".bmp";
                break;
            }
            return saveBmpPath;
        }

        public void DelectDir(string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);
                    }
                    else
                    {
                        File.Delete(i.FullName);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string greenshotPath = @"D:\FTBAutoTest\Input\ES\Input\QL\QL-820\a.bmp";
            es_machine.getScreen(greenshotPath);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string saveBinPath = null;
            string keyStr = textBox1.Text;
            try
            {
                es_machine.doCommand("KeyClick", keyStr);
                FormBorderStyle = FormBorderStyle.None;
                //get image
                string path = @"D:\FTBAutoTest\ES\Input\QL\QL-820\";
                while (true)
                {
                    saveBinPath = path + TcCount.ToString() + @".bin";
                    DateTime dt1 = DateTime.Now;
                    pictureBox_FrameShow.Image = es_machine.getScreen(saveBinPath);
                    DateTime dt2 = DateTime.Now;
                    TimeSpan ts = dt2.Subtract(dt1);
                    Console.WriteLine("image {0}", ts.TotalMilliseconds);
                    TcCount++;
                    break;
                }
            }
            catch { MessageBox.Show("Click key failed by uncorrect keyName!"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<int> intList = new List<int>();
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Text File|*.bin|ALL|*.*";
            of.Title = "Please select Machine Config File";
            of.InitialDirectory = Application.StartupPath;
            if (of.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(of.FileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] data = br.ReadBytes(320*120/8);
                fs.Close();
                br.Close();
                ReverseBytes(data);
                GCHandle hObject = GCHandle.Alloc(data, GCHandleType.Pinned);
                IntPtr dataPtr = hObject.AddrOfPinnedObject();
                image = new Bitmap(320, 120, 40, PixelFormat.Format1bppIndexed, dataPtr);
                pictureBox_FrameShow.Image = ConvertTo1Bpp1(image);
            }
        }
        public static IntPtr byteToIntptr(byte[] bytes)
        {
            int size = bytes.Length;
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(bytes, 0, buffer, size);
                return buffer;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }
        public static void ReverseBytes(byte[] bytes)
        {
            byte tmp;
            int len = bytes.Length;

            for (int i = 0; i < len / 2; i++)
            {
                tmp = bytes[len - 1 - i];
                bytes[len - 1 - i] = bytes[i];
                bytes[i] = tmp;
            }
        }
        public static Bitmap ConvertTo1Bpp1(Bitmap bmp)
        {
            Bitmap image = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format32bppArgb);
            int average = 0;
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color color = bmp.GetPixel(i, j);
                    average += color.B;
                }
            }
            average = (int)average / (bmp.Width * bmp.Height);

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color color = bmp.GetPixel(i, j);
                    int value = 255 - color.B;
                    Color newColor = value < average ? Color.FromArgb(0, 0, 0) : Color.FromArgb(255,255, 255);
                    image.SetPixel(i, j, newColor);
                }
            }
            return image;
        }

        //public static int bytesToIntBig(byte[] src, int offset)
        //{
        //    int value;
        //    value = (int)(((src[offset] & 0xFF)) << 24)
        //        | ((src[offset + 1] & 0xFF) << 16)
        //        | ((src[offset + 2] & 0xFF) << 8)
        //        | ((src[offset + 3] & 0xFF));
        //    return value;
        //}

        //public static byte[] intToBytesLittle(int value)
        //{
        //    byte[] src = new byte[4];
        //    src[3] = (byte)((value >> 24) & 0xFF);
        //    src[2] = (byte)((value >> 16) & 0xFF);
        //    src[1] = (byte)((value >> 8) & 0xFF);
        //    src[0] = (byte)(value & 0xFF);
        //    return src;
        //}
    }
}
