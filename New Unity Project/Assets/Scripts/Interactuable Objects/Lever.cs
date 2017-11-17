using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IObservable {

    List<IObserver> observerList = new List<IObserver>();

    public void Suscribe(IObserver observer)
    {
        if (!observerList.Contains(observer))
        {
            observerList.Add(observer);
        }
    }

    public void Unsuscribe(IObserver observer)
    {
        if (observerList.Contains(observer))
        {
            observerList.Remove(observer);
        }
    }

    void OnTriggerStay(Collider c)
    {
        if (c.GetComponent<Character>() && Input.GetMouseButtonUp(0))
        {
            foreach (var item in observerList)
            {
                item.Notify(gameObject);
            }

            ObjectsCount.instance.getlever++;

            if (ObjectsCount.instance.getlever == 3)
            {
                waterfall.instance.startAnimation = true;

            }
        }

    }
}
