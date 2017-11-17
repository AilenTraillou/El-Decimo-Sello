using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IObservable
{
    List<IObserver> observerList = new List<IObserver>();
    public Door door;

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

            door.hasKey = true;
            Destroy(gameObject);
        }

    }
}
