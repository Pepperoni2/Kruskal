namespace DataStructureLibrary.Graph;

public class Vertex
{
    // Fields
    public uint Id;
    public string Name = "UnknownName";

    // Constructors
    public Vertex(uint id, string name)
    {
        Id = id;
        Name = name;
    }
}