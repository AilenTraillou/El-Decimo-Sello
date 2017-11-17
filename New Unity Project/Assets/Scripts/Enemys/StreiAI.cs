using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreiAI : MonoBehaviour {

    public Transform enemy;
    public Transform player;

    private float _distance;  
    public float speed = 15f;
    public int _followRange = 50;
    public int _attackRange = 20;
    private bool _detected;
    private float _rotationSpeed = 5f;


    public GameObject particles;
    public GameObject ph_particles;

    //public Light pointlight;


    void Start()
    {
        //if(pointlight != null)
        //{
        //    pointlight = GetComponent<Light>();
        //    pointlight.enabled = false;
        //}
        enemy = transform;
        
    }

    void Update()
    {
        var distance = (player.transform.position - enemy.position).magnitude;
        _distance = distance;


        if (_distance <= _followRange)
        {
            _detected = true;
        }
        else _detected = false;

        if (_detected)
        {
            FollowThePlayer();
        }
        else
        {
            if (gameObject.name == "Monstruo Esqueleto 2")
            {
                GetComponent<Animation>().Stop("Run");
                GetComponent<Animation>().Play("Idle");
            }
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _followRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }

    public void FollowThePlayer()
    {
       
        if(_distance >= _attackRange)
        {
            if (gameObject.name == "Monstruo Esqueleto 2")
            {
                GetComponent<Animation>().Stop("Idle");
                GetComponent<Animation>().Play("Run");

            }
            enemy.position += enemy.forward * speed * Time.deltaTime;
        }

        if (_distance <= _attackRange)
        {
            
            Attack();
        }

        enemy.rotation = Quaternion.Slerp(enemy.rotation, Quaternion.LookRotation(player.position - enemy.position), _rotationSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        SoundsManager.instancia.Play((int)SoundID.Sream, 0.5f, false);

    }

    void Attack()
    {

        if (gameObject.tag == "hiena")
        {

            //GameObject attack_effect = GameObject.Instantiate(particles);
            //attack_effect.transform.position = ph_particles.transform.position;
            //attack_effect.transform.forward = this.transform.forward;
            //Character.instance.ReciveDamage(20f);
            MainPlayer.instance.AddFear(90f);
            Destroy(gameObject);
            

        }else
        {
            if(particles != null)
            {
                GameObject attack_effect = GameObject.Instantiate(particles);
                attack_effect.transform.position = ph_particles.transform.position;
                attack_effect.transform.forward = ph_particles.transform.forward;
            }

            //if(pointlight != null)
            //{
            //    pointlight.enabled = true;
            //}

        }

        if (gameObject.name == "Monstruo Esqueleto 2")
            {
                //GetComponent<Animation>().Stop();
                GetComponent<Animation>().Play("Attack");

            }
           
        


    }
}
