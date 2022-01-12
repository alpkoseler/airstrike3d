using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camera : MonoBehaviour
{
    public Transform hedef;
    public Transform namlu;
    public GameObject bullet;
    public RectTransform cross;

    float atis_araligi = 0.3f;
    float atis_kalan = 0.0f;

    public float atis_hizi = 10000.0f;

    bool otomatik_silah_aktif_mi = true;
    Vector3 baslangic_kamera_pozisyonu;

   
    void Start()
    {
        Cursor.visible = true;
        baslangic_kamera_pozisyonu = transform.localPosition;
        
    }
    void Update()
    {
        if (transform.localPosition != baslangic_kamera_pozisyonu) 
        {
            transform.localPosition = baslangic_kamera_pozisyonu;
        }
        hedef_noktasi_tespiti();
        otomatik_silah_atesi();
    }
    void hedef_noktasi_tespiti()
    {
        cross.position = Input.mousePosition;

        RaycastHit temas;

        Ray isik = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(isik, out temas))
        {
            hedef.position = temas.point;
        }

        float sapma_payi_x = Random.Range(-2.0f, 2.0f);
        float sapma_payi_z = Random.Range(-2.0f, 2.0f);

        namlu.LookAt(new Vector3(hedef.position.x + sapma_payi_x, hedef.position.y, hedef.position.z + sapma_payi_z));

    }
    void otomatik_silah_atesi()
    {
        if (Input.GetMouseButton(0) && otomatik_silah_aktif_mi == true)
        {
            if (Time.time >= atis_kalan)
            {
                GameObject yeni_kursun = Instantiate(bullet, namlu.position, Quaternion.identity);
                yeni_kursun.GetComponent<Rigidbody>().velocity = namlu.forward * atis_hizi * Time.deltaTime;
                atis_kalan = Time.time + atis_araligi;
                Destroy(yeni_kursun, 3.0f);
            }
        }
    }
    
}
