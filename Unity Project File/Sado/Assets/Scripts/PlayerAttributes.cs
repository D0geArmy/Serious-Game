using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour {

    //essential
    public NodeManager manager;

    //attributes
    public int morale;
    int totalMorale;

    //node and movement related
    public bool move = false;
    NodeController previousNode;
    Vector3 destination;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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

    //movement
    public void movePlayer(bool mo, Vector3 des)
    {
        if (previousNode != null)
        {
            if (manager.stalker != null)
            {
                manager.stalker.MoveTo(previousNode.gameObject.transform.position, true);
            }
        }
        previousNode = manager.currentNode(1,  transform);
        move = mo;
        destination = des;
    }

    //morale increase and decrease from scripts
    public void DecreaseMorale(int amount)
    {
        morale -= amount;
    }

    public void IncreaseMorale(int amount)
    {
        morale += amount;
    }
}
