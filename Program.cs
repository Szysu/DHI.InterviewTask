using DHI.InterviewTask;
using DHI.InterviewTask.Models;

var roofParts = Samples.Roofs;
const float aspectRatio = Samples.AspectRatio;
const float cellSize = Samples.CellSize;

var buildings = new List<Building>();
foreach (var roof in roofParts)
{
    var building = buildings.FirstOrDefault(b => b.Name == roof.Name);
    if (building is null)
    {
        building = new Building(roof.Name, aspectRatio);
        buildings.Add(building);
    }

    building.AddRoof(roof);
}

var matrix = new MatrixBuilder(buildings, cellSize).Build();
MatrixExporter.ExportToFile(matrix);

Console.WriteLine($"The results saved to: {Environment.CurrentDirectory}/results.txt");
Console.WriteLine("Press any key...");
Console.Read();