using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScreamerObservable
{

    void Suscribe(IScreamerObserver screamerObserver);

    void Unsuscribe(IScreamerObserver screamerObserver);

}
