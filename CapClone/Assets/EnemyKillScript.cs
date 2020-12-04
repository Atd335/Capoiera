using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillScript : MonoBehaviour
{
    public bool killMe;
    public GameObject energy;
    // Start is called before the first frame update
    void Start()
    {
        killMe = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (killMe)
        {
            createPickup();
            Destroy(this.gameObject);
        }
    }

    void createPickup()
    {
        Instantiate(energy, transform.position, Quaternion.identity);
    }
}
