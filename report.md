# Report

**Course:** C# Development SS20?? (4 ECTS, 3 SWS)

**Student ID:** CC

**BCC Group:**

**Name:**

## Methodology: 
The goal of the project was to minimize the cost of fiber optic installation by finding the Minimum Spanning Tree (MST) of a city network. My methodology followed these core steps:

* **Domain-Specific Modeling:** I used inheritance to extend the generic `DataStructureLibrary`. I created a `TrenchRoute` class that inherits from the base `Edge` class to include a `Distance` property and implemented `IComparable` to allow for weight-based sorting.
* **Graph Extension:** I developed a `CityNetwork` class inheriting from the library's `Graph` class to provide specialized methods like `AddBuilding` and `AddTrenchRoute`.
* **Kruskal’s Algorithm Implementation:** * **Greedy Sorting:** The algorithm begins by sorting all potential trenching routes from the shortest to the longest distance.
    * **Cycle Detection (Union-Find):** I implemented a Union-Find structure using a `Dictionary<string, string>` to track building connectivity.
    * **Path Compression:** The `Find` function utilizes recursion and path compression to flatten the set structure, ensuring future connectivity checks are nearly $O(1)$.
    * **MST Construction:** The algorithm iterates through sorted routes and adds them to the final plan only if they connect two buildings that are not already in the same set, thus preventing cycles.

## Additional Features
* **Spectre.Console Integration:** To fulfill the application requirement, I integrated the `Spectre.Console` library to replace standard text output with professional rounded tables, color-coded building names, and summary panels.
* **Polymorphic Edge Handling:** I implemented a method overload for `AddEdge` in the base library to allow the graph to accept specialized `TrenchRoute` objects while treating them as standard `Edge` types.
* **Automated ID Generation:** Rather than using static placeholders, the application dynamically generates unique edge IDs using the current count of the `_edges` collection.

## Discussion/Conclusion
During development, I encountered and solved several key challenges:
* **Encapsulation Barriers:** The base `Graph` library initially used `private` fields for vertices and edges. I solved this by refactoring the library to use `protected` access modifiers, allowing my `CityNetwork` child class to access the data without exposing it to the entire application.
* **Data Structure Compatibility:** The library utilized a `LinkedList<Edge>`, which does not support the `.Sort()` method. I resolved this by using LINQ to cast the collection into a `List<TrenchRoute>`, enabling efficient sorting.
* **Null-Safety Warnings:** Working with C# 10.0 nullable references initially caused warnings when passing vertices to constructors. I implemented defensive null-checks in the `AddTrenchRoute` method to ensure the compiler guaranteed that no `null` objects reached the algorithm engine.

## Reference: 
* **Algorithm Logic:** "Kruskal’s MST Algorithm in C# Use Case: Urban Fiber Optic Infrastructure (Metro-Net)". ([https://en.wikipedia.org/wiki/Kruskal%27s_algorithm](https://en.wikipedia.org/wiki/Kruskal%27s_algorithm))
* **Base Framework:** `DataStructureLibrary` (Graph, Vertex, Edge) provided in course lectures.
* **UI Library:** Spectre.Console Documentation ([https://spectreconsole.net/](https://spectreconsole.net/)).