using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public Light key;
    public GameObject door;

    void Start()
    {
        this.gameObject.SetActive(true);
        key.enabled = false;
    }

    public void CloseDialog()
    {
        MessegeController.instance.CloseDialog();
    }

    void Update()
    {
        int layer = this.gameObject.layer;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var layerMask = 1 << layer;
        if (Physics.Raycast(ray, 30f, layerMask))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (this.gameObject.name == "llave2")
                {
                    MessegeController.instance.OpenDialog("Llave encontrada");
                    this.gameObject.SetActive(false);
                    ObjectsCount.instance.getKey_2 = true;
                }

                if (this.gameObject.name == "llave1")
                {
                    MessegeController.instance.OpenDialog("Llave encontrada");
                    this.gameObject.SetActive(false);
                    ObjectsCount.instance.getKey_1 = true;
                }
                if (this.gameObject.tag == "switch")
                {
                    MessegeController.instance.OpenDialog("Se ha abierto una puerta");
                    if(door != null)
                    {
                        OpenDoor();

                    }

                }

                Cursor.SetCursor(null, Vector2.zero, cursorMode);
                Invoke("CloseDialog", 2f);
            }

            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            key.enabled = true;
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
            key.enabled = false;
        }


    }
    public void OpenDoor()
    {
        if (door.transform.position.y < 60)
        {
            door.transform.position += Vector3.up * Time.deltaTime * 15;

        }
    }


}
