namespace DataStructureLibrary.Graph;

public class Edge
{
    // Fields
    public uint Id;
    // references
    public Vertex Source;
    public Vertex Target;

    // Constructors
    public Edge(uint id, Vertex source, Vertex target)
    {
        Id = id;
        Source = source;
        Target = target;
    }
}