using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Babosa : MonoBehaviour{


    public Transform phBabosa;
    public Transform playerarm;

    private float _distanceBabosa;

    private float speedBabosa = 15f;

    private int followRangeBabosa = 40;
    private int _attackRangeBabosa = 20;

    private bool _detectedBabosa;

    private float _rotationSpeedBabosa = 5f;

    public GameObject particles;

    public GameObject ph_particles;

    public bool compuerta;


    void Start()
    {
        compuerta = true;
        phBabosa = this.transform;
        playerarm = GameObject.Find("brazo").gameObject.transform;
        GetComponent<Animation>().Stop("babosa");
    }

    void Update()
    {
        var distance = (playerarm.transform.position - phBabosa.transform.position).magnitude;
        _distanceBabosa = distance;


        if (_distanceBabosa <= followRangeBabosa)
        {

            _detectedBabosa = true;
        }
        else
        {
            GetComponent<Animation>().Stop("babosa");
            _detectedBabosa = false;
        }

        if (_detectedBabosa)
        {

            GetComponent<Animation>().Play("babosa");

            FollowThePlayer();
        }

        if (compuerta)
        {
            if (CompuertaAutomatica.instance._detected)
            {
                compuerta = false;
                Destroy(this.gameObject);
            }
        }
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, followRangeBabosa);

    }

    void FollowThePlayer()
    {



        if (_distanceBabosa >= _attackRangeBabosa)
        {
            phBabosa.position += phBabosa.forward * speedBabosa * Time.deltaTime;
        }

        if (_distanceBabosa <= _attackRangeBabosa)
        {
            Attack();
        }

        phBabosa.rotation = Quaternion.Slerp(phBabosa.rotation, Quaternion.LookRotation(playerarm.position - phBabosa.position), _rotationSpeedBabosa * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        SoundsManager.instancia.Play((int)SoundID.Sonido_bicho, 1.5f, false);

    }


    void Attack()
    {
        GameObject attack_effect = GameObject.Instantiate(particles);
        attack_effect.transform.position = ph_particles.transform.position;
        attack_effect.transform.forward = ph_particles.transform.forward;
    }

}
