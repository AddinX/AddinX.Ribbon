using System;
using System.Drawing;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class ToggleButtonCommand : ToggleRegularCommand, IToggleButtonCommand, IVisibleField {
        #region Implementation of ICommand

        /// <summary>
        ///     写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public override void WriteCallbackXml(XElement element) {
            base.WriteCallbackXml(element);
            element.AddCallbackAttribute("getVisible", getVisible);
        }

        #endregion


        #region Implementation of IVisibleField

        public Func<bool> getVisible { get; set; }

        #endregion
    }


    public class ToggleRegularCommand : AbstractCommand, IToggleRegularCommand {
        /// <summary>
        /// 写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public override void WriteCallbackXml(XElement element) {
            element.AddCallbackAttribute("onAction", "OnActionPressed", onActionPressed);
            element.AddCallbackAttribute("getPressed", getPressed);
            element.AddCallbackAttribute("getEnabled", getEnabled);
            element.AddCallbackAttribute("getImage", getImage);
            element.AddCallbackAttribute("getDescription", getDescription);
        }

        #region Implementation of IPressedField

        public Func<bool> getPressed { get; set; }

        #endregion

        #region Implementation of IDescriptionField

        public Func<string> getDescription { get; set; }

        #endregion

        #region Implementation of IEnabledField

        public Func<bool> getEnabled { get; set; }

        #endregion

        #region Implementation of IImageField

        public Func<Image> getImage { get; set; }

        #endregion

        #region Implementation of IActionPressedField

        /// <summary>
        /// onAction
        /// 回调
        /// VBA：Sub OnActionPressed(control As IRibbonControl, isPressed As Boolean)
        /// C#：void OnActionPressed(IRibbonControl control, bool isPressed)
        /// </summary>
        public Action<bool> onActionPressed { get; set; }

        #endregion
    }

    public class ButtonRegularCommand : AbstractCommand, IButtonRegularCommand {
        #region Implementation of ICommand

        /// <summary>
        /// 写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public override void WriteCallbackXml(XElement element) {
            element.AddCallbackAttribute("getEnabled", getEnabled);
            element.AddCallbackAttribute("getImage", getImage);
            element.AddCallbackAttribute("onAction", onAction);
            element.AddCallbackAttribute("getDescription", getDescription);
            element.AddCallbackAttribute("getVisible", getVisible);
        }

        #endregion

        #region Implementation of IEnabledField

        public Func<bool> getEnabled { get; set; }

        #endregion

        #region Implementation of IImageField

        public Func<Image> getImage { get; set; }

        #endregion

        #region Implementation of IActionField

        public Action onAction { get; set; }

        #endregion

        #region Implementation of IDescriptionField

        public Func<string> getDescription { get; set; }

        #endregion

        #region Implementation of IVisibleField

        /// <summary>
        /// getVisible
        /// 回调
        /// VBA：Sub GetVisible(control As IRibbonControl, ByRef returnedVal)
        /// C#：bool GetVisible(IRibbonControl control)
        /// </summary>
        public Func<bool> getVisible { get; set; }

        #endregion
    }

    public abstract class AbstractCommand : ICommand {
        #region Implementation of ICommand

        public string ControlId { get; protected internal set; }

        /// <summary>
        /// 写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        public abstract void WriteCallbackXml(XElement element);

        #endregion
    }
}