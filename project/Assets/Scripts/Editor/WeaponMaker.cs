using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using UnityEditor.AnimatedValues;
using UnityEngine.UI;



#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MyEditor
{
    public class WeaponMaker : EditorWindow
    {
        WeaponInfo info;
        private EditMode _editMode;
        private string _savePath;

        bool _showWeaponRange = false;
        const int XSize = 5;
        const int YSize = 5;
        Vector2Int Size => new Vector2Int(XSize, YSize);
        enum EditMode
        {
            None, Create, Modify
        }

        [MenuItem("Custom/WeaponMaker")]
        private static void ShowWindow()
        {
            var window = GetWindow<WeaponMaker>();
            window.titleContent = new GUIContent("WeaponMaker");
            window.Init();
            window.Show();
        }
        void Init()
        {
            Debug.Log("Init");
            info = ScriptableObject.CreateInstance<WeaponInfo>();
        }

        private void OnGUI()
        {
            using (var editorScope = new EditorGUILayout.VerticalScope())
            {
                _editMode = (EditMode)EditorGUILayout.EnumPopup("EditMode", _editMode);

                using (var topBarScope = new EditorGUILayout.HorizontalScope())
                {
                    if (GUILayout.Button("Save"))
                    {
                        string assetPath = "Assets/NewScriptableObject.asset";

                        // 에셋으로 저장
                        AssetDatabase.CreateAsset(info, assetPath);
                        AssetDatabase.SaveAssets();

                        // 에디터에서 선택 상태로 만들기
                        Selection.activeObject = info;

                        Debug.Log("ScriptableObject created and saved at path: " + assetPath);
                    }
                    if (GUILayout.Button("Load"))
                    {

                    }
                }

                EditorGUILayout.Space(20);
                if (_editMode != EditMode.None)
                {
                    info.Damage = EditorGUILayout.FloatField("Damage", info.Damage);
                    EditorGUILayout.Space(10);
                    info.Weight = EditorGUILayout.FloatField("Weight", info.Weight);
                    EditorGUILayout.Space(10);
                    info.DefaultImage = (Sprite)EditorGUILayout.ObjectField("Image", info.DefaultImage, typeof(Sprite), true);
                    EditorGUILayout.Space(10);
                    if (_showWeaponRange = EditorGUILayout.ToggleLeft("WeaponRange", _showWeaponRange))
                    {
                        DrawAllWeaponRange(info);
                    }
                }
            }
        }

        public static void DrawAllWeaponRange(WeaponInfo weaponInfo)
        {
            using (var rangeScope = new EditorGUILayout.VerticalScope())
            {
                DrawWeaponRange(weaponInfo);
            }


            void DrawWeaponRange(WeaponInfo info)
            {

                GUILayout.Width(100); GUILayout.Height(10);

                using (var rangeScope = new EditorGUILayout.VerticalScope())
                {
                    for (int y = YSize - 1; y >= 0; --y)
                    {
                        using (var lineScore = new EditorGUILayout.HorizontalScope())
                        {
                            for (int x = 0; x < XSize; ++x)
                            {
                                info.WpRange[y * XSize + x] = EditorGUILayout.Toggle(info.WpRange[y * XSize + x], GUILayout.MinHeight(15), GUILayout.MinWidth(15), GUILayout.MaxWidth(20), GUILayout.MaxHeight(20));
                            }
                        }
                    }
                }
            }
        }
    }
}