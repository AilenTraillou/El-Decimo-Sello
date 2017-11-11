using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraBlackEffect : MonoBehaviour, IScreamerObserver
{
    public IScreamerObservable screamer;
    public Image blackScreen;
    public Image screamerImage;
    bool blackScreenOn;
    byte _newAplha = 0;

    void Awake () {

        screamer = FindObjectOfType<Screamer>();
        screamer.Suscribe(this);

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

            Color newAlpha = new Color32((byte)blackScreen.color.r,
            (byte)blackScreen.color.g, (byte)blackScreen.color.b, _newAplha);


            Color newScreamerAlpha = new Color32(109, 72, 72, _newAplha);

            blackScreen.color = newAlpha;
            screamerImage.color = newScreamerAlpha;
        }

    }


    void IScreamerObserver.CameraBlackEffect()
    {
        SoundsManager.instancia.Play((int)SoundID.screamer, 1, false);
        blackScreenOn = true;

    }

    

}
