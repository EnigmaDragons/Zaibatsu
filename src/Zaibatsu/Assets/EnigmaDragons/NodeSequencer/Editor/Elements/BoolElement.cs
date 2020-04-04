using UnityEditor;
using UnityEngine;

public class BoolElement : IElement
{
    private readonly string _name;
    private readonly Rect _rect;

    public bool Value { get; set; }
    public float Width { get; }
    public float Height { get; }

    public BoolElement(string name, bool initialValue, int width)
    {
        _name = name;
        Value = initialValue;
        Width = width;
        Height = EditorConstants.ToggleHeight;
        _rect = new Rect(0, 0, Width, Height);
    }

    public void Draw(Vector2 position)
    {
        Value = EditorGUI.Toggle(_rect.WithOffset(position), _name, Value);
    }
}
