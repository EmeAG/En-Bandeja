using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField] float alto, ancho;

    public Vector3 posVel = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name.Contains("(Clone)"))
        {
            if (!gameObject.transform.Find("/GestionGameplay").GetComponent<GestionGameplay>().getPaused())
            {
                transform.position -= posVel * Time.deltaTime;
                if (transform.position.z < -10f)
                {
                    Destroy(gameObject);
                }
            }
        }
        
    }

    public float getAncho()
    {
        return ancho;
    }

    public void setVel(float v)
    {
        posVel = new Vector3(0.0f, 0.0f, v);
    }

    public float getAlto()
    {
        return alto;
    }
}
