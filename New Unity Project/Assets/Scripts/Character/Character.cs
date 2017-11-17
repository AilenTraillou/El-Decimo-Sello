using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour, IObservable {

    float characterSpeed = 50;
    float characterRunSpeed = 70;
    public Vector3 direction;
    public GameObject visual;

    List<IObserver> lifeObservers;

    public Rigidbody rb;
    public float characterJumpStr;
    

    public bool isJumping;
    private bool isGrounded;
    private int ground;

    private bool isWalking;
    private bool isWalkingOnWater;
    private CameraWalkAnimation walkAnimation;

    public static Character instance;
    private Scene scene;
    public static string nivel;
    public static string asesino;

    IAdvance currentState;
    IAdvance jump;
    IAdvance walk;
    IAdvance run;

    void Awake()
    {
        currentState = null;
        walk = new WalkAdvance(rb, characterSpeed);
        run = new RunAdvance(rb, characterRunSpeed);
        jump = new JumpAdvance(rb, characterJumpStr);
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

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            currentState = jump;
            isJumping = true;
            isWalking = false;
            ground = 1;

        }
        else
        if (Input.GetAxis("Vertical") != 0 && Input.GetKey(KeyCode.LeftShift) ||
            Input.GetAxis("Horizontal") != 0 && Input.GetKey(KeyCode.LeftShift))
        {
            isWalking = true;
            currentState = run;
        }
        else
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {         
            isWalking = true;
            currentState = walk;
        }
        else
        {
            isWalking = false;
            currentState = null;
        }
        

        if (currentState != null)
        {
            currentState.Advance();
        }


        if (isGrounded)
        {
            Grounding();
        }
        else isWalking = true;
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0 && isJumping == false || Input.GetAxis("Vertical") != 0 && isJumping == false)
        {
            if (isWalkingOnWater)
            {
                SoundsManager.instancia.Play((int)SoundID.water_footsteps, 1, false);
                SoundsManager.instancia.channels[(int)SoundID.water_footsteps].pitch = 0.9f;
            }
            else SoundsManager.instancia.Play((int)SoundID.Footsteps, 1, false);

        }else SoundsManager.instancia.Stop((int)SoundID.Footsteps);

        if (Input.GetAxis("Vertical" )< 0.2f && Input.GetAxis("Vertical")  > -0.2f) walkAnimation.walk = false;
        else walkAnimation.walk = true;

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

    void OnCollisionEnter (Collision c)
    {

        if (c.gameObject.layer == 9)
        {
            characterRunSpeed = 0;
            characterSpeed = 0;
        }

        if (c.gameObject.layer == 8)
        {
            isJumping = false;
            
        }

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
                item.Notify(gameObject);
            }
        }

        //if (life.CurrentVal == 0)
        //{
        //    asesino = c.gameObject.name;
        //    analtycsstrei.QuienMeMato();
        //}

    }

    void OnCollisionExit (Collision c)
    {
        if (c.gameObject.layer == 8)
        isGrounded = false;
    }

    void Grounding()
    {
        SoundsManager.instancia.Play((int)SoundID.Land, 1, false);
        isGrounded = false;
        ground = 0;
    }
   

    public void Suscribe(IObserver observer)
    {
        if (lifeObservers != null)
        {
            lifeObservers.Add(observer);

        }
        else
        {
            lifeObservers = new List<IObserver>();
        }
    }

    public void Unsuscribe(IObserver observer)
    {
        if (lifeObservers.Contains(observer))
        {
            lifeObservers.Remove(observer);
        }
    }
}
