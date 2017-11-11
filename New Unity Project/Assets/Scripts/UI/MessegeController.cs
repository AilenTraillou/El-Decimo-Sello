using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessegeController : MonoBehaviour {


    public Text messege;

    public Image dialogBox;

    public static MessegeController instance;

    void Awake () {
        instance = this;
        messege.enabled = false;
        dialogBox.enabled = false;
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
}
