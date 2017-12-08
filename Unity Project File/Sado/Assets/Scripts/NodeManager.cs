using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NodeManager : MonoBehaviour {

    //fungus related
    public Flowchart flowchart;

    //Nodemanager functionalities
    public MySceneManager scene;
    public bool disabled = false;
    [Tooltip("Add all the nodes here")]
    public NodeController[] iNode;
    NodeController[] Objective;
    NodeController endGoal;

    //player related
    public PlayerAttributes attributes;
    public Transform player;
    public int mor;

	// Use this for initialization
	void Start () {
        foreach (NodeController nc in iNode)
        {
            if (nc.isEnd)
            {
                endGoal = nc;
            }
        }
    }

    private void Update()
    {
        //init bool disabled every frame
        disabled = flowchart.GetBooleanVariable("NodeDisabled");
        //init morale values in script and flowchart
        mor = attributes.morale;
        flowchart.SetIntegerVariable("Morale", mor);

        if (endGoal != null)
        {
            if (player.position == endGoal.gameObject.transform.position)
            {
                ReachedEnd();
            }
        }
    }

    //Returns the current node the player is in
    public NodeController currentNode(int tNodeNo, Transform t)
    {
        foreach(NodeController n in iNode)
        {
            Transform nt = n.gameObject.transform;
            if(nt.position == t.position)
            {
                tNodeNo = n.NodeNo;
            }
        }
        return iNode[tNodeNo];
    }

    public void ReachedEnd()
    {

    }
}
