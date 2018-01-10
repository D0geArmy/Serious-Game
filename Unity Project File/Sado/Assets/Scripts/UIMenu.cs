using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class UIMenu : MonoBehaviour {

    [SerializeField]
    NodeManager nodeManager;
    [SerializeField]
    Flowchart flowchart;
    [SerializeField]
    GameObject Obj;

	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update()
    {
        if (Obj != null)
        {
            if (Camera.main.orthographicSize == 20.5)
            {
                Obj.SetActive(true);
            }
            else
            {
                Obj.SetActive(false);
            }
        }
    }

    public void ApplicationPause(bool pause)
    {
        if (Camera.main.orthographicSize == 20.5)
        {
            nodeManager.disabled = pause;
        }
    }

    public void ApplicationQuit()
    {
        Application.Quit();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
