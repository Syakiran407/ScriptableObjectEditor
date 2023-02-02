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
                selectedScriptableObjectIndex = scriptableObjectNames.Count - 1;            }
        }

        if (GUILayout.Button("Delete Scriptable Object"))
        {
            if (scriptableObjectNames.Count > 0)
            {
                string scriptableObjectToDelete = scriptableObjectNames[selectedScriptableObjectIndex];
                scriptableObjectNames.RemoveAt(selectedScriptableObjectIndex);
                scriptableObjects.Remove(scriptableObjectToDelete);
                AssetDatabase.DeleteAsset("Assets/Resources/" + scriptableObjectToDelete + ".asset");
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                selectedScriptableObjectIndex = 0;
            }
        }

        if (GUILayout.Button("Save Scriptable Object"))
        {
            if (scriptableObjectNames.Count > 0)
            {
                EditorUtility.SetDirty(scriptableObjects[scriptableObjectNames[selectedScriptableObjectIndex]]);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }

        if (scriptableObjectNames.Count > 0)
        {
           
            scriptableObjects[scriptableObjectNames[selectedScriptableObjectIndex]].name = EditorGUILayout.TextField("Name:", scriptableObjects[scriptableObjectNames[selectedScriptableObjectIndex]].name);

            // check if object has been destroyed
            if (scriptableObjects[scriptableObjectNames[selectedScriptableObjectIndex]] == null)
            {
                scriptableObjectNames.RemoveAt(selectedScriptableObjectIndex);
                selectedScriptableObjectIndex = 0;
            }

            scriptableObjects[scriptableObjectNames[selectedScriptableObjectIndex]].skillName = EditorGUILayout.TextField("Skill Name:", scriptableObjects[scriptableObjectNames[selectedScriptableObjectIndex]].skillName);
            scriptableObjects[scriptableObjectNames[selectedScriptableObjectIndex]].description = EditorGUILayout.TextField("Skill Description:", scriptableObjects[scriptableObjectNames[selectedScriptableObjectIndex]].description);
        }
    }
}
