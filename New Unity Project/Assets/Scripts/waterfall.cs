using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterfall : MonoBehaviour {

    public static waterfall instance;
    public bool startAnimation;
    public GameObject waterFloor1;
    public GameObject waterFloor2;
    public Animator anim;
    public GameObject wall;
    public ParticleSystem waterfall1;
    public ParticleSystem waterfall2;
    public ParticleSystem waterfall3;
    public ParticleSystem waterfall4;
    public AudioSource waterfallAudio;
    private float volume = 5;
    void Start () {

        anim = GetComponent<Animator>();
        anim.speed = 0;
        instance = this;

    }

    void Update () {
        volume -= Time.deltaTime * 0.5f;
		if (startAnimation)
        {
            waterFloor1.transform.position += Vector3.down * Time.deltaTime * 1;
            waterFloor2.transform.position += Vector3.down * Time.deltaTime * 1;
            if (wall.transform.position.y <= -23)
            {
                wall.transform.position += Vector3.up * Time.deltaTime * 2;
            }

            waterfall1.Stop();
            waterfall2.Stop();
            waterfall3.Stop();
            waterfall4.Stop();
            waterfallAudio.volume -= Time.deltaTime;
            volume -= 0.00005f;
            if (volume > -6)
            {
                SoundsManager.instancia.Play((int)SoundID.agua_drenando, volume, false);
            }
            
        }
	}
}
