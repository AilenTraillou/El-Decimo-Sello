using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlinder : MonoBehaviour, IObserver, IEnemyObservable
{
    public List<IEnemyObserver> enemyObserversList= new List<IEnemyObserver>();

    public ManaManager manaManager;
    private IObservable consumeMana;
    public new Light light;
    Color baseColor = new Color(0.99f, 0.92f, 0.31f, 255);
    Color effectBlueColor = new Color(0.31f, 0.77f, 0.99f, 255);
    bool consumeManaIsActive = false;


    void Awake()
    {
        consumeMana = FindObjectOfType<ConsumeMana>();
        consumeMana.Suscribe(this);

        manaManager = FindObjectOfType<ManaManager>();
    }

    public void Suscribe(IEnemyObserver enemyObserver)
    {
        if (!enemyObserversList.Contains(enemyObserver))
        {
            enemyObserversList.Add(enemyObserver);
        }
    }

    public void Unsuscribe(IEnemyObserver enemyObserver)
    {

        if (enemyObserversList.Contains(enemyObserver))
        {
            enemyObserversList.Remove(enemyObserver);
        }
    }

    void Update()
    {

        if (manaManager.mana.fillAmount == 0)
        {
            
            light.color = baseColor;

        }
    }

    public void Notify(GameObject _object)
    {
        consumeManaIsActive = !consumeManaIsActive;
        if (consumeManaIsActive)
        {
            light.color = effectBlueColor;
            light.intensity = 3.08f;

            for (int i = 0; i < enemyObserversList.Count; i++)
            {
                enemyObserversList[i].RestEnemyLife();
                enemyObserversList[i].RestAlphaEnemy();
            }
        }
        else
        {
            light.color = baseColor;

        }
    }
}
