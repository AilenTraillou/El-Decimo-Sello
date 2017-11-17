using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour, IObserver {

    public Image lifeImage;
    public IObservable lifeObs;
    public List<IObservable> screamerObs = new List<IObservable>();
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

        screamerObs.AddRange(FindObjectsOfType<Screamer>());

        foreach (var item in screamerObs)
        {
            item.Suscribe(this);
        }
    }

    private void Update()
    {

        RecoveryLife();
        lifeImage.fillAmount = lifeValue / 100;

    }

    void RecoveryLife()
    {
        lifeValue += 0.001f;
    }
}
