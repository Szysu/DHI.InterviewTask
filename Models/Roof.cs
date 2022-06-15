namespace DHI.InterviewTask.Models;

public class Roof
{
    public Roof(string name, SurfaceType surfaceType, int area)
    {
        Name = name;
        SurfaceType = surfaceType;
        Area = area;
    }

    public string Name { get; }
    public SurfaceType SurfaceType { get; }
    public int Area { get; }
}