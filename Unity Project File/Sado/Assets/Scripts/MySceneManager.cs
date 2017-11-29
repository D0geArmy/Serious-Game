using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySceneManager : MonoBehaviour {

    [SerializeField]
    NodeManager nodeManager;
    [SerializeField]
    int sequenceNo;
    
    public Counter sceneCounter;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //triggered in Timer when time ends
    public void ExceededTime()
    {
        //pop-up for lose condition
    }

    //triggered in nodemanager reachedEnd()
    public void LoadNextDay()
    {
        //update values in game manager and go to next day
        sequenceNo += 1;
    }
}
