using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour {

    public float speed = 15f;
    float tailleMin;
    float tailleMax;
    public Rigidbody myRigibody;
    public Vector3 strick;

    private void Start()
    {
        strick = new Vector3(0, 0, 0.5f);
        myRigibody = GetComponent<Rigidbody>();
        tailleMin = 1.5f;
        tailleMax = 4.5f;
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
        if (gameObject.transform.localScale.x < tailleMax)
        {
            gameObject.transform.localScale += new Vector3(0.5f, 0, 0);
        }
    }
    public void SizeDown()
    {
        if (gameObject.transform.localScale.x > tailleMin)
        {
            gameObject.transform.localScale -= new Vector3(0.5f, 0, 0);
        }
    }

    // Update is called once per frame
    public abstract void Update();
}
