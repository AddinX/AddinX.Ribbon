using System;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;
using AddinX.Ribbon.Contract.Enums;

namespace AddinX.Ribbon.Implementation.Command {
    public class ToggleButtonCommand : ToggleRegularCommand, IToggleButtonCommand, IVisibleField{

        #region Implementation of ICommand

        /// <summary>
        ///     写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public override void WriteCallbackXml(XElement element) {
            base.WriteCallbackXml(element);
            element.AddCallbackAttribute("getVisible",IsVisibleField);
        }

        #endregion


        #region Implementation of IVisibleField

        public Func<bool> IsVisibleField { get; set; }

        #endregion
    }


    public class ToggleRegularCommand : IToggleRegularCommand {

        /// <summary>
        /// 写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public virtual void WriteCallbackXml(XElement element) {
            element.AddCallbackAttribute("onAction", "OnActionPressed", onActionPressed);
            element.AddCallbackAttribute("getPressed", getPressed);
            element.AddCallbackAttribute("getEnabled", getEnabled);
            element.AddCallbackAttribute("getImage", getImage);
            element.AddCallbackAttribute("getDescription", GetDescription);
        }

        #region Implementation of IPressedField

        public Func<bool> getPressed { get; set; }

        #endregion

        #region Implementation of IDescriptionField

        public Func<string> GetDescription { get; set; }

        #endregion

        #region Implementation of IEnabledField

        public Func<bool> getEnabled { get; set; }

        #endregion

        #region Implementation of IImageField

        public Func<object> getImage { get; set; }

        #endregion

        #region Implementation of IActionPressedField

        public Action<bool> onActionPressed { get; set; }

        #endregion
    }

    public class ButtonRegularCommand: IButtonRegularCommand {
        #region Implementation of ICommand

        /// <summary>
        /// 写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public virtual void WriteCallbackXml(XElement element) {
            element.AddCallbackAttribute("getEnabled", getEnabled);
            element.AddCallbackAttribute("getImage", getImage);
            element.AddCallbackAttribute("onAction", OnAction);
            element.AddCallbackAttribute("getDescription",GetDescription);
        }

        #endregion

        #region Implementation of IEnabledField

        public Func<bool> getEnabled { get; set; }

        #endregion

        #region Implementation of IImageField

        public Func<object> getImage { get; set; }

        #endregion

        #region Implementation of IActionField

        public Action OnAction { get; set; }

        #endregion

        #region Implementation of IDescriptionField

        public Func<string> GetDescription { get; set; }

        #endregion
    }
}