# Metro-Net Fiber Optic Optimizer

This project implements **Kruskal’s Minimum Spanning Tree (MST) Algorithm** to solve a real-world urban planning problem: connecting multiple buildings with fiber optic cable using the absolute minimum amount of material. By treating buildings as vertices and potential trenching routes as weighted edges, the application calculates the most cost-effective infrastructure plan while ensuring every building is part of the same network.

## Built With
* **Language:** C#
* **Framework:** .NET 10.0
* **Libraries:** * **DataStructureLibrary:** A custom-built library providing core Graph, Vertex, and Edge data structures.
    * **Spectre.Console:** Used for advanced terminal styling, tables, and colorized output.

## Getting Started 

### Prerequisites
* **.NET 10.0 SDK** or higher.
* A C# IDE (Visual Studio 2022, VS Code, or JetBrains Rider).

### Installation
1. Clone the repository to your local machine.
2. Navigate to the `DataStructureLibrary` folder and build the library:
   ```bash
   dotnet build
   ```
3. Navigate to the `MetroNetApp` project folder.
4. Install the **Spectre.Console** dependency:
   ```bash
   dotnet add package Spectre.Console
   ```
5. Run the application:
   ```bash
   dotnet run
   ```

### Usage
The project allows you to define a city layout and find the optimal connection plan. Below is a conceptual example of how the `CityNetwork` class is used:

```csharp
// Initialize the network
CityNetwork opticFiberNet = new();

// 1. Add Buildings (Vertices)
opticFiberNet.AddBuilding("City Hall");
opticFiberNet.AddBuilding("Hospital");

// 2. Add Potential Trenching Routes (Edges with distance)
opticFiberNet.AddTrenchRoute("City Hall", "Hospital", 1200);

// 3. Calculate the Minimum Spanning Tree
List<TrenchRoute> finalPlan = opticFiberNet.CalculateOptimalNetwork();
```

## Roadmap 
* [x] **Core Library:** Implementation of `Graph`, `Vertex`, and `Edge` classes.
* [x] **Inheritance Model:** Created `TrenchRoute` (inheriting from `Edge`) and `CityNetwork` (inheriting from `Graph`) to specialize the library for urban planning.
* [x] **Algorithm:** Manual implementation of Kruskal’s Algorithm with **Path Compression** for $O(E \log E)$ efficiency.
* [x] **Polymorphism:** Utilized method overloading and casting to integrate custom routes into the base graph library.
* [x] **Modern UI:** Integrated Spectre.Console for professional table-based reporting.
* [ ] **Planned:** Add support for importing city data from JSON or CSV files.
* [ ] **Planned:** Implement an interactive CLI mode to add buildings and routes via user prompts.
* [ ] **Planned:** Add geographical coordinate support (Latitude/Longitude) to calculate distances automatically.

## Contributing 
Contributions are welcome! If you have suggestions for improving the algorithm's performance or adding new features (like Prim's Algorithm for comparison), please follow these steps:
1. Fork the Project.
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`).
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`).
4. Push to the Branch (`git push origin feature/AmazingFeature`).
5. Open a Pull Request.

## License 
Distributed under the **MIT License**. See `LICENSE` for more information.

## Contact
**Florian Golubic** - cc241008@ustp-students.at

Project Link: [https://github.com/Pepperoni2/Kruskal](https://github.com/Pepperoni2/Kruskal)

## Acknowledgments
* **Kruskal's Algorithm:** For providing the logic to solve the Minimum Spanning Tree problem.
* **Spectre.Console:** For making the .NET console beautiful.
* **Course Instructors:** For the foundational `DataStructureLibrary` development lectures.