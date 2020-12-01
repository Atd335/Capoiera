using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPivots : MonoBehaviour
{

    public bool qIsPivot;

    public Transform qPivot;
    public Transform ePivot;

    public Transform eText;
    public Transform qText;

    public float speed;
    public float accel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            speed += accel*Time.deltaTime;
        }
        else
        {
            speed -= accel*Time.deltaTime;
        }

        speed = Mathf.Clamp(speed,90,270);

        if (qIsPivot)
        {
            qPivot.parent = transform;
            ePivot.parent = qPivot;

            qPivot.Rotate(0,0,speed*Time.deltaTime);
            if (Input.GetKey(KeyCode.E)) { qIsPivot = false; }
        }
        else
        {
            ePivot.parent = transform;
            qPivot.parent = ePivot;
            ePivot.Rotate(0, 0, speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.Q)) { qIsPivot = true; }
        }

        eText.up = Vector3.up;
        qText.up = Vector3.up;
    }
}
