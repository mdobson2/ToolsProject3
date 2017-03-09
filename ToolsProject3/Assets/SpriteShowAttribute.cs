using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpriteShowAttribute : PropertyAttribute {

    public readonly float spriteSize;

    public SpriteShowAttribute(float size)
    {
        this.spriteSize = size;
    }
}

[CustomPropertyDrawer(typeof(SpriteShowAttribute))]
public class SpriteShowDrawer : PropertyDrawer
{
    SpriteShowAttribute SpriteAtt
    {
        get { return ((SpriteShowAttribute)attribute); }
    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) * SpriteAtt.spriteSize + 1;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect drawerRect = position;
        if(property.objectReferenceValue != null)
        {

        }

        //base.OnGUI(position, property, label);
    }
}
