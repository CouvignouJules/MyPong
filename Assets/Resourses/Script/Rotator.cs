using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
    public int x;
    public int y;
    public int z;
    void Update()
    {
        transform.Rotate(new Vector3(x, y, z) * Time.deltaTime);
    }
}