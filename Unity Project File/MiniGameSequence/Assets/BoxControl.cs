using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Box control.
/// </summary>
public class BoxControl : MonoBehaviour 
{	
	[SerializeField]
	public MiniGameManager mgm;


	//Transform Poition of the Particle System
//	public Tranform Spawnpoint;

	//Creating an integer that will control the value of the box render color 
	public int currentcolor;

	// Declaring public material types
	public Material red;
	public Material blue;

	//Setting up the variable for spawning the particle effect;
	public ParticleSystem effect;


	// To initiate the material renderer function of unity
	Renderer rend;

	// Use this for initialization
	void Start () 
	{
		rend = GetComponent<Renderer> ();
		rend.enabled = true;


	}

	void OnMouseDown ()
	{
//		if (currentcolor < 1) 
//		{
//			currentcolor = +1;
//			mgm.checkforred -= 1;
//		} 

		 if (currentcolor > 0) 
		{
			currentcolor -= 1;
			mgm.checkforred += 1;
			effect.Play ();

		}
	}


	// Update is called once per frame
	void Update () 
	{
		if (currentcolor == 0) 
		{
			rend.sharedMaterial = red;
		} 

		else if (currentcolor == 1) 
		{
			rend.sharedMaterial = blue;
		}

		if (mgm.checkforred == 4) 
		{
			Destroy (gameObject);
			Debug.Log ("You won, sex please");
		}
	}
}
