using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour {

    //essential
    public NodeManager manager;

    //attributes
    public int morale;
    int totalMorale;

    //node and movement related
    [HideInInspector]
    public bool move = false;
    NodeController previousNode;
    Vector3 destination;

    //GUI
    /*[SerializeField]
    Text moraleText;
    [SerializeField]
    Image moraleIcon;
    [SerializeField]
    int stage5 = 90;
    [SerializeField]
    Sprite SStage5;
    [SerializeField]
    int stage4 = 75;
    [SerializeField]
    Sprite SStage4;
    [SerializeField]
    int stage3 = 50;
    [SerializeField]
    Sprite SStage3;
    [SerializeField]
    int stage2 = 20;
    [SerializeField]
    Sprite SStage2;
    [SerializeField]
    int stage1 = 10;
    [SerializeField]
    Sprite SStage1;*/
    [SerializeField]
    Slider slider;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

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

        slider.value = morale;

        if(morale<= 0)
        {
            morale = 0;
            manager.GameOver();
        }
      /*  //GUI
        moraleText.text = morale.ToString();

        if (morale >= stage5)
        {
            moraleIcon.sprite = SStage5;
        }
        else if (morale >= stage4)
        {
            moraleIcon.sprite = SStage4;
        }
        else if (morale >= stage3)
        {
            moraleIcon.sprite = SStage3;
        }
        else if (morale >= stage2)
        {
            moraleIcon.sprite = SStage2;
        }
        else if (morale >= stage1)
        {
            moraleIcon.sprite = SStage1;
        }*/
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
