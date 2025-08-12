using System;
using System.Linq;
using Core.Units;
using Core.Utils;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Editor.Utils
{
    [CustomEditor(typeof(UnitSceneContainer))]
    [CanEditMultipleObjects]
    public class UnitSceneContainerEditor : UnityEditor.Editor
    {
        private ReorderableList _reorderableList;

        private void OnEnable()
        {
            SerializedProperty prop = serializedObject.FindProperty("UnitEffects");

            if (prop.arraySize == 0)
            {
                foreach (int value in Enum.GetValues(typeof(PlayableUnitEffectTypes)))
                {
                    prop.InsertArrayElementAtIndex(value);
                    prop.GetArrayElementAtIndex(value).FindPropertyRelative("Type").intValue = (int)value;
                    serializedObject.ApplyModifiedProperties();
                    serializedObject.Update();
                }
            }
            
            _reorderableList = new ReorderableList(serializedObject, prop, false, false, true, true);
            
            _reorderableList.drawHeaderCallback = DrawHeader;
            _reorderableList.drawElementCallback = DrawListItems;
            _reorderableList.elementHeightCallback = SetElementHeight;
            
        }

        private float SetElementHeight(int index)
        {
            var listElement = _reorderableList.serializedProperty.GetArrayElementAtIndex(index);
            int count = 5;
            var effectAnimationType = listElement.FindPropertyRelative("EffectTransformAnimationType");
            
            if ((AnimationTypes)effectAnimationType.FindPropertyRelative("AnimationType").enumValueIndex != AnimationTypes.None)
            {
                count += 5;
            }

            return count * EditorGUIUtility.singleLineHeight;
        }

        void DrawListItems(Rect rect, int index, bool isActive, bool isFocused)
        {
            SerializedProperty property = _reorderableList.serializedProperty.GetArrayElementAtIndex(index);
            rect.height = EditorGUIUtility.singleLineHeight;
            EditorGUI.LabelField(rect, "UnitEffects");
            EditorGUI.indentLevel ++;
            DrawListProperty("Type", property, ref rect);
            DrawListProperty("EffectAnimation", property, ref rect, true);
            DrawListProperty("EffectParticleSystem", property, ref rect, true);
            DrawListProperty("EffectTransformAnimationType", property, ref rect);
            EditorGUI.indentLevel--;
        }

        private void DrawListProperty(string propertyName, SerializedProperty property, ref Rect rect, bool checkBool = false)
        {
            SerializedProperty childProperty = property.FindPropertyRelative(propertyName);
            rect.y += EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(rect, childProperty, GUIContent.none);
            if (!checkBool) return;
            var boolProperty = property.FindPropertyRelative("Has" + propertyName);
            boolProperty.boolValue = childProperty.objectReferenceValue != null;
        }
        
        void DrawHeader(Rect rect)
        {
            EditorGUI.LabelField(rect, "UnitEffects");
        }
        
        public override void OnInspectorGUI()
        {
            UnitSceneContainer container = (UnitSceneContainer)target;
            container.UnitTransform = (Transform)EditorGUILayout.ObjectField("Unit Transform", container.UnitTransform, typeof(Transform), true);
            if (container.UnitTransform == null)
            {
                container.UnitTransform = container.transform;
            }
            container.UnitGameObject = (GameObject)EditorGUILayout.ObjectField("Unit GameObject", container.UnitGameObject, typeof(GameObject), true);
            if (container.UnitGameObject == null)
            {
                container.UnitGameObject = container.gameObject;
            }
            
            serializedObject.Update();
            _reorderableList.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
            container.UnitEffects = container.UnitEffects.ToList().OrderBy(x => (int)x.Type).ToArray();
        }
    }
}