using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    int type;
    public AudioSource sound;

	// Use this for initialization
	void Start () {
        type = Random.Range(1, 9);
        Debug.Log(type);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("ball"))
        {
            sound.Play();
            Debug.Log("get a bonus");
            if(type == 1)
            {
                col.gameObject.GetComponent<Ball>().SizeUp();
            }
            if(type == 2)
            {
                col.gameObject.GetComponent<Ball>().SizeDown();
            }
            if (type == 3)
            {
                col.gameObject.GetComponent<Ball>().SpeedUp();
            }
            if (type == 4)
            {
                col.gameObject.GetComponent<Ball>().SpeedDown();
            }
            if (type == 5)
            {
                if(col.gameObject.GetComponent<Ball>().player == 1)
                {
                    GameObject.Find("player1").GetComponent<Player>().SizeUp();
                }
                else
                {
                    GameObject.Find("player2").GetComponent<Player2>().SizeUp();
                }
            }
            if (type == 6)
            {
                if (col.gameObject.GetComponent<Ball>().player == 1)
                {
                    GameObject.Find("player1").GetComponent<Player>().SizeDown();
                }
                else
                {
                    GameObject.Find("player2").GetComponent<Player2>().SizeDown();
                }
            }
            if (type == 7)
            {
                if (col.gameObject.GetComponent<Ball>().player == 1)
                {
                    GameObject.Find("player1").GetComponent<Player>().SpeedUp();
                }
                else
                {
                    GameObject.Find("player2").GetComponent<Player2>().SpeedUp();
                }
            }
            if (type == 8)
            {
                if (col.gameObject.GetComponent<Ball>().player == 1)
                {
                    GameObject.Find("player1").GetComponent<Player>().SpeedDown();
                }
                else
                {
                    GameObject.Find("player2").GetComponent<Player2>().SpeedDown();
                }
            }
            Destroy(gameObject);
        }
    }
}
