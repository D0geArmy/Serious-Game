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

    //stalker
    public EnemyController stalker;

    //minigame
    public int checkforred = 0;
    string continueBlock;
    bool haveWon;

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

        if (endGoal != null)
        {
            if (player.position == endGoal.gameObject.transform.position)
            {
                GameOver();
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

        //minigame win state
        if(checkforred == 4)
        {
            haveWon = true;
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

    public void GameOver()
    {

        flowchart.ExecuteBlock("Lost");
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
        if (!haveWon)
        {
            flowchart.ExecuteBlock("MiniGame TimeOver");
        }
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
