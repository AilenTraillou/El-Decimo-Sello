using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (SoundsManager))]
public class SoundInspector : Editor {

    //SoundsManager _target;
    //bool muteSound;
    //string soundName;

    //AudioClip[] _audioList;
    //List<bool> _muteAudioList = new List<bool>();
    //List<float> _volumeAudioList;
    //List<bool> _playSound = new List<bool>();

    //List<bool> _temporal_MuteAudioList = new List<bool>();
    //List<float> _temporal_volumeAudioList;
    //List<bool> _temporal_playSound = new List<bool>();

    //bool _showAudioList;
    //List<bool> _showAudioOptions = new List<bool>();

    //private void OnEnable()
    //{
    //    //El target es el scripts que manipula los sonidos.
    //    _target = (SoundsManager)target;

    //    //Inicializo las listas.

    //    InitializeList(_muteAudioList);
    //    InitializeList(_playSound);
    //    InitializeList(_volumeAudioList);

    //    InitializeList(_temporal_MuteAudioList);
    //    InitializeList(_temporal_playSound);
    //    InitializeList(_temporal_volumeAudioList);


    //}

    //public void OnInspectorGUI()
    //{

    //    ShowSoundValues();
    //    Repaint();

    //}

    //void ShowSoundValues()
    //{

       
    //    GUILayout.Space(20);

    //    //Muestro la lista de sonidos.
    //    _showAudioList = EditorGUILayout.Foldout(_showAudioList, "Sounds List");

    //    if (_showAudioList)
    //    {
    //        //Recorro la lista de sonidos del target.
    //        for (int i = 0; i < _target.clips.Length; i++)
    //        {
    //            //Agrego opcion para mostrar parametros de cada sonido a la lista.
    //            _showAudioOptions.Add(false);

    //            //Muestro los sonidos.
    //            EditorGUILayout.BeginHorizontal();
    //            _target.clips[i] = (AudioClip)EditorGUILayout.ObjectField(_target.clips[i].name, _target.clips[i], 
    //                                typeof(AudioClip), true);
    //            EditorGUILayout.EndHorizontal();

    //            //Muestro del desplegable de los parametros de cada sonido.
    //            EditorGUILayout.BeginHorizontal();
    //            GUILayout.Space(15);
    //            _showAudioOptions[i] = EditorGUILayout.Foldout(_showAudioOptions[i], "Sound Options");
    //            EditorGUILayout.EndHorizontal();

    //            //Si abro el desplegable, se muestran las opciones de cada sonido.
    //            if (_showAudioOptions[i])
    //            {

    //                //Opcion de muteado del sonido.
    //                _muteAudioList.Add(false);
    //                EditorGUILayout.BeginHorizontal();
    //                GUILayout.Space(20);
    //                _muteAudioList[i] = EditorGUILayout.Toggle("Mute Audio", _muteAudioList[i]);
    //                EditorGUILayout.EndHorizontal();

    //                //Slider del Volumen del Sonido.

    //                _volumeAudioList.Add(1);
    //                EditorGUILayout.BeginHorizontal();
    //                GUILayout.Space(20);
    //                EditorGUILayout.LabelField("Volume");
    //                _volumeAudioList[i] = EditorGUILayout.Slider(_volumeAudioList[i], 0f, 1f);
    //                EditorGUILayout.EndHorizontal();

    //            }

    //        }

    //        GUILayout.Space(20);

    //    }


    //}


    //void InitializeList<T>(List<T> list)
    //{
    //    if (list != null)
    //    {
    //        list = new List<T>();
    //    }
    //    else
    //    {
    //        list.Clear();
    //    }
    //}
}
