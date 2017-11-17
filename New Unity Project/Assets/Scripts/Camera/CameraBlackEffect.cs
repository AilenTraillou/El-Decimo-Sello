using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraBlackEffect : MonoBehaviour, IObserver
{
    public List<IObservable> screamer = new List<IObservable>();
    public Image monsterScreamer;
    public Image ghostScreamer;
    bool blackScreenOn;
    byte _newAplha = 0;
    string screamerName;

    void Awake () {

        screamer.AddRange(FindObjectsOfType<Screamer>());

        foreach (var item in screamer)
        {
            item.Suscribe(this);
        }

    }

    void Update()
    {
        if (blackScreenOn)
        {
            _newAplha = 255;
            blackScreenOn = false;
        }

        if (_newAplha != 0)
        {
            _newAplha--;

            Color newScreamerAlpha = new Color32(109, 72, 72, _newAplha);

            if (screamerName == "Painting 4 Screamer")
            {
                monsterScreamer.color = newScreamerAlpha;
                MainPlayer.instance.AddFear(70f);
            }
            if (screamerName == "Painting 2 Screamer")
            {
                ghostScreamer.color = newScreamerAlpha;
                MainPlayer.instance.AddFear(70f);

            }
        }

    }

    public void Notify(GameObject _object)
    {
        screamerName = _object.name;

        if (screamerName == "Painting 4 Screamer")
            SoundsManager.instancia.Play((int)SoundID.monster_screamer, 1, false);
        if (screamerName == "Painting 2 Screamer")
            SoundsManager.instancia.Play((int)SoundID.ghost_screamer, 1, false);

        blackScreenOn = true;
    }
}
