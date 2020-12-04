using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyScript : MonoBehaviour
{

    int whichPoint;

    // Start is called before the first frame update
    void Start()
    {
        whichPoint = Random.Range(0,GameObject.Find("EnergySpawnPoints").GetComponentsInChildren<EPointScript>().Length);

        while (GameObject.Find("EnergySpawnPoints").GetComponentsInChildren<EPointScript>()[whichPoint].OCCUPIED)
        {
            whichPoint = Random.Range(0, GameObject.Find("EnergySpawnPoints").GetComponentsInChildren<EPointScript>().Length);
        }

        transform.parent = GameObject.Find("EnergySpawnPoints").GetComponentsInChildren<EPointScript>()[whichPoint].transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero,Time.deltaTime * 10);
    }
}
