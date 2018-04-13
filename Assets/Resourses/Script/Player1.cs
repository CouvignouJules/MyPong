using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : Player {
    bool m_ZDown = false;
    float m_Time = 0.0f;
    public override void Update()
    {
        if (Input.GetKey(KeyCode.Q) && myRigibody.transform.position.x > -7.5)
        {
            myRigibody.MovePosition(transform.position + Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && myRigibody.transform.position.x < 7.5)
        {
            myRigibody.MovePosition(transform.position + Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!m_ZDown)
                myRigibody.MovePosition(transform.position + strick);
            m_Time = 0;
            m_ZDown = true;
        }
        if (m_ZDown)
        {
            m_Time += Time.deltaTime;
            if (m_Time > 0.5f)
            {
                myRigibody.MovePosition(transform.position - strick);
                m_ZDown = false;
                m_Time = 0;
            }
        }
    }
}