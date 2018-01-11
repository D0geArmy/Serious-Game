using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour {

    MySceneManager scene;
    public int totalTime;
    int minutes;
    int seconds;
    string disMinutes;
    string disSeconds;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (totalTime <= 0)
        {
            disMinutes = "Late for work";
        }
        else
        {
            minutes = totalTime / 60;
            seconds = totalTime;
            if (minutes < 10)
            {
                disMinutes = "0" + minutes.ToString();
            }
            else
            {
                disMinutes = minutes.ToString();
            }
            if (seconds < 10)
            {
                disSeconds = "0" + Mathf.RoundToInt(seconds).ToString();
            }
            disSeconds = seconds.ToString();
        }
    }

    public void DecreaseTime(int amount)
    {
        totalTime -= amount;
    }

    public void IncreaseTime(int amount)
    {
        totalTime += amount;
    }

    void OnGUI()
    {
        //GUI.Label(new Rect(10, 6, 250, 100), "No of Nodes left: " + disSeconds);
    }
}
