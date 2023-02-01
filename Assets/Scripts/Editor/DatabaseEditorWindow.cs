using System.Linq;
using System;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using System.Numerics;

public class DatabaseEditorWindow : EditorWindow
{
    private string[] _tabs = { "Actors", "Classes", "Skills", "Weapons", "Items" };
    private int _selectedTab;
    private Actors _actor;
    public PlayerClasses _playerClasses;
    public Skills skills;
    public Weapons weapons;
    public Items items;
    public PlayerClass playerClass;
    
    [MenuItem("Window/Database Editor")]
    public static void ShowWindow()
    {
        GetWindow<DatabaseEditorWindow>("Database Editor");
    }

    private void OnGUI()
    {
  
        
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical(GUILayout.Width(100));
        _selectedTab = GUILayout.SelectionGrid(_selectedTab, _tabs, 1, GUILayout.ExpandHeight(true));
        GUILayout.EndVertical();

        GUILayout.BeginVertical();
        switch (_selectedTab)
        {
            case 0:
                // code for actors tab 

                _actor = (Actors)EditorGUILayout.ObjectField(_actor, typeof(Actors), false);

                if (_actor == null)
                {
                    if (GUILayout.Button("Create New Player"))
                    {
                        _actor = CreateInstance<Actors>();
                        AssetDatabase.CreateAsset(_actor, "Assets/Player Information/Player General/NewPlayer.asset");
                        AssetDatabase.SaveAssets();    
                    }
                }
                else
                {
                    string assetPath = AssetDatabase.GetAssetPath(_actor);
                    string assetName = assetPath.Substring(assetPath.LastIndexOf("/") + 1).Replace(".asset", "");
                    string newAssetName = EditorGUILayout.TextField("Asset Name", assetName);

                    if (assetName != newAssetName)
                    {
                        string newAssetPath = assetPath.Replace(assetName, newAssetName);
                        AssetDatabase.RenameAsset(assetPath, newAssetName);
                    }

                    _actor.playerName = EditorGUILayout.TextField("Name", _actor.playerName);
                    _actor.description = EditorGUILayout.TextField("Description", _actor.description);
                    _actor.level = EditorGUILayout.IntField("Level", _actor.level);
                    _actor.playerSprite = (Sprite)EditorGUILayout.ObjectField("Sprite", _actor.playerSprite, typeof(Sprite), false);
                    _actor.actors = (Actors)EditorGUILayout.ObjectField("Actors", _actor.actors, typeof(Actors), false);
                    //_actor.actors = Actors.All[Mathf.Clamp(EditorGUILayout.Popup("Actors", Actors.All.IndexOf(_actor.actors), Actors.All.Select(a => a.name).ToArray()), 0, Actors.All.Count - 1)];
                    
                    if (GUILayout.Button("Reset"))
                    {
                        _actor.Reset();
                    }

                    if (GUILayout.Button("Save"))
                    {
                        EditorUtility.SetDirty(_actor);
                        AssetDatabase.SaveAssets();

                        //save Actor
                        Actors.All.Add(_actor);

                    }

                    if (GUILayout.Button("Create New Player"))
                    {
                        _actor = CreateInstance<Actors>();
                        AssetDatabase.CreateAsset(_actor, "Assets/Resources/NewActor.asset");
                        AssetDatabase.SaveAssets();
                    }
                }

                break;
            case 1:
                
                // code for classes tab
                
                _playerClasses = (PlayerClasses)EditorGUILayout.ObjectField(_playerClasses, typeof(PlayerClasses), false);

                if (_playerClasses == null)
                {
                    if (GUILayout.Button("Create New Class"))
                    {
                        _playerClasses = CreateInstance<PlayerClasses>();
                        AssetDatabase.CreateAsset(_playerClasses, "Assets/Player Information/Player Classes/NewPlayerClass.asset");
                        AssetDatabase.SaveAssets();
                    }
                }
                else
                {
                    string assetPath = AssetDatabase.GetAssetPath(_playerClasses);
                    string assetName = assetPath.Substring(assetPath.LastIndexOf("/") + 1).Replace(".asset", "");
                    string newAssetName = EditorGUILayout.TextField("Asset Name", assetName);

                    if (assetName != newAssetName)
                    {
                        string newAssetPath = assetPath.Replace(assetName, newAssetName);
                        AssetDatabase.RenameAsset(assetPath, newAssetName);
                    }
                }

                if (_playerClasses != null)
                {
                    // load player class data
                    _playerClasses.playerClass = (PlayerClass)EditorGUILayout.EnumPopup("Class", _playerClasses.playerClass);
                    _playerClasses.description = EditorGUILayout.TextField("Description", _playerClasses.description);
                    _playerClasses.maxHP = EditorGUILayout.IntField("Max HP", _playerClasses.maxHP);
                    _playerClasses.maxMP = EditorGUILayout.IntField("Max MP", _playerClasses.maxMP);
                    _playerClasses.attack = EditorGUILayout.IntField("Attack", _playerClasses.attack);
                    _playerClasses.defense = EditorGUILayout.IntField("Defense", _playerClasses.defense);
                    _playerClasses.maxAttack = EditorGUILayout.IntField("Max Attack", _playerClasses.maxAttack);
                    _playerClasses.maxDefense = EditorGUILayout.IntField("Max Defense", _playerClasses.maxDefense);
                    _playerClasses.agility = EditorGUILayout.IntField("Agility", _playerClasses.agility);
                    _playerClasses.luck = EditorGUILayout.IntField("Luck", _playerClasses.luck);

                    if (GUILayout.Button("Reset"))
                    {
                        _playerClasses.Reset();
                    }

                    if (GUILayout.Button("Save"))
                    {
                        EditorUtility.SetDirty(_playerClasses);
                        AssetDatabase.SaveAssets();

                    }
                }

                break;
            case 2:
                // code for skills tab

                skills = (Skills)EditorGUILayout.ObjectField(skills, typeof(Skills), false);

                if (skills == null)
                {
                    if (GUILayout.Button("Create New Skill"))
                    {
                        skills = CreateInstance<Skills>();
                        AssetDatabase.CreateAsset(skills, "Assets/Player Information/Player Skills/NewSkill.asset");
                        AssetDatabase.SaveAssets();
                    }
                }
                else
                {
                    string assetPath = AssetDatabase.GetAssetPath(skills);
                    string assetName = assetPath.Substring(assetPath.LastIndexOf("/") + 1).Replace(".asset", "");
                    string newAssetName = EditorGUILayout.TextField("Asset Name", assetName);

                    if (assetName != newAssetName)
                    {
                        string newAssetPath = assetPath.Replace(assetName, newAssetName);
                        AssetDatabase.RenameAsset(assetPath, newAssetName);
                    }
                }

                if (skills != null)
                {
                    // load skill data
                    skills.skillName = EditorGUILayout.TextField("Skill Name", skills.skillName);
                    skills.description = EditorGUILayout.TextField("Description", skills.description);
                    skills.skillID = EditorGUILayout.IntField("Skill ID", skills.skillID);
                    //skills.requiredWeapon = (WeaponType)EditorGUILayout.EnumPopup("Required Weapon", skills.requiredWeapon);
                    
                    skills.skillPower = EditorGUILayout.IntField("Skill Power", skills.skillPower);
                    skills.skillCost = EditorGUILayout.IntField("Skill Cost", skills.skillCost);
                    skills.skillType = EditorGUILayout.IntField("Skill Type", skills.skillType);
                    skills.skillTarget = EditorGUILayout.IntField("Skill Target", skills.skillTarget);
                    skills.skillRange = EditorGUILayout.IntField("Skill Range", skills.skillRange);
                    skills.skillAOE = EditorGUILayout.IntField("Skill AOE", skills.skillAOE);
                    skills.skillStatus = EditorGUILayout.IntField("Skill Status", skills.skillStatus);
                    skills.skillStatusChance = EditorGUILayout.IntField("Skill Status Chance", skills.skillStatusChance);
                    skills.skillStatusDuration = EditorGUILayout.IntField("Skill Status Duration", skills.skillStatusDuration);
                    skills.skillStatusPower = EditorGUILayout.IntField("Skill Status Power", skills.skillStatusPower);
                    skills.skillStatusResistance = EditorGUILayout.IntField("Skill Status Resistance", skills.skillStatusResistance);


                    if (GUILayout.Button("Reset"))
                    {
                        skills.Reset();
                    }

                    if (GUILayout.Button("Save"))
                    {
                        EditorUtility.SetDirty(skills);
                        AssetDatabase.SaveAssets();


                    }
                }


                break;
            case 3:
                // Code for weapons
                weapons = (Weapons)EditorGUILayout.ObjectField(weapons, typeof(Weapons), false);

                if (weapons == null)
                {
                    if (GUILayout.Button("Create New Weapon"))
                    {
                        weapons = CreateInstance<Weapons>();
                        AssetDatabase.CreateAsset(weapons, "Assets/Player Information/Player Weapons/NewWeapon.asset");
                        AssetDatabase.SaveAssets();
                    }
                }
                else
                {
                    string assetPath = AssetDatabase.GetAssetPath(weapons);
                    string assetName = assetPath.Substring(assetPath.LastIndexOf("/") + 1).Replace(".asset", "");
                    string newAssetName = EditorGUILayout.TextField("Asset Name", assetName);

                    if (assetName != newAssetName)
                    {
                        string newAssetPath = assetPath.Replace(assetName, newAssetName);
                        AssetDatabase.RenameAsset(assetPath, newAssetName);
                    }
                }

                if (weapons != null)
                {
                    // load weapon data
                    weapons.weaponName = EditorGUILayout.TextField("Weapon Name", weapons.weaponName);
                    weapons.description = EditorGUILayout.TextField("Description", weapons.description);
                    //weapons.weaponID = EditorGUILayout.IntField("Weapon ID", weapons.weaponID);
                    weapons.weaponType = (WeaponType)EditorGUILayout.EnumPopup("Weapon Type", weapons.weaponType);             
                }

                break;
            case 4:
                // Code for items

                items = (Items)EditorGUILayout.ObjectField(items, typeof(Items), false);


                if (items == null)
                {
                    if (GUILayout.Button("Create New Item"))
                    {
                        items = CreateInstance<Items>();
                        AssetDatabase.CreateAsset(items, "Assets/Player Information/Player Items/NewItem.asset");
                        AssetDatabase.SaveAssets();
                    }
                }
                else
                {
                    string assetPath = AssetDatabase.GetAssetPath(items);
                    string assetName = assetPath.Substring(assetPath.LastIndexOf("/") + 1).Replace(".asset", "");
                    string newAssetName = EditorGUILayout.TextField("Asset Name", assetName);

                    if (assetName != newAssetName)
                    {
                        string newAssetPath = assetPath.Replace(assetName, newAssetName);
                        AssetDatabase.RenameAsset(assetPath, newAssetName);
                    }
                }


                if (items != null)
                {
                    // load item data
                    items.itemName = EditorGUILayout.TextField("Item Name", items.itemName);
                    items.description = EditorGUILayout.TextField("Description", items.description);
                    items.itemID = EditorGUILayout.IntField("Item ID", items.itemID);
                    items.itemPower = EditorGUILayout.IntField("Item Power", items.itemPower);
                    items.itemCost = EditorGUILayout.IntField("Item Cost", items.itemCost);
                    items.itemStatus = EditorGUILayout.IntField("Item Status", items.itemStatus);
                    items.itemStatusChance = EditorGUILayout.IntField("Item Status Chance", items.itemStatusChance);
                    items.itemStatusDuration = EditorGUILayout.IntField("Item Status Duration", items.itemStatusDuration);
                    items.itemStatusPower = EditorGUILayout.IntField("Item Status Power", items.itemStatusPower);
                    items.itemStatusResistance = EditorGUILayout.IntField("Item Status Resistance", items.itemStatusResistance);

                    if (GUILayout.Button("Reset"))
                    {
                        items.Reset();
                    }

                    if (GUILayout.Button("Save"))
                    {
                        EditorUtility.SetDirty(items);
                        AssetDatabase.SaveAssets();
                    }
                }


                break;
        }
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
    }
}
