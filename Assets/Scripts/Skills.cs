using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Create New Skill")]
public class Skills : ScriptableObject
{
    public string skillName;
    public string description;
    public int skillID;
    public WeaponType requiredWeapon;
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
