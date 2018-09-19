﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Implementation;
using ExcelDna.Integration;
using ExcelDna.Integration.CustomUI;

namespace AddinX.Ribbon.ExcelDna
{
    [ComVisible(true)]
    public abstract partial class RibbonFluent : ExcelRibbon, IRibbonFluent
    {
        protected IRibbonUI Ribbon;

        //private IRibbonBuilder ribbonBuilder;
        private IRibbonCommands cmds;
        protected IEnumerable<string> CommandNames;

        protected RibbonFluent()
        {
            cmds = new RibbonCommands();
            //ribbonBuilder = new RibbonBuilder();
        }

        public override void OnBeginShutdown(ref Array custom)
        {
            OnClosing();
            cmds = null;
            //ribbonBuilder = null;
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

        public string GetRibbonXml() {
            RibbonBuilder builder;
            if (ExcelDnaUtil.ExcelVersion >= 14.0) {
                builder = new RibbonBuilder(NamespaceCustomUI2010);
                CreateFluentRibbon(builder);
            }

            if (ExcelDnaUtil.ExcelVersion < 12.0) {
                throw new InvalidOperationException("Not expected to provide CustomUI string for Excel version < 12.0");
            } else {
                builder = new RibbonBuilder(NamespaceCustomUI2007);
                CreateFluentRibbon(builder);
            }
            CreateRibbonCommand(cmds);
            CommandNames = cmds.GetListCommandNames();
            return builder.GetXmlString();
        }

        public ICommand FindRibbonCmd(string id)
        {
            return !cmds.GetListCommandNames().Contains(id)
                ? null
                : cmds.Find(id);
        }

        protected abstract void CreateFluentRibbon(IRibbonBuilder build);

        protected abstract void CreateRibbonCommand(IRibbonCommands cmds);

        public abstract void OnClosing();

        public abstract void OnOpening();

    }
}
