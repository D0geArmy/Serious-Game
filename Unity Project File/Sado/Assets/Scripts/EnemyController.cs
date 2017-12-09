using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class EnemyController : MonoBehaviour {

    public NodeManager manager;
    //player Moral access
    PlayerAttributes attributes;
    //position of nodes
    NodeController myCurrentNode;
    NodeController playerCurrentNode;
    Flowchart flowchart;
    [SerializeField]
    int moraleAmount;

    //movement
    bool move;
    Vector3 destination;

    // Use this for initialization
    void Start ()
    {
        flowchart = manager.flowchart;
        attributes = manager.attributes;
        myCurrentNode = manager.currentNode(1, transform);
	}
	
	// Update is called once per frame
	void Update ()
    {
        //movement
        if (move)
        {
            float distance = Vector3.Distance(transform.position, destination);
            float speed = 1 / distance;
            transform.position = Vector3.Lerp(transform.position, destination, speed);
            if (transform.position == destination)
            {
                move = false;
            }
        }
    }

    public void MoveTo(Vector3 playerDes, bool canMove)
    {
        move = canMove;
        destination = playerDes;
    }

    void DrainMorale()
    {
        //drain morale if player is one node away
        playerCurrentNode = manager.currentNode(1, transform);
        myCurrentNode = manager.currentNode(1, attributes.gameObject.transform);
        foreach(NodeController myNC in myCurrentNode.connectedNodes)
        {
            foreach (NodeController oneNCAway in myNC.connectedNodes)
            {
                if (oneNCAway.NodeNo == playerCurrentNode.NodeNo)
                {
                    //drain morale
                    attributes.DecreaseMorale(moraleAmount);
                }
            }
        }
    }
}
