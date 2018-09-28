using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class ButtonCommand : ButtonRegularCommand<IButtonCommand>, IButtonCommand,IActionField {

        #region Overrides of ButtonRegularCommand<IButtonCommand>

        protected override IButtonCommand Interface => this;

        #endregion

        #region Overrides of ButtonRegularCommand<IButtonCommand>

        /// <summary>
        /// 写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public override void WriteCallbackXml(XElement element) {
            base.WriteCallbackXml(element);
            element.AddCallbackAttribute("onAction",onAction);
        }

        #endregion

        #region Implementation of IButtonCommand

        public IButtonCommand OnAction(Action action) {
            this.onAction = action;
            return Interface;
        }

        #endregion

        #region Implementation of IActionField

        /// <summary>
        /// onAction 
        /// 回调
        /// VBA：Sub OnAction(control As IRibbonControl, itemID As String, itemIndex As Integer)
        /// C#：void OnAction(IRibbonControl control, string itemID, int itemIndex)
        /// </summary>
        public Action onAction { get; set; }

        #endregion
    }
}