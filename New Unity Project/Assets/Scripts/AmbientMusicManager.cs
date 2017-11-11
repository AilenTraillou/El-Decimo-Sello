using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientMusicManager : MonoBehaviour {

	void Start () {

        SoundsManager.instancia.Play((int)SoundID.Cementery_Music, 1, true);

    }
	
}
