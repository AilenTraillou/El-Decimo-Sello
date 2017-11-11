using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer : MonoBehaviour, IObservable {


    List<IObserver> screamerObserversList = new List<IObserver>();

    public void Suscribe(IObserver observer)
    {
        screamerObserversList.Add(observer);
    }
    public void Unsuscribe(IObserver observer)
    {
        if (screamerObserversList.Contains(observer))
            screamerObserversList.Remove(observer);
    }


    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.layer == 10)
        {
            foreach (var item in screamerObserversList)
            {
                item.Notify(gameObject);
            }
        }

    }

}
