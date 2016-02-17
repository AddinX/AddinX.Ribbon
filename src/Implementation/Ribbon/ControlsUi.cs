using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Core.Contract.Control.Box;
using AddinX.Core.Contract.Control.Button;
using AddinX.Core.Contract.Control.ButtonGroup;
using AddinX.Core.Contract.Control.ButtonUnsize;
using AddinX.Core.Contract.Control.CheckBox;
using AddinX.Core.Contract.Control.ComboBox;
using AddinX.Core.Contract.Control.DialogBoxLauncher;
using AddinX.Core.Contract.Control.DropDown;
using AddinX.Core.Contract.Control.EditBox;
using AddinX.Core.Contract.Control.Gallery;
using AddinX.Core.Contract.Control.GalleryUnsize;
using AddinX.Core.Contract.Control.Label;
using AddinX.Core.Contract.Control.Menu;
using AddinX.Core.Contract.Control.MenuSeparator;
using AddinX.Core.Contract.Control.MenuUnsize;
using AddinX.Core.Contract.Control.Separator;
using AddinX.Core.Contract.Control.ToggleButton;
using AddinX.Core.Contract.Control.ToggleButtonUnsize;
using AddinX.Core.Contract.Ribbon.Group;
using AddinX.Core.Implementation.Control;

namespace AddinX.Core.Implementation.Ribbon
{
    public class ControlsUi : AddInList, IGroupControlsUi, IGalleryControlsUi, IMenuControlsUi
        , IDropDownControlsUi, IGalleryUnsizeControlsUi, IMenuUnsizeControlsUi,
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

        public IButtonIdUi AddButton(string label)
        {
            var item = new ButtonUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IToggleButtonUnsizeIdUi IButtonGroupControlsUi.AddToggleButton(string label)
        {
            var item = new ToggleButtonUnsizeUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IGalleryUnsizeIdUi IMenuUnsizeControlsUi.AddGallery(string label)
        {
            var item = new GalleryUnsizeUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IMenuUnsizeIdUi IButtonGroupControlsUi.AddMenu(string label)
        {
            var item = new MenuUnsizeUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IMenuUnsizeIdUi IMenuUnsizeControlsUi.AddMenu(string label)
        {
            var item = new MenuUnsizeUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IMenuUnsizeIdUi IMenuControlsUi.AddMenu(string label)
        {
            var item = new MenuUnsizeUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }


        IToggleButtonUnsizeIdUi IMenuUnsizeControlsUi.AddToggleButton(string label)
        {
            var item = new ToggleButtonUnsizeUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IGalleryUnsizeIdUi IButtonGroupControlsUi.AddGallery(string label)
        {
            var item = new GalleryUnsizeUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IButtonUnsizeIdUi IMenuControlsUi.AddButton(string label)
        {
            var item = new ButtonUnsizeUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IButtonUnsizeIdUi IMenuUnsizeControlsUi.AddButton(string label)
        {
            var item = new ButtonUnsizeUi();
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

        IButtonUnsizeIdUi IButtonGroupControlsUi.AddButton(string label)
        {
            var item = new ButtonUnsizeUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IToggleButtonUnsizeIdUi IMenuControlsUi.AddToggleButton(string label)
        {
            var item = new ToggleButtonUnsizeUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IGalleryUnsizeIdUi IMenuControlsUi.AddGallery(string label)
        {
            var item = new GalleryUnsizeUi();
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

        IButtonUnsizeIdUi IGalleryControlsUi.AddButton(string label)
        {
            var item = new ButtonUnsizeUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IButtonUnsizeIdUi IDropDownControlsUi.AddButton(string label)
        {
            var item = new ButtonUnsizeUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IButtonUnsizeIdUi IGalleryUnsizeControlsUi.AddButton(string label)
        {
            var item = new ButtonUnsizeUi();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }
    }
}