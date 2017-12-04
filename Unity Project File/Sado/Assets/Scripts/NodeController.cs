using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class NodeController : MonoBehaviour {

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
    int crowdDensity;


    Counter sTimer;
    NodeManager myManager;
    Transform Player;
    NodeController currentNode;

    public delegate void OnObjective();
    public static event OnObjective callDialogWork;
    public static event OnObjective callDialogSchool;
    public static event OnObjective callDialogSecObj;

	// Use this for initialization
	void Start () {
        myManager = FindObjectOfType<NodeManager>().gameObject.GetComponent<NodeManager>();
        Player = myManager.player;
        sTimer = myManager.scene.sceneCounter;
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
        
    }

    //on click move to clicked object
    private void OnMouseOver()
    {
        if (!myManager.disabled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //find the node player is on
                currentNode = myManager.currentNode(NodeNo);
                //find if th clicked node is part of the connected nodes in current node
                foreach (NodeController nc in currentNode.connectedNodes)
                {
                    if (nc.NodeNo == NodeNo)
                    {
                        Player.position = transform.position;
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
        isObjectiveOver = true;
        sTimer.DecreaseTime(1);
        if (isPrimObjective)
        {
            //trigger for prim obj narrative sequence here
            if (isEnd)
            {
                //trigger end here
                myManager.ReachedEnd();
                callDialogWork();
            }
            else
            {
                callDialogSchool();
            }
        }
        else
        {
            //trigger for seco obj narrative sequence here
            //callDialogSecObj();
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
}
