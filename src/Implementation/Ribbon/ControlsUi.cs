using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Core.Contract.Control.Box;
using AddinX.Core.Contract.Control.Button;
using AddinX.Core.Contract.Control.ButtonGroup;
using AddinX.Core.Contract.Control.ButtonItem;
using AddinX.Core.Contract.Control.CheckBox;
using AddinX.Core.Contract.Control.ComboBox;
using AddinX.Core.Contract.Control.DialogBoxLauncher;
using AddinX.Core.Contract.Control.DropDown;
using AddinX.Core.Contract.Control.EditBox;
using AddinX.Core.Contract.Control.Gallery;
using AddinX.Core.Contract.Control.Label;
using AddinX.Core.Contract.Control.Menu;
using AddinX.Core.Contract.Control.MenuSeparator;
using AddinX.Core.Contract.Control.Separator;
using AddinX.Core.Contract.Control.ToggleButton;
using AddinX.Core.Contract.Control.ToggleButtonItem;
using AddinX.Core.Contract.Ribbon.Group;
using AddinX.Core.Implementation.Control;

namespace AddinX.Core.Implementation.Ribbon
{
    public class ControlsUi : AddInList, IGroupControlsUi, IGalleryControlsUi, IMenuControlsUi,
        IGroupDialogBox, IButtonGroupControlsUi, IBoxControlsUi
    {
        private readonly IList<ControlUi> items;

        public ControlsUi()
        {
            items = new List<ControlUi>();
        }

        public IBoxUi AddBox()
        {
            var item = new BoxUi();
            items.Add(item);
            return item;
        }

        public IButtonIdUi AddBouton(string label)
        {
            var item = new ButtonUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IButtonItemIdUi IMenuControlsUi.AddBouton(string label)
        {
            var item = new ButtonItemUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        public ICheckboxIdUi AddCheckbox(string label)
        {
            var item = new CheckboxUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IToggleButtonItemIdUi IMenuControlsUi.AddToggleButton(string label)
        {
            var item = new ToggleButtonItemUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        public IEditBoxIdUi AddEditbox(string label)
        {
            var item = new EditBoxUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        public ILabelControlIdUi AddLabelControl()
        {
            var item = new LabelControlUi();
            items.Add(item);
            return item;
        }

        public ISeparatorIdUi AddSeparator()
        {
            var item = new SeparatorUi();
            items.Add(item);
            return item;
        }

        public IToggleButtonIdUi AddToggleButton(string label)
        {
            var item = new ToggleButtonUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        public IComboBoxIdUi AddComboBox(string label)
        {
            var item = new ComboBoxUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        public IDropDownIdUi AddDropDown(string label)
        {
            var item = new DropDowUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        public IGalleryIdUi AddGallery(string label)
        {
            var item = new GalleryUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        public IMenuIdUi AddMenu(string label)
        {
            var item = new MenuUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        public IButtonGroupUi AddButtonGroup()
        {
            var item = new ButtonGroupUi();
            items.Add(item);
            return item;
        }

        public IMenuSeparatorIdUi AddSeparator(string title)
        {
            var item = new MenuSeparatorUi();
            item.SetLabel(title);
            items.Add(item);
            return item;
        }

        protected internal override XElement[] ToXml(XNamespace ns)
        {
            if (items == null || !items.Any())
            {
                return null;
            }
            return items.Select(o => o.ToXml(ns)).ToArray();
        }

        public IDialogBoxLauncherIdUi AddDialogBoxLauncher()
        {
            var item = new DialogBoxLauncherUi();
            items.Add(item);
            return item;
        }

        IButtonItemIdUi IGalleryControlsUi.AddBouton(string label)
        {
            var item = new ButtonItemUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }
    }
}