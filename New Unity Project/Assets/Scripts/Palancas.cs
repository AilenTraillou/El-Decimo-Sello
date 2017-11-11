using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palancas : MonoBehaviour {


    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = new Vector2(16,16);
    public Light lever;
    public GameObject manija;
    public Animator anim;
    void Start()
    {

        anim = manija.GetComponent<Animator>();
        anim.speed = 0;
        lever.enabled = false;
    }

    void Update() {

        int layer = this.gameObject.layer;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var layerMask = 1 << layer;
        if (Physics.Raycast(ray, 30f, layerMask))
        {
            if (Input.GetMouseButtonDown(0))
            {
                switch (this.gameObject.name)
                {
                    case "palanca1":
                        {
                            anim.Play("manija1");
                            anim.speed = 1;
                        } break;
                    case "palanca2":
                        {
                            anim.Play("manija2");
                            anim.speed = 1;
                        }
                        break;
                    case "palanca3":
                        {
                            anim.Play("manija3");
                            anim.speed = 1;
                        }
                        break;
                }
                ObjectsCount.instance.getlever++;
            }
            print(cursorTexture.name);
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            lever.enabled = true;
        }
        else
        {
            Cursor.SetCursor(null, hotSpot, cursorMode);
            lever.enabled = false;
        }

        if (ObjectsCount.instance.getlever == 3)
        {
            waterfall.instance.startAnimation = true;
        }
    }
}
