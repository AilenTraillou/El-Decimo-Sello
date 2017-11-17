using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IObservable
{
    public List<IObserver> observersList = new List<IObserver>();

    public bool hasKey;
    public BoxCollider myCollider;
    bool openDoor = false;
    public new Light light;

    void OnTriggerStay(Collider c)
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (!hasKey)
            {
                foreach (var item in observersList)
                {
                    item.Notify(gameObject);
                }

                openDoor = false;

            }
            else
            {
                if (myCollider.enabled)
                {
                    SoundsManager.instancia.Play((int)SoundID.door, 1, false);
                    myCollider.enabled = false;
                    openDoor = true;
                        
                }
                    
            }
            
        }

        light.enabled = true;

    }

    private void OnTriggerExit(Collider c)
    {
        light.enabled = false;
    }

    private void Update()
    {
        if (openDoor && transform.position.y <= 59)
        transform.position += Vector3.up * 10 * Time.deltaTime;
    }

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
}
