using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour, ILifeObservable {

    public float speed;
    public Rigidbody rb;
    public Vector3 direction;
    public GameObject visual;

    List<ILifeObserver> lifeObservers;

    //public float steerSpeed;
    public float jumpStr;

    public bool isJumping;
    private bool isGrounded;
    private int ground;

    private bool isWalking;

    private bool isWalkingOnWater;

    public Stat life;

    private CameraWalkAnimation walkAnimation;

    public static Character instance;
    private Scene scene;
    public static string nivel;
    public static string asesino;

    public Light light;

    void Awake()
    {
        life.Initialize();

    }
    void Start()
    {

        scene = SceneManager.GetActiveScene();
        rb = GetComponent<Rigidbody>();
        walkAnimation = Camera.main.GetComponent<CameraWalkAnimation>();

        
        instance = this;
    }

    void Update()
    {
        RecoveryLife();
    }
    

    void FixedUpdate()
    {
        Movement();

        if (Input.GetAxis("Horizontal") != 0 && isJumping == false)
        {
            if (isWalkingOnWater)
            {
                SoundsManager.instancia.Play((int)SoundID.water_footsteps, 1, false);
                SoundsManager.instancia.channels[(int)SoundID.water_footsteps].pitch = 0.9f;
            }
            else SoundsManager.instancia.Play((int)SoundID.Footsteps, 1, false);

        }else SoundsManager.instancia.Stop((int)SoundID.Footsteps);


        if (Input.GetAxis("Vertical") != 0 && isJumping == false)
        {
            if (isWalkingOnWater)
            {
                SoundsManager.instancia.Play((int)SoundID.water_footsteps, 1, false);
                SoundsManager.instancia.channels[(int)SoundID.water_footsteps].pitch = 0.9f;
            }
            else SoundsManager.instancia.Play((int)SoundID.Footsteps, 1, false);
        }
        else SoundsManager.instancia.Stop((int)SoundID.Footsteps);




        if (Input.GetAxis("Vertical" )< 0.2f && Input.GetAxis("Vertical")  > -0.2f) walkAnimation.walk = false;
        else walkAnimation.walk = true;

    }


    private void Move() 
    {

        direction = Vector3.zero;
        direction += Vector3.forward * Input.GetAxis("Vertical");
        direction += Vector3.right * Input.GetAxis("Horizontal");
        rb.velocity = direction.normalized * speed;

    }

    void OnTriggerEnter(Collider c)
    {

        if (c.gameObject.name == "WaterProNighttime")
        {

            isWalkingOnWater = true;


        }
        
    }


    void OnTriggerExit(Collider c)
    {

        if (c.gameObject.name == "WaterProNighttime")
        {

            isWalkingOnWater = false;


        }

    }

    private float mouseSensitivity = 100.0f;
    private float rotY = 0.0f;


    private void Rotation()
    {
        float mouseX = Input.GetAxis("Mouse X");


        rotY += mouseX * mouseSensitivity * Time.deltaTime;

        Quaternion localRotation = Quaternion.Euler(transform.rotation.x , rotY, transform.rotation.z);
        transform.rotation = localRotation;

        
    }



    void Movement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 50;
            SoundsManager.instancia.channels[(int)SoundID.Footsteps].pitch = 1.2f;
        }
        else
        {
            speed = 40;
            SoundsManager.instancia.channels[(int)SoundID.Footsteps].pitch = 0.8f;
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            rb.transform.Translate(Vector3.forward * -speed * Time.deltaTime);

        }else isWalking = false;

        if (Input.GetAxis("Vertical") > 0)
        {
            rb.transform.Translate(Vector3.forward * speed * Time.deltaTime);

        } else isWalking = true;
       

        if (Input.GetAxis("Horizontal") < 0)
        {
            rb.transform.Translate(Vector3.right * -speed * Time.deltaTime);
            

        } else isWalking = true;


        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
           
            Jump();
            SoundsManager.instancia.Stop((int)SoundID.Footsteps);
            SoundsManager.instancia.Play((int)SoundID.Jump, 1, false);
            ground = 1;

        } else isWalking = true;


        if (isGrounded)
        {
            Grounding();
        } else isWalking = true;

     
    }
   

    void OnCollisionEnter (Collision c)
    {
        if (c.gameObject.layer == 8)
        {
            isJumping = false;
            
        }
        //else isJumping = true;

        if (ground == 1)
        {
            isGrounded = true;
            isWalking = true;
        }
        else  isGrounded = false ;

        if(c.gameObject.layer == 11)
        {
            foreach (var item in lifeObservers)
            {
                item.TakeDamage();
            }
        }

        if (life.CurrentVal == 0)
        {
            asesino = c.gameObject.name;
            analtycsstrei.QuienMeMato();
        }

    }

    void Jump()
    {
        if (isJumping) return;
        rb.AddForce(Vector3.up * jumpStr, ForceMode.Impulse);
        isJumping = true;
        isWalking = false;

    }

    void Grounding()
    {
        SoundsManager.instancia.Play((int)SoundID.Land, 1, false);
        isGrounded = false;
        ground = 0;
    }


    //public void ReciveDamage(float damage)
    //{
    //    life.CurrentVal -= damage;

    //    if (life.CurrentVal <= 0)
    //    {
    //        if (scene.name == "nivel1")
    //        {
    //            nivel = "nivel1";
    //            analtycsstrei.NivelMuerte();
                
    //        }

    //        if (scene.name == "nivel2")
    //        {
    //            nivel = "nivel2";
    //            analtycsstrei.NivelMuerte();
    //        }
    //    }

    
        
    //}

    

    void RecoveryLife()
    {
        life.CurrentVal += 0.001f;
    }

    public void Suscribe(ILifeObserver lifeObserver)
    {
        if (lifeObservers != null)
        {
            lifeObservers.Add(lifeObserver);

        }else
        {
            lifeObservers = new List<ILifeObserver>();
        }
    }

    public void Unsuscribe(ILifeObserver lifeObserver)
    {
        if (lifeObservers.Contains(lifeObserver))
        {
            lifeObservers.Remove(lifeObserver);
        }
    }
}
