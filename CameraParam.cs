using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Reflection;
using ThridLibray;

namespace PrinterMonitor
{
    class CameraParam
    {
        public string ImagePixelFormat;
        public string ImageReverseX;
        public string ImageReverseY;
        public string ImageTranspose;

        public string AcquisitionFrameRate;
        public string AcquisitionFrameRateEnable;
        public string TriggerMode;
        public string GainAuto;
        public string GainRaw;
        public string Gamma;

        public string ExposureAuto;
        public string ExposureTime;

        public string Brightness;
        public string Digitalshift;

        public string BalanceWhiteAuto;
        public string BalanceRatioRed;
        public string BalanceRatioGreen;
        public string BalanceRatioBlue;

        public string ContrastMode;
        public string Contrast;
        public string ContrastThreshold;

        public string DenoisingMode;
        public string Denoising;

        public string SharpnessAuto;
        public string SharpnessEnable;
        public string Sharpness;

        public void loadParam(string configFilePath)
        {
            if (!File.Exists(configFilePath))
                throw new Exception("Camera param config File is not existed.");
            string xmlstr = File.ReadAllText(configFilePath);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlstr);
            XmlNode rootNode = xmlDoc.SelectSingleNode("Property");
            foreach(XmlNode paramNode in rootNode.ChildNodes)
            {
                //Get param filed
                FieldInfo field = GetType().GetField(paramNode.Attributes["name"].Value);

                ////prepare Value object
                //Type valueType = Type.GetType(field.FieldType.ToString().Replace(".I", ".") + ",ThridLibray");
                //object[] parameters = new object[1];
                //parameters[0] = paramNode.Attributes["value"].Value; 
                //object valueObj = Activator.CreateInstance(valueType, parameters);

                ////set param value
                //field.SetValue(this, valueObj);

                //Set param filed
                field.SetValue(this, paramNode.Attributes["value"].Value);
            }
        }

        public void loadParam(IDevice f_dev)
        {
            IParameterCollection cameraParam = f_dev.ParameterCollection;

            ImagePixelFormat = cameraParam[ParametrizeNameSet.ImagePixelFormat].GetValue().ToString();
            ImageReverseX = cameraParam[ParametrizeNameSet.ImageReverseX].GetValue().ToString();
            ImageReverseY = cameraParam[ParametrizeNameSet.ImageReverseY].GetValue().ToString();

            AcquisitionFrameRate = cameraParam[ParametrizeNameSet.AcquisitionFrameRate].GetValue().ToString();
            AcquisitionFrameRateEnable = cameraParam[ParametrizeNameSet.AcquisitionFrameRateEnable].GetValue().ToString();
            TriggerMode = cameraParam[ParametrizeNameSet.TriggerMode].GetValue().ToString();
            GainAuto = cameraParam[ParametrizeNameSet.GainAuto].GetValue().ToString();
            GainRaw = cameraParam[ParametrizeNameSet.GainRaw].GetValue().ToString();
            Gamma = cameraParam[ParametrizeNameSet.Gamma].GetValue().ToString();

            ExposureAuto = cameraParam[ParametrizeNameSet.ExposureAuto].GetValue().ToString();
            ExposureTime = cameraParam[ParametrizeNameSet.ExposureTime].GetValue().ToString();

            Brightness = cameraParam[ParametrizeNameSet.Brightness].GetValue().ToString();
            Digitalshift = cameraParam[ParametrizeNameSet.Digitalshift].GetValue().ToString();

            BalanceWhiteAuto = cameraParam[ParametrizeNameSet.BalanceWhiteAuto].GetValue().ToString();
            cameraParam[ParametrizeNameSet.BalanceRatioSelector].SetValue("Red");
            BalanceRatioRed = cameraParam[ParametrizeNameSet.BalanceRatio].GetValue().ToString();
            cameraParam[ParametrizeNameSet.BalanceRatioSelector].SetValue("Green");
            BalanceRatioGreen = cameraParam[ParametrizeNameSet.BalanceRatio].GetValue().ToString();
            cameraParam[ParametrizeNameSet.BalanceRatioSelector].SetValue("Blue");
            BalanceRatioBlue = cameraParam[ParametrizeNameSet.BalanceRatio].GetValue().ToString();

            ContrastMode = cameraParam[ParametrizeNameSet.ContrastMode].GetValue().ToString();
            Contrast = cameraParam[ParametrizeNameSet.Contrast].GetValue().ToString();
            ContrastThreshold = cameraParam[ParametrizeNameSet.ContrastThreshold].GetValue().ToString();

            DenoisingMode = cameraParam[ParametrizeNameSet.DenoisingMode].GetValue().ToString();
            Denoising = cameraParam[ParametrizeNameSet.Denoising].GetValue().ToString();

            SharpnessAuto = cameraParam[ParametrizeNameSet.SharpnessAuto].GetValue().ToString();
            SharpnessEnable = cameraParam[ParametrizeNameSet.SharpnessEnable].GetValue().ToString();
            Sharpness = cameraParam[ParametrizeNameSet.Sharpness].GetValue().ToString();
        }

        public void saveParam(string configFilePath)
        {
            if (!Path.GetFileName(configFilePath).EndsWith(".xml"))
                throw new Exception("Camera param config File name error.");
            if (!Directory.Exists(Path.GetDirectoryName(configFilePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(configFilePath));

            XmlDocument xmlDoc = new XmlDocument();
 
            XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
            xmlDoc.AppendChild(node);

            XmlNode root = xmlDoc.CreateElement("Property");
            xmlDoc.AppendChild(root);

            XmlElement chileNode;

            foreach (FieldInfo param in this.GetType().GetFields())
            {
                chileNode = xmlDoc.CreateElement("Item");
                chileNode.SetAttribute("name", param.Name);
                chileNode.SetAttribute("value", (string)param.GetValue(this));
                root.AppendChild(chileNode);
            }

            xmlDoc.Save(configFilePath);
        }

        public void saveParam(IDevice f_dev)
        {
            IParameterCollection cameraParam = f_dev.ParameterCollection;

            // ImageFormatControl
            cameraParam[ParametrizeNameSet.ImagePixelFormat].SetValue(ImagePixelFormat);
            cameraParam[ParametrizeNameSet.ImageReverseX].SetValue(bool.Parse(ImageReverseX));
            cameraParam[ParametrizeNameSet.ImageReverseY].SetValue(bool.Parse(ImageReverseY));

            // AcquisitionControl
            cameraParam[ParametrizeNameSet.AcquisitionFrameRate].SetValue(double.Parse(AcquisitionFrameRate));
            cameraParam[ParametrizeNameSet.AcquisitionFrameRateEnable].SetValue(bool.Parse(AcquisitionFrameRateEnable));
            cameraParam[ParametrizeNameSet.TriggerSelector].SetValue("FrameStart");
            cameraParam[ParametrizeNameSet.TriggerMode].SetValue(TriggerMode);
            cameraParam[ParametrizeNameSet.TriggerSelector].SetValue("AcquisitionStart");
            cameraParam[ParametrizeNameSet.TriggerMode].SetValue(TriggerMode);

            // GainControl
            cameraParam[ParametrizeNameSet.GainAuto].SetValue(GainAuto);
            cameraParam[ParametrizeNameSet.GainRaw].SetValue(double.Parse(GainRaw));
            cameraParam[ParametrizeNameSet.Gamma].SetValue(double.Parse(Gamma));

            // ExposureControl
            cameraParam[ParametrizeNameSet.ExposureAuto].SetValue(ExposureAuto);
            cameraParam[ParametrizeNameSet.ExposureTime].SetValue(double.Parse(ExposureTime));

            // BrightnessControl
            cameraParam[ParametrizeNameSet.Brightness].SetValue(long.Parse(Brightness));
            cameraParam[ParametrizeNameSet.Digitalshift].SetValue(long.Parse(Digitalshift));

            // WhiteBalanceControl
            cameraParam[ParametrizeNameSet.BalanceWhiteAuto].SetValue(BalanceWhiteAuto);
            cameraParam[ParametrizeNameSet.BalanceRatioSelector].SetValue("Red");
            cameraParam[ParametrizeNameSet.BalanceRatio].SetValue(double.Parse(BalanceRatioRed));
            cameraParam[ParametrizeNameSet.BalanceRatioSelector].SetValue("Green");
            cameraParam[ParametrizeNameSet.BalanceRatio].SetValue(double.Parse(BalanceRatioGreen));
            cameraParam[ParametrizeNameSet.BalanceRatioSelector].SetValue("Blue");
            cameraParam[ParametrizeNameSet.BalanceRatio].SetValue(double.Parse(BalanceRatioBlue));

            // ContrastControl
            cameraParam[ParametrizeNameSet.ContrastMode].SetValue(ContrastMode);
            cameraParam[ParametrizeNameSet.Contrast].SetValue(long.Parse(Contrast));
            cameraParam[ParametrizeNameSet.ContrastThreshold].SetValue(long.Parse(ContrastThreshold));

            // DenoisingControl
            cameraParam[ParametrizeNameSet.DenoisingMode].SetValue(DenoisingMode);
            cameraParam[ParametrizeNameSet.Denoising].SetValue(long.Parse(Denoising));

            // SharpControl
            cameraParam[ParametrizeNameSet.SharpnessAuto].SetValue(bool.Parse(SharpnessAuto));
            cameraParam[ParametrizeNameSet.SharpnessEnable].SetValue(SharpnessEnable);
            cameraParam[ParametrizeNameSet.Sharpness].SetValue(long.Parse(Sharpness));
        }
    }
}
