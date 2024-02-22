using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WeaponInfo))]
public class WeaponInfoEditor : Editor
{
    bool _showWeaponRange = false;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Space(10);
        if (_showWeaponRange = EditorGUILayout.Toggle("Show WeaponRange", _showWeaponRange))
            MyEditor.WeaponMaker.DrawAllWeaponRange((WeaponInfo)target);
    }
}