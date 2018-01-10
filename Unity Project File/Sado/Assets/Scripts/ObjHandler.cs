using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class ObjHandler : MonoBehaviour {

    public NodeManager nodeManager;
    public Image obj;

    GameObject[] list = new GameObject[6];
    Flowchart flowchart;

    // Use this for initialization
    void Start()
    {
        flowchart = nodeManager.flowchart;

       // GameObject[] temp = GameObject.FindGameObjectsWithTag("List");
        
        /*foreach (GameObject go in temp)
        {
            //for (int i = 0; i < temp.Length; i++)
            //{
            int i = 0;
            list[i] = go.gameObject;
            i++;
           // }
        }*/
    }
	
	// Update is called once per frame
	void Update () {

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
}
