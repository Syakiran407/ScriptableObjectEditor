using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    public Actors actors;
    public PlayerClass playerClass;
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
        
    }

}
