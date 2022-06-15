using System.Text;

namespace DHI.InterviewTask;

public static class MatrixExporter
{
    public static void ExportToFile(int[,] matrix)
    {
        File.WriteAllText($"{Environment.CurrentDirectory}/results.txt", GetPlainMatrix(matrix));
    }

    private static string GetPlainMatrix(int[,] matrix)
    {
        var plainMatrix = new StringBuilder();
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                plainMatrix.Append(matrix[i, j] + " ");
            }

            plainMatrix.AppendLine();
        }

        return plainMatrix.ToString();
    }
}