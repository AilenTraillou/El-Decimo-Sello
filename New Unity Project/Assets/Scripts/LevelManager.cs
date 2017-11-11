using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public Transform character;
    public Transform level;
    private float distance;
    private float range = 60;

	void Start () {

        
       

    }
	
	void Update () {

        distance = (character.transform.position - level.transform.position).magnitude;
        //print(distance);

        if (distance < range)
        {

            SceneManager.LoadScene(2);

        }
	}


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
     
    }

}
