using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Actors))]
public class ActorEnumDataDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        if (Actors.All != null)
        {
            int index = 0;
            string[] options = new string[Actors.All.Count];
            foreach (var data in Actors.All)
            {
                options[index++] = data.name;
            }

            int value = EditorGUI.Popup(position, property.objectReferenceValue == null ? 0 : Array.IndexOf(Actors.All.ToArray(), property.objectReferenceValue), options);

            if (value >= 0 && value < options.Length)
            {
                property.objectReferenceValue = Actors.All[value];
            }
            else
            {
                Debug.LogError("Selected index is out of range");
            }
        }
        else
        {
            Debug.LogError("Actors object is null");
        }

        EditorGUI.EndProperty();
    }
}
