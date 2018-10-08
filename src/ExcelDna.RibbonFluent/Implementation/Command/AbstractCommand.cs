using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Command {
    /// <summary>
    /// 抽象命令,用于更新 <see cref="ControlId"/>
    /// </summary>
    public abstract partial class AbstractCommand : ICommand {


        #region Implementation of ICommand

        public string ControlId { get; protected internal set; }

        /// <summary>
        /// 写入回调Xml属性
        /// </summary>
        /// <param name="element"></param>
        protected internal abstract void WriteXml(XElement element);

        #endregion

        protected void AddGetVisible(XElement element, object condition) {
            if (condition != null) {
                element.Attribute(AttrNames.visible)?.Remove();
                element.AddAttribute(CallbackNames.getVisible,nameof(IRibbonFluentCallback.GetVisible));
            }
        }

        protected void AddOnAction(XElement element, object condition) {
            if (condition != null) {
                element.AddAttribute(CallbackNames.onAction, nameof(IRibbonFluentCallback.OnAction));
            }
        }

        protected void AddOnActionPressed(XElement element, object condition) {
            if (condition != null) {
                element.AddAttribute(CallbackNames.onAction, nameof(IRibbonFluentCallback.OnActionPressed));
            }
        }

        protected void AddOnChange(XElement element, object condition) {
            if (condition != null) {
                element.AddAttribute(CallbackNames.onChange, nameof(IRibbonFluentCallback.OnChange));
            }
        }

        protected void AddGetPressed(XElement element, object condition) {
            if (condition != null) {
                element.AddAttribute(CallbackNames.getPressed, nameof(IRibbonFluentCallback.GetPressed));
            }
        }

        protected void AddGetText(XElement element, object condition) {
            if (condition != null) {
                element.Attribute(AttrNames.text)?.Remove();
                element.AddAttribute(CallbackNames.getText, nameof(IRibbonFluentCallback.GetText));
            }
        }

        protected void AddGetImage(XElement element, object condition) {
            if (condition != null) {
                element.Attribute(AttrNames.image)?.Remove();
                element.Attribute(AttrNames.imageMso)?.Remove();
                element.AddAttribute(CallbackNames.getImage,nameof(IRibbonFluentCallback.GetImage));
            }
        }

        protected void AddGetLabel(XElement element, object condition) {
            if (condition != null) {
                element.Attribute(AttrNames.label)?.Remove();
                element.AddAttribute(CallbackNames.getLabel, nameof(IRibbonFluentCallback.GetLabel));
            }
        }

        protected void AddGetDescription(XElement element, object condition) {
            if (condition != null) {
                element.Attribute(AttrNames.description)?.Remove();
                element.AddAttribute(CallbackNames.getDescription, nameof(IRibbonFluentCallback.GetDescription));
            }
        }

        protected void AddGetEnabled(XElement element, object condition) {
            if (condition != null) {
                element.Attribute(AttrNames.enable)?.Remove();
                element.AddAttribute(CallbackNames.getEnabled, nameof(IRibbonFluentCallback.GetEnabled));
            }
        }

        protected void AddGetSize(XElement element, object condition) {
            if (condition != null) {
                element.Attribute(AttrNames.size)?.Remove();
                element.AddAttribute(CallbackNames.getSize, nameof(IRibbonFluentCallback.GetSize));
            }
        }

        protected void AddGetItemCount(XElement element, object condition) {
            if (condition != null) {
                element.AddAttribute(CallbackNames.getItemCount , nameof(IRibbonFluentCallback.GetItemCount));
            }
        }
        protected void AddGetItemID(XElement element, object condition) {
            if (condition != null) {
                element.AddAttribute(CallbackNames.getItemID , nameof(IRibbonFluentCallback.GetItemId));
            }
        }
        protected void AddGetItemImage(XElement element, object condition) {
            if (condition != null) {
                element.AddAttribute(CallbackNames.getItemImage , nameof(IRibbonFluentCallback.GetItemImage));
            }
        }
        protected void AddGetItemLabel(XElement element, object condition) {
            if (condition != null) {
                element.AddAttribute(CallbackNames.getItemLabel , nameof(IRibbonFluentCallback.GetItemLabel));
            }
        }
        protected void AddGetItemScreentip(XElement element, object condition) {
            if (condition != null) {
                element.AddAttribute(CallbackNames.getItemScreentip , nameof(IRibbonFluentCallback.GetItemScreentip));
            }
        }
        protected void AddGetItemSupertip(XElement element, object condition) {
            if (condition != null) {
                element.AddAttribute(CallbackNames.getItemSupertip , nameof(IRibbonFluentCallback.GetItemSupertip));
            }
        }

        protected void AddOnItemAction(XElement element, object condition) {
            if (condition != null) {
                element.AddAttribute(CallbackNames.onAction, nameof(IRibbonFluentCallback.OnItemAction));
            }
        }
        protected void AddGetSelectedItemIndex(XElement element, object condition) {
            if (condition != null) {
                element.AddAttribute(CallbackNames.getSelectedItemIndex, nameof(IRibbonFluentCallback.GetSelectedItemIndex));
            }
        }
    }
}