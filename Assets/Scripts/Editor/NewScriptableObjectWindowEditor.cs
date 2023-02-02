using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class NewScriptableObjectWindowEditor : EditorWindow
{
    private Dictionary<string, Skills> scriptableObjects = new Dictionary<string, Skills>();
    private List<string> scriptableObjectNames = new List<string>();
    private int selectedScriptableObjectIndex = 0;

    [MenuItem("Window/New Scriptable Object Window Editor")]
    public static void ShowWindow()
    {
        GetWindow<NewScriptableObjectWindowEditor>("New Scriptable Object Window Editor");
    }

    private void OnGUI()
    {
        selectedScriptableObjectIndex = EditorGUILayout.Popup("Scriptable Object:", selectedScriptableObjectIndex, scriptableObjectNames.ToArray());

        if (GUILayout.Button("Create New Scriptable Object"))
        {
            string path = EditorUtility.SaveFilePanelInProject("Save Scriptable Object", "New Scriptable Object", "asset", "Save Scriptable Object");
            if (path.Length != 0)
            {
                Skills newScriptableObject = ScriptableObject.CreateInstance<Skills>();
                AssetDatabase.CreateAsset(newScriptableObject, path);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                scriptableObjects.Add(newScriptableObject.name, newScriptableObject);
                scriptableObjectNames.Add(newScriptableObject.name);
                selectedScriptableObjectIndex = scriptableObjectNames.Count - 1;
            }
        }
    }
}
