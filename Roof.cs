namespace DHI.InterviewTask;

public class Roof
{
    public Roof(string name, SurfaceType surfaceType, object area)
    {
        Name = name;
        SurfaceType = surfaceType;
        Area = area;
    }

    public string Name { get; }
    public SurfaceType SurfaceType { get; }
    public object Area { get; }
}