using UnityEditor;
using UnityEngine;

public class DrawBox 
{
    protected Rect backgroundRect;
    protected Color backgroundColor;

    //Default 
    public virtual void DrawingBox(Rect rect, string title)
    {
        GUILayout.BeginArea(rect);
        GUILayout.Box(title, GUILayout.MaxWidth(rect.width), GUILayout.MaxHeight(rect.height)); //Force the rect to be the size of the area.
        GUILayout.EndArea();
    }

    //Custom background style! In the image, EditorStyles.Helpbox is being used
    public virtual void DrawingBox(Rect rect, string title, GUIStyle backgroundStyle)
    {
        GUILayout.BeginArea(rect);
        GUILayout.Box(title, backgroundStyle, GUILayout.MaxWidth(rect.width), GUILayout.MaxHeight(rect.height));
        GUILayout.EndArea();
    }

    //Adjust color too if you want
    //Default GUI color is white, which is the light greyish color. the slight darker line should be grey and the darker version is dark grey / black
    public virtual void DrawingBox(Rect rect, string title, GUIStyle backgroundStyle, Color backgroundColor)
    {
        GUILayout.BeginArea(rect);
        GUI.backgroundColor = backgroundColor;
        GUILayout.Box(title, backgroundStyle, GUILayout.MaxWidth(rect.width), GUILayout.MaxHeight(rect.height));
        GUI.backgroundColor = Color.white; // reset the color! Making it only affect this element.
        GUILayout.EndArea();
    }
}