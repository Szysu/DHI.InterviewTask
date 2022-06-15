using DHI.InterviewTask.Models;

namespace DHI.InterviewTask;

public static class Samples
{
    public const float AspectRatio = 1.66f;

    public const float CellSize = 0.25f;

    public static List<Roof> Roofs { get; } = new()
    {
        new Roof("Roof 1", SurfaceType.Sealed, 48),
        new Roof("Roof 1", SurfaceType.Green, 92),
        new Roof("Roof 1", SurfaceType.Gravel, 33),

        new Roof("Roof 2", SurfaceType.Sealed, 53),
        new Roof("Roof 2", SurfaceType.Green, 177),
        new Roof("Roof 2", SurfaceType.Gravel, 59),

        new Roof("Roof 3", SurfaceType.Sealed, 74),
        new Roof("Roof 3", SurfaceType.Green, 238),
        new Roof("Roof 3", SurfaceType.Gravel, 61),

        new Roof("Roof 4", SurfaceType.Sealed, 51),
        new Roof("Roof 4", SurfaceType.Green, 275),
        new Roof("Roof 4", SurfaceType.Gravel, 57),

        new Roof("Roof 5", SurfaceType.Sealed, 49),
        new Roof("Roof 5", SurfaceType.Green, 310),
        new Roof("Roof 5", SurfaceType.Gravel, 48)
    };
}