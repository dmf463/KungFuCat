using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : InspectableObject {

    public int timesJumpedOnBed;
    private bool jumpedFirst = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(timesJumpedOnBed > 2 && !jumpedFirst)
        {
            timesJumpedOnBed = 0;
            jumpedFirst = true;
        }
        if (!Services.CutsceneController.inCutscene)
        {
            if (other.gameObject.tag == "Player") timesJumpedOnBed++;

            if (timesJumpedOnBed >= 4) timesClicked++;

            if (timesJumpedOnBed >= 4) PlayerSpeak();
        }
    }

    public override void DoFunction()
    {
        
    }

    public override void PlayerSpeak()
    {
        base.PlayerSpeak();
    }
}
