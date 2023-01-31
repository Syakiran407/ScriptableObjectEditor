using UnityEngine;

public enum PlayerClass
{
    Warrior,
    Mage,
    Archer
}

[CreateAssetMenu(fileName = "New Player Class", menuName = "Create Player Class")]
public class PlayerClasses : ScriptableObject
{
   
    public PlayerClass playerClass;
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


    public void SetClass(PlayerClass playerClass)
    {
        switch (playerClass)
        {
            case PlayerClass.Warrior:
                
                maxHP = 100;
                maxMP = 100;
                attack = 10;
                defense = 10;
                maxAttack = 10;
                maxDefense = 10;
                agility = 10;
                luck = 10;
          
                break;
            case PlayerClass.Mage:
                
                maxHP = 100;
                maxMP = 100;
                attack = 10;
                defense = 10;
                maxAttack = 10;
                maxDefense = 10;
                agility = 10;
                luck = 10;
                
                break;
            case PlayerClass.Archer:

                maxHP = 100;
                maxMP = 100;
                attack = 10;
                defense = 10;
                maxAttack = 10;
                maxDefense = 10;
                agility = 10;
                luck = 10;
                
                break;
        }
    }

}
