using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[EventHandlerInfo("Narrative", "Trigger", "Use this")]
public class NodeNarrativeTrigger : EventHandler {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartEvent()
    {
        ExecuteBlock();
    }
}
