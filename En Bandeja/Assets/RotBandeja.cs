using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotBandeja : MonoBehaviour
{
    [Range(0.0f, 100.0f)]
    public float rotSpeed;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float haxis=  Input.GetAxis("Horizontal");
       // rb.angularVelocity = new Vector3(0, 0, -haxis * rotSpeed);
        rb.angularVelocity = new Vector3(0, -haxis * rotSpeed, 0);
        
        //this.transform.Rotate(new Vector3(0,0,-haxis* rotSpeed));
    }
}
