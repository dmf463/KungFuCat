using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VikingCrewTools.UI;

public class MyGameManager : MonoBehaviour {

    private void Awake()
    {
        Services.PrefabDB = Resources.Load<PrefabDB>("Prefabs/PrefabDB");
        Services.Player = GameObject.Find("KungFuCat").GetComponent<PlayerController>();
        Services.PlayerFeet = Services.Player.gameObject.GetComponentInChildren<PlayerFeetScript>();
        Services.SpeechBubble = GameObject.Find("Speechbubble Manager").GetComponent<SpeechBubbleManager>();
        Services.SoundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        Services.GameManager = this;
        Services.Camera = Camera.main.gameObject.GetComponent<CameraController>();
        Services.CutsceneController = GameObject.Find("CutsceneController").GetComponent<CutsceneController>();
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
