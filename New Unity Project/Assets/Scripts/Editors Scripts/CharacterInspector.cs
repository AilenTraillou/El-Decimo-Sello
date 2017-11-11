using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Character))]
public class CharacterInspector : Editor {

    Character _target;

    float _defaultSpeed = 40f;
    float _defaultJumpForce = 30f;
    float _defaultCurrentLife = 100f;
    float _defaultMaxLife = 100f;
    float _defaultLightIntensity = 5.52f;
    float _defaultLightRange = 100f;


    private void OnEnable()
    {
        _target = (Character)target;
    }

    public void OnInspectorGUI()
    {
        ShowValuesOnInspector();
        Repaint();
    }

    void ShowValuesOnInspector()
    {


        GUILayout.Space(20);

        ///Validacion de si los valores ingresados sin distintos a los default
        if (_target.speed != _defaultSpeed ||
            _target.jumpStr != _defaultJumpForce ||
            _target.life.CurrentVal != _defaultCurrentLife ||
            _target.life.MaxVal != _defaultMaxLife ||
            _target.light.intensity != _defaultLightIntensity ||
            _target.light.range != _defaultLightRange)
        {
            EditorGUILayout.HelpBox("Los valores ingresados son distintos a los predeterminados", MessageType.Info);
        }

        GUILayout.Space(20);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Default Speed: " + _defaultSpeed, EditorStyles.largeLabel);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Default Jump Force : " + _defaultJumpForce, EditorStyles.largeLabel);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Default current Life: " + _defaultCurrentLife, EditorStyles.largeLabel);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Default Max Life: " + _defaultMaxLife, EditorStyles.largeLabel);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Default Light Intensity: " + _defaultLightIntensity, EditorStyles.largeLabel);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Default Light Range: " + _defaultLightRange, EditorStyles.largeLabel);
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(20);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Variables fisicas", EditorStyles.boldLabel);
        EditorGUILayout.EndHorizontal();

        ///Campo Speed
        EditorGUILayout.BeginHorizontal();
        _target.speed = EditorGUILayout.FloatField("Speed", _target.speed);
        EditorGUILayout.EndHorizontal();

        if (_target.speed <= 0)
        {
            EditorGUILayout.HelpBox("La velocidad no puede ser nula o negativa", MessageType.Error);
        }
        if (_target.speed > 40)
        {
            EditorGUILayout.HelpBox("La velocidad no puede ser mayor a 40", MessageType.Warning);
        }

        ///Campo Fuerza de Salto
        EditorGUILayout.BeginHorizontal();
        _target.jumpStr = EditorGUILayout.FloatField("Jump Force", _target.jumpStr);
        EditorGUILayout.EndHorizontal();
        if (_target.jumpStr <= 0)
        {
            EditorGUILayout.HelpBox("La fuerza de salto no puede ser nula o negativa", MessageType.Error);
        }
        if (_target.jumpStr > 30)
        {
            EditorGUILayout.HelpBox("La fuerza de salto no puede ser mayor a 30", MessageType.Warning);
        }

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Variables de stats", EditorStyles.boldLabel);
        EditorGUILayout.EndHorizontal();

        ///Campo Vida actual
        EditorGUILayout.BeginHorizontal();
        _target.life.CurrentVal = EditorGUILayout.FloatField("Current Life Value", _target.life.CurrentVal);
        EditorGUILayout.EndHorizontal();
        if (_target.life.CurrentVal < 0)
        {
            EditorGUILayout.HelpBox("La vida actual no puede ser negativa", MessageType.Error);
        }
        if (_target.life.CurrentVal > _target.life.MaxVal)
        {
            EditorGUILayout.HelpBox("La vida actual no puede ser mayor a la vida maxima", MessageType.Error);
        }

        ///Campo Vida Maxima
        EditorGUILayout.BeginHorizontal();
        _target.life.MaxVal = EditorGUILayout.FloatField("Life Max Value", _target.life.MaxVal);
        EditorGUILayout.EndHorizontal();
        if (_target.life.MaxVal < 100)
        {
            EditorGUILayout.HelpBox("El maximo de vida no puede ser menor a 100", MessageType.Error);
        }

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Variables de luces", EditorStyles.boldLabel);
        EditorGUILayout.EndHorizontal();

        ///Campo Intensidad de la luz del farol del personaje. 
        EditorGUILayout.BeginHorizontal();
        _target.light.intensity =  EditorGUILayout.FloatField("Light Intensity", _target.light.intensity);
        EditorGUILayout.EndHorizontal();
        if (_target.light.intensity > 8)
        {
            EditorGUILayout.HelpBox("La intensidad de la luz no puede ser mayor a 8", MessageType.Warning);
        }


        ///Campo Rango de la luz del farol del personaje.
        EditorGUILayout.BeginHorizontal();
        _target.light.range = EditorGUILayout.FloatField("Light Range", _target.light.range);
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(20);

        ///Reestablecer valores por defecto.
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Reestablecer valores" + "\n" + "por default"))
        {
           
            _target.speed = _defaultSpeed;
            _target.jumpStr = _defaultJumpForce;
            _target.life.CurrentVal = _defaultCurrentLife;
            _target.life.MaxVal = _defaultMaxLife;
            _target.light.intensity = _defaultLightIntensity;
            _target.light.range = _defaultLightRange;

        }

        if (GUILayout.Button("Guardar valores" + "\n" +  "como default"))
        {
            bool opcion = EditorUtility.DisplayDialog("Advertencia",
                "Esta a punto de sobreescribir los valores por default. ¿Desea Continuar?",
                "Aceptar", "Cancelar");

            if (opcion)
            {
                _defaultSpeed = _target.speed;
                _defaultJumpForce = _target.jumpStr;
                _defaultCurrentLife = _target.life.CurrentVal;
                _defaultMaxLife = _target.life.MaxVal;
                _defaultLightIntensity = _target.light.intensity;
                _defaultLightRange = _target.light.range;
            }


        }

        EditorGUILayout.EndHorizontal();

        GUILayout.Space(20);

    }

}
