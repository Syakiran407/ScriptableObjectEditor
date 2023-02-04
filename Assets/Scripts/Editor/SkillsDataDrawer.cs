using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Skills))]
public class SkillsDataDrawer : PropertyDrawer 
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        if (Skills.All != null)
        {
            int index = 0;
            string[] options = new string[Skills.All.Count];
            foreach (var data in Skills.All)
            {

                options[index++] = data.name;
            }

            int value = EditorGUI.Popup(position, property.objectReferenceValue == null ? 0 : Array.IndexOf(Skills.All.ToArray(), property.objectReferenceValue), options);

            if (value >= 0 && value < options.Length)
            {
                property.objectReferenceValue = Skills.All[value];
            }
            else
            {
                return;
            }
        }
        else
        {
            Debug.LogWarning("Skills object is null, skipping property drawer");
        }

        EditorGUI.EndProperty();
    }
}
