using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class ButtonManager : MonoBehaviour 
{
	private static bool displayCreditPage = false; 
	private static bool isCreditUpdated = false;
	public GameObject creditDetails;
    [SerializeField]
    Flowchart flowchart;
    
//	private static bool isSoundOn = false;

	public void LoadScene(string newGameLevel)
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
		//isCreditUpdated = false;
		//creditDetails.SetActive (displayCreditPage);
		//displayCreditPage = !displayCreditPage;	
		//Debug.Log ("Display Status :"+ displayCreditPage.ToString());
		//isCreditUpdated = true;
	}

    bool isMute;
    public void ToggleMute()
    {
        if (flowchart != null)
        {
            if (!isMute)
            {
                isMute = true;
                flowchart.ExecuteBlock("Mute");
            }
            else
            {
                isMute = false;
                flowchart.ExecuteBlock("Unmute");
            }
        }
    }
    //	public void ToggleSound()
    //		{
    //		if (isSoundOn = false) 
    //		{
    //			;
    //		}

}