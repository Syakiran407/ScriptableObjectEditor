using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(PlayerClass))]
public class PlayerClassDataDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        if (PlayerClass.All != null)
        {
            int index = 0;
            string[] options = new string[PlayerClass.All.Count];
            foreach (var data in PlayerClass.All)
            {
                options[index++] = data.name;
            }

            int value = EditorGUI.Popup(position, property.objectReferenceValue == null ? 0 : Array.IndexOf(PlayerClass.All.ToArray(), property.objectReferenceValue), options);

            if (value >= 0 && value < options.Length)
            {
                property.objectReferenceValue = PlayerClass.All[value];
            }
            else
            {
                return;
            }
        }
        else
        {
            Debug.LogWarning("Player Class object is null, skipping property drawer");
        }


        EditorGUI.EndProperty();
    }
}
