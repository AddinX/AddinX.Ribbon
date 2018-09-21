using AddinX.Ribbon.Implementation;
using AddinX.Ribbon.Implementation.Control;
using System;

namespace AddinX.Ribbon.Tests {
    class BuilderTests {
        public void Build() {
            var builder = new RibbonBuilder();
            var btn = new Button().Supertip("test").ShowLabel().Description("test button").NoImage().SetId("test_btn");
            new RibbonBuilder().CustomUi.Ribbon.Tabs(
                c => c.AddTab("test").SetId("item1")
                    .Groups(g1 => g1.AddGroup("group").SetId("id")
                        .Items(g => g.AddButton("b")
                            .Callback(cb=>cb.OnAction(
                                () => { Console.WriteLine("Test Button"); }
                        )))));
        }
    }
}