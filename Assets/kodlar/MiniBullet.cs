using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBullet : MonoBehaviour
{
    [SerializeField]
    GameObject dusmanpatlama;
    Rigidbody2D fizik;
    Rigidbody2D colfizik;
    Vector2 vec1;
    UIKontrol uiKontrol;
    bool destroy = false;
    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();
        uiKontrol = Camera.main.GetComponent<UIKontrol>();
        vec1 = new Vector2(0.3f, Random.Range(-0.1f, 0.1f));
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        colfizik = col.GetComponent<Rigidbody2D>();
        if (col.gameObject.CompareTag("Barrel"))
        {
            if (destroy)
            {
                Destroy(gameObject);
            }
            destroy = true;
        }
        fizik.velocity = vec1;
        if (col.gameObject.CompareTag("Projectile"))
        {
            //Eğer yönleri zıtsa birbirlerini yok etsinler
            if (colfizik.velocity.x*fizik.velocity.x<0)
            {
                Destroy(gameObject);
                Destroy(col.gameObject);
            }
        }
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Player2"))
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().VurulmaSesi();
            if (uiKontrol.DusmanCaniGuncelle() == 0)
            {
                Instantiate(dusmanpatlama, transform.position, Quaternion.identity);
                Destroy(col.gameObject);
                uiKontrol.OyunBitti();
            }
            Destroy(gameObject);
        }
    }
}
