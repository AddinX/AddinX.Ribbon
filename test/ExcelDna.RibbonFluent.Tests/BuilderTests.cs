using System;
using System.Collections.Generic;
using System.Diagnostics;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.Contract.Command.Field;
using AddinX.Ribbon.Contract.Control;
using AddinX.Ribbon.Contract.Ribbon.Group;
using AddinX.Ribbon.Implementation;
using AddinX.Ribbon.Implementation.Command;
using AddinX.Ribbon.Implementation.Control;
using NUnit.Framework;

namespace ExcelDna.RibbonFluent.Tests {
    internal class BuilderTests {
        private IRibbonBuilder BuildInGroup(Action<IGroupControls> buildAction) {
            var builder = new RibbonBuilder();
            builder.CustomUi.Ribbon.Tabs(
                c => c.AddTab("test").Id("item1")
                    .Groups(g1 => g1.AddGroup("group").Id("id")
                        .Items(buildAction)));
            return builder;
        }

        [Test]
        public void BuildButton() {
            var builder = new RibbonBuilder();
            var btn = new Button().Supertip("test").ShowLabel().Description("test button").NoImage()
                .Id("test_btn");

            btn.Callback(cmd => {
                cmd.OnAction(() => Console.WriteLine("test"));
                cmd.GetLabel(() => "Test Button");
            });

            builder.CustomUi.Ribbon.Tabs(
                c => c.AddTab("test")
                    .Groups(g1 => g1.AddGroup("group").Items(g => g.AddButton("b")
                        .Callback(cb => cb.OnAction(() =>Console.WriteLine("Test Button"))
                        .GetEnabled(() => true).GetLabel(()=>"Button Callback")))));
            Console.WriteLine(builder.GetXmlString());
        }

        [Test]
        public void TestOrderInRibbonXml() {
            var _startMeasureCommand = new ToggleButtonCommand();
            var callbacks = new CallbackRegsMock();
            var builder = new RibbonBuilder(){CallbackRigister = callbacks};
            builder.CustomUi.Ribbon.Tabs(ts => ts.AddTab("测量管理工具")
                .Groups(g => g.AddGroup("测量管理工具")
                    .Items(items => {
                        //<toggleButton id="Id_StartMeasuring" description="开始测量" getLabel="GetLabel" getPressed = "GetPressed" size = "large" onAction = "OnToggleButtonAction" getImage = "GetImage" getEnabled = "GetEnabled" />
                            items.AddToggleButton("开始测量").LargeSize().Callback(_startMeasureCommand);
                            items.AddSeparator();
                            items.AddCheckbox("跟踪测量单元格")
                                .Supertip("如果选中此项，在测量时会选中正在进行的 测量数据单元格,用来指示当前测量的位置")
                                .Callback(chk => chk.GetChecked(() => true).OnChecked(b => Console.WriteLine("跟踪测量单元格" + b)));
                            //<toggleButton id="Id_SpeechValue" imageMso="SpeakCells" label = "语音报读" supertip = "选中此项，会朗读测量读数，需要系统语音支持" onAction = "OnToggleButtonAction"getPressed = "GetPressed" />
                            items.AddToggleButton("语音报读").Supertip("选中此项，会朗读测量读数，需要系统语音支持").Callback(t => t.OnPressed((b) => Console.WriteLine(t.ControlId + " " + b)));
                            //button id="SetMeasureValuesRange" label="测量数据区域" imageMso="ImportSharePointList" supertip = "设置当前工作表的数据采集区域" onAction = "OnButtonAction" getEnabled = "GetEnabled" />
                            items.AddButton("测量数据区域").ImageMso("ImportSharePointList").Supertip("设置当前工作表的数据采集区域")
                                .Callback(t => t.OnAction(() => Console.WriteLine($"{t.ControlId} Action")));    
                        }
                    )));
            Console.WriteLine(builder.GetXmlString());
            TestCallback(callbacks.Commands);
        }

        private void TestCallback(IEnumerable<ICommand> commands) {
            foreach (var command in commands) {
                if (command is IActionField actionField) {
                    actionField.onAction?.Invoke();
                }else if (command is IActionPressedField pressed) {
                    pressed.onActionPressed?.Invoke(true);
                }

            }

        }

        [Test]
        public void BuildCheckBox() {
            var builder = new RibbonBuilder();
            builder.CustomUi.Ribbon.Tabs(
                c => c.AddTab("test").Id("item1")
                    .Groups(g1 => g1.AddGroup("group").Id("id")
                        .Items(g => g.AddCheckbox("checkbox")
                            .Callback(cb =>
                                cb.OnChecked(b => { Console.WriteLine("Test Checkbox press:" + b); }
                                )))));
            Console.WriteLine(builder.GetXmlString());
        }

        [Test]
        public void BuildCombox() {
            var builder = BuildInGroup(i => {
                i.AddComboBox("Colors").Id("colorsPicking")
                    .ShowLabel().NoImage()
                    .Items(o => {
                        o.AddItem("Green").Id("greenColor");
                        o.AddItem("Red").Id("redColor").NoImage();
                        o.AddItem("Blue").Id("blueColor").NoImage();
                    }).Supertip("Color Picking")
                    .MaxLength(15).SizeString(15);
            });

            Console.WriteLine(builder.GetXmlString());
        }

        [Test]
        public void TestAddControl() {
            var builder = new RibbonBuilder();
            builder.CustomUi.Ribbon.Tabs(t => t.AddTab("table")
                .Groups(g => g.AddGroup("group1").Items(gc=>gc.AddButton("测试"))
                )
            );
        }

        [Test]
        public void TestGalleiesAndMenu() {
        const string HappyButtonId = "HappyButton1";
        const string ShowNumberId = "ShowNumberId1";
        const string HappyButtonId2 = "HappyButton2";
        const string ShowNumberId2 = "ShowNumberId2";
        const string MyTabId = "MyTabId";
        const string DataGroupId = "DataGroupId";
        const string OptionId = "OptionId";
        const string GalleryId = "GalleryId";
        const string DynamicGalleryId = "DynamicGalleryId";
        const string ButtonMore = "buttonMoreId";

        var builder = new RibbonBuilder();
            builder.CustomUi.Ribbon.Tabs(c => {
                c.AddTab("My Tab").Id(MyTabId)
                    .Groups(g => {
                        g.AddGroup("Data").Id(DataGroupId)
                            .Items(d => {
                                d.AddMenu("Option").Id(OptionId).ShowLabel()
                                    .ImageMso("FileNew").LargeSize()
                                    .ItemLargeSize().Items(
                                        v => {
                                            v.AddCheckbox("Show numbers").Id(ShowNumberId);
                                            v.AddSeparator().SetTitle("Mood");
                                            v.AddButton("Happy")
                                                .Id(HappyButtonId)
                                                .ImageMso("HappyFace");
                                            v.AddGallery("Dynamic Option").Id(DynamicGalleryId)
                                                .ShowLabel().NoImage().ShowItemLabel().ShowItemImage()
                                                //.DynamicItems()
                                                .Buttons(b => b.AddButton("Button...").Id(ButtonMore))
                                                .NumberRows(6).NumberColumns(1);
                                        });
                                d.AddGallery("Multi Option").Id(GalleryId)
                                    .ShowLabel().LargeSize().NoImage().ShowItemLabel().ShowItemImage()
                                    .Items(v => {
                                        v.AddItem("Show numbers").Id(ShowNumberId2);
                                        v.AddItem("Happy").Id(HappyButtonId2).ImageMso("HappyFace");
                                    });
                            });
                    });
            });

            var str = builder.GetXmlString();
            Console.WriteLine(str);

            Assert.True(ValidateHelper.Validate(str));
        }
    }

    public class CallbackRegsMock : ICallbackRigister {
        private readonly IDictionary<string, ICommand> _commands = new SortedDictionary<string, ICommand>();

        public IEnumerable<ICommand> Commands {
            get { return _commands.Values; }
        }

        #region Implementation of ICallbackRigister
        /// <summary>
        /// 注册命令
        /// </summary>
        /// <param name="elementId"></param>
        /// <param name="command"></param>
        public void Add(IElementId elementId, ICommand command) {
            Debug.WriteLine("Add Command {0} {1}", elementId, command.GetType());
            if (_commands.ContainsKey(elementId.Value)) {
                _commands[elementId.Value] = command;
            } else {
                _commands.Add(elementId.Value, command);
            }
        }

        /// <summary>
        /// 注册命令
        /// </summary>
        /// <param name="elementId"></param>
        /// <param name="command"></param>
        public void Add(string elementId, ICommand command) {
            Debug.WriteLine("Add Command {0} {1}", elementId, command.GetType());
            if (_commands.ContainsKey(elementId)) {
                _commands[elementId] = command;
            } else {
                _commands.Add(elementId, command);
            }
        }

        public ICommand Find(string id) {
            return !_commands.Keys.Contains(id)
                ? null
                : _commands[id];
        }

        #endregion
    }
}