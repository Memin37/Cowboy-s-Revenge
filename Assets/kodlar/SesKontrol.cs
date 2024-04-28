using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesKontrol : MonoBehaviour
{
    [SerializeField]
    AudioClip tasPatlama = default;
    [SerializeField]
    AudioClip ates = default;
    [SerializeField]
    AudioClip ficiPatlama = default;
    [SerializeField]
    AudioClip yenidenDoldur = default;
    [SerializeField]
    AudioClip vurulmaSesi = default;
    [SerializeField]
    AudioClip kaktusKirilma = default;

    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Ates() 
    {
        
        audioSource.PlayOneShot(ates,0.2f);
    }
    public void FiciPatlama()
    {
        audioSource.PlayOneShot(ficiPatlama,0.2f);
    }
    public void TasPatlama()
    {
        audioSource.PlayOneShot(tasPatlama,0.5f);
    }
    public void YenidenDoldur()
    {
        audioSource.PlayOneShot(yenidenDoldur,0.6f);
    }
    public void VurulmaSesi() 
    {
        audioSource.PlayOneShot(vurulmaSesi,1);
    }
    public void KaktusKirilma() 
    {
        audioSource.PlayOneShot(kaktusKirilma);
    }
}
