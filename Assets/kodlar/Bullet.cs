using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    GameObject patlama;
    Rigidbody2D fizik;
    Rigidbody2D colfizik;
    UIKontrol uiKontrol;
    bool destroy = false;
    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();
        uiKontrol = Camera.main.GetComponent<UIKontrol>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        colfizik = col.GetComponent<Rigidbody2D>();
        if (col.gameObject.CompareTag("Player"))
        { 
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().VurulmaSesi();
            if (uiKontrol.CaniGuncelle() == 0)
            {
                Instantiate(patlama, transform.position, Quaternion.identity);
                Destroy(col.gameObject);
                uiKontrol.OyunBitti();
            }
        }
        if (col.gameObject.CompareTag("Player2"))
        {
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().VurulmaSesi();
            if (uiKontrol.DusmanCaniGuncelle() == 0)
            {
                Destroy(col.gameObject);
                Instantiate(patlama, transform.position, Quaternion.identity);
                uiKontrol.OyunBitti();
            }
        }
        if (col.gameObject.CompareTag("Barrel"))
        {
            if (destroy)
            {
                Destroy(gameObject);
            }
            destroy = true;
        }
        //Şişe vurdukça puan kazanmalı bir minigame olabilir
        //if (col.tag == "sise")
        //{
        //    uiKontrol.PuaniGuncelle();
        //    Destroy(col.gameObject);
        //}
        if (col.gameObject.CompareTag("Projectile"))
        {
            if ((colfizik.velocity.x*fizik.velocity.x)<0)
            {
                Destroy(col.gameObject);
                Destroy(gameObject);
            }
        }
        //if (col.gameObject.CompareTag("kaktus"))
        //{
        //    if (col.transform.localScale.y / 6 > (this.transform.position.y - col.transform.position.y))
        //    {
        //        fizik.AddForce(new Vector2(-2 * fizik.velocity.x * Time.deltaTime, 0), ForceMode2D.Impulse);
        //    }
        //    else
        //    {

        //    }
        //    float x = (col.transform.position.x - this.transform.position.x);
        //    float z = (col.transform.position.y - this.transform.position.y);
        //}
    }
}
