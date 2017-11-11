using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzTitila : MonoBehaviour
{
    Light myLight;
    float currentFloat;

	void Awake ()
    {
        myLight = GetComponent<Light>();
        StartCoroutine(LightOnOff());
	}

    IEnumerator LightOnOff()
    {
        yield return new WaitForSeconds(currentFloat);
        myLight.enabled = false;
        yield return new WaitForSeconds(currentFloat);
        myLight.enabled = true;
        currentFloat = Random.Range(0.1f, 0.4f);
        StartCoroutine(LightOnOff());
    }
	
}
