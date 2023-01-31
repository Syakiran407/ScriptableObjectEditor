using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Create New Player")]
public class Player : ScriptableObject
{
    public string playerName;
    public PlayerClasses playerClass;
    public string description;
    public int level;
    public Sprite playerSprite;

    public void LevelUp()
    {
        level++;
    }

    public void Reset()
    {
        level = 1;
        playerSprite = null;
    }
}
