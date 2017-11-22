using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour {

    NodeController[] iNode;

	// Use this for initialization
	void Start () {
        iNode = GetComponents<NodeController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
