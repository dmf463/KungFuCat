using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenScale : InspectableObject {

    public int timesJumpedOnScale;
    private bool jumpedFirst = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (timesJumpedOnScale > 1 && !jumpedFirst)
        {
            timesJumpedOnScale = 0;
            jumpedFirst = true;
        }
        if (!Services.CutsceneController.inCutscene)
        {
            if (other.gameObject.tag == "Player") timesJumpedOnScale++;

            if (timesJumpedOnScale >= 1) timesClicked++;

            if (timesJumpedOnScale >= 1) PlayerSpeak();
        }
    }
}
