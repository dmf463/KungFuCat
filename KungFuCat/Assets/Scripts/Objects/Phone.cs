using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : InspectableObject {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Speak()
    {

    }

    public override void DoFunction()
    {
        Services.SoundManager.GetSourceAndStop(GetComponent<AudioSource>());
        myAnim.SetBool("isRinging", false);
        Services.SoundManager.GenerateSourceAndPlay(Services.SoundManager.phonePickup, 1);
        Services.CutsceneController.PhoneConversation();
        //base.DoFunction();
    }
}
