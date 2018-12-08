using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeetScript : MonoBehaviour {

    TaskManager tm;

	// Use this for initialization
	void Start () {

        tm = new TaskManager();
		
	}
	
	// Update is called once per frame
	void Update () {
        tm.Update();
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!Services.CutsceneController.inCutscene)
        {
            if (other.gameObject.tag == "Floor" && !(Services.Player.myRb.velocity.y > 0))
            {
                Services.Player.jumping = false;
                Services.Player.myAnim.SetBool("Jumping", false);
                Services.Player.myAnim.SetBool("SpinKick", false);
            }
            if (other.gameObject.GetComponent<PlatformEffector2D>() != null)
            {
                if (Services.Player.myPlat != null) Services.Player.previousPlat = Services.Player.myPlat;
                Services.Player.myPlat = other.gameObject.GetComponent<PlatformEffector2D>();
                Debug.Log("on Platform: " + Services.Player.myPlat.gameObject.name);
            }
        }
    }

    public void MoveThroughPlatform()
    {
        ActionTask moveDown = new ActionTask(() =>
        {
            Services.Player.myPlat.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        });

        ActionTask resetPlat = new ActionTask(() =>
        {
            Services.Player.myPlat.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            if (Services.Player.previousPlat != null) Services.Player.previousPlat.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        });

        moveDown.
            Then(new Wait(0.2f)).
            Then(resetPlat);
        tm.Do(moveDown);
    }
}
