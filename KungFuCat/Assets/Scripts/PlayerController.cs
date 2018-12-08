using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VikingCrewTools.UI;

public class PlayerController : MonoBehaviour {

    [HideInInspector]
    public Animator myAnim;
    [HideInInspector]
    public Rigidbody2D myRb;
    [HideInInspector]
    public bool jumping;
    public float jumpHeight;
    [HideInInspector]
    public TaskManager tm;
    private InspectableObject inspectable;
    [HideInInspector]
    public PlatformEffector2D myPlat;
    [HideInInspector]
    public PlatformEffector2D previousPlat;
    public float runningSpeed;

    // Use this for initialization

    private void Awake()
    {
        tm = new TaskManager();
        myAnim = GetComponent<Animator>();
        myRb = GetComponent<Rigidbody2D>();
    }
    void Start () {

        inspectable = null;
        jumping = false;
	}
	
	// Update is called once per frame
	void Update () {
        tm.Update();
        if (Input.GetKey(KeyCode.L))
        {
            runningSpeed = 0.02f;
        }
        else runningSpeed = 0.01f;

        if (!Services.CutsceneController.inCutscene)
        {
            InspectingObject();

            if (Input.GetKey(KeyCode.A))
            {
                GetComponent<SpriteRenderer>().flipX = true;
                myAnim.SetBool("Walking", true);
                PlayerMovement(-runningSpeed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                GetComponent<SpriteRenderer>().flipX = false;
                myAnim.SetBool("Walking", true);
                PlayerMovement(runningSpeed);
            }
            else myAnim.SetBool("Walking", false);

            if (Input.GetKeyDown(KeyCode.W) && !jumping)
            {
                myAnim.SetBool("Walking", false);
                myAnim.SetBool("Jumping", true);
                jumping = true;
                PlayerJump(0);
            }

            if (Input.GetKeyDown(KeyCode.Q) && !jumping)
            {
                SpinKick();
            }

            if (Input.GetKey(KeyCode.S))
            {
                if (myPlat != null)
                {
                    Debug.Log("calling fall");
                    Services.PlayerFeet.MoveThroughPlatform();
                }
                else Debug.Log("Plat = null");
            }
        }
    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<InspectableObject>() != null)
        {
            inspectable = other.gameObject.GetComponent<InspectableObject>();
            Debug.Log("Current objToInspect = " + inspectable.name);
        }
        CheckTriggers(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inspectable = null;
        Debug.Log("ObjToInspect is null");
    }


    public void SpinKick()
    {
        jumping = true;
        myAnim.SetBool("Walking", false);
        myAnim.SetBool("SpinKick", true);
        Services.SoundManager.GenerateSourceAndPlay(Services.SoundManager.spinKick, 1);
        PlayerJump(1);
    }

    public void PlayerMovement(float speed)
    {
        transform.Translate(speed, 0, 0);
    }

    public void PlayerJump(float offset)
    {
        myRb.velocity += new Vector2(0, jumpHeight + offset);
    }


    public Speak Meow(string text, float duration, VikingCrewTools.UI.SpeechBubbleManager.SpeechbubbleType speechType)
    {
        Speak line = new Speak(gameObject, transform, text, duration, speechType);
        return line;
    }

    public void InspectingObject()
    {
        if (Input.GetKeyDown(KeyCode.F) && inspectable != null)
        {
            inspectable.DoFunction();
            inspectable.Speak();
        }
    }

    public void PlayerInit()
    {
        myAnim.enabled = true;
        myRb.constraints = RigidbodyConstraints2D.None;
        myRb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void CheckTriggers(Collider2D other)
    {
        if(other.gameObject.name == "PhoneRing")
        {
            GameObject phone = Services.CutsceneController.phone;
            phone.GetComponent<Animator>().SetBool("isRinging", true);
            Services.SoundManager.GetSourceAndPlay(phone.GetComponent<AudioSource>(), Services.SoundManager.phone);
        }
    }
}
