using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour, ILifeObserver {

    public Image lifeImage;
    public ILifeObservable lifeObs;
    public ILifeObservable screamerObs;
    float lifeValue = 100;
    
    public void TakeDamage()
    {
        print("dadadsad");
        lifeValue -= 20;
        MainPlayer.instance.AddFear(70f);

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
