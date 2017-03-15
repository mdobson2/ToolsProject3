using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColorLineAttribute : PropertyAttribute {

    public readonly Color lineColor = Color.white;
    public ColorLineAttribute( float r, float g, float b)
    {
        this.lineColor = new Color(Mathf.Clamp(r,0,1),Mathf.Clamp(g,0,1),Mathf.Clamp(b,0,1));
    }
}

[CustomPropertyDrawer(typeof(ColorLineAttribute))]
public class ColorLineDrawer : DecoratorDrawer {

    ColorLineAttribute ColorLine
    {
        get { return ((ColorLineAttribute)attribute); }
    }

    public override float GetHeight()
    {
        return base.GetHeight();
    }

    public override void OnGUI(Rect position)
    {
        float lineX = position.x;
        float lineY = position.y;
        float lineWidth = position.width;
        float lineHeight = 1;

        Color returnColor = GUI.color;
        GUI.color = ColorLine.lineColor;
        EditorGUI.DrawPreviewTexture(new Rect(lineX, lineY, lineWidth, lineHeight), Texture2D.whiteTexture);
        GUI.color = returnColor;
    }
}
