using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class araba : MonoBehaviour
{
    Rigidbody rigi;
    float can = 100.0f;
    float simdiki_can = 100.0f;
    float hiz = 2.0f;
    Camera kamera;

    Transform border;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "kursun")
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        border = GameObject.Find("border").transform;
        transform.LookAt(border);

        can = 100.0f;
        simdiki_can = 100.0f;

        rigi = GetComponent<Rigidbody>();
        kamera = GameObject.Find("Main Camera").GetComponent<Camera>();

    }

    
    void Update()
    {
        rigi.velocity = transform.forward * hiz;
        GetComponentInChildren<Canvas>().gameObject.transform.LookAt(kamera.transform);
    }

    public void can_azalt(float deger)
    {
        simdiki_can -= deger;
        if (simdiki_can <= 0)
        {
            hiz = 0.0f;
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject,0.05f);
        }
    }
}
