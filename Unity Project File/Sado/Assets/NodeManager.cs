using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour {

    [SerializeField]
    NodeController[] iNode;
    public Transform player;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}


    //Returns the current node the player is in
    public NodeController currentNode(int nodeNo)
    {
        foreach(NodeController n in iNode)
        {
            Transform nt = n.gameObject.transform;
            if(nt.position == player.position)
            {
                nodeNo = n.NodeNo;
            }
        }
        return iNode[nodeNo];
    }
}
