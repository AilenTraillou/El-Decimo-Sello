using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StreiAI))]
public class StreiInspector : Editor {
    StreiAI _target;
    private void OnEnable()
    {
        _target = (StreiAI)target;
    }

    public override void OnInspectorGUI()
    {
        ShowOriginalValues();


        Repaint();
    }

    void ShowOriginalValues()
    {

        EditorGUILayout.BeginHorizontal();
        _target.speed = EditorGUILayout.FloatField("Speed", _target.speed);
        EditorGUILayout.EndHorizontal();

        if (_target.speed <= 0)
        {
            EditorGUILayout.HelpBox("La velocidad no puede ser nula o negativa", MessageType.Error);
        }
        if (_target.speed >20)
        {
            EditorGUILayout.HelpBox("La velocidad no puede ser mayor a 20", MessageType.Error);
        }
        EditorGUILayout.BeginHorizontal();
        _target._followRange = EditorGUILayout.IntField("Follow range", _target._followRange);
        EditorGUILayout.EndHorizontal();

        if (_target._followRange <= 0)
        {
            EditorGUILayout.HelpBox("El rango de persecucion no puede ser nulo o negativo", MessageType.Error);
        }
        EditorGUILayout.BeginHorizontal();
        _target._attackRange = EditorGUILayout.IntField("Attack range", _target._attackRange);
        EditorGUILayout.EndHorizontal();
        if (_target._attackRange >= _target._followRange)
        {
            EditorGUILayout.HelpBox("El rango de ataque no puede superar o ser igual al rango de persecucion", MessageType.Error);
        }

        if (_target._attackRange <=0)
        {
            EditorGUILayout.HelpBox("El rango de ataque no puede ser nulo o negativo", MessageType.Error);
        }

        //if (_target.pointlight != null)
        //{

        //    EditorGUILayout.BeginHorizontal();
        //    _target.pointlight = (Light)EditorGUILayout.ObjectField("Light", _target.particles, typeof(GameObject), true);
        //    EditorGUILayout.EndHorizontal();

        //    EditorGUILayout.BeginHorizontal();
        //_target.pointlight.intensity = EditorGUILayout.FloatField("Light intensity", _target.pointlight.intensity);
        //EditorGUILayout.EndHorizontal();

        //if (_target.pointlight.intensity > 8)
        //{
        //    EditorGUILayout.HelpBox("La intensidad de la luz no puede ser mayor a 8", MessageType.Error);
        //}


        //EditorGUILayout.BeginHorizontal();
        //_target.pointlight.range = EditorGUILayout.FloatField("Light range", _target.pointlight.range);
        //EditorGUILayout.EndHorizontal();
        //}


        EditorGUILayout.BeginHorizontal();
        _target.particles = (GameObject)EditorGUILayout.ObjectField("Particles", _target.particles, typeof(GameObject), true);
        EditorGUILayout.EndHorizontal();


        if (_target.particles == null)
        {
            EditorGUILayout.HelpBox("El enemigo no tiene particulas", MessageType.Error);
        }

    }

}
