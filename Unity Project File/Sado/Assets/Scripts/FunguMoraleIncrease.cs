using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;



[CommandInfo("Morale", "Increase", "Increases Morale")]
public class FungusMoraleIncrease : Command
{

    [SerializeField]
    protected int amount;

    public override void OnEnter()
    {
        FindObjectOfType<NodeManager>().GetComponent<NodeManager>().attributes.IncreaseMorale(amount);
        Continue();
    }
}
