using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyObservable {


    void Suscribe(IEnemyObserver enemyObserver);

    void Unsuscribe(IEnemyObserver enemyObserver);
}
