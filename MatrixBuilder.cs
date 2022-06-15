using DHI.InterviewTask.Models;

namespace DHI.InterviewTask;

public class MatrixBuilder
{
    private const int Margin = 2;
    private const int SpaceBetweenBuildings = 2;

    public MatrixBuilder(List<Building> buildings, float cellSize)
    {
        Buildings = buildings;
        CellSize = cellSize;

        var width = CalculateMatrixWidth();
        var length = CalculateMatrixLength();

        Matrix = new int[width, length];
    }

    private List<Building> Buildings { get; }
    private float CellSize { get; }
    private int[,] Matrix { get; }

    public int[,] Build()
    {
        AddOuterRoofsToMatrix();
        AddInnerRoofsToMatrix();
        return Matrix;
    }

    private int CalculateMatrixWidth()
    {
        var width = Buildings.Sum(b => b.GetTotalWidth());
        width /= CellSize;
        width += (Buildings.Count - 1) * SpaceBetweenBuildings;
        width += Margin * 2;

        return (int) MathF.Ceiling(width);
    }

    private int CalculateMatrixLength()
    {
        var length = Buildings.Max(b => b.GetTotalLength());
        length /= CellSize;
        length += Margin * 2;

        return (int) MathF.Ceiling(length);
    }

    private void AddOuterRoofsToMatrix()
    {
        var widthBuffer = Margin;
        foreach (var building in Buildings)
        {
            var buildingWidth = building.GetTotalWidth() / CellSize;
            var buildingLength = building.GetTotalLength() / CellSize;

            int i;
            for (i = 0; i < buildingWidth; i++)
            {
                for (var j = 0; j < buildingLength; j++)
                {
                    Matrix[i + widthBuffer, j + Margin] = (int) SurfaceType.Sealed;
                }
            }

            widthBuffer += i + SpaceBetweenBuildings;
        }
    }

    private void AddInnerRoofsToMatrix()
    {
        var widthBuffer = Margin;
        foreach (var building in Buildings)
        {
            var widthPadding = building.GetOuterWidth() / CellSize / 2;
            var lengthPadding = building.GetOuterLength() / CellSize / 2;

            var innerWidth = building.GetInnerWidth() / CellSize;
            var innerLength = building.GetInnerLength() / CellSize;

            var gravelLength = building.GetGravelLength() / CellSize;

            int i;
            for (i = 0; i < innerWidth; i++)
            {
                for (var j = 0; j < innerLength; j++)
                {
                    var surfaceType = j < gravelLength
                        ? SurfaceType.Gravel
                        : SurfaceType.Green;

                    var yCursor = (int) (i + widthPadding + widthBuffer);
                    var xCursor = (int) (j + Margin + lengthPadding);

                    Matrix[yCursor, xCursor] = (int) surfaceType;
                }
            }

            widthBuffer += i + SpaceBetweenBuildings + (int) Math.Round(widthPadding * 2);
        }
    }
}