using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject araba;
    public bool spawnstop;
    public float spawntime, spawndelay;
    void Start()
    {
        spawnstop = false;
        InvokeRepeating("spawn", spawntime, spawndelay);
    }

    public void spawn()
    {
        Instantiate(araba, transform.position, transform.rotation);
        if (spawnstop)
        {
            CancelInvoke("spaawn");
        }
    }
}
