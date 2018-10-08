using System;
using System.Drawing;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;

namespace AddinX.Ribbon.Implementation.Command {
    public class ToggleButtonCommand : ButtonRegularCommand<IToggleButtonCommand>, IToggleButtonCommand, IActionPressedField, IPressedField{
    #region Implementation of ICommand

        protected override IToggleButtonCommand Interface => this;

        /// <summary>
        ///     写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        protected internal override void WriteXml(XElement element) {
            base.WriteXml(element);
            element.AddCallbackAttribute("onAction", "OnActionPressed", onActionPressed);
            element.AddCallbackAttribute("getPressed", getPressed);
        }

        #endregion

        #region Implementation of IToggleButtonCommand

        public IToggleButtonCommand OnPressed(Action<bool> pressed) {
            onActionPressed = pressed;
            return this;
        }

        public IToggleButtonCommand GetPressed(Func<bool> pressedFunc) {
            getPressed = pressedFunc;
            return this;
        }

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

        #region Implementation of IPressedField

        /// <summary>
        /// getPressed
        /// 回调
        /// VBA：Sub GetPressed(control As IRibbonControl, ByRef returnedVal)
        /// C#：bool GetPressed(IRibbonControl control)
        /// </summary>
        public Func<bool> getPressed { get; set; }

        #endregion
    }

    public abstract class ButtonRegularCommand<T> : ControlCommand<T>, IButtonRegularCommand<T>, 
        ILabelField, IDescriptionField, IEnabledField, IImageField,
        IVisibleField  where T:ICommand{

        #region Implementation of ICommand

        /// <summary>
        /// 写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        protected internal override void WriteXml(XElement element) {
            base.WriteXml(element);
            //element.AddCallbackAttribute("getImage", getImage);
            //element.AddCallbackAttribute("getDescription", getDescription);
            AddGetImage(element,getImage);
            AddGetDescription(element, getDescription);
        }

        #endregion

        #region Implementation of IImageField

        public Func<Image> getImage { get; set; }

        #endregion

        #region Implementation of IDescriptionField

        public Func<string> getDescription { get; set; }

        #endregion

        #region Implementation of IButtonRegularCommand<out T>



        public T GetImage(Func<Image> imageFunc) {
            getImage = imageFunc;
            return Interface;
        }

        public T GetDescription(Func<string> descriptionFunc) {
            getDescription = descriptionFunc;
            return Interface;
        }

        #endregion
    }


    public abstract class ControlCommand<T> : AbstractCommand,IControlCommand<T>,
        IEnabledField,IVisibleField,ILabelField where T:ICommand {

        protected abstract T Interface { get; }

        /// <summary>
        /// 写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        protected internal override void WriteXml(XElement element) {
            AddGetEnabled(element, getEnabled);
            AddGetVisible(element, getVisible);
            AddGetLabel(element,getLabel);
            //element.AddCallbackAttribute("getEnabled",getEnabled);
            //element.AddCallbackAttribute("getVisible", getVisible);
            //element.AddCallbackAttribute("getLabel", getLabel);
        }

        #region Implementation of IControlCommand<out T>

        public T GetVisible(Func<bool> visibleFunc) {
            getVisible = visibleFunc;
            return Interface;
        }

        public T GetLabel(Func<string> labelFunc) {
            getLabel = labelFunc;
            return Interface;
        }

        public T GetEnabled(Func<bool> enabledFunc) {
            getEnabled = enabledFunc;
            return Interface;
        }

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

        #region Implementation of ILabelField

        /// <summary>
        /// getLabel
        /// 回调
        /// VBA：Sub GetLabel(control As IRibbonControl, ByRef returnedVal)
        /// C#：string GetLabel(IRibbonControl control)
        /// </summary>
        public Func<string> getLabel { get; set; }

        #endregion

        #region Implementation of IEnabledField

        /// <summary>
        /// getEnabled
        /// 回调
        /// VBA：Sub GetEnabled(control As IRibbonControl, ByRef returnedVal)
        /// C#：bool GetEnabled(IRibbonControl control)
        /// </summary>
        public Func<bool> getEnabled { get; set; }

        #endregion
    }
}