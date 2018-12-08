using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClock : InspectableObject {

    private bool alarmOn = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void DoFunction()
    {
        myAnim.SetBool("AlarmOn", false);
        Services.SoundManager.GetSourceAndStop(GetComponent<AudioSource>());
        base.DoFunction();
    }

    public override void PlayerSpeak()
    {
        if (alarmOn)
        {
            Services.SoundManager.GenerateSourceAndPlay(Services.SoundManager.faceSmack, 1);
            alarmOn = false;
        }
        if (timesClicked <= KFC_Comments.Length)
        {
            if (timesClicked > 1) speechType = VikingCrewTools.UI.SpeechBubbleManager.SpeechbubbleType.NORMAL;
        }
        base.PlayerSpeak();
    }
}
