using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StickPivots : MonoBehaviour
{

    public bool qIsPivot;

    public Transform qPivot;
    public Transform ePivot;

    public Transform eText;
    public Transform qText;

    public float speed;
    public float setSpeed;
    public float dashSpeed;
    public float dashSlow;

    public float scrollSpeed;

    LineRenderer LR;

    public bool inStage;


    RaycastHit2D hit;

    void Start()
    {
        LR = GetComponent<LineRenderer>();
    }


    void Update()
    {
        LR.SetPosition(0,qPivot.position);
        LR.SetPosition(1,ePivot.position);

        speed = Mathf.Lerp(speed,setSpeed,Time.deltaTime * dashSlow);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = dashSpeed;
        }

        if (qIsPivot)
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Camera.main.WorldToScreenPoint(ePivot.position)), Vector2.zero);
            inStage = hit.collider != null;

            CameraController.focus = qPivot;
            qPivot.parent = transform;
            ePivot.parent = qPivot;

            //ePivot.localPosition += new Vector3(Input.GetAxisRaw("Mouse ScrollWheel"), 0, 0)*Time.deltaTime * scrollSpeed;
            ePivot.localPosition += new Vector3(Input.GetAxis("Vertical"), 0, 0) * Time.deltaTime * scrollSpeed;

            if (ePivot.localPosition.x > 8) { ePivot.localPosition = new Vector3(8, 0, 0); }
            if (ePivot.localPosition.x < 1.5f) { ePivot.localPosition = new Vector3(1.5f, 0, 0); }

            qPivot.Rotate(0,0,speed*Time.deltaTime);
            if (Input.GetKey(KeyCode.E) && inStage) { qIsPivot = false; }
            else if (Input.GetKey(KeyCode.E) && !inStage) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }//restart. temp die 

            
        }
        else
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Camera.main.WorldToScreenPoint(qPivot.position)), Vector2.zero);
            inStage = hit.collider != null;

            CameraController.focus = ePivot;
            ePivot.parent = transform;
            qPivot.parent = ePivot;

            //qPivot.localPosition -= new Vector3(Input.GetAxisRaw("Mouse ScrollWheel"),0,0)*Time.deltaTime * scrollSpeed;
            qPivot.localPosition -= new Vector3(Input.GetAxisRaw("Vertical"),0,0)*Time.deltaTime * scrollSpeed;

            if (qPivot.localPosition.x < -8) { qPivot.localPosition = new Vector3(-8, 0, 0); }
            if (qPivot.localPosition.x > -1.5f) { qPivot.localPosition = new Vector3(-1.5f, 0, 0); }

            ePivot.Rotate(0, 0, speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.Q) && inStage) { qIsPivot = true; }
            else if (Input.GetKey(KeyCode.Q) && !inStage) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }//restart. temp die
        }

        //set it so that when you hit comething with a certain collider tag, you change directions

        eText.up = Vector3.up;
        qText.up = Vector3.up;
    }
}
