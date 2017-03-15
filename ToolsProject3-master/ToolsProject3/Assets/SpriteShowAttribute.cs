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
        return base.GetPropertyHeight(property, label) * (SpriteAtt.spriteSize + 1);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Sprite texture = (Sprite)property.objectReferenceValue;
        Rect drawerRect = position;
        drawerRect.height = drawerRect.height / (SpriteAtt.spriteSize + 1);
        texture = (Sprite)EditorGUI.ObjectField(drawerRect, property.displayName, texture, typeof(Sprite), false) as Sprite;
        drawerRect.y += drawerRect.height;
        drawerRect.height = drawerRect.height * SpriteAtt.spriteSize;
        if(texture != null)
        {
            EditorGUI.DrawPreviewTexture(drawerRect, texture.texture);
        }
        property.objectReferenceValue = texture;
    }
}
