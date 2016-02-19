using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control.Box;
using AddinX.Ribbon.Contract.Control.Button;
using AddinX.Ribbon.Contract.Control.ButtonGroup;
using AddinX.Ribbon.Contract.Control.ButtonUnsize;
using AddinX.Ribbon.Contract.Control.CheckBox;
using AddinX.Ribbon.Contract.Control.ComboBox;
using AddinX.Ribbon.Contract.Control.DialogBoxLauncher;
using AddinX.Ribbon.Contract.Control.DropDown;
using AddinX.Ribbon.Contract.Control.EditBox;
using AddinX.Ribbon.Contract.Control.Gallery;
using AddinX.Ribbon.Contract.Control.GalleryUnsize;
using AddinX.Ribbon.Contract.Control.Label;
using AddinX.Ribbon.Contract.Control.Menu;
using AddinX.Ribbon.Contract.Control.MenuSeparator;
using AddinX.Ribbon.Contract.Control.MenuUnsize;
using AddinX.Ribbon.Contract.Control.Separator;
using AddinX.Ribbon.Contract.Control.ToggleButton;
using AddinX.Ribbon.Contract.Control.ToggleButtonUnsize;
using AddinX.Ribbon.Contract.Ribbon.Group;
using AddinX.Ribbon.Implementation.Control;

namespace AddinX.Ribbon.Implementation.Ribbon
{
    public class Controls : AddInList, IGroupControls, IGalleryControls, IMenuControls
        , IDropDownControls, IGalleryUnsizeControls, IMenuUnsizeControls,
        IGroupDialogBox, IButtonGroupControls, IBoxControls
    {
        private readonly IList<Control.Control> items;

        public Controls()
        {
            items = new List<Control.Control>();
        }

        public IBoxId AddBox()
        {
            var item = new Box();
            items.Add(item);
            return item;
        }
        
        public IButtonId AddButton(string label)
        {
            var item = new Button();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IToggleButtonUnsizeId IButtonGroupControls.AddToggleButton(string label)
        {
            var item = new ToggleButtonUnsize();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IGalleryUnsizeId IMenuUnsizeControls.AddGallery(string label)
        {
            var item = new GalleryUnsize();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IMenuUnsizeId IButtonGroupControls.AddMenu(string label)
        {
            var item = new MenuUnsize();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }
        
        IMenuUnsizeId IMenuUnsizeControls.AddMenu(string label)
        {
            var item = new MenuUnsize();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IMenuUnsizeId IMenuControls.AddMenu(string label)
        {
            var item = new MenuUnsize();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }


        IToggleButtonUnsizeId IMenuUnsizeControls.AddToggleButton(string label)
        {
            var item = new ToggleButtonUnsize();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IGalleryUnsizeId IButtonGroupControls.AddGallery(string label)
        {
            var item = new GalleryUnsize();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IButtonUnsizeId IMenuControls.AddButton(string label)
        {
            var item = new ButtonUnsize();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IButtonUnsizeId IMenuUnsizeControls.AddButton(string label)
        {
            var item = new ButtonUnsize();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        public ICheckboxId AddCheckbox(string label)
        {
            var item = new Checkbox();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IButtonUnsizeId IButtonGroupControls.AddButton(string label)
        {
            var item = new ButtonUnsize();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IToggleButtonUnsizeId IMenuControls.AddToggleButton(string label)
        {
            var item = new ToggleButtonUnsize();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IGalleryUnsizeId IMenuControls.AddGallery(string label)
        {
            var item = new GalleryUnsize();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        public IEditBoxId AddEditbox(string label)
        {
            var item = new EditBox();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        public ILabelControlId AddLabelControl()
        {
            var item = new LabelControl();
            items.Add(item);
            return item;
        }

        public ISeparatorId AddSeparator()
        {
            var item = new Separator();
            items.Add(item);
            return item;
        }

        public IToggleButtonId AddToggleButton(string label)
        {
            var item = new ToggleButton();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        public IComboBoxId AddComboBox(string label)
        {
            var item = new ComboBox();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        public IDropDownId AddDropDown(string label)
        {
            var item = new DropDow();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        public IGalleryId AddGallery(string label)
        {
            var item = new Gallery();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        public IMenuId AddMenu(string label)
        {
            var item = new Menu();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        public IButtonGroupId AddButtonGroup()
        {
            var item = new ButtonGroup();
            items.Add(item);
            return item;
        }

        public IMenuSeparatorId AddSeparator(string title)
        {
            var item = new MenuSeparator();
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

        public IDialogBoxLauncherId AddDialogBoxLauncher()
        {
            var item = new DialogBoxLauncher();
            items.Add(item);
            return item;
        }

        IButtonUnsizeId IGalleryControls.AddButton(string label)
        {
            var item = new ButtonUnsize();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IButtonUnsizeId IDropDownControls.AddButton(string label)
        {
            var item = new ButtonUnsize();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }

        IButtonUnsizeId IGalleryUnsizeControls.AddButton(string label)
        {
            var item = new ButtonUnsize();
            item.SetLabel(label);
            items.Add(item);
            return item;
        }
    }
}