using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New RuntimeEnumData", menuName = "RuntimeEnumData")]
public class RuntimeEnumData : ScriptableObject
{
    public Dictionary<string, int> values = new Dictionary<string, int>();

    public int nextValue = 0;

    private static List<RuntimeEnumData> all;
    public static List<RuntimeEnumData> All
    {
        get
        {
            if (all == null)
            {
                all = new List<RuntimeEnumData>(Resources.LoadAll<RuntimeEnumData>(""));
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

 
}
