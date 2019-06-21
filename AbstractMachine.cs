using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMachineMonitorForm
{
    abstract class AbstractMachine
    {
        public const string _KeyClick = "KeyClick";

        public const string _TpPush = "TpPush";
        public const string _TpRelease = "TpRelease";
        public const string _TpClick = "TpClidk";

        public const string _Language = "Language";
        public virtual string getLog()
        {
            throw new NotImplementedException();
        }

        //public virtual Bitmap getScreen(string imagePath)
        //{
        //    throw new NotImplementedException();
        //}

        public virtual void doCommand(string type,string command)
        {
            throw new NotImplementedException();
        }
        public virtual void doCommandLang(string type, string command)
        {
            throw new NotImplementedException();
        }
    }
}
