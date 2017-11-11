using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BabosaAnimationInspector : MonoBehaviour {



	void Update() {
        if (Application.isEditor)
            GetComponent<Animation>().Play("babosa");

    }

}
