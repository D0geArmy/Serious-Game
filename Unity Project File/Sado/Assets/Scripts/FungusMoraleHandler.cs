using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Fungus;

[CommandInfo("Morale", "Decrease", "Decreases Morale")]
public class FungusMoraleHandler : Command {

    [SerializeField]
    protected int amount;

    public override void OnEnter()
    {
        FindObjectOfType<NodeManager>().GetComponent<NodeManager>().attributes.DecreaseMorale(amount);
        Continue();
    }
}
