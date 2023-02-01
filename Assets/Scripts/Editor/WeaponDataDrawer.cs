using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Weapons))]
public class WeaponDataDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        int index = 0;
        string[] options = new string[Weapons.All.Count];
        foreach (var data in Weapons.All)
        {
            options[index++] = data.name;
        }

        int value = EditorGUI.Popup(position, property.objectReferenceValue == null ? 0 : Array.IndexOf(Weapons.All.ToArray(), property.objectReferenceValue), options);

        if (value >= 0 && value < Weapons.All.Count)
        {
            property.objectReferenceValue = Weapons.All[value];
        }
        else
        {
            Debug.LogError("Selected index is out of range");
        }


        EditorGUI.EndProperty();
    }
}
