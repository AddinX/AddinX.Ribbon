# AddinX.Ribbon

Fluent ribbon builder for Excel add-in (using Excel-DNA)

Visit our online documentation at http://addinx.github.io

## Retrieve the Nuget packages

Run the following command to install the fluent ribbon for Excel-DNA. It will also install Excel-DNA for you.
You will need to get **NetOffice** as we are using it instead of **Office.Interop.Excel** to manipulate the Excel application.

```
PM> Install-Package AddinX.Ribbon.ExcelDna
PM> Install-Package NetOffice.Excel -Version 1.7.3
```

## The AddInContext class

In a new class project, create a static class named ***AddinContext*** that will keep the objects that you want to be unique in the application like Excel application instance, logger, an inversion of control container or a token cancellation. It will also be easier to dispose them when Excel closes

```
    public static class AddinContext
    {
        public static Application ExcelApp { get; set; }
    }
```

> We have a reference to <b>NetOffice.ExcelApi;</b>



## The starting class

Name the starting class ***Program*** and it needs to be inheriting from  ***IExcelAddIn*** (ExcelDna.Integration).
Only the method *AutoOpen* need to be filled.

In the *AutoOpen* method we will instantiate the unique instance of the Excel application from the *AddinContext* created above.

```
    public class Program : IExcelAddIn
    {
        public void AutoOpen()
        {
            // The Excel Application object
            AddinContext.ExcelApp = new Application(null, ExcelDnaUtil.Application);
        }

        public void AutoClose()
        {
            throw new NotImplementedException();
        }
    }
```

## The ribbon class

Create a new class named ***Ribbon*** and it needs to be inheriting from  ***RibbonFluent*** (AddinX.Ribbon.ExcelDna).
This class must be **ComVisible** in order for Excel-DNA to use it.

The following inherited methods will be created:

* **CreateFluentRibbon** : This is where you will define the UI part of the ribbon.
* **CreateRibbonCommand** : This is where you will define the callbacks methods for the controls using the control's unique identifier.
* **OnClosing** : This is where you can dispose objects from the **AddinContext** class before Excel closes.
* **OnOpening** : This method is mainly used to listen to Excel's events

```
    [ComVisible(true)]
    public class Ribbon : RibbonFluent
    {
        protected override void CreateFluentRibbon(IRibbonBuilder build)
        {
        }

        protected override void CreateRibbonCommand(IRibbonCommands cmds)
        {
        }

        public override void OnClosing()
        {
        }

        public override void OnOpening()
        {
        }
    }
```

## Creating the first ribbon
 
We are going to create the first group with the 3 buttons from the above image.

 * Those three buttons are in the same group named "Reporting".
 * One of those buttons is large while the other two are smalls.
 * The first button is large and is named "Allocation" and use the Microsoft image "repeat".
 * The two others buttons are smalls and are respectively named "Contributor" and "Performance".
 * The button "Contribitors" don't have an image while the button "Performance" is using the Microsoft image "Bold".

We are going to see how to do it, it's quick and easy to do!!!

**Defining the unique Identifier**

Each of those elements have a unique identifier. It is important and mandatory to give them a unique “Id”. This way it is possible to associate the right event to the right control.

So we will create private properties in the class *Ribbon* for each identifier. This way it will be easy to link the right control with the events.

```
    private const string SampleTab = "sampleTab";
    private const string ReportingBox = "reportingBox";
    private const string ReportingGroup = "reportingGroup";	
    private const string PortfolioAllocationBtn = "allocationBtn";
    private const string PortfolioContributorBtn = "contributorBtn";
    private const string PortfolioPerformanceBtn = "performanceBtn";    
```

**Creating the new tab and group**

Inside the inherited method *CreateFluentRibbon*, we will define the UI part. We will start by adding a tab and a group in the ribbon.

```
	builder.CustomUi.Ribbon.Tabs(c =>
	{
		c.AddTab("Sample").SetId(TestTab)
		    .Groups(g =>
		    {
		        g.AddGroup("Reporting").SetId(ReportingGroup)
		            .Items(); 
		    });
	});
```

**Adding buttons to the group**

Then we will add the buttons. We will create one large button with a [Microsoft Office image](https://imagemso.codeplex.com/) and a box with two regular size button. 

To do so we will replace the code above *.Items()* by the below.

```
	.Items(d =>
	{
	    d.AddBouton("Allocation")
	        .SetId(PortfolioAllocationBtn)
	        .LargeSize()
	        .ImageMso("Repeat");

	    d.AddBox().SetId(ReportingBox)
	        .HorizontalDisplay()
	        .AddItems(i =>
	        {  
	            i.AddBouton("Contributor").SetId(PortfolioContributorBtn)
	                .NormalSize().NoImage().ShowLabel()
	                .Supertip("Portfolio best contributor")
	                .Screentip("Display the top / bottom X contributor of performance.");

	            i.AddBouton("Performance")
	               .SetId(PortfolioPerformanceBtn)
	               .NormalSize()
	               .ImageMso("Bold");

	        });
	});
```


> A <strong>screentip</strong> is a text that will be display when the control is hovered with the pointer of the mouse.  

> A <strong>supertip</strong> is a enhanced screentip.



## The callback events

After adding the elements that will be part of the ribbon, it is necessary to define the events commands for those elements. In other terms, define how those elements will behave. The most common events are **Enable** and **Visible**, those events can be defined for nearly any elements part of a ribbon.

* **Enable** is called to define if the control should be enabled or not.
* **Visible** is called to define what condition need to be meet to display a control or group of controls. 

Another important one is **Action** which is used to define the action that will be done when a control is clicked or selected.The elements are reference using them identifier defined during the creation of the ribbon.

The code that will be used to define those events is the following:

```
    protected override void CreateRibbonCommand(IRibbonCommands cmds)
    {
        // Reporting Group
        cmds.AddButtonCommand(PortfolioPerformanceBtn)
            .IsEnabled(() => AddinContext.ExcelApp.Worksheets.Count() > 2)
            .Action(() => MessageBox.Show("Performance button clicked"));

        cmds.AddButtonCommand(PortfolioContributorBtn)
            .Action(() => MessageBox.Show("To enable the Performance button you need to have 3 sheets."));

        cmds.AddButtonCommand(PortfolioAllocationBtn)
            .Action(() => MessageBox.Show("Add one more sheet"));

        cmds.AddBoxCommand(ReportingBox)
            .IsVisible(() => AddinContext.ExcelApp.Worksheets.Count() > 1);
    }
```

* When clicking on the button *Allocation* a message box will be display stating "Add one more sheet".
* Adding one more sheet will trigger the visibility condition for the box containing the two small buttons. The buttons will be visible if there is more than one sheet in the workbook.
* To enable the button *Performance*, it is necessary to add an extra sheet as the condition to enable that button is to have more than two sheets.
