using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acuatico1 : MonoBehaviour {

    public StreiAI ai;
    public GameObject ph;
    private float _distance;
	void Start () {

        
    }
	
	void Update () {
        var distance = (ph.transform.position - this.transform.position).magnitude;
        _distance = distance;

        if (waterfall.instance.startAnimation)
        {
            ai.enabled = false;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
            Quaternion.LookRotation(ph.transform.position - this.transform.position), 5f * Time.deltaTime);
            if(_distance > 9)
            {
                this.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                this.transform.position += this.transform.forward * 25 * Time.deltaTime;
            }else
            {
                this.transform.position += Vector3.down * 25 * Time.deltaTime;
            }
            
        }
	}
}
