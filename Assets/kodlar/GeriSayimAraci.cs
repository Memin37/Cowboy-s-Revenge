using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeriSayimAraci : MonoBehaviour
{
    float toplamSure = 0;
    float gecenSure = 0;
    bool calisiyor = false;
    bool basladi = false;
    /// <summary>
    /// Süre ataması yapılan yer
    /// </summary>
    public float ToplamSure 
    {
        set
        {
            if (!calisiyor) 
            {
                toplamSure = value; 
            } 
        } 
    }
    /// <summary>
    /// Çalıştırma komutu
    /// </summary>
    public void Calistir() 
    {
        if (toplamSure > 0) 
        {
            calisiyor = true;
            basladi = true;
            gecenSure = 0;  
        }
    }
    /// <summary>
    /// Bitip bitmediğini kontrol ederiz
    /// </summary>
    public bool Bitti 
    {
        get 
        {
            return basladi && !calisiyor;
        }
    }
    void Update()
    {
        if (calisiyor) 
        {
            gecenSure += Time.deltaTime;
            if (gecenSure >= toplamSure) 
            {
                calisiyor = false;
            }
        }
    }
}
