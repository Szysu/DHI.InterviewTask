namespace DHI.InterviewTask.Models;

public class Building
{
    public Building(string name, float aspectRatio)
    {
        Name = name;
        AspectRatio = aspectRatio;
    }

    public string Name { get; }

    private float AspectRatio { get; }

    private List<Roof> Roofs { get; } = new();

    private Roof GreenSurface => Roofs.First(r => r.SurfaceType == SurfaceType.Green);

    private Roof GravelSurface => Roofs.First(r => r.SurfaceType == SurfaceType.Gravel);

    public void AddRoof(Roof roof)
    {
        Roofs.Add(roof);
    }

    public float GetTotalWidth()
    {
        var area = Roofs.Sum(r => r.Area);
        return MathF.Sqrt(area / AspectRatio);
    }

    public float GetTotalLength()
    {
        return GetTotalWidth() * AspectRatio;
    }

    public float GetInnerWidth()
    {
        var innerArea = GreenSurface.Area + GravelSurface.Area;
        return MathF.Sqrt(innerArea / AspectRatio);
    }

    public float GetInnerLength()
    {
        return GetInnerWidth() * AspectRatio;
    }

    public float GetGreenLength()
    {
        var innerArea = GravelSurface.Area + GreenSurface.Area;
        var percentage = (float) GreenSurface.Area / innerArea;

        return GetInnerLength() * percentage;
    }

    public float GetGravelLength()
    {
        return GetInnerLength() - GetGreenLength();
    }
}