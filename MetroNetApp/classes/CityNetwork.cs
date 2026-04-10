using DataStructureLibrary.Graph;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
namespace MetroNetApp.classes;

public class CityNetwork : Graph
{
    
    // Methods
    // ======================
    /// <summary>
    ///  AddBuilding acting as wrapper around generic AddVertex to make the method relevant to the class domain
    /// </summary>
    /// <param name="name"></param>
    /// <returns>Returning the added Vertex</returns>
    public Vertex AddBuilding(string name)
    {
        return AddVertex(name);
    }

    public void AddTrenchRoute(string buildingA, string buildingB, float distance)
    {
        // Find the Vertex Objects using the building names
        Vertex? v1 = HasVertex(buildingA);
        Vertex? v2 = HasVertex(buildingB);

        if( v1 == null || v2 == null) return;

        // Generate unique ID
        uint newId = (uint)_edges.Count;
        // Instantiate TrenchRoute using the two vertices
        TrenchRoute route = new(newId, v1, v2, distance);

        // Add TrenchRoute to the edge list
        AddEdge(route);
    }

    // Kruskal's Algorithm
    public List<TrenchRoute> CalculateOptimalNetwork()
    {
        // Cast all the _edges to TrenchRoute
        List<TrenchRoute> trenchRoutes = _edges.Cast<TrenchRoute>().ToList();
        // Sort the new list
        trenchRoutes.Sort();
        // create a Dictionary<string, string> for storing the building names
        var parent = _vertices.ToDictionary(v => v.Name, v => v.Name);

        string Find(string node)
        {
            if(parent[node] == node) return node;
            return parent[node] = Find(parent[node]);
        }

        // Create Minimum Spanning Tree
        List<TrenchRoute> optimalPlan = [];

        foreach (var route in trenchRoutes)
        {
            string buildingA = Find(route.Source.Name);
            string buildingB = Find(route.Target.Name);

            // if buildings are different, they are not connected 
            if(buildingA != buildingB)
            {
                optimalPlan.Add(route);
                // Add new edge to connect the two buildings
                parent[buildingA] = buildingB; // Union to connect the two sets
            }

            // Stops the loop, when every building is connected
            if (optimalPlan.Count == _vertices.Count - 1) break;
        }
        return optimalPlan;
    }
}
