using Entitas;

using System.Collections.Generic;

public static class CoreComponentIds {
    public const int Acceleratable = 0;
    public const int Accelerating = 1;
    public const int Destroy = 2;
    public const int Move = 3;
    public const int Position = 4;
    public const int FinishLine = 5;
    public const int Resource = 6;
    public const int View = 7;

    public const int TotalComponents = 8;

    static readonly Dictionary<int, string> components = new Dictionary<int, string> {
        { 0, "Acceleratable" },
        { 1, "Accelerating" },
        { 2, "Destroy" },
        { 3, "Move" },
        { 4, "Position" },
        { 5, "FinishLine" },
        { 6, "Resource" },
        { 7, "View" }
    };

    public static string IdToString(int componentId) {
        return components[componentId];
    }
}

public partial class CoreMatcher : AllOfMatcher {
    public CoreMatcher(int index) : base(new [] { index }) {
    }

    public override string ToString() {
        return string.Format(CoreComponentIds.IdToString(indices[0]));
    }
}