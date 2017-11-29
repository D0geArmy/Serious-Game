using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour 
{
	private static bool displayCreditPage = false; 
	private static bool isCreditUpdated = false;
	public GameObject creditDetails;
//	private static bool isSoundOn = false;

	public void NewGameBin(string newGameLevel)
	{
		SceneManager.LoadScene (newGameLevel);
	}

	public void ExitGameBin()
	{
		Application.Quit ();
	}

	public void Update()
	{
		if (!isCreditUpdated) {
			ToggleCredits ();
		}
			
	}


	public void ToggleCredits()
	{	
		isCreditUpdated = false;
		creditDetails.SetActive (displayCreditPage);
		displayCreditPage = !displayCreditPage;	
		Debug.Log ("Display Status :"+ displayCreditPage.ToString());
		isCreditUpdated = true;
	}

//	public void ToggleSound()
//		{
//		if (isSoundOn = false) 
//		{
//			;
//		}

}