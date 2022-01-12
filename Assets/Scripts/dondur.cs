using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dondur : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float donme_hizi = 7.0f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, donme_hizi * Time.deltaTime,0);
    }
}
