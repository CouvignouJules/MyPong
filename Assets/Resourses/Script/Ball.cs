using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float speed;
    public Vector3 initialImpulse;
    public float player;
    Vector3 Dir;
    float tailleMin;
    float tailleMax;
    bool strick = false;
    public ParticleSystem particule;
    public AudioSource bip;
    public AudioSource bop;

    private void Start()
    {
        Dir = initialImpulse;
        speed = 10;
        tailleMax = 2.5f;
        tailleMin = 0.5f;
        GetComponent<Rigidbody>().velocity = initialImpulse * speed;
    }
    private void Update()
    {
        GetComponent<Rigidbody>().velocity = Dir * speed;
    }

    float HitFactor(Vector3 BallPos, Vector3 RacketPos, float RacketHeight)
    {
        return (BallPos.x - RacketPos.x) / RacketHeight;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "player1")
        {
            player = 1;
            float x = HitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);
            if (col.transform.position.z == -7.5)
            {
                speed += 2;
                strick = true;
            }
            else
            {
                if (strick == true)
                {
                    speed = 10;
                    strick = false;
                }
            }
            Dir = new Vector3(x, 0, player).normalized;
            GetComponent<Rigidbody>().velocity = Dir * speed;
            bip.Play();
        }
        if (col.gameObject.tag == "player2")
        {
            player = -1;
            float x = HitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);
            if (col.transform.position.z == 7.5)
            {
                speed += 2;
                strick = true;
            }
            else 
            {
                if (strick == true)
                {
                    speed = 10;
                    strick = false;
                }
            }
            Dir = new Vector3(x, 0, player).normalized;
            GetComponent<Rigidbody>().velocity = Dir * speed;
            bip.Play();
        }
        if (col.gameObject.tag == "wall")
        {
            float x = HitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);
            Dir = new Vector3(x, 0, player).normalized;
            GetComponent<Rigidbody>().velocity = Dir * speed;
            bip.Play();
        }
        if (col.gameObject.tag == "goal")
        {
            if (player == 1)
            {
                GameObject.Find("Floor").GetComponent<Game>().player1Marc();
            }
            else
            {
                GameObject.Find("Floor").GetComponent<Game>().player2Marc();
            }
            bop.Play();
            particule.Play();
            Destroy(gameObject,1f);
            Debug.Log("boommmm");
        }
    }

    public void SpeedUp()
    {
        this.speed += 4;
    }

    public void SpeedDown()
    {
        this.speed -= 4;
    }

    public void SizeUp()
    {
        if(gameObject.transform.localScale.x < tailleMax)
        {
            gameObject.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            gameObject.transform.position += new Vector3(0, 0.25f);
        }
    }
    public void SizeDown()
    {
        if (gameObject.transform.localScale.x > tailleMin)
        {
            gameObject.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
            gameObject.transform.position -= new Vector3(0, 0.25f);
        }
    }

}
