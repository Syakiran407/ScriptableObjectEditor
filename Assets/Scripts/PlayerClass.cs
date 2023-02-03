using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Class", menuName = "Create Player Class")]
public class PlayerClass : ScriptableObject
{
    
    public Dictionary<string, int> values = new Dictionary<string, int>();
    public int nextValue = 0;
    private static List<PlayerClass> all;
    public static List<PlayerClass> All
    {
        get
        {
            if (all == null)
            {
                all = new List<PlayerClass>();
                var guids = AssetDatabase.FindAssets("t:PlayerClass");
                foreach (var guid in guids)
                {
                    var path = AssetDatabase.GUIDToAssetPath(guid);
                    var asset = AssetDatabase.LoadAssetAtPath<PlayerClass>(path);
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

    public string className;
    public string description;
    public int maxHP;
    public int maxMP;
    public int attack;
    public int defense;
    public int maxAttack;
    public int maxDefense;
    public int agility;
    public int luck;

    public void LevelUp()
    {
        maxHP += 10;
        maxMP += 10;
        attack += 1;
        defense += 1;
        maxAttack += 1;
        maxDefense += 1;
        agility += 1;
        luck += 1;
    }

    public void Reset()
    {
        maxHP = 100;
        maxMP = 100;
        attack = 10;
        defense = 10;
        maxAttack = 10;
        maxDefense = 10;
        agility = 10;
        luck = 10;
    }

    public void SkillsToLearn()
    {

    }

    static void OnProjectChanged()
    {
        //Debug.Log("OnProjectChanged");

        all = new List<PlayerClass>();
        var guids = AssetDatabase.FindAssets("t:PlayerClass");
        foreach (var guid in guids)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            var asset = AssetDatabase.LoadAssetAtPath<PlayerClass>(path);
            all.Add(asset);

        }
    }

}
