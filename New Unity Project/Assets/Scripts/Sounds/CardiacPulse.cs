using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardiacPulse : MonoBehaviour, IObserver {

    
    public List<IObservable> screamerObs = new List<IObservable>();
    bool startPulse;
    float counter;
    float pulsePitch;
    float volume;

    public void Notify(GameObject _object)
    {
        if (_object.GetComponent<Screamer>())
        {
            volume = 1;
            pulsePitch = 1.6f;
            startPulse = true;
        }
    }

    void Awake()
    {
        screamerObs.AddRange(FindObjectsOfType<Screamer>());

        foreach (var item in screamerObs)
        {
            item.Suscribe(this);
        }
    }

    void Pulse()
    {
        
        SoundsManager.instancia.Play(14, 1, false);
        SoundsManager.instancia.channels[14].pitch = pulsePitch;
        SoundsManager.instancia.channels[14].volume = volume;
    }

    void Update()
    {
        if (startPulse)
        {
            Pulse();
            counter++;
            volume -= 0.0005f;
            pulsePitch -= 0.0005f;
        }

        if (counter > 800)
        {
            startPulse = false;
            counter = 0;
        }
    }

}
