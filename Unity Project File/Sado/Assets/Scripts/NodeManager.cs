using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NodeManager : MonoBehaviour {

    //fungus related
    public Flowchart flowchart;

    //Nodemanager functionalities
    public MySceneManager scene;
    [HideInInspector]
    public bool disabled = false;
    [Tooltip("Add all the nodes here")]
    public NodeController[] iNode;
    NodeController endGoal;
    Counter counter;

    //player related
    public PlayerAttributes attributes;
    public Transform player;
    public int mor;

    //stalker
    public EnemyController stalker;
    public EnemyController groper;

    //minigame
    public int checkforred = 0;
    string continueBlock;

    // Use this for initialization
    void Start() {
        counter = scene.sceneCounter;
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

        //counter late time setup
        if(counter.totalTime <= 0)
        {
            flowchart.SetBooleanVariable("isLate", true);
        }
        else
        {
            flowchart.SetBooleanVariable("isLate", false);
        }

        //minigame state
        if(checkforred == 4)
        {
            flowchart.ExecuteBlock(continueBlock);
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

    //mini game timer and sequencing
    public void startMiniGame(float miniTime)
    {
        continueBlock = flowchart.GetStringVariable("nextBlock");
        StartCoroutine(minTimer(miniTime));
    }

    IEnumerator minTimer(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        flowchart.ExecuteBlock("MiniGame TimeOver");
    }

    void HighlightOn()
    {
        gameObject.SetActive(true);
    }

    void HighlightOff()
    {
        gameObject.SetActive(false);
    }
}
