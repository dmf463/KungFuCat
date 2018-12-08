using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VikingCrewTools.UI;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour {

    TaskManager tm;
    Animator blackCanvasAnim;
    public bool inCutscene;

    [Header("Objects to be Animated")]
    public GameObject alarmClock;
    public GameObject blackCanvas;
    public GameObject phone;
    public int fadeTime; 

    // Use this for initialization

    void Start () {
        if (!blackCanvas.activeSelf) blackCanvas.SetActive(true);
        tm = new TaskManager();
        //FadeIn();
        OpeningCutscene();
	}
	
	// Update is called once per frame
	void Update () {

        tm.Update();
		
	}

    public void FadeIn(int time)
    {
        FadeUIAlpha fadeIn = new FadeUIAlpha(blackCanvas, blackCanvas.GetComponent<Image>().color, 1, 0, time);
        tm.Do(fadeIn);
    }

    public void FadeOut(int time)
    {
        FadeUIAlpha fadeOut = new FadeUIAlpha(blackCanvas, blackCanvas.GetComponent<Image>().color, 0, 1, time);
        tm.Do(fadeOut);
    }

    public Animator GetAnimator(GameObject obj)
    {
        return obj.GetComponent<Animator>();
    }

    public AudioSource GetAudioSource(GameObject obj)
    {
        return obj.GetComponent<AudioSource>();
    }

    public void SetCutsceneBool(bool val)
    {
        inCutscene = val;
    }

    public void OpeningCutscene()
    {
        ActionTask FadeIn = new ActionTask(() =>
        {
            Services.CutsceneController.FadeIn(fadeTime);
        });

        ActionTask AlarmClockRing = new ActionTask(() =>
        {
            Services.SoundManager.GetSourceAndPlay(GetAudioSource(alarmClock), Services.SoundManager.alarmClock);
            GetAnimator(alarmClock).SetBool("AlarmOn", true);
        });

        ActionTask InitPlayer = new ActionTask(() =>
        {
            Services.Player.PlayerInit();
        });

        ActionTask SpinKick = new ActionTask(() =>
        {
            Services.Player.SpinKick();
        });

        ActionTask SpriteMaskOff = new ActionTask(() =>
        {
            Services.Player.gameObject.GetComponentInChildren<SpriteMask>().enabled = false;
        });

        ActionTask setBoolTrue = new ActionTask(() =>
        {
            SetCutsceneBool(true);
            Debug.Log("CUTSCENE IN PROGRESS");
        });

        Speak openingLine = Services.Player.Meow("I hate mondays.", 2, SpeechBubbleManager.SpeechbubbleType.NORMAL);

        ActionTask setBoolFalse = new ActionTask(() =>
        {
            SetCutsceneBool(false);
        });

        FadeIn.
            Then(setBoolTrue).
            Then(AlarmClockRing).
            Then(new Wait(fadeTime)).
            Then(openingLine).
            Then(new Wait(2)).
            Then(InitPlayer).
            Then(SpinKick).
            Then(SpriteMaskOff).
            Then(setBoolFalse);
        tm.Do(FadeIn);
    }

    public void PhoneConversation()
    {
        Debug.Log("phone convo started");
        Phone p = phone.GetComponent<Phone>();

        ActionTask setBoolTrue = new ActionTask(() =>
        {
            SetCutsceneBool(true);
            Debug.Log("CUTSCENE IN PROGRESS");
        });

        ActionTask setBoolFalse = new ActionTask(() =>
        {
            SetCutsceneBool(false);
        });

        setBoolTrue.
            Then(new ActionTask(() => { p.timesClicked++; })).
            Then(new ActionTask(() => { p.PlayerSpeak(); })).//C1
            Then(new Wait(3)).
            Then(new ActionTask(() => { p.ObjectSpeak(); })).//?1
            Then(new Wait(3)).
            Then(new ActionTask(() => { p.timesClicked++; })).
            Then(new ActionTask(() => { p.PlayerSpeak(); })).//C2
            Then(new Wait(3)).
            Then(new ActionTask(() => { p.ObjectSpeak(); })).//?2
            Then(new Wait(3)).
            Then(new ActionTask(() => { p.timesClicked++; })).
            Then(new ActionTask(() => { p.PlayerSpeak(); })).//C3
            Then(new Wait(3)).
            Then(new ActionTask(() => { p.ObjectSpeak(); })).//?3
            Then(new Wait(3)).
            Then(new ActionTask(() => { p.timesClicked++; })).
            Then(new ActionTask(() => { p.PlayerSpeak(); })).//C4
            Then(new Wait(3)).
            Then(new ActionTask(() => { p.ObjectSpeak(); })).//?4
            Then(new Wait(3)).
            Then(new ActionTask(() => { p.timesClicked++; })).
            Then(new ActionTask(() => { Services.SoundManager.GenerateSourceAndPlay(Services.SoundManager.phonePickup, 1); })).
            Then(new Wait(1)).
            Then(new ActionTask(() => { p.PlayerSpeak(); })).//C5
            Then(setBoolFalse);

        tm.Do(setBoolTrue);
    }
    
}
