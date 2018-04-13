using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    private bool startMenu = true;
    private bool launchMenu = false;

    public Button start;
    public Button quit;
    public Button launch;

	// Use this for initialization
	void Start () {
        start.onClick.AddListener(delegate { startAction(); });
        quit.onClick.AddListener(delegate { quitAction(); });
        launch.onClick.AddListener(delegate { launchAction(); });
	}
	
	// Update is called once per frame
	void Update () {
		if(startMenu == true && launchMenu == false)
        {
            start.gameObject.SetActive(true);
            quit.gameObject.SetActive(true);
            launch.gameObject.SetActive(false);
        }
        else if(launchMenu == true && startMenu == false)
        {
            start.gameObject.SetActive(false);
            quit.gameObject.SetActive(false);
            launch.gameObject.SetActive(true);
        }
        else
        {
            start.gameObject.SetActive(false);
            quit.gameObject.SetActive(false);
            launch.gameObject.SetActive(false);
        }
	}

    public void toggleStartMenu()
    {
        startMenu = !startMenu;
    }

    public void toggleStartMenuOn()
    {
        startMenu = true;
    }

    public void toggleLaunchMenu()
    {
        launchMenu = !launchMenu;
    }

    void startAction()
    {
        GameObject.Find("Floor").GetComponent<Game>().toggleIsPlaying();
        GameObject.Find("Floor").GetComponent<Game>().reset();
        toggleStartMenu();
    }

    void quitAction()
    {
        Application.Quit();
    }

    void launchAction()
    {
        GameObject.Find("Floor").GetComponent<Game>().toggleIsPlaying();
        toggleLaunchMenu();
    }
}
