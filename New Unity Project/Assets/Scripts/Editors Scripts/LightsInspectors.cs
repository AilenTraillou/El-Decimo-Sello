using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Light))]
public class LightsInspectors : Editor
{

    public Light _target;
    public string[] lightType;


    private void OnEnable()
    {
        _target = (Light)target;
    }

    public void OnInspectorGUI()
    {
        ShowLightsValues();
        Repaint();
    }

    void ShowLightsValues()
    {

        EditorGUILayout.BeginHorizontal();
        _target.intensity = EditorGUILayout.FloatField("Light intensity", _target.intensity);
        EditorGUILayout.EndHorizontal();

        if (_target.intensity > 8)
        {
            EditorGUILayout.HelpBox("La intensidad de la luz no puede ser mayor a 8", MessageType.Error);
        }

        EditorGUILayout.BeginHorizontal();
        _target.color = EditorGUILayout.ColorField("Light Color", _target.color);
        EditorGUILayout.EndHorizontal();

        if (_target.color.r > 200)
        {
            EditorGUILayout.HelpBox("Se recomienda que los valores del RGB no sean superiores a 200", MessageType.Warning);
        }

        EditorGUILayout.BeginHorizontal();
        _target.range = EditorGUILayout.FloatField("Light Range", _target.range);
        EditorGUILayout.EndHorizontal();

        if (_target.range > 22f)
        {
            EditorGUILayout.HelpBox("Se recomienda que el rango de la luz no sea mayor a 22", MessageType.Warning);
        }

        //EditorGUILayout.BeginHorizontal();
        //_target.type = EditorGUILayout.Popup( 0, lightType[LightType.Spot], "Light Range");
        //EditorGUILayout.EndHorizontal();



    }


    enum LightType
    {
        Spot,
        Directional,
        Point,
        Area
    }

}
