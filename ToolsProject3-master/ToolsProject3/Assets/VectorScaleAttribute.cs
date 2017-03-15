using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class VectorScaleAttribute : PropertyAttribute {

    public readonly float minSlider;
    public readonly float maxSlider;

    public VectorScaleAttribute(float Min, float Max)
    {
        this.minSlider = Min;
        this.maxSlider = Max;
    }
}

[CustomPropertyDrawer(typeof(VectorScaleAttribute))]
public class VectorScaleDrawer : PropertyDrawer
{
    VectorScaleAttribute VectorAtt
    {
        get { return ((VectorScaleAttribute)attribute); }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) * 4;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        if(property.propertyType == SerializedPropertyType.Vector3)
        {
            Rect drawerRect = position;
            float vectorX = property.vector3Value.x;
            float vectorY = property.vector3Value.y;
            float vectorZ = property.vector3Value.z;
            drawerRect.height = drawerRect.height / 4;

            EditorGUI.SelectableLabel(drawerRect, property.displayName);
            drawerRect.y += drawerRect.height;
            vectorX = EditorGUI.Slider(drawerRect, "X:", vectorX, VectorAtt.minSlider, VectorAtt.maxSlider);
            drawerRect.y += drawerRect.height;
            vectorY = EditorGUI.Slider(drawerRect, "Y:", vectorY, VectorAtt.minSlider, VectorAtt.maxSlider);
            drawerRect.y += drawerRect.height;
            vectorZ = EditorGUI.Slider(drawerRect, "Z:", vectorZ, VectorAtt.minSlider, VectorAtt.maxSlider);

            property.vector3Value = new Vector3(vectorX, vectorY, vectorZ);
        }
        else
        {
            EditorGUI.HelpBox(position, "To use the VectorScale attribute, your variable must be a Vector3", MessageType.Error);
        }
        //base.OnGUI(position, property, label);
    }
}
