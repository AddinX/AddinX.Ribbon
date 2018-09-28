using AddinX.Ribbon.Contract.Control.ButtonUnsize;

namespace AddinX.Ribbon.Implementation.Control {
    public class ButtonUnsize : Control<IButtonUnsize>, IButtonUnsize {
        public ButtonUnsize() : base("button") {
            NoImage();
        }

        protected override IButtonUnsize Interface => this;
    }
}