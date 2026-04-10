using MetroNetApp.classes;

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

        // 2. Add Potential Routes
        opticFiberNet.AddTrenchRoute("City Hall", "Hospital", 1200);
        opticFiberNet.AddTrenchRoute("City Hall", "Library", 500);
        opticFiberNet.AddTrenchRoute("Library", "Hospital", 900);

        // 3. Run algorithm
        List<TrenchRoute> finalPlan = opticFiberNet.CalculateOptimalNetwork();

        // 4. Output results
        Console.WriteLine("=== METRO-NET FIBER OPTIC OPTIMAL PLAN ===");
        float totalCable = 0;
        foreach (var f in finalPlan)
        {
            Console.WriteLine($"Link: {f.Source.Name} <-> {f.Target.Name} | Distance: {f.Distance}m");
            totalCable += f.Distance;
        }
        Console.WriteLine("==========================================");
        Console.WriteLine($"Total Cable Required: {totalCable / 1000} km");
    }
}
