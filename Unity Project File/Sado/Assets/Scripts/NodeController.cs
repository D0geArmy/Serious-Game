using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[RequireComponent(typeof(CircleCollider2D))]
public class NodeController : MonoBehaviour {

    Flowchart flowchart;
    [Tooltip("Unique ID")]
    public int NodeNo;
    [Tooltip("Nodes you can move to from this one")]
    public NodeController[] connectedNodes;

    [Tooltip("Either primary or secondary")]
    public bool isPrimObjective;
    [Tooltip("Either primary or secondary")]
    public bool isSecoObjective;
    public int secObjValue;
    public bool isObjectiveOver = true;
    [SerializeField] [Tooltip("If the node has objective. In seconds")]
    //int objectiveTime; change to counter
    public bool isStart = false;
    public bool isEnd = false;
    [SerializeField] [Tooltip("Time to get to this node")]
    //int timeConsumed; change to counter
    public int myHighlight;
    public GameObject highlight;
    public bool highlightable;

    Counter sTimer;
    NodeManager myManager;
    Transform Player;
    NodeController currentNode;

	// Use this for initialization
	void Start () {
        myManager = FindObjectOfType<NodeManager>().gameObject.GetComponent<NodeManager>();
        Player = myManager.player;
        sTimer = myManager.scene.sceneCounter;
        flowchart = myManager.flowchart;
        foreach (NodeController nc in myManager.iNode)
        {
            if (nc.isStart)
            {
                Player.position = nc.transform.position;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if (isSecoObjective || isPrimObjective)
        {
            if (highlightable)
            {
                if (myHighlight == flowchart.GetIntegerVariable("Highlight"))
                {
                    if (isObjectiveOver)
                    {
                        highlight.SetActive(false);
                    }
                    else
                    {
                        highlight.SetActive(true);
                    }
                }
                else
                {
                    highlight.SetActive(false);
                }
            }
        }
    }

    //on click move to clicked object
    private void OnMouseOver()
    {
        if (!myManager.disabled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //find the node player is on
                currentNode = myManager.currentNode(NodeNo , Player);
                //find if th clicked node is part of the connected nodes in current node
                foreach (NodeController nc in currentNode.connectedNodes)
                {
                    if (nc.NodeNo == NodeNo)
                    {
                        myManager.attributes.movePlayer(true, transform.position);
                        //Player.position = transform.position;
                        //onclick update objective and reduce time
                        UpdateObjective();
                        sTimer.DecreaseTime(1);
                    }
                }
            }
        }
    }

    void UpdateObjective()
    {
        if (!isObjectiveOver)
        {
            sTimer.DecreaseTime(0);
            if (isPrimObjective)
            {
                //trigger for prim obj narrative sequence here
                if (isEnd)
                {
                    if (flowchart.GetBooleanVariable("isMorning"))
                    {
                        //myManager.disabled = true;
                        //trigger end here
                        //myManager.ReachedEnd();
                        flowchart.ExecuteBlock("Work");
                        flowchart.SetIntegerVariable("TriggerID", NodeNo);
                    }
                    else
                    {
                        flowchart.ExecuteBlock("Home");
                        flowchart.SetIntegerVariable("TriggerID", NodeNo);
                    }
                }
                else
                {
                    flowchart.ExecuteBlock("School");
                    flowchart.SetIntegerVariable("TriggerID", NodeNo);
                }
            }
            else
            {
                myManager.disabled = true;
                //trigger for seco obj narrative sequence here
                flowchart.SetIntegerVariable("CurrObj", secObjValue);
                flowchart.ExecuteBlock("SecondaryObj");
            }
        }
    }

    //showing the connections between node in editor
    private void OnDrawGizmosSelected()
    {
        if (connectedNodes != null)
        {
            foreach (NodeController nc in connectedNodes)
            {
                Gizmos.color = Color.magenta;
                Vector3 a = new Vector3 (nc.transform.position.x, nc.transform.position.y, nc.transform.position.z);
                Vector3 b = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
                Gizmos.DrawLine(a, b);
                Vector3 dir = b - a;
                //Gizmos.DrawRay(a, dir);
                //Vector3 dir = new Vector3 (a.x - b.x, a.y - b.y, a.z - b.z);
                //Vector3 c = new Vector3(dir.x + .5f, dir.y, dir.z);
                //Gizmos.DrawLine(dir, c);
            }
        }
    }


   /* public void MoraleUpdate()
    {
        PlayerAttributes att = Player.gameObject.GetComponent<PlayerAttributes>();
        att.morale = flowchart.GetIntegerVariable("Morale");
    }*/
}
