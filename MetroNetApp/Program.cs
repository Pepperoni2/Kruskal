using MetroNetApp.classes;
using Spectre.Console;

namespace MetroNetApp;

class Program
{
    static void Main(string[] args)
    {
        CityNetwork opticFiberNet = new();

        // 1. Add Buildings
        opticFiberNet.AddBuilding("City Hall");
        opticFiberNet.AddBuilding("Hospital");
        opticFiberNet.AddBuilding("Library");
        opticFiberNet.AddBuilding("Gym");
        opticFiberNet.AddBuilding("School");

        // 2. Add Potential Routes
        opticFiberNet.AddTrenchRoute("City Hall", "Hospital", 1200);
        opticFiberNet.AddTrenchRoute("City Hall", "Library", 500);
        opticFiberNet.AddTrenchRoute("Library", "Hospital", 900);
        opticFiberNet.AddTrenchRoute("Gym", "School", 200);
        opticFiberNet.AddTrenchRoute("School", "Library", 400);
        opticFiberNet.AddTrenchRoute("City Hall", "Gym", 100);


        // 3. Run algorithm
        List<TrenchRoute> finalPlan = opticFiberNet.CalculateOptimalNetwork();

        // =================================
        // SPECTRE.CONSOLE UI OUTPUT
        // =================================

        // Create header rule
        AnsiConsole.Write(
            new Rule("[bold cyan]METRO-NET FIBER OPTIC OPTIMAL PLAN[/]")
            .RuleStyle("cyan")
            .LeftJustified()
        );

        // Table for routes
        Table table = new();
        table.Border(TableBorder.Rounded);

        // Columns
        table.AddColumn("[bold]Source Building[/]");
        table.AddColumn("[bold]Target Building[/]");
        table.AddColumn(new TableColumn("[bold]Distance[/]").RightAligned());

        float totalCable = 0;
        foreach (var f in finalPlan)
        {
            table.AddRow(
                $"[green]{f.Source.Name}[/]",
                $"[green]{f.Target.Name}[/]",
                $"[yellow]{f.Distance}[/]"
            );
            totalCable += f.Distance;
        }

        // Render table
        AnsiConsole.Write(table);
        
        // Print final summary
        var summaryPanel = new Panel($"Total Cabel Required: [bold yellow]{totalCable / 1000} km[/]");
        summaryPanel.BorderColor(Color.Green);
        summaryPanel.Header = new PanelHeader("[bold]Summary[/]");

        AnsiConsole.Write(summaryPanel);
    }
}
