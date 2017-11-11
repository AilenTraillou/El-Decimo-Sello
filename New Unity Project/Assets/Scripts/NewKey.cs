using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewKey : MonoBehaviour
{
    public Light[] managerLight;
    public NewDoor myDoor;

    void Awake()
    {
        
        //var t = GameObject.FindGameObjectsWithTag("LucesAModificar");
        //for(var i =0; i<t.Length;i++)
        //{
        //    managerLight[i] = t[i].GetComponent<Light>();
        //}

    }
    void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<Character>() && Input.GetMouseButtonUp(0))
        {
            MessegeController.instance.OpenDialog("Llave encontrada");
            this.gameObject.SetActive(false);
            ObjectsCount.instance.getKey_1 = true;
            myDoor.hasKey = true;
            Invoke("CloseDialog", 2);
        }

    }
}
