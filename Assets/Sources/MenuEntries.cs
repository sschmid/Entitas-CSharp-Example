using System.Reflection;
using Entitas.CodeGenerator;
using UnityEditor;

public static class MenuEntries {

    [MenuItem("Game/Entitas/Generate")]
    public static void EntitasGenerate() {
        var assembly = Assembly.GetAssembly(typeof(EntitasCodeGenerator));
        EntitasCodeGenerator.Generate(assembly, "Assets/Sources/Generated/");
        AssetDatabase.Refresh();
    }
}

