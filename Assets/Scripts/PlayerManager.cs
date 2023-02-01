using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public Player player;
    public PlayerClasses playerClass;
    public Skills skills;
    public Weapons weapons;

    void Start()
    {
   /*     Debug.Log(player.playerName);
        Debug.Log(playerClass.playerClass);
        Debug.Log(playerClass.description);
        Debug.Log(skills.skillName);
        Debug.Log(weapons.weaponName);*/

        // reset player
        // player.Reset();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (skills.skillName == "Throw Boomerang" && weapons.weaponType == WeaponType.Boomerang)
            {
                Debug.Log("You can use this skill");
            }
            else
            {
                Debug.Log("You can't use this skill");
            }
        }
    }

}
