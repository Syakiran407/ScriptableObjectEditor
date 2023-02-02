using UnityEngine;
using UnityEditor;
using System.Linq;
using System;
using Unity.VisualScripting;

public class MyWindowEditor : EditorWindow
{
    private Skills selectedSkillsScriptableObject;
    private Skills[] skillsScriptableObject;
    private SerializedObject serializedObject;

    [MenuItem("Window/My Window Editor")]
    static void Init()
    {
        MyWindowEditor window = (MyWindowEditor)EditorWindow.GetWindow(typeof(MyWindowEditor));
        window.Show();
    }

    private void OnEnable()
    {
        if (EditorPrefs.HasKey("Skills"))
        {
            string assetPaths = EditorPrefs.GetString("Skills");
            string[] paths = assetPaths.Split(',');
            skillsScriptableObject = paths.Select(x => AssetDatabase.LoadAssetAtPath<Skills>(x)).ToArray();
            selectedSkillsScriptableObject = skillsScriptableObject.FirstOrDefault();
        }
        else
        {
            skillsScriptableObject = new Skills[0];

            // if object at index 0 is null
           
        }

        if (skillsScriptableObject == null)
        {
            // create new object
            selectedSkillsScriptableObject = CreateInstance<Skills>();
            // add it to the array
            skillsScriptableObject[0] = selectedSkillsScriptableObject;
            // save it
            AssetDatabase.CreateAsset(selectedSkillsScriptableObject, "Assets/Resources/Skills.asset");
        }

        if (skillsScriptableObject.Length > 0)
        {
            selectedSkillsScriptableObject = skillsScriptableObject[0];

            serializedObject = new SerializedObject(selectedSkillsScriptableObject);
            
            // if object at index 0 is null
            if (skillsScriptableObject == null)
            {
                // create new object
                selectedSkillsScriptableObject = CreateInstance<Skills>();
                // add it to the array
                skillsScriptableObject[0] = selectedSkillsScriptableObject;
                // save it
                AssetDatabase.CreateAsset(selectedSkillsScriptableObject, "Assets/Resources/Skills.asset");
            }

        }
        else
        {
            selectedSkillsScriptableObject = null;

            serializedObject = new SerializedObject(selectedSkillsScriptableObject);
        }
    }

    private void OnDestroy()
    {
        if (skillsScriptableObject.Length > 0)
        {
            string assetPaths = string.Join(",", skillsScriptableObject.Select(x => AssetDatabase.GetAssetPath(x)).ToArray());
            EditorPrefs.SetString("Skills", assetPaths);
        }
    }

    private void OnGUI()
    {
        // create a new ScriptableObject
        if (GUILayout.Button("Create New Skills"))
        {
            Skills newScriptableObject = CreateInstance<Skills>();
            AssetDatabase.CreateAsset(newScriptableObject, "Assets/Resources/" + skillsScriptableObject.Length + ".asset");
            AssetDatabase.SaveAssets();
            skillsScriptableObject = skillsScriptableObject.Concat(new Skills[] { newScriptableObject }).ToArray();
            selectedSkillsScriptableObject = newScriptableObject;
            Repaint();
        }

        // Check if the scriptable objects deleted or null
        if (skillsScriptableObject == null || skillsScriptableObject.Length == 0)
        {
            Debug.Log("No Scriptable Objects");
            // Just create a new ScriptableObject
            Skills newScriptableObject = CreateInstance<Skills>();
            AssetDatabase.CreateAsset(newScriptableObject, "Assets/Resources/" + skillsScriptableObject.Length + ".asset");
            AssetDatabase.SaveAssets();
        }

        if (selectedSkillsScriptableObject != null)
        {

            serializedObject = new SerializedObject(selectedSkillsScriptableObject);

            // show the properties of the selected ScriptableObject
            serializedObject = new SerializedObject(selectedSkillsScriptableObject);
            SerializedProperty skillNameProperty = serializedObject.FindProperty("skillName");
            SerializedProperty descriptionProperty = serializedObject.FindProperty("description");
            SerializedProperty skillIdProperty = serializedObject.FindProperty("skillID");
            SerializedProperty skillPowerProperty = serializedObject.FindProperty("skillPower");
            /*   SerializedProperty property = serializedObject.FindProperty("skillCost");
               SerializedProperty property = serializedObject.FindProperty("skillType");
               SerializedProperty property = serializedObject.FindProperty("skillTarget");
               SerializedProperty property = serializedObject.FindProperty("skillRange");
               SerializedProperty property = serializedObject.FindProperty("skillAOE");
               SerializedProperty property = serializedObject.FindProperty("skillStatus");
               SerializedProperty property = serializedObject.FindProperty("skillStatusChance");
               SerializedProperty property = serializedObject.FindProperty("skillStatusDuration");
               SerializedProperty property = serializedObject.FindProperty("skillStatusPower");
               SerializedProperty property = serializedObject.FindProperty("skillStatusResistance");*/

            EditorGUILayout.PropertyField(skillNameProperty, true);
            EditorGUILayout.PropertyField(descriptionProperty, true);
            EditorGUILayout.PropertyField(skillIdProperty, true);
            EditorGUILayout.PropertyField(skillPowerProperty, true);
            serializedObject.ApplyModifiedProperties();
            // save the changes made to the ScriptableObject
            if (GUILayout.Button("Save"))
            {
                serializedObject.ApplyModifiedProperties();
                EditorUtility.SetDirty(selectedSkillsScriptableObject);
                AssetDatabase.SaveAssets();
            }

            // delete the selected ScriptableObject
            if (GUILayout.Button("Delete"))
            {
                if (EditorUtility.DisplayDialog("Delete ScriptableObject", "Are you sure you want to delete " + selectedSkillsScriptableObject.name + "?", "Yes", "No"))
                {
                    skillsScriptableObject = skillsScriptableObject.Where(x => x != selectedSkillsScriptableObject).ToArray();
                    EditorPrefs.SetString("Skills", string.Join(",", skillsScriptableObject.Select(x => AssetDatabase.GetAssetPath(x)).ToArray()));
                    AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(selectedSkillsScriptableObject));
                    selectedSkillsScriptableObject = skillsScriptableObject.FirstOrDefault();
                    Repaint();
                }
            }
        }



      
    }
}