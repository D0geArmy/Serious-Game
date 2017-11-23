using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class NodeController : MonoBehaviour {

    public int NodeNo;
    public NodeController[] connectedNodes;

    NodeManager myManager;
    Transform Player;
    NodeController currentNode;

	// Use this for initialization
	void Start () {
        myManager = FindObjectOfType<NodeManager>().gameObject.GetComponent<NodeManager>();
        Player = myManager.player;
        print(myManager);
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    //on click move to clicked object
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //find the node player is on
            currentNode = myManager.currentNode(NodeNo);
            //find if th clicked node is part of the connected nodes in current node
            foreach (NodeController nc in currentNode.connectedNodes) {
                if (nc.NodeNo == NodeNo)
                {
                    Player.position = transform.position;
                }
            }
        }
    }
}
