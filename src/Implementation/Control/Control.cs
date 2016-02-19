using AddinX.Ribbon.Contract.Control;

namespace AddinX.Ribbon.Implementation.Control
{
    public abstract class Control : AddInElement
    {
        protected internal IElementId Id { get; protected set; }
        protected internal string Label { get; set; }
    }
}