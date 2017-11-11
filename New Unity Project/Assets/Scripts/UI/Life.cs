using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour, IObserver {

    public Image lifeImage;
    public IObservable lifeObs;
    public IObservable screamerObs;
    float lifeValue = 100;

    public void Notify(GameObject _object)
    {
        if (_object.GetComponent<Screamer>())
        {
            lifeValue -= 20;
            MainPlayer.instance.AddFear(70f);
        }
    }

    void Awake () {

        lifeObs = FindObjectOfType<Character>();
        lifeObs.Suscribe(this);

        screamerObs = FindObjectOfType<Screamer>();
        screamerObs.Suscribe(this);
    }

    private void Update()
    {        
        lifeImage.fillAmount = lifeValue / 100;
    }
}
