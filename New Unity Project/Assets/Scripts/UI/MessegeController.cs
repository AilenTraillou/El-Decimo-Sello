using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessegeController : MonoBehaviour, IObserver {

    List<IObservable> interactuableObjectsList = new List<IObservable>();
    public Text messege;
    public Image dialogBox;
    string messageToWrite;

    void Awake () {

        messege.enabled = false;
        dialogBox.enabled = false;

        interactuableObjectsList.AddRange(FindObjectsOfType<Key>());
        interactuableObjectsList.AddRange(FindObjectsOfType<Door>());
        interactuableObjectsList.AddRange(FindObjectsOfType<PowerUpLight>());

        foreach (var item in interactuableObjectsList)
        {
            item.Suscribe(this);
        }
	}
	
    public void OpenDialog(string messegeContent)
    {
        messege.enabled = true;
        dialogBox.enabled = true;
        messege.text = messegeContent;

    }

    public void CloseDialog()
    {
        messege.enabled = false;
        dialogBox.enabled = false;
    }

    public void Notify(GameObject _object)
    {
        if (_object.GetComponent<Key>())
        {
            messageToWrite = "Key found";
        }
        if (_object.GetComponent<Door>())
        {
            messageToWrite = "The door is closed";
        }
        if (_object.GetComponent<PowerUpLight>())
        {
            messageToWrite = "Substance found";
        }
        OpenDialog(messageToWrite);
        Invoke("CloseDialog", 2f);
    }
}
