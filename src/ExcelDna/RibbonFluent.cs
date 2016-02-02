using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using AddinX.Core.Contract;
using AddinX.Core.Contract.Command;
using AddinX.Core.Implementation;
using ExcelDna.Integration.CustomUI;

namespace AddinX.Core.ExcelDna
{
    [ComVisible(true)]
    public abstract partial class RibbonFluent : ExcelRibbon, IRibbonFluent
    {
        protected IRibbonUI Ribbon;

        private IRibbonBuilder ribbonBuilder;
        private IRibbonCommands cmds;
        protected IEnumerable<string> CommandNames;

        protected RibbonFluent()
        {
            this.cmds = new RibbonCommands();
            ribbonBuilder = new RibbonBuilder();
        }

        public override void OnBeginShutdown(ref Array custom)
        {
            OnClosing();
            cmds = null;
            ribbonBuilder = null;
            base.OnBeginShutdown(ref custom);
        }

        public override string GetCustomUI(string ribbonId)
        {
            OnOpening();
            var ribbonXml = GetRibbonXml();
            return ribbonXml;
        }

        public void OnLoad(IRibbonUI ribbon)
        {
            Ribbon = ribbon;
        }

        public virtual Bitmap OnLoadImage(string imageName)
        {
            return null;
        }

        public string GetRibbonXml()
        {
            CreateFluentRibbon(ribbonBuilder);
            CreateRibbonCommand(cmds);
            CommandNames = cmds.GetListCommandNames();
            return ribbonBuilder.GetXmlString();
        }

        public ICommand FindRibbonCmd(string id)
        {
            return (!cmds.GetListCommandNames().Contains(id)
                ? null
                : cmds.Find(id));
        }

        protected abstract void CreateFluentRibbon(IRibbonBuilder build);

        protected abstract void CreateRibbonCommand(IRibbonCommands cmds);

        public abstract void OnClosing();

        public abstract void OnOpening();

    }
}
