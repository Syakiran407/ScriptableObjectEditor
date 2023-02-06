using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(InputEvent))]
public class InputEventDataDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        if (InputEvent.All != null)
        {
            int index = 0;
            string[] options = new string[InputEvent.All.Count];
            foreach (var data in InputEvent.All)
            {
                options[index++] = data.name;
            }

            int value = EditorGUI.Popup(position, property.objectReferenceValue == null ? 0 : Array.IndexOf(InputEvent.All.ToArray(), property.objectReferenceValue), options);

            if (value >= 0 && value < options.Length)
            {
                property.objectReferenceValue = InputEvent.All[value];
            }
            else
            {
                return;
            }
        }
        else
        {
            Debug.LogWarning("Input Event object is null, skipping property drawer");
        }


        EditorGUI.EndProperty();
    }
}
