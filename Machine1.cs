using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Xml;
using System.Threading;

namespace ESMachineMonitorForm
{
    class Machine
    {
        private Size panelSize;
        private Dictionary<string, int> keyBoardDic;
        private SerialPort serialPort;
        private StringBuilder buf;
        private Mutex bufMutex;

        public Machine()
        {
            panelSize = new Size();
            keyBoardDic = new Dictionary<string, int>();
            serialPort = new SerialPort();
            serialPort.BaudRate = 1200;
            serialPort.Parity = Parity.None;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.ReadBufferSize = 16 * 1024;
            serialPort.WriteBufferSize = 16 * 1024;
            serialPort.ReadTimeout = 500;
            serialPort.WriteTimeout = 500;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(dataReceiver);
            buf = new StringBuilder(0, 1024 * 1024);
            bufMutex = new Mutex();
        }

        public void loadParam(string configFilePath)
        {
            if (!File.Exists(configFilePath))
                throw new Exception("Camera param config File is not existed.");
            string xmlstr = File.ReadAllText(configFilePath);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlstr);
            XmlNode machineNode = xmlDoc.SelectSingleNode("Machine");
            XmlNode touchPanelNode = machineNode.SelectSingleNode("TouchPanel");
            foreach (XmlNode childNode in touchPanelNode.ChildNodes)
            {
                if (childNode.Attributes["name"].Value == "Width")
                    panelSize.Width = Convert.ToInt32(childNode.Attributes["value"].Value);
                else if (childNode.Attributes["name"].Value == "Height")
                    panelSize.Height = Convert.ToInt32(childNode.Attributes["value"].Value);
                else
                    throw new Exception("Load Param Failed by Invalid config File.");
            }
            XmlNode keyBoardNode = machineNode.SelectSingleNode("KeyBoard");
            keyBoardDic.Clear();
            foreach (XmlNode childNode in keyBoardNode.ChildNodes)
            {
                keyBoardDic.Add(childNode.Attributes["name"].Value, Convert.ToInt32(childNode.Attributes["value"].Value));
            }
        }

        public List<string> getKeyList()
        {
            return keyBoardDic.Keys.ToList();
        }
        
        public void connect(string portName)
        {
            try
            {
                serialPort.PortName = portName;
                serialPort.Open();
            }
            catch
            {
                throw new Exception("Connect Serial port failed, please check Com number.");
            }
        }

        public void disconnect()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            else
            {
                throw new Exception("Disconnect Serial port failed,");
            }
        }

        public void pushPanel(Point pt)
        {
            string sendbuf = "|p" + String.Format("{0:d3}{1:d3}", pt.X, pt.Y);
            writeSerail(sendbuf);
        }
        public void releasePanel(Point pt)
        {
            string sendbuf = "|r" + String.Format("{0:d3}{1:d3}", pt.X, pt.Y);
            writeSerail(sendbuf);
        }
        public void clickPanel(Point pt)
        {
            pushPanel(pt);
            releasePanel(pt);
        }

        public void clickKey(string keyCode)
        {
            if (!keyBoardDic.ContainsKey(keyCode))
            {
                throw new Exception("TargetKey[" + keyCode + "] is invalid.");
            }
            writeSerail(((char)keyBoardDic[keyCode]).ToString());
        }

        public void getAdditionalInfo(string path)
        {
            //todo
        }

        private void writeSerail(string cmd)
        {
            byte[] sendbuf = new byte[cmd.Length];
            //sendbuf = System.Text.Encoding.ASCII.GetBytes(cmd);
            int i = 0;
            while (i < cmd.Length)
            {
                sendbuf[i] = (byte)cmd[i];
                i++;
            }
            if (null == serialPort || !serialPort.IsOpen)
            {
                throw new Exception("SerialPort not initialized");
            }
            try
            {
                serialPort.Write(sendbuf, 0, sendbuf.Length);
            }
            catch
            {
                throw new Exception("Send command to MFC Failed!");
            }
        }

        private string readSerail()
        {
            string ret = "";
            bufMutex.WaitOne();
            if (buf.Length > 0)
            {
                ret = buf.ToString();
                buf.Remove(0, buf.Length);
            }
            bufMutex.ReleaseMutex();
            return ret;
        }

        private void dataReceiver(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string indata = serialPort.ReadExisting();
                bufMutex.WaitOne();
                buf.Append(indata);
                bufMutex.ReleaseMutex();
            }
            catch
            {
                throw new Exception("The specified port is not open");
            }
        }
    }
}
