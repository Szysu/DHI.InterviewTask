using DHI.InterviewTask.Models;

namespace DHI.InterviewTask;

public class MatrixBuilder
{
    private const int Margin = 2;

    public MatrixBuilder(List<Building> buildings, float cellSize)
    {
        Buildings = buildings;
        CellSize = cellSize;

        var width = CalculateMatrixWidth();
        var length = CalculateMatrixLength();

        Matrix = new int[width, length];
    }

    private List<Building> Buildings { get; }
    private int[,] Matrix { get; }

    private float CellSize { get; }

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
        // spaces between buildings
        width += (Buildings.Count - 1) * Margin;
        // top and bottom margins
        width += Margin * 2;
        width = MathF.Ceiling(width);
        return (int) width;
    }

    private int CalculateMatrixLength()
    {
        var length = Buildings.Max(b => b.GetTotalLength());
        length /= CellSize;
        // left and right margins
        length += Margin * 2;
        length = MathF.Ceiling(length);
        return (int) length;
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

            widthBuffer += i + Margin;
        }
    }

    private void AddInnerRoofsToMatrix()
    {
        var widthBuffer = Margin;
        foreach (var building in Buildings)
        {
            var totalLength = MathF.Round(building.GetTotalLength() / CellSize);
            var innerLength = MathF.Round(building.GetInnerLength() / CellSize);
            var sealedRoofLength = totalLength - innerLength;
            var lengthPadding = sealedRoofLength / 2;

            var totalWidth = MathF.Round(building.GetTotalWidth() / CellSize);
            var innerWidth = MathF.Round(building.GetInnerWidth() / CellSize);
            var sealedRoofWidth = totalWidth - innerWidth;
            var widthPadding = sealedRoofWidth / 2;

            var gravelLength = MathF.Round(building.GetGravelLength() / CellSize);

            int i;
            for (i = 0; i < innerWidth; i++)
            {
                for (var j = 0; j < innerLength; j++)
                {
                    var surfaceType = j < gravelLength
                        ? SurfaceType.Gravel
                        : SurfaceType.Green;

                    Matrix[i + (int) widthPadding + widthBuffer, j + Margin + (int) lengthPadding] =
                        (int) surfaceType;
                }
            }

            widthBuffer += i + Margin + (int) Math.Round(widthPadding * 2);
        }
    }
}