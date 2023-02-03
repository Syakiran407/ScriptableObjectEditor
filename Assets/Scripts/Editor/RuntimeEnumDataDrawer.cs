using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(RuntimeEnumData))]
public class RuntimeEnumDataDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        int index = 0;
        string[] options = new string[RuntimeEnumData.All.Count];
        foreach (var data in RuntimeEnumData.All)
        {

            if (data != null)
            {

                options[index++] = data.name;
            }

            int value = EditorGUI.Popup(position, property.objectReferenceValue == null ? 0 : Array.IndexOf(RuntimeEnumData.All.ToArray(), property.objectReferenceValue), options);

            if (value >= 0 && value < RuntimeEnumData.All.Count)
            {
                property.objectReferenceValue = RuntimeEnumData.All[value];
            }
            else
            {
                Debug.LogError("Selected index is out of range");
            }


            EditorGUI.EndProperty();
        }
    }
}
