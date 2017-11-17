using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLight : MonoBehaviour, IObservable {

    List<IObserver> observersList = new List<IObserver>();

    public void Suscribe(IObserver observer)
    {
        if (!observersList.Contains(observer))
        {
            observersList.Add(observer);
        }
    }

    public void Unsuscribe(IObserver observer)
    {
        if (observersList.Contains(observer))
        {
            observersList.Remove(observer);
        }

    }

    void OnTriggerStay(Collider c)
    {
        if (c.GetComponent<Character>() && Input.GetMouseButtonUp(0))
        {

            for (int i = 0; i < observersList.Count; i++)

            {
                observersList[i].Notify(gameObject);
            }

            //agregar corrutina
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {

        for (int i = 0; i < observersList.Count; i++)

        {
            observersList[i].Notify(gameObject);
        }

    }

}
