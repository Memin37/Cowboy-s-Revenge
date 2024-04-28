using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareket: MonoBehaviour
{
    Rigidbody2D fizik;
    float horizontal;
    float vertical;
    
    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();

    }

    
    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(horizontal, 0, vertical);
        fizik.AddForce(vec);
    }
}
