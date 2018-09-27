using System;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Control.Menu;
using AddinX.Ribbon.Contract.Enums;
using AddinX.Ribbon.Implementation.Command;
using AddinX.Ribbon.Implementation.Ribbon;

namespace AddinX.Ribbon.Implementation.Control {
    public class Menu : ControlContainer<IMenu,Controls>, IMenu {

        public Menu(): base( "menu") {
            NoImage();
        }

        public IMenu AddItems(Action<IMenuControls> items) {
            items.Invoke(Items);
            return this;
        }

        #region Implementation of IRibbonCallback<out IMenu,out IMenuCommand>

        public void Callback(Action<IMenuCommand> builder) {
            builder(GetCommand<MenuCommand>());
        }

        #endregion

        #region Overrides of Control<IMenu>

        protected override IMenu Interface => this;

        #endregion

        #region Implementation of IRibbonCallback<out IMenu,IMenuCommand>

        public void Callback(IMenuCommand command) {
            base.SetCommand(command);
        }

        #endregion
    }
}