using AddinX.Core.Contract.Control;

namespace AddinX.Core.Implementation.Control
{
    public abstract class ControlUi : AddInElement
    {
        protected internal IElementId Id { get; protected set; }
        protected internal string Label { get; set; }
    }
}