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
    public GameObject weaponObject;
    public Collider2D weaponCollider;
    public string weaponName;
    public string description;
    public WeaponType weaponType;
    public int price;
    
    private PlayerClasses playerClasses;
    
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
