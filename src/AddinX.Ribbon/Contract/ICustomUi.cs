using AddinX.Ribbon.Contract.Ribbon;

namespace AddinX.Ribbon.Contract {
    public interface ICustomUi {
        IRibbon Ribbon { get; }

        ICustomUi AddNamespace(string letter, string privateNamespace);
    }
}