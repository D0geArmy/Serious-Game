using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDisable : MonoBehaviour {

    int enableTime;
    int dissableTime;
    [SerializeField]
    GameObject title;

	// Use this for initialization
	void Start () {
        Invoke("disableSprite", 0);
	}
	
    void disableSprite()
    {
        Debug.Log("disable");
        gameObject.active = false;
        title.active = false;
        enableTime = Mathf.RoundToInt(Random.Range (1, 4));
        Invoke("enableSprite", enableTime/2);
    }

    void enableSprite()
    {
        Debug.Log("enable");
        gameObject.active = true;
        title.active = true;
        dissableTime = Mathf.RoundToInt(Random.Range(2, 3));
        Invoke("disableSprite", dissableTime/2);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
