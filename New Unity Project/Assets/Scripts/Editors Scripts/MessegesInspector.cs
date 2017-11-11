using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[ExecuteInEditMode]
//[CustomEditor(typeof(MessegeController))]
public class MessegesInspector : Editor
{

    //MessegeController _target;

    ////List<string> _pickableObjects;
    ////Dictionary<List<string>, string> _pickableObjMesseges;

    ////string[] _interactuableObjects;
    ////Dictionary<List<string>, string> _interactuableObjMesseges;
    ////public int _messageCount;


    //public GameObject llave;
    //Texture2D llaveTexture;
    //string llaveMessage;

    //public GameObject puerta_1;
    //Texture2D puerta_1Texture;
    //string puerta_1Message;

    //private void OnEnable()
    //{
    //    _target = (MessegeController)target;
  
    //}

    //public void OnInspectorGUI()
    //{

    //    ShowMessegeValues();
    //    Repaint();

    //}

    //void ShowMessegeValues()
    //{



    //    //Llave
    //    GUILayout.Space(20);

    //    GUILayout.BeginHorizontal();
    //    llave = (GameObject)EditorGUILayout.ObjectField("Llave", llave, typeof(GameObject), true);
    //    llaveTexture = AssetPreview.GetAssetPreview(llave);
    //    GUILayout.EndHorizontal();

    //    GUILayout.Space(20);


    //    if (llaveTexture != null)
    //    {
    //        Repaint();
    //        GUILayout.BeginHorizontal();
    //        GUI.DrawTexture(GUILayoutUtility.GetRect(70, 70, 70, 70), llaveTexture, ScaleMode.ScaleToFit);
    //        llaveMessage = GUILayout.TextArea(llaveMessage);
    //        GUILayout.EndHorizontal();
    //        GUILayout.Space(20);

    //    }


    //    //puerta 1
    //    puerta_1 = (GameObject)EditorGUILayout.ObjectField("Puerta 1 - Casa", puerta_1, typeof(GameObject), true);
    //    puerta_1Texture = AssetPreview.GetAssetPreview(puerta_1);

    //    GUILayout.Space(20);


    //    if (puerta_1Texture != null)
    //    {
    //        Repaint();
    //        GUILayout.BeginHorizontal();
    //        GUI.DrawTexture(GUILayoutUtility.GetRect(70, 70, 70, 70), puerta_1Texture, ScaleMode.ScaleToFit);
    //        puerta_1Message = EditorGUILayout.TextArea(puerta_1Message);
    //        GUILayout.EndHorizontal();
    //        GUILayout.Space(20);

    //    }

    //}

}
