using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class ObjHandler : MonoBehaviour {

    public NodeManager nodeManager;
    public Image obj;

    Flowchart flowchart;
    int noOfObj;

    // Use this for initialization
    void Start () {
        flowchart = nodeManager.flowchart;
	    /*foreach(NodeController nc in nodeManager.iNode)
        {
            if (nc.secObjValue > 0)
            {
                noOfObj += 1;
            }
        }*/
	}
	
	// Update is called once per frame
	void Update () {
        if (Camera.main.orthographicSize != 20.5)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void ShowObjList(Button hideButt)
    {
        obj.gameObject.SetActive(true);
        hideButt.gameObject.SetActive(true);
    }

    public void HideObjList(Button showButt)
    {
        obj.gameObject.SetActive(false);
        showButt.gameObject.SetActive(true);
    }

    void CreateList()
    {
        for(int i = 0; i < noOfObj; i++)
        {
            //Text[i] = 
        }
    }
}
