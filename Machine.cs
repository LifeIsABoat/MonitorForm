using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Threading;
using ESMachineMonitorForm;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace ESMachineMonitorForm
{
    class ESMachine : AbstractMachine
    {
        private Dictionary<string, string> keyInfo;
        private Dictionary<string, string> lcdInfo;
        private Dictionary<string, string> keyName;
        private string iniFileName;
        private string intputPath;
        private string outputPath;
        Bitmap image;
        public ESMachine()
        {
            keyInfo = new Dictionary<string, string>();
            lcdInfo = new Dictionary<string, string>();
            keyName = new Dictionary<string, string>();
            this.intputPath = StaticEnvironInfo.getewsAndRspConfigPath();
            this.outputPath = intputPath.Substring(0, intputPath.LastIndexOf("Input")) + @"Output\QL\QL-820\";
            iniFileName = intputPath + @"\config.ini";
            InitMachine(iniFileName);
        }
        void InitMachine(string iniFileName)
        {
            List<string> keylist = new List<string>();
            INIParser.getKeyList("Key", iniFileName, keylist);
            for (int i = 0; i < keylist.Count; i++)
            {
                //get value
                string value = INIParser.getvalue("Key", iniFileName, keylist[i]);
                if (value != "")
                {
                    keyInfo.Add(keylist[i], value);
                }
            }
            keylist.Clear();
            INIParser.getKeyList("Lcd", iniFileName, keylist);
            for (int i = 0; i < keylist.Count; i++)
            {
                //get value
                string value = INIParser.getvalue("Lcd", iniFileName, keylist[i]);
                if (value != "")
                {
                    lcdInfo.Add(keylist[i], value);
                }
            }
            keylist.Clear();

            INIParser.getKeyList("KeyClassification", iniFileName, keylist);
            for (int i = 0; i < keylist.Count; i++)
            {
                //get value
                string value = INIParser.getvalue("KeyClassification", iniFileName, keylist[i]);
                if (value != "")
                {
                    keyName.Add(keylist[i], value);
                }
            }
            keylist.Clear();
        }
        public List<string> getKeyList()
        {
            return keyName.Keys.ToList();
        }

        public Bitmap getScreen(string imagePath)
        {
            string cmd, binfilename, binPath;
            string cmdTxt = intputPath + @"\Jlink.txt";
            int index = imagePath.LastIndexOf(@"\");

            if (index == -1)
            {
                binfilename = imagePath.Replace(".bmp", ".bin");
                binPath = outputPath + binfilename;
                imagePath = outputPath + imagePath;
            }
            else
            {
                binPath = imagePath.Substring(index + 1, imagePath.LastIndexOf(@".") - index - 1) + ".bin";
                binPath = outputPath + binPath;
            }

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }

            if (File.Exists(binPath))
            {
                File.Delete(binPath);
            }

            using (StreamWriter file = new StreamWriter(cmdTxt))
            {
                cmd = "setBP " + lcdInfo["LcdAddressBreakPoint"];
                file.WriteLine(cmd);
                file.WriteLine("sleep 50");
                cmd = "savebin " + binPath + " " + lcdInfo["LcdBuff"] + " " + lcdInfo["LcdBuffSize"];
                file.WriteLine(cmd);
                file.WriteLine("clrBP 1");
                file.WriteLine("q");
            }
            cmd = "-device LPC1830 -Speed 10000 -IF JTAG -CommanderScript " + cmdTxt;
            DateTime dt1 = DateTime.Now;
            CallScript("jlink.exe", cmd);
            DateTime dt2 = DateTime.Now;
            TimeSpan ts = dt2.Subtract(dt1);
            Console.WriteLine("bin {0}", ts.TotalMilliseconds);
            cmd = binPath + " " + imagePath;
            return getImageFromBin(binPath);
        }

        public override void doCommand(string type, string command)
        {
            string cmd, cmdTxt;

            if (type != "KeyClick")
            {
                throw new Exception("Key type is not KeyClick");
            }

            if (!keyInfo.ContainsKey(command))
            {
                throw new Exception("This Key does not exist");
            }

            cmdTxt = intputPath + @"\Jlink.txt";
            using (StreamWriter file = new StreamWriter(cmdTxt))
            {
                cmd = "setBP " + keyInfo["KeyAddressBreakPoint"];
                file.WriteLine(cmd);
                file.WriteLine("sleep 50");
                cmd = "w2  " + keyInfo["KeyValueAddress"] + " " + keyInfo[command];
                file.WriteLine(cmd);
                cmd = "wreg   " + keyInfo["KeyCount"] + ",0x01";
                file.WriteLine(cmd);
                file.WriteLine("clrBP 1");
                file.WriteLine("g");
                file.WriteLine("q");
            }
            cmd = "-device LPC1830 -Speed 10000 -IF JTAG -CommanderScript " + cmdTxt;
            DateTime dt1 = DateTime.Now;
            CallScript("jlink.exe", cmd);
            DateTime dt2 = DateTime.Now;
            TimeSpan ts = dt2.Subtract(dt1);
            Console.WriteLine("key {0}", ts.TotalMilliseconds);
        }

        private void CallScript(string FileName, string Arguments)
        {
            Process proc = null;
            proc = new Process();
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//设置DOS窗口不显示
            proc.StartInfo.WorkingDirectory = intputPath;
            proc.StartInfo.FileName = FileName;
            proc.StartInfo.Arguments = Arguments;//this is argument
                                                 //proc.StartInfo.CreateNoWindow = true;
                                                 //proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//这里设置DOS窗口不显示，经实践可行
            proc.Start();
            proc.WaitForExit();

        }

        public Bitmap getImageFromBin(string binPath)
        {
            FileStream fs = new FileStream(binPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] data = br.ReadBytes(320 * 120 / 8);
            fs.Close();
            br.Close();
            ReverseBytes(data);
            GCHandle hObject = GCHandle.Alloc(data, GCHandleType.Pinned);
            IntPtr dataPtr = hObject.AddrOfPinnedObject();
            image = new Bitmap(320, 120, 40, PixelFormat.Format1bppIndexed, dataPtr);
            return ConvertTo1Bpp1(image);
        }

        private static void ReverseBytes(byte[] bytes)
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
        private static Bitmap ConvertTo1Bpp1(Bitmap bmp)
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
                    Color newColor = value < average ? Color.FromArgb(0, 0, 0) : Color.FromArgb(255, 255, 255);
                    image.SetPixel(i, j, newColor);
                }
            }
            return image;
        }

    }
}
