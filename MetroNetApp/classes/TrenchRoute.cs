using DataStructureLibrary.Graph;

namespace MetroNetApp.classes;

public class TrenchRoute(uint id, Vertex source, Vertex target, float distance): Edge(id, source, target), IComparable<TrenchRoute>
{
    // Fields
    public float Distance = distance; // Physical distance of the trench == weight of the edge

    /// <summary>
    ///  CompareTo function checks if the distance of this route is longer, shorter or is the same
    /// </summary>
    /// <param name="other"></param>
    /// <returns>Integer</returns>
    public int CompareTo(TrenchRoute? other)
    {
        /*
            < 0 => this route is shorter than the other
            0   => Same distance
            > 0 => this route is longer than the other
        */
        return Distance.CompareTo(other?.Distance);
    }
}