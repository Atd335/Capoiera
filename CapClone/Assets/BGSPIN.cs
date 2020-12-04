using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSPIN : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        dir = -1;   
    }

    public float speed;
    public static int dir;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,Time.deltaTime * speed * dir);
    }
}
