using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseilehareket : MonoBehaviour
{
    [SerializeField]
    GameObject oyuncupatlama;
    [SerializeField]
    GameObject dusmanpatlama;
    float colliderEnYarim;
    float colliderBoyYarim;
    void Start()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        colliderBoyYarim = collider.size.y / 2;
        colliderEnYarim = collider.size.x / 2;
    }

    
    void Update()
    {
        Vector3 position = Input.mousePosition;
        position.z = -Camera.main.transform.position.z;
        position = Camera.main.ScreenToWorldPoint(position);
        transform.position = position;
        EkrandaKal();
    }
    void EkrandaKal() 
    {
        Vector3 position = transform.position;
        if (position.x - colliderEnYarim < EkranHesaplayici.Sol)
        {
            
            position.x = EkranHesaplayici.Sol + colliderEnYarim;

        } 
        else if (position.x+colliderEnYarim>EkranHesaplayici.Sag) 
        {

            position.x = EkranHesaplayici.Sag - colliderEnYarim;
        
        }
        if (position.y - colliderBoyYarim < EkranHesaplayici.Alt) 
        {
            
            position.y = EkranHesaplayici.Alt + colliderBoyYarim;

        }
        else if (position.y + colliderBoyYarim > EkranHesaplayici.Ust) 
        {
            position.y = EkranHesaplayici.Ust - colliderBoyYarim;

        }
        transform.position = position;
    
    
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy") 
        {
            Instantiate(dusmanpatlama, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Instantiate(oyuncupatlama,transform.position,Quaternion.identity);
            Destroy(gameObject);
            

        }
    }
}
