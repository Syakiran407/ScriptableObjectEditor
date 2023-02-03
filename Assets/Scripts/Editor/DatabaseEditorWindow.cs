using System.Linq;
using UnityEditor;
using UnityEngine;


public class DatabaseEditorWindow : EditorWindow
{
    private string[] _tabs = { "Actors", "Classes", "Skills", "Weapons", "Items" };
    private int _selectedTab;
    private Actors _actor;
    private PlayerClass _playerClass;
    private Skills skills;
    private Weapons weapons;
    public Items items;
    //public PlayerClass playerClass;
    
    [MenuItem("Window/Database Editor")]
    public static void ShowWindow()
    {
        GetWindow<DatabaseEditorWindow>("Database Editor");
    }

    private void OnEnable()
    {
        _actor = (Actors)AssetDatabase.LoadAssetAtPath("Assets/Database/Actors.asset", typeof(Actors));
        _playerClass = (PlayerClass)AssetDatabase.LoadAssetAtPath("Assets/Database/Actors.asset", typeof(PlayerClass));
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
                        AssetDatabase.CreateAsset(_actor, "Assets/Player Information/Player General/NewActor.asset");
                        Actors.All.Add(_actor);
                        AssetDatabase.SaveAssets();
                        AssetDatabase.Refresh();

                        Repaint();

                        EditorApplication.projectChanged += Repaint;
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
                    //_actor.actors = (Actors)EditorGUILayout.ObjectField("Actors", _actor.actors, typeof(Actors), false);
                    _actor.playerClass = PlayerClass.All[Mathf.Clamp(EditorGUILayout.Popup("Class", PlayerClass.All.IndexOf(_actor.playerClass), PlayerClass.All.Select(a => a.name).ToArray()), 0, PlayerClass.All.Count - 1)];

                    
                    if (GUILayout.Button("Reset"))
                    {
                        _actor.Reset();
                        AssetDatabase.Refresh();
                        Repaint();
                        EditorApplication.projectChanged += Repaint;
                    }

                    if (GUILayout.Button("Save"))
                    {
                        EditorUtility.SetDirty(_actor);
                        //save Actor
                        Actors.All.Add(_actor);
                        AssetDatabase.SaveAssets();
                        AssetDatabase.Refresh();
                        Repaint();
                        EditorApplication.projectChanged += Repaint;
                    }

                    if (GUILayout.Button("Create New Player"))
                    {
                        _actor = CreateInstance<Actors>();
                        AssetDatabase.CreateAsset(_actor, "Assets/Player Information/Player General/NewActor.asset");

                        Actors.All.Add(_actor);
                        AssetDatabase.SaveAssets();
                        AssetDatabase.Refresh();

                        Repaint();
                        EditorApplication.projectChanged += Repaint;
                    }

                    if (GUILayout.Button("Delete"))
                    {
                        Actors.All.Remove(_actor);
                        AssetDatabase.DeleteAsset(assetPath);
                        AssetDatabase.SaveAssets();
                        AssetDatabase.Refresh();
                        EditorApplication.projectChanged += Repaint;
                    }
                }

                break;
            case 1:

                // code for classes tab

                _playerClass = (PlayerClass)EditorGUILayout.ObjectField(_playerClass, typeof(PlayerClass), false);

                if (_playerClass == null)
                {
                    if (GUILayout.Button("Create New Class"))
                    {
                        _playerClass = CreateInstance<PlayerClass>();
                        AssetDatabase.CreateAsset(_playerClass, "Assets/Player Information/Player Classes/NewPlayerClass.asset");
                        PlayerClass.All.Add(_playerClass);
                        AssetDatabase.SaveAssets();
                        AssetDatabase.Refresh();

                        Repaint();

                        EditorApplication.projectChanged += Repaint;
                    }
                }
                else
                {
                    string assetPath = AssetDatabase.GetAssetPath(_playerClass);
                    string assetName = assetPath.Substring(assetPath.LastIndexOf("/") + 1).Replace(".asset", "");
                    string newAssetName = EditorGUILayout.TextField("Asset Name", assetName);

                    if (assetName != newAssetName)
                    {
                        string newAssetPath = assetPath.Replace(assetName, newAssetName);
                        AssetDatabase.RenameAsset(assetPath, newAssetName);
                    }

                    if (_playerClass != null)
                    {
                        // load player class data
                        _playerClass.className = EditorGUILayout.TextField("Class Name", _playerClass.className);
                        _playerClass.description = EditorGUILayout.TextField("Description", _playerClass.description);
                        _playerClass.maxHP = EditorGUILayout.IntField("Max HP", _playerClass.maxHP);
                        _playerClass.maxMP = EditorGUILayout.IntField("Max MP", _playerClass.maxMP);
                        _playerClass.attack = EditorGUILayout.IntField("Attack", _playerClass.attack);
                        _playerClass.defense = EditorGUILayout.IntField("Defense", _playerClass.defense);
                        _playerClass.maxAttack = EditorGUILayout.IntField("Max Attack", _playerClass.maxAttack);
                        _playerClass.maxDefense = EditorGUILayout.IntField("Max Defense", _playerClass.maxDefense);
                        _playerClass.agility = EditorGUILayout.IntField("Agility", _playerClass.agility);
                        _playerClass.luck = EditorGUILayout.IntField("Luck", _playerClass.luck);

                        if (GUILayout.Button("Reset"))
                        {
                            _playerClass.Reset();
                            AssetDatabase.Refresh();
                            Repaint();
                            EditorApplication.projectChanged += Repaint;
                        }

                        if (GUILayout.Button("Save"))
                        {
                            EditorUtility.SetDirty(_playerClass);
                            //save Actor
                            PlayerClass.All.Add(_playerClass);
                            AssetDatabase.SaveAssets();
                            AssetDatabase.Refresh();
                            Repaint();
                            EditorApplication.projectChanged += Repaint;
                        }

                        if (GUILayout.Button("Create New Player"))
                        {
                            _playerClass = CreateInstance<PlayerClass>();
                            AssetDatabase.CreateAsset(_playerClass, "Assets/Player Information/Player Classes/NewPlayerClass.asset");

                            PlayerClass.All.Add(_playerClass);
                            AssetDatabase.SaveAssets();
                            AssetDatabase.Refresh();

                            Repaint();
                            EditorApplication.projectChanged += Repaint;
                        }

                        if (GUILayout.Button("Delete"))
                        {
                            PlayerClass.All.Remove(_playerClass);
                            AssetDatabase.DeleteAsset(assetPath);
                            AssetDatabase.SaveAssets();
                            AssetDatabase.Refresh();
                            EditorApplication.projectChanged += Repaint;
                        }
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
                        PlayerClass.All.Add(_playerClass);
                        AssetDatabase.SaveAssets();
                        AssetDatabase.Refresh();

                        Repaint();

                        EditorApplication.projectChanged += Repaint;
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

                    if (skills != null)
                    {
                        // load skill data
                        skills.skillName = EditorGUILayout.TextField("Skill Name", skills.skillName);
                        skills.description = EditorGUILayout.TextField("Description", skills.description);
                        skills.skillID = EditorGUILayout.IntField("Skill ID", skills.skillID);
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

                        skills.requiredWeapon = Weapons.All[Mathf.Clamp(EditorGUILayout.Popup("RequiredWeapon", Weapons.All.IndexOf(skills.requiredWeapon), Weapons.All.Select(a => a.name).ToArray()), 0, Weapons.All.Count - 1)];

                        if (GUILayout.Button("Reset"))
                        {
                            skills.Reset();
                            AssetDatabase.Refresh();
                            Repaint();
                            EditorApplication.projectChanged += Repaint;
                        }

                        if (GUILayout.Button("Save"))
                        {
                            EditorUtility.SetDirty(skills);
                            //save Actor
                            Skills.All.Add(skills);
                            AssetDatabase.SaveAssets();
                            AssetDatabase.Refresh();
                            Repaint();
                            EditorApplication.projectChanged += Repaint;
                        }

                        if (GUILayout.Button("Create New Skills"))
                        {
                            skills = CreateInstance<Skills>();
                            AssetDatabase.CreateAsset(skills, "Assets/Player Information/Player Skills/NewPlayerSkills.asset");

                            Skills.All.Add(skills);
                            AssetDatabase.SaveAssets();
                            AssetDatabase.Refresh();

                            Repaint();
                            EditorApplication.projectChanged += Repaint;
                        }

                        if (GUILayout.Button("Delete"))
                        {
                            Skills.All.Remove(skills);
                            AssetDatabase.DeleteAsset(assetPath);
                            AssetDatabase.SaveAssets();
                            AssetDatabase.Refresh();
                            EditorApplication.projectChanged += Repaint;
                        }
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
                        Weapons.All.Add(weapons);
                        AssetDatabase.SaveAssets();
                        AssetDatabase.Refresh();

                        Repaint();

                        EditorApplication.projectChanged += Repaint;
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

                    if (weapons != null)
                    {
                        // load weapons data
                        weapons.weaponName = EditorGUILayout.TextField("Weapon Name", weapons.weaponName);
                        weapons.weaponType = (WeaponType)EditorGUILayout.EnumPopup("Weapon Type", weapons.weaponType);

                        
                        if (GUILayout.Button("Reset"))
                        {
                            //weapons.Reset();
                            AssetDatabase.Refresh();
                            Repaint();
                            EditorApplication.projectChanged += Repaint;
                        }

                        if (GUILayout.Button("Save"))
                        {
                            EditorUtility.SetDirty(weapons);
                            //save Actor
                            Weapons.All.Add(weapons);
                            AssetDatabase.SaveAssets();
                            AssetDatabase.Refresh();
                            Repaint();
                            EditorApplication.projectChanged += Repaint;
                        }

                        if (GUILayout.Button("Create New Weapon"))
                        {
                            weapons = CreateInstance<Weapons>();
                            AssetDatabase.CreateAsset(weapons, "Assets/Player Information/Player Weapons/NewWeapon.asset");

                            Weapons.All.Add(weapons);
                            AssetDatabase.SaveAssets();
                            AssetDatabase.Refresh();

                            Repaint();
                            EditorApplication.projectChanged += Repaint;
                        }

                        if (GUILayout.Button("Delete"))
                        {
                            Weapons.All.Remove(weapons);
                            AssetDatabase.DeleteAsset(assetPath);
                            AssetDatabase.SaveAssets();
                            AssetDatabase.Refresh();
                            EditorApplication.projectChanged += Repaint;
                        }
                    }
                }



                break;
            case 4:
                // Code for items

               /* items = (Items)EditorGUILayout.ObjectField(items, typeof(Items), false);


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
                }*/
                break;
        }
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
    }
}
