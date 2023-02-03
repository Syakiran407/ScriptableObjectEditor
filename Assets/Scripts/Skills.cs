using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Create New Skill")]
public class Skills : ScriptableObject
{
    public Dictionary<string, int> values = new Dictionary<string, int>();

    public int nextValue = 0;

    public string skillName;
    public string description;
    public int skillID;
    [SerializeField]
    public Weapons requiredWeapon;
    public int skillPower;
    public int skillCost;
    public int skillType;
    public int skillTarget;
    public int skillRange;
    public int skillAOE;
    public int skillStatus;
    public int skillStatusChance;
    public int skillStatusDuration;
    public int skillStatusPower;
    public int skillStatusResistance;


    private static List<Skills> all;
    public static List<Skills> All
    {
        get
        {
            if (all == null)
            {
                all = new List<Skills>();
                var guids = AssetDatabase.FindAssets("t:Skills");
                foreach (var guid in guids)
                {
                    var path = AssetDatabase.GUIDToAssetPath(guid);
                    var asset = AssetDatabase.LoadAssetAtPath<Skills>(path);
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

        all = new List<Skills>();
        var guids = AssetDatabase.FindAssets("t:Actors");
        foreach (var guid in guids)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            var asset = AssetDatabase.LoadAssetAtPath<Skills>(path);
            all.Add(asset);

        }
    }


    public void ParameterChanges()
    {
        switch (skillType)
        {
            case 1:
                // Change parameters
                break;
            case 2:
                // Change parameters
                break;
            case 3:
                // Change parameters
                break;
            case 4:
                // Change parameters
                break;
        }
    }

    public void Reset()
    {
        skillPower = 0;
        skillCost = 0;
        skillType = 0;
        skillTarget = 0;
        skillRange = 0;
        skillAOE = 0;
        skillStatus = 0;
        skillStatusChance = 0;
        skillStatusDuration = 0;
        skillStatusPower = 0;
        skillStatusResistance = 0;
    }
}
