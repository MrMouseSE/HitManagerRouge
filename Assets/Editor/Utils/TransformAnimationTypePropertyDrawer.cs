using Core.Utils;
using UnityEditor;
using UnityEngine;

namespace Editor.Utils
{
    [CustomPropertyDrawer(typeof(TransformAnimationType))]
    public class TransformAnimationTypePropertyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty animationType = property.FindPropertyRelative("AnimationType");
            if (animationType.enumValueIndex == (int)AnimationTypes.None) return EditorGUIUtility.singleLineHeight;
            return EditorGUIUtility.singleLineHeight * property.CountInProperty();
        }
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var indent = EditorGUI.indentLevel;
            
            SerializedProperty animationType = property.FindPropertyRelative("AnimationType");
            AnimationTypes enumValue = (AnimationTypes)property.FindPropertyRelative("AnimationType").enumValueIndex;
            var positionHeight = position.height;
            position.height = EditorGUIUtility.singleLineHeight;
            enumValue = (AnimationTypes)EditorGUI.EnumPopup(position, enumValue);
            animationType.enumValueIndex = (int)enumValue;
            if (enumValue != AnimationTypes.None)
            {
                EditorGUI.indentLevel += 1;
                position.y += EditorGUIUtility.singleLineHeight + 3;
                SerializedProperty tweenTransform = property.FindPropertyRelative("TweenTransform");
                EditorGUI.ObjectField(position, tweenTransform);
                position.y += EditorGUIUtility.singleLineHeight + 3;
                SerializedProperty curveProperty = property.FindPropertyRelative("EffectCurve");
                curveProperty.animationCurveValue =
                    EditorGUI.CurveField(position, "EffectCurve", curveProperty.animationCurveValue);
                position.y += EditorGUIUtility.singleLineHeight + 3;
                SerializedProperty fromProperty = property.FindPropertyRelative("From");
                fromProperty.vector3Value = EditorGUI.Vector3Field(position, "From", fromProperty.vector3Value);
                position.y += EditorGUIUtility.singleLineHeight + 3;
                SerializedProperty toProperty = property.FindPropertyRelative("To");
                toProperty.vector3Value = EditorGUI.Vector3Field(position, "To", toProperty.vector3Value);
            }
            EditorGUI.indentLevel = indent;
            position.height = positionHeight;
            EditorGUI.EndProperty();
        }
    }
}
