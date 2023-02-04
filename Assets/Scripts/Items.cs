using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "New Item", menuName = "Create new Item")]
public class Items : ScriptableObject
{
    public Dictionary<string, int> values = new Dictionary<string, int>();

    public int nextValue = 0;
    public string itemName;
    public string description;
    public int itemID;
    public int itemPower;
    public int itemCost;
    public int itemStatus;
    public int itemStatusChance;
    public int itemStatusDuration;
    public int itemStatusPower;
    public int itemStatusResistance;

    private static List<Items> all;
    public static List<Items> All
    {
        get
        {
            if (all == null)
            {
                all = new List<Items>(Resources.LoadAll<Items>(""));
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

    public void Reset()
    {
        itemName = null;
        description = null;
        itemID = 0;
        itemPower = 0;
        itemCost = 0;
        itemStatus = 0;
        itemStatusChance = 0;
        itemStatusDuration = 0;
        itemStatusPower = 0;
        itemStatusResistance = 0;
    }


}
