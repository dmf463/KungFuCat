using UnityEngine;
using VikingCrewTools.UI;

public class InspectableObject : MonoBehaviour {

    public Animator myAnim;
    public SpeechBubbleManager.SpeechbubbleType speechType;
    [TextArea]
    public string[] KFC_Comments;
    [TextArea]
    public string[] Object_Comments;
    public int timesClicked;
    public float speechSpeed = 2;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

    public virtual void Speak()
    {
        if (KFC_Comments.Length > 0) PlayerSpeak();
        else if (Object_Comments.Length > 0) ObjectSpeak();
        else Debug.Log("There is nothing to say");
    }

    public virtual void PlayerSpeak()
    {
        int commentIndex = timesClicked - 1;
        if (timesClicked > KFC_Comments.Length) commentIndex = KFC_Comments.Length - 1;
        Speak lineToSpeak = Services.Player.Meow(KFC_Comments[commentIndex], speechSpeed, speechType);
        Services.Player.tm.Do(lineToSpeak);
    }

    public virtual void ObjectSpeak()
    {
        int commentIndex = timesClicked - 1;
        if (timesClicked > Object_Comments.Length) commentIndex = Object_Comments.Length - 1;
        Speak lineToSpeak = ObjSpeak(Object_Comments[commentIndex], speechSpeed, speechType);
        Services.Player.tm.Do(lineToSpeak);
    }

    public Speak ObjSpeak(string text, float duration, VikingCrewTools.UI.SpeechBubbleManager.SpeechbubbleType speechType)
    {
        Speak line = new Speak(this.gameObject, transform, text, duration, speechType);
        return line;
    }

    public virtual void DoFunction()
    {
        timesClicked++;
    }
}
