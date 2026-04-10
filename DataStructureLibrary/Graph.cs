namespace DataStructureLibrary.Graph;

public class Graph
{
    // Fields
    protected LinkedList<Vertex> _vertices;
    protected LinkedList<Edge> _edges;

    // Constructors
    public Graph()
    {
        _vertices = new LinkedList<Vertex>();
        _edges = new LinkedList<Edge>();
    }

    // Methods
    // Vertex
    public Vertex AddVertex(string name)
    {
        // check if the vertex exist
        Vertex? v = HasVertex(name);

        if (v == null)
        {
            Vertex newV = new Vertex((uint)_vertices.Count, name);
            _vertices.AddLast(newV);

            return newV;
        }

        return v;
    }

    public void RemoveVertex(string name)
    {
        // Check if the vertex exsits
        Vertex? v = HasVertex(name);

        // If it exist,
        if (v != null)
        {
            // remove adjacent edges
            // v.1 get run-time error
            // foreach (Edge e in _edges)
            // {
            //     if (e.Source == v || e.Target == v)
            //     {
            //         _edges.Remove(e);
            //     }
            // }

            // v.2 get logical error
            // for (int i = 0; i < _edges.Count; i++)
            // {
            //     Edge e = _edges.ElementAt(i);

            //     if (e.Source == v || e.Target == v)
            //     {
            //         _edges.Remove(e);
            //     }
            // }

            // v.3 without error
            for (int i = 0; i < _edges.Count; i++)
            {
                // bool isRemoved = false;
                Edge e = _edges.ElementAt(i);

                if (e.Source == v || e.Target == v)
                {
                    _edges.Remove(e);
                    // isRemoved = true;
                    i--;
                }

                // if (isRemoved == true) i--;
            }

            // remove the vertex
            _vertices.Remove(v);
        }
    }

    public Vertex? HasVertex(string name)
    {
        foreach (Vertex v in _vertices)
        {
            if (v.Name == name)
                return v;
        }

        return null;
    }

    // Edge
    public Edge? AddEdge(Vertex? source, Vertex? target)
    {
        // Check if the source and target vertices exist
        if (source == null || target == null)
        {
            Console.WriteLine("Source or Target Vertex could not be found. Please add vertices first");
            return null;
        }

        // Check if the edge exists
        Edge? e = HasEdge(source, target);

        // If not, add a new edge
        if (e == null)
        {
            Edge newE = new Edge((uint)_edges.Count, source, target);
            _edges.AddLast(newE);
            return newE;
        }

        return e;
    }
    
    // Method overload to accept an already existing Edge object to add it to the list
    public void AddEdge(Edge newEdge)
    {
        // Check if the edge already exists just to be safe
        if (newEdge != null && HasEdge(newEdge.Source, newEdge.Target) == null)
        {
            _edges.AddLast(newEdge);
        }
    }

    public void RemoveEdge(Vertex? source, Vertex? target)
    {
        // Check if the edge exists
        Edge? e = HasEdge(source, target);

        // If yes, remove it
        if (e != null)
        {
            _edges.Remove(e);
        }
        else
        {
            Console.WriteLine("Edge could not be found");
        }
    }

    public Edge? HasEdge(Vertex? source, Vertex? target)
    {
        if (source == null || target == null) return null;

        foreach (Edge e in _edges)
        {
            if ((e.Source == source) &&
                (e.Target == target))
                return e;
        }

        return null;
    }

    // Graph
    public void PrintGraph()
    {
        Console.WriteLine("Total Vertex Number: " + _vertices.Count);
        Console.WriteLine("Total Edge Number: " + _edges.Count);
        Console.WriteLine("======================");

        // vertex list
        foreach (Vertex v in _vertices)
        {
            Console.WriteLine($"V({v.Id}) = {v.Name}");
        }
        Console.WriteLine("======================");

        // edge list
        foreach (Edge e in _edges)
        {
            Console.WriteLine($"E({e.Id}) = V({e.Source.Name}) -- V({e.Target.Name})");
        }
        Console.WriteLine("======================");
    }
}