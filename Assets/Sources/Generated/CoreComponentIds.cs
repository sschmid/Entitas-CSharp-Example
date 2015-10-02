using Entitas;

public static class CoreComponentIds {
    public const int Acceleratable = 0;
    public const int Accelerating = 1;
    public const int Destroy = 2;
    public const int FinishLine = 3;
    public const int Move = 4;
    public const int Position = 5;
    public const int Resource = 6;
    public const int View = 7;

    public const int TotalComponents = 8;

    static readonly string[] _components = {
        "Acceleratable",
        "Accelerating",
        "Destroy",
        "FinishLine",
        "Move",
        "Position",
        "Resource",
        "View"
    };

    public static string IdToString(int componentId) {
        return _components[componentId];
    }
}