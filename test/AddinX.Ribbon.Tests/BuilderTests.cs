using AddinX.Ribbon.Implementation;
using AddinX.Ribbon.Implementation.Control;
using System;
using NUnit.Framework;

namespace AddinX.Ribbon.Tests {
    class BuilderTests {
        [Test]
        public void BuildButton() {
            var btn = new Button().Supertip("test").ShowLabel().Description("test button").NoImage().SetId("test_btn");
            var builder = new RibbonBuilder();
                builder.CustomUi.Ribbon.Tabs(
                c => c.AddTab("test").SetId("item1")
                    .Groups(g1 => g1.AddGroup("group").SetId("id")
                        .Items(g => g.AddButton("b").OnAction(
                            () => { Console.WriteLine("Test Button"); }
                        ))));
            Console.WriteLine(builder.GetXmlString());
        }

        [Test]
        public void BuildCheckBox() {
            var btn = new Button().Supertip("test").ShowLabel().Description("test button").NoImage().SetId("test_btn");
            var builder = new RibbonBuilder();
            builder.CustomUi.Ribbon.Tabs(
                c => c.AddTab("test").SetId("item1")
                    .Groups(g1 => g1.AddGroup("group").SetId("id")
                        .Items(g => g.AddCheckbox("checkbox").OnAction(
                            (b) => { Console.WriteLine("Test Checkbox press:"+b); }
                        ))));
            Console.WriteLine(builder.GetXmlString());
        }
    }
}