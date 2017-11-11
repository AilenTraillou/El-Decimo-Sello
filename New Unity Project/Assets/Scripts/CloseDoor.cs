using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour {

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public Light door;
    bool openDoor;

    void Start()
    {
        this.gameObject.SetActive(true);
        door.enabled = false;
    }


    void OpenDoor()
    {
        this.gameObject.transform.position += Vector3.up * Time.deltaTime * 5;
    }

    void CloseDialog()
    {
        MessegeController.instance.CloseDialog();
    }

    void Update()
    {
        if (openDoor)
        {
            OpenDoor();
        }

        int layer = this.gameObject.layer;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var layerMask = 1 << layer;
        if (Physics.Raycast(ray, 30f, layerMask))
        {
            //Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            door.enabled = true;
            if (Input.GetMouseButtonDown(0))
            {
                switch (this.gameObject.name)
                {
                    case "door_1":
                        {
                            if (ObjectsCount.instance.getKey_1)
                            {
                                SoundsManager.instancia.Play((int)SoundID.door, 1, false);
                                openDoor = true;
                                Invoke("CloseDialog", 0f);


                            }
                            else
                            {
                                MessegeController.instance.OpenDialog(MessegeDictionary.instance.CreateMessage(MessegeDictionary.PUERTA_1_CASA));
                                Invoke("CloseDialog", 5f);
                            }
                        }
                        break;
                    case "door_2":
                        {
                            if (ObjectsCount.instance.getKey_2)
                            {
                                SoundsManager.instancia.Play((int)SoundID.door, 1, false);
                                openDoor = true;

                            }
                            else
                            {
                                MessegeController.instance.OpenDialog("La puerta se encuentra cerrada...");
                                Invoke("CloseDialog", 5f);
                            }
                        }
                        break;
                }
            }

            
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
            door.enabled = false;
        }
    }

    

}
