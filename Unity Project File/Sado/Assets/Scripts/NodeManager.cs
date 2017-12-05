﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NodeManager : MonoBehaviour {

    //fungus related
    public Flowchart flowchart;
    public MenuDialog ObjList;

    //Nodemanager functionalities
    public MySceneManager scene;
    public bool disabled = false;
    [Tooltip("Add all the nodes here")]
    public NodeController[] iNode;
    NodeController[] Objective;
    NodeController endGoal;
    public Transform player;

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
        //init disabled every frame
        disabled = flowchart.GetBooleanVariable("NodeDisabled");
        if (endGoal != null)
        {
            if (player.position == endGoal.gameObject.transform.position)
            {
                ReachedEnd();
            }
        }
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

    public void ReachedEnd()
    {

    }
}
