using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class LabelCommand : AbstractCommand, ILabelCommand, IVisibleField, IEnabledField, ILabelField {
        public Func<bool> getEnabled { get;  set; }

        public Func<string> getLabel { get; set; }

        public Func<bool> getVisible { get; set; }

        public void IsVisible(Func<bool> condition) {
            getVisible = condition;
        }

        public void IsEnabled(Func<bool> condition) {
            getEnabled = condition;
        }

        public void GetLabel(Func<string> text) {
            getLabel = text;
        }

        #region Implementation of ICommand

        /// <summary>
        ///     写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public override void WriteCallbackXml(XElement element) {
            element.AddCallbackAttribute("getLabel", getLabel);
            element.AddCallbackAttribute("getEnabled", getEnabled);
            element.AddCallbackAttribute("getVisible", getVisible);
        }

        #endregion

        
    }
}