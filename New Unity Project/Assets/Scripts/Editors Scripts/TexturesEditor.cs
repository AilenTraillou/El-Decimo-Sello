using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Threading;
using UnityEditor.AnimatedValues;


public class TexturesEditor : EditorWindow {


    private bool _groupEnabled;
    private bool _groupBoolExample;
    private string _groupStringExample;
    private float _groupFloatExample;
    private float _clicks;
    private Texture2D _preview;
    private GameObject _goToPreview;

    bool showEnemies;


    [MenuItem("Editor Windows/Textures Manager")]

    
    static void CreeateWindow()
    {
        GetWindow(typeof(TexturesEditor)).Show();
    }

    void OnEnable()
    {
        //showEnemies = new AnimBool(false);
        //showEnemies.valueChanged.AddListener(Repaint);

    }

    void OnGUI()
    {
        maxSize = new Vector2(1300, 600);
        minSize = new Vector2(1000, 600);

        Repaint();

        //GUI.Label(new Rect(new Vector2(15, 15), new Vector2(100, 100)), "Enemigos");

        //Espaciado
        EditorGUILayout.BeginVertical(GUIStyle.none);
        GUILayout.Space(10);        
        EditorGUILayout.EndVertical();
     


        EditorGUILayout.BeginHorizontal(GUILayout.Width(50));

        //Espaciado
        EditorGUILayout.LabelField("", GUILayout.Width(50));

        EditorGUILayout.LabelField("Escenario", GUILayout.Width(120));
        EditorGUILayout.LabelField("Objetos Decorativos", GUILayout.Width(190));
        EditorGUILayout.LabelField("Objetos Interactuables", GUILayout.Width(200));
        EditorGUILayout.LabelField("Enemigos", GUILayout.Width(120));
        EditorGUILayout.LabelField("Personaje", GUILayout.Width(200));
        

        EditorGUILayout.EndHorizontal();



        showEnemies = EditorGUILayout.Foldout(showEnemies, "Lista de Enemigos");

        if (showEnemies)
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(30);
            EditorGUILayout.LabelField("Strei");
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(30);
            EditorGUILayout.LabelField("Hiena");
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(30);
            EditorGUILayout.LabelField("Acuatico");
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(30);
            EditorGUILayout.LabelField("Babosa");
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(30);
            EditorGUILayout.LabelField("Esqueleto");
            EditorGUILayout.EndHorizontal();
            
        }


        /*
        EJEMPLO GROUP:

        Para iniciar un grupo se utiliza EditorGUILayout.BeginToggleGroup(Texto del toggle, si se habilita o no).
        Todo lo que sigue dentro del mismo es un grupo.
        Para terminar el grupo se usa EditorGUILayout.EndToogleGroup().
        */
        _groupEnabled = EditorGUILayout.BeginToggleGroup("Toggle Group Example", _groupEnabled);
        _groupBoolExample = EditorGUILayout.Toggle("Bool Example", _groupBoolExample);
        _groupStringExample = EditorGUILayout.TextField("String Example", _groupStringExample);
        _groupFloatExample = EditorGUILayout.FloatField("Float Example", _groupFloatExample);
        EditorGUILayout.EndToggleGroup();

            

        /*
        EJEMPLO BOTON:

        En este ejemplo, tenemos un boton que con cada click suma uno
        */
        Rect rectAdd = EditorGUILayout.BeginHorizontal("Button");
        if (GUI.Button(rectAdd, GUIContent.none))
            _clicks++;
        GUILayout.Label("+1 Click");
        EditorGUILayout.EndHorizontal();
        GUILayout.Label("Total Clicks: " + _clicks);

        /*
        EJEMPLO CERRAR VENTANA:

        Creamos un botón que al hacerle click se cierre la ventana.
        Como nuestra ventana hereda de EditorWindow, podemos usar la función Close()
        */
        Rect rectClose = EditorGUILayout.BeginHorizontal("Button");
        if (GUI.Button(rectClose, GUIContent.none))
            Close();
        GUILayout.Label("Cerrar Ventana");
        EditorGUILayout.EndHorizontal();

        /*
        EJEMPLO ABRIR OTRA VENTANA:

        Creamos un botón que al hacerle click abra otra ventana.
        //*/
        //Rect rectOpenNew = EditorGUILayout.BeginHorizontal("Button");
        //if (GUI.Button(rectOpenNew, GUIContent.none))
        //    ((OpenAnotherWindowExample)GetWindow(typeof(OpenAnotherWindowExample))).Show();
        //GUILayout.Label("Abrir la otra ventana");
        //EditorGUILayout.EndHorizontal();

        /*
        EJEMPLO FOCO:

        Podemos saber si el usuario tiene el foco sobre esta ventana
        */
        if (focusedWindow == this) EditorGUILayout.LabelField("Tengo el foco en esta ventana");

        /*
        EJEMPLO MOUSE OVER:

        Podemos saber si el usuario tiene el mouse sobre la ventana
        */
        if (mouseOverWindow == this) EditorGUILayout.LabelField("Tengo el mouse sobre esta ventana");

        /*
  
        EJEMPLO LEER MOVIMIENTO DEL MOUSE:
        
        Podemos detectar los eventos de movimiento del mouse
        */
        wantsMouseMove = true; // Por defecto viene false. Sin esto no podemos detectar los comportamientos del mouse
        EditorGUILayout.LabelField("Posición del mouse: ", Event.current.mousePosition.ToString());
        if (Event.current.type == EventType.MouseMove) Repaint();

        /*
        EJEMPLO MOSTRAR UN PREVIEW:

        Podemos mostrar un preview de casi cualquier cosa
        */
        _goToPreview = (GameObject)EditorGUILayout.ObjectField("Objeto: ", _goToPreview, typeof(GameObject), true);
        _preview = AssetPreview.GetAssetPreview(_goToPreview);
        if (_preview != null)
        {
            Repaint();
            //GUILayout.BeginHorizontal();
            GUI.DrawTexture(GUILayoutUtility.GetRect(250, 250, 250, 250), _preview, ScaleMode.ScaleToFit);
            GUILayout.Label(_goToPreview.name);
            GUILayout.Label(AssetDatabase.GetAssetPath(_goToPreview));
            //GUILayout.EndHorizontal();
        }
        else
            EditorGUILayout.LabelField("No existe ninguna preview");


        _goToPreview = (GameObject)EditorGUILayout.ObjectField("Objeto: ", _goToPreview, typeof(GameObject), true);
        _preview = AssetPreview.GetAssetPreview(_goToPreview);
        if (_preview != null)
        {
            Repaint();
            GUILayout.BeginHorizontal();
            GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50, 50, 50), _preview, ScaleMode.ScaleToFit);
            GUILayout.Label(_goToPreview.name);
            GUILayout.Label(AssetDatabase.GetAssetPath(_goToPreview));
            GUILayout.EndHorizontal();
        }
        else
            EditorGUILayout.LabelField("No existe ninguna preview");


    }
}


