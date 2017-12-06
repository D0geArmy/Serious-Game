using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrain : MonoBehaviour {

    public NodeManager manager;
    NodeController nc;
    PlayerAttributes player;

	// Use this for initialization
	void Start ()
    {
        player = manager.attributes;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
