using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float yPos;
    private float startYpos;
    public float yOffset;
    public float moveSpeed;
    public bool moving;
    TaskManager tm;

	// Use this for initialization
	void Start () {
        tm = new TaskManager();
        startYpos = transform.position.y - yOffset;
        yPos = startYpos;
	}
	
	// Update is called once per frame
	void Update () {
        tm.Update();

        transform.position = new Vector3(Services.Player.gameObject.transform.position.x,
                                         yPos,
                                         transform.position.z);	
	}
}
