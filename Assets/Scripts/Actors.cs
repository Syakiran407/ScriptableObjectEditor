using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Actor", menuName = "Create New Actor")]
public class Actors : ScriptableObject
{
    public Dictionary<string, int> values = new Dictionary<string, int>();
    
    public int nextValue = 0;
    public string playerName;
    public string description;
    public int level;
    public Sprite playerSprite;
    [SerializeField]
    public Actors actors;

    private static List<Actors> all;
    public static List<Actors> All
    {
        get
        {
            if (all == null)
            {
                all = new List<Actors>();
                var guids = AssetDatabase.FindAssets("t:Actors");
                foreach (var guid in guids)
                {
                    var path = AssetDatabase.GUIDToAssetPath(guid);
                    var asset = AssetDatabase.LoadAssetAtPath<Actors>(path);
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

    public void LevelUp()
    {
        level++;
    }

    public void Reset()
    {
        level = 1;
        playerSprite = null;
    }

    private void OnDestroy()
    {
        
    }

    static void OnProjectChanged()
    {
        Debug.Log("OnProjectChanged");


        all = new List<Actors>();
        var guids = AssetDatabase.FindAssets("t:Actors");
        foreach (var guid in guids)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            var asset = AssetDatabase.LoadAssetAtPath<Actors>(path);
            all.Add(asset);
  
        }
    }

}
