using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILifeObservable {


    void Suscribe(ILifeObserver lifeObserver);

    void Unsuscribe(ILifeObserver lifeObserver);

}
