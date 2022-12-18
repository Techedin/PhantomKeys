using UnityEngine;
using UnityEditor;

//Tell drawer that it is drawing properties from MyHealthAttribute
[CustomPropertyDrawer(typeof(MyHealthAttribute))]
public class HealthDrawer : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //Get Health Attribute
        MyHealthAttribute health = (MyHealthAttribute)attribute;

        //Draw the slider and overload function to handle float or integer
        if (property.propertyType == SerializedPropertyType.Float)
        {
            EditorGUI.Slider(position, property, health.minHealth, health.maxHealth, label);
        }
        else if (property.propertyType == SerializedPropertyType.Integer)
        {
            EditorGUI.IntSlider(position, property, (int)health.minHealth, (int)health.maxHealth, label);
        }
        else
        {
            EditorGUI.LabelField(position, label.text, "Use MyHealth with float or int.");
        }
    }


}
