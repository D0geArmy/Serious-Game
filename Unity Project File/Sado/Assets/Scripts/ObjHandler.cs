using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class ObjHandler : MonoBehaviour {

    public NodeManager nodeManager;
    public Text[] obj;

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
		
	}

    public void ShowObjList(Button hideButt)
    {
        foreach(Text t in obj)
        {
            t.gameObject.SetActive(true);
        }
        hideButt.gameObject.SetActive(true);
    }

    public void HideObjList(Button showButt)
    {
        foreach (Text t in obj)
        {
            t.gameObject.SetActive(false);
        }
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
