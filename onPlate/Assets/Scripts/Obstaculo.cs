using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField] float ancho;
    float vel;
    Vector3 posVel;
    // Start is called before the first frame update
    void Start()
    {
        posVel = new Vector3(0.0f, 0.0f, 0.0f);
        ancho = transform.GetComponent<MeshFilter>().mesh.bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += posVel;
    }

    public float getAncho()
    {
        return ancho;
    }

    public void setVel(float v)
    {
        posVel = new Vector3(0.0f, 0.0f, v);
    }
}
