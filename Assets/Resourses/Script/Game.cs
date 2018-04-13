using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    public GameObject pickup;
    public GameObject ball;
    public Text score1;
    public Text score2;
    public Text winText;
    Vector3 position;
    GameObject bonus1;
    GameObject bonus2;
    GameObject playball;
    private int scoreplayer1;
    private int scoreplayer2;
    private bool isplaying;
    // Use this for initialization
    void Start () {     
        scoreplayer1 = 0;
        scoreplayer2 = 0;
        isplaying = false;
    }
	
	// Update is called once per frame
	void Update () {
        setScore();
        if(GameObject.Find("bonus1") == null && isplaying == true)
        {
            position = new Vector3(Random.Range(-6.5f, 6.5f), 1, Random.Range(-3.5f, 3.5f));
            GameObject bonus1 = (GameObject)Instantiate(pickup, position, transform.rotation);
            bonus1.name = "bonus1";
        }
        if (GameObject.Find("bonus2") == null && isplaying == true)
        {
            position = new Vector3(Random.Range(-6.5f, 6.5f), 1, Random.Range(-3.5f, 3.5f));
            GameObject bonus2 = (GameObject)Instantiate(pickup, position, transform.rotation);
            bonus2.name = "bonus2";
        }
        if(scoreplayer1 >= 5)
        {
            this.winText.text = "Game Over \nPlayer1 Win";
            this.winText.gameObject.SetActive(true);
            GameObject.Find("Menu").GetComponent<Menu>().toggleStartMenuOn();
        }
        if (scoreplayer2 >= 5)
        {
            this.winText.text = "Game Over \nPlayer2 Win";
            this.winText.gameObject.SetActive(true);
            GameObject.Find("Menu").GetComponent<Menu>().toggleStartMenuOn();
        }
        if (GameObject.Find("playball") == null && scoreplayer1 < 5 && scoreplayer2 < 5 && isplaying == true)
        {
            playball = (GameObject)Instantiate(ball);
            playball.name = "playball";
        }
    }

    public void toggleIsPlaying()
    {
        isplaying = !isplaying;
    }

    public void player1Marc()
    {
        scoreplayer1 += 1;
        toggleIsPlaying();
        if(scoreplayer1 < 5)
            GameObject.Find("Menu").GetComponent<Menu>().toggleLaunchMenu();
    }

    public void player2Marc()
    {
        scoreplayer2 += 1;
        toggleIsPlaying();
        if (scoreplayer2 < 5)
            GameObject.Find("Menu").GetComponent<Menu>().toggleLaunchMenu();
    }

    public void setScore()
    {
        this.score1.text = "Score player1 : " + scoreplayer1.ToString();
        this.score2.text = "Score player2 : " + scoreplayer2.ToString();
    }

    public void reset()
    {
        this.winText.gameObject.SetActive(false);
        scoreplayer1 = 0;
        scoreplayer2 = 0;
        setScore();
    }
}
