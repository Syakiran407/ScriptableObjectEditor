using System.Collections.Generic;
using UnityEditor;
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

    private static List<Weapons> all;
    public static List<Weapons> All
    {
        get
        {
            if (all == null)
            {
                all = new List<Weapons>();
                var guids = AssetDatabase.FindAssets("t:Weapons");
                foreach (var guid in guids)
                {
                    var path = AssetDatabase.GUIDToAssetPath(guid);
                    var asset = AssetDatabase.LoadAssetAtPath<Weapons>(path);
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

    public GameObject weaponObject;
    public Collider2D weaponCollider;
    public string weaponName;
    public string description;
    public WeaponType weaponType;
    public int price;

    private PlayerClass playerClasses;

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

   /* public void Reset()
    {
        playerClasses.maxAttack = 0;

    }*/

    static void OnProjectChanged()
    {
        //Debug.Log("OnProjectChanged");

        all = new List<Weapons>();
        var guids = AssetDatabase.FindAssets("t:Weapons");
        foreach (var guid in guids)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            var asset = AssetDatabase.LoadAssetAtPath<Weapons>(path);
            all.Add(asset);
        }
    }

}
