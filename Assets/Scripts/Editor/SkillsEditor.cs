using Unity.VisualScripting;
using UnityEditor;

[CustomEditor(typeof(Skills))]
public class SkillsEditor : Editor
{
    private SerializedObject serializedObject;
    private SerializedProperty skillName;
    private SerializedProperty description;
    private SerializedProperty skillID ;
    private SerializedProperty skillPower ;
    private SerializedProperty skillCost ;
    private SerializedProperty skillType ;
    private SerializedProperty skillTarget ;
    private SerializedProperty skillRange ;
    private SerializedProperty skillAOE ;
    private SerializedProperty skillStatus ;
    private SerializedProperty skillStatusChance ;
    private SerializedProperty skillStatusDuration ;
    private SerializedProperty skillStatusPower ;
    private SerializedProperty skillStatusResistance ;
    private SerializedProperty damage;
    private SerializedProperty cost;

    private void OnEnable()
    {
        serializedObject = new SerializedObject(target);
        skillName = serializedObject.FindProperty("skillName");
        description = serializedObject.FindProperty("description");
        skillID = serializedObject.FindProperty("skillID");
        skillPower = serializedObject.FindProperty("skillPower");
        skillCost = serializedObject.FindProperty("skillCost");
        skillType = serializedObject.FindProperty("skillType");
        skillTarget = serializedObject.FindProperty("skillTarget");
        skillRange = serializedObject.FindProperty("skillRange");
        skillAOE = serializedObject.FindProperty("skillAOE");
        skillStatus = serializedObject.FindProperty("skillStatus");
        skillStatusChance = serializedObject.FindProperty("skillStatusChance");
        skillStatusDuration = serializedObject.FindProperty("skillStatusDuration");
        skillStatusPower = serializedObject.FindProperty("skillStatusPower");
        skillStatusResistance = serializedObject.FindProperty("skillStatusResistance");


        damage = serializedObject.FindProperty("damage");
        cost = serializedObject.FindProperty("cost");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(skillName);

        EditorGUILayout.PropertyField(description);

        EditorGUILayout.PropertyField(skillID);

        EditorGUILayout.PropertyField(skillPower);

        EditorGUILayout.PropertyField(skillCost);

        EditorGUILayout.PropertyField(skillType);

        EditorGUILayout.PropertyField(skillTarget);

        EditorGUILayout.PropertyField(skillRange);

        EditorGUILayout.PropertyField(skillAOE);

        EditorGUILayout.PropertyField(skillStatus);

        EditorGUILayout.PropertyField(skillStatusChance);

        EditorGUILayout.PropertyField(skillStatusDuration);

        EditorGUILayout.PropertyField(skillStatusPower);

        EditorGUILayout.PropertyField(skillStatusResistance);

        /*EditorGUILayout.PropertyField(damage);
        EditorGUILayout.PropertyField(cost);*/

        serializedObject.ApplyModifiedProperties();
    }
}
