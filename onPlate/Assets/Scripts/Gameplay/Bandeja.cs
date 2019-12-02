using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandeja : MonoBehaviour
{
    public float posX, posAnt;
    public float ajusteMovimiento;
    public float auxAngle, maxAngle;
    public Vector3 initRotation;

    // Start is called before the first frame update
    void Start()
    {
        initRotation = transform.eulerAngles;
        posX = Input.mousePosition.x;
        posAnt = Input.mousePosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.transform.Find("/GestionGameplay").GetComponent<GestionGameplay>().getPaused())
        {
            if (posAnt < 0)
            {
                posAnt = Input.mousePosition.x;
            }
            auxAngle = transform.eulerAngles.y;
            posX = Input.mousePosition.x;
            transform.Rotate(new Vector3(0.0f, calculoAngulo(posAnt, posX), 0.0f));
            posAnt = posX;
        }
        else
        {
            posAnt = -1;
        }
            
    }

    float calculoAngulo(float a, float b)
    {
        float aux = (a-b) / ajusteMovimiento;
        if (auxAngle >= initRotation.y && auxAngle <= initRotation.y + maxAngle)
        {
            if ((initRotation.y+auxAngle + aux) >= initRotation.y+maxAngle)
            {
                aux = initRotation.y+ maxAngle - auxAngle;
            }
            return aux;
        }
        else
        {
            if ((initRotation.y+auxAngle + aux) <= (initRotation.y - maxAngle))
            {
                aux = (initRotation.y - maxAngle) - auxAngle;
            }
            return aux;
        }
    }

}
