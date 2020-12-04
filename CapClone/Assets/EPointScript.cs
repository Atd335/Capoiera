using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPointScript : MonoBehaviour
{
    public bool OCCUPIED;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OCCUPIED = transform.childCount > 0;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, .5f);
    }
}
