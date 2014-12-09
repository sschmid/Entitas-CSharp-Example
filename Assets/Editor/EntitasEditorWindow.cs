using System.Reflection;
using Entitas.CodeGenerator;
using UnityEditor;
using UnityEngine;

public class EntitasEditorWindow : EditorWindow {
    [MenuItem("Game/Entitas/Code Generator")]
    public static void ShowEntitasCodeGeneratorWindow() {
        var window = (EntitasEditorWindow)EditorWindow.GetWindow(typeof(EntitasEditorWindow));
        window.title = "Code Generator";
        window.minSize = new Vector2(135, 30);
    }

    const string generatedFolder = "Assets/Sources/Generated/";

    void OnGUI() {
        GUI.enabled = !EditorApplication.isCompiling;

        if (GUILayout.Button("Generate")) {
            var assembly = Assembly.GetAssembly(typeof(EntitasCodeGenerator));
            EntitasCodeGenerator.Generate(assembly, generatedFolder);
        }

        GUI.enabled = true;

        AssetDatabase.Refresh();
    }
}
