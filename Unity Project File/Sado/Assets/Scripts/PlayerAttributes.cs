using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour {

    
    int morale;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DecreaseMorale(int amount)
    {
        morale -= amount;
    }

    public void IncreaseMorale(int amount)
    {
        morale += amount;
    }
}
