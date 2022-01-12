using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kursun : MonoBehaviour
{


    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "dusman")
        {
            other.gameObject.GetComponent<araba>().can_azalt(50.0f);
        }
        Destroy(gameObject);
    }
}
