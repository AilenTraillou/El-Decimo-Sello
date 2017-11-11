using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDoor : MonoBehaviour
{
    public bool hasKey;
    public BoxCollider myCollider;
    bool openDoor = false;
    public new Light light;

    void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (!hasKey)
            {
                MessegeController.instance.OpenDialog("La puerta se encuentra cerrada...");
                Invoke("CloseDialog", 2);
                openDoor = false;

            }
            else
            {
                if (myCollider.enabled)
                {
                    SoundsManager.instancia.Play((int)SoundID.door, 1, false);
                    myCollider.enabled = false;
                    openDoor = true;
                        
                }
                    
            }
            
        }

        light.enabled = true;

    }

    private void OnTriggerExit(Collider other)
    {
        light.enabled = false;
    }

    private void Update()
    {
        if (openDoor && transform.position.y <= 59)
        transform.position += Vector3.up * 10 * Time.deltaTime;
    }

    public void CloseDialog()
    {
        MessegeController.instance.CloseDialog();
    }
}
