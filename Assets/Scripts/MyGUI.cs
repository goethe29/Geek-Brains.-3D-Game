using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGUI : MonoBehaviour
{
    public Color myColor;
    private float _myHealth;
    private GUIStyle _style = new GUIStyle();
    
    private void Start() 
    {
        _myHealth = FindObjectOfType<Player>().HP;
    }
    
    void OnGUI()
    {
        myColor = RGBSlider(new Rect(10, 10, 200, 20), myColor);
        //GUILayout.TextArea(_myHealth.ToString());
        GUI.Box(new Rect(Screen.width - 100, Screen.height - 50, 100, 50), _myHealth.ToString(), _style );
    }
    Color RGBSlider(Rect screenRect, Color rgb)
    {
        rgb.r = LabelSlider(screenRect, rgb.r, 1.0f, "Red");
        screenRect.y += 20;
        rgb.g = LabelSlider(screenRect, rgb.g, 1.0f, "Green");
        screenRect.y += 20;
        rgb.b = LabelSlider(screenRect, rgb.b, 1.0f, "Blue");
        screenRect.y += 20;
        rgb.a = LabelSlider(screenRect, rgb.a, 1.0f, "Alpha", 0.3f);
        return rgb;
    }
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMaxValue, string labelText, float sliderMinValue = 0.0f)
    {
        GUI.Label(screenRect, labelText);
        screenRect.x += screenRect.width;
        sliderValue = GUI.HorizontalSlider(screenRect, sliderValue, sliderMinValue, sliderMaxValue);
        return sliderValue;
    }
}
