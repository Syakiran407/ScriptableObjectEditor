using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Sword,
    Axe,
    Bow,
    Boomerang
}


[CreateAssetMenu(fileName = "New Weapon", menuName = "Create New Weapon")]
public class Weapons : ScriptableObject
{
    public Dictionary<string, int> values = new Dictionary<string, int>();
    public int nextValue = 0;
    public GameObject weaponObject;
    public Collider2D weaponCollider;
    public string weaponName;
    public string description;
    public WeaponType weaponType;
    public int price;
    
    private PlayerClasses playerClasses;


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

    public void ParameterChanges()
    {
        {
            switch (weaponType)
            {
                case WeaponType.Sword:
                    // Change parameters

                    playerClasses.maxAttack += 5;

                    break;
                case WeaponType.Axe:
                    // Change parameters
                    playerClasses.maxAttack += 5;
                    break;
                case WeaponType.Bow:
                    // Change parameters
                    playerClasses.maxAttack += 5;
                    break;
                case WeaponType.Boomerang:

                    // Change parameters
                    playerClasses.maxAttack += 5;

                    break;
            }
        }
    }
}
