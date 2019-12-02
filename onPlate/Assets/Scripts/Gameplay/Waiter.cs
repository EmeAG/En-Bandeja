using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waiter : MonoBehaviour
{
    public float speedMove, speedDash, forceMove, forceDash;
    Vector3 pos;
    float clickedA, clickedD, time;
    float timeDelay = 0.3f;
    bool dash;
    Rigidbody[] vasos;
    int numVasos;
    
    // Start is called before the first frame update
    void Start()
    {
        vasos= GetComponentsInChildren<Rigidbody>();
        numVasos = vasos.Length;
        dash = false;
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.transform.Find("/GestionGameplay").GetComponent<GestionGameplay>().getPaused())
        {
            checkDoublePress();
            gestionMovement();
            if (numVasos == 0)
            {
                GetComponentInParent<GestionGameplay>().FinGamePlay();
            }
        }
    }      

    public void updateVasos()
    {
        numVasos--;
    }
    
    void gestionMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (pos.x <= -3.5f)
            {
                pos.x = -3.5f;
            }
            else
            {
                if (dash)
                {
                    pos.x -= speedDash * Time.deltaTime;
                    foreach (Rigidbody r in vasos)
                    {
                        if(r!=null)
                            r.AddForce(new Vector3(+forceDash, 0, 0));
                    }
                }
                else
                {
                    pos.x -= speedMove * Time.deltaTime;
                    foreach (Rigidbody r in vasos)
                    {
                        if(r!=null)
                            r.AddForce(new Vector3(+forceMove, 0, 0));
                    }
                }
            }           
            transform.position = pos;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            if (dash)
            {
                clickedA = 0;
                dash = false;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (pos.x >= 3.5f)
            {
                pos.x = 3.5f;
            }
            else
            {
                if (dash)
                {
                    pos.x += speedDash * Time.deltaTime;
                    foreach (Rigidbody r in vasos)
                    {
                        if(r!=null)
                            r.AddForce(new Vector3(-forceDash, 0, 0));
                    }
                }
                else
                {
                    pos.x += speedMove * Time.deltaTime;
                    foreach (Rigidbody r in vasos)
                    {
                        if(r!=null)
                            r.AddForce(new Vector3(-forceMove, 0, 0));
                    }
                }
            }
            transform.position = pos;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            if (dash)
            {
                clickedD = 0;
                dash = false;
            }
        }
    }

    void checkDoublePress()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            clickedA++;
            if (clickedA == 1)
            {
                time = Time.time;
            }
        }
        if (!dash)
        {
            if (clickedA > 1 && Time.time - time < timeDelay)
                {
                    clickedA = 0;
                    time = 0;
                    dash = true;
                }
            else if (Time.time - time > timeDelay) clickedA = 0;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            clickedD++;
            if (clickedD == 1)
            {
                time = Time.time;
            }
        }
        if (!dash)
        {
            if (clickedD > 1 && Time.time - time < timeDelay)
            {
                clickedD = 0;
                time = 0;
                dash = true;
            }
            else if (Time.time - time > timeDelay) clickedD = 0;
        }
    }
}
