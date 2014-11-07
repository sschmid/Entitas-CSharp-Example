using UnityEngine;
using UnityEditor;
using Entitas.CodeGenerator;
using System.Reflection;

public class EntitasEditorWindow : EditorWindow {
    [MenuItem("Game/Entitas/Entitas Manager")]
    public static void ShowEntitasManagerWindow() {
        var window = (EntitasEditorWindow)EditorWindow.GetWindow(typeof(EntitasEditorWindow));
        window.title = "Entitas Manger";
        window.minSize = new Vector2(135, 45);
    }

    void OnGUI() {

        EntitasCodeGenerator.generatedFolder = "Assets/Sources/Generated/";

        if (GUILayout.Button("Generate")) {
            var assembly = Assembly.GetAssembly(typeof(EntitasCodeGenerator));
            EntitasCodeGenerator.Generate(assembly);
        }
        if (GUILayout.Button("Clean")) {
            EntitasCodeGenerator.CleanGeneratedFolder();
        }
        AssetDatabase.Refresh();
    }
}
