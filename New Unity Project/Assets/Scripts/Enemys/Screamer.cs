using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer : MonoBehaviour, IScreamerObservable, ILifeObservable {


    List<IScreamerObserver> observersList = new List<IScreamerObserver>();
    List<ILifeObserver> lifeObservers = new List<ILifeObserver>();

    public void Suscribe(ILifeObserver lifeObserver)
    {
        lifeObservers.Add(lifeObserver);
    }
    public void Unsuscribe(ILifeObserver lifeObserver)
    {
        if (lifeObservers.Contains(lifeObserver))
        {
            lifeObservers.Remove(lifeObserver);
        }
    }

    public void Suscribe(IScreamerObserver screamerObserver)
    {
        observersList.Add(screamerObserver);
    }


    public void Unsuscribe(IScreamerObserver screamerObserver)
    {
        if (observersList.Contains(screamerObserver))
        observersList.Remove(screamerObserver);
    }


    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.layer == 10)
        {
            foreach (var item in observersList)
            {
                item.CameraBlackEffect();
            }

            foreach (var item in lifeObservers)
            {
                item.TakeDamage();
            }
        }

    }

}
