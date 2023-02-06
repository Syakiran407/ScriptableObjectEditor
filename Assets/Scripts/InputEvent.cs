using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "InputEvent", menuName = "InputEvent", order = 0)]
public class InputEvent : ScriptableObject
{
    public Dictionary<string, int> values = new Dictionary<string, int>();

    public int nextValue = 0;

    public string horizontalInput;
    public string verticalInput;

    private static List<InputEvent> all;
    public static List<InputEvent> All
    {
        get
        {
            if (all == null)
            {
                all = new List<InputEvent>();
                var guids = AssetDatabase.FindAssets("t:InputEvent");
                foreach (var guid in guids)
                {
                    var path = AssetDatabase.GUIDToAssetPath(guid);
                    var asset = AssetDatabase.LoadAssetAtPath<InputEvent>(path);
                    all.Add(asset);
                    EditorApplication.projectChanged += OnProjectChanged;
                }
            }
            return all;
        }
    }

    public void AddValue(string value)
    {
        values.Add(value, nextValue);
        nextValue++;
    }

    public int GetValue(string value)
    {
        return values[value];
    }

    public string[] GetNames()
    {
        string[] names = new string[values.Count];
        values.Keys.CopyTo(names, 0);
        return names;
    }

    static void OnProjectChanged()
    {
        //Debug.Log("OnProjectChanged");

        all = new List<InputEvent>();
        var guids = AssetDatabase.FindAssets("t:InputEvent");
        foreach (var guid in guids)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            var asset = AssetDatabase.LoadAssetAtPath<InputEvent>(path);
            all.Add(asset);
        }
    }
}
