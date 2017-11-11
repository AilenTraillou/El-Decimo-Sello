using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour, IEnemyObserver {


    float life = 3;
    public IEnemyObservable lightBlinderObservable;
    bool RestLifeisactive = false;

    public Material enemyMaterial;
    bool changeAlpha = false;
     
    public void RestAlphaEnemy()
    {

        changeAlpha = !changeAlpha;

    }


    public void ChangeAlpha(byte newcolor)
    {
        Color newAlpha = new Color32((byte)enemyMaterial.color.r, 
                        (byte)enemyMaterial.color.g, (byte)enemyMaterial.color.b, (byte)enemyMaterial.color.a);
        enemyMaterial.color = newAlpha;

    }

    public void RestEnemyLife()
    {
        RestLifeisactive = !RestLifeisactive;
 
    }

    void Awake ()
    {

        lightBlinderObservable = FindObjectOfType<LightBlinder>();
        lightBlinderObservable.Suscribe(this);


    }
	
	void Update () {

        if (RestLifeisactive)
        {
            print(life);
            life -= 0.01f;
        }

        if (life <= 0)
        {
            Destroy(this.gameObject);
        }

        print(changeAlpha);

        if (changeAlpha)
        {
            var auxAlpha = enemyMaterial.color.a;
            auxAlpha--;
            ChangeAlpha((byte)auxAlpha);
            print(auxAlpha);
        }

    }
}
