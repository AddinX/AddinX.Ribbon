namespace AddinX.Ribbon.Contract.Control
{
    public interface IElementId {
        IElementId SetId(string name);

        IElementId SetMicrosoftId(string name);

        IElementId SetNamespaceId(string namespaceKey, string name);

        string Id { get; }
}
}