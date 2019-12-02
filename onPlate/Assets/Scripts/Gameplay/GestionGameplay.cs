using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GestionGameplay : MonoBehaviour
{
    [SerializeField] float vel;
    bool paused, fin;
    int ini;//, pto;
    float pto;
    float startTimePto, startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        ini = 0;
        pto = 0;
        paused = true;
        fin = false;
        GetComponentInChildren<SpawnObstaculos>().setVel(vel);
        GetComponentInChildren<gestionPasillos>().setVel(vel);
        gameObject.transform.Find("Empezar").GetComponentInChildren<Canvas>().gameObject.SetActive(true);
        gameObject.transform.Find("HUD").GetComponentInChildren<Canvas>().gameObject.SetActive(true);
        gameObject.transform.Find("Paused").GetComponentInChildren<Canvas>().gameObject.SetActive(false);
        gameObject.transform.Find("Continuar").GetComponentInChildren<Canvas>().gameObject.SetActive(false);
        gameObject.transform.Find("FinGameplay").GetComponentInChildren<Canvas>().gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!fin)
        {
            gameObject.transform.Find("HUD").GetComponentInChildren<Text>().text = pto + " ptos";
            if (ini == 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    paused = false;
                    ini++;
                    startTimePto = Time.time;
                    gameObject.transform.Find("Empezar").GetComponentInChildren<Canvas>().gameObject.SetActive(false);
                }
            }
            else
            {
                if (!paused)
                {
                    if (Time.time - startTimePto >= 0.1f)
                    {
                        pto++;
                        startTimePto = Time.time;
                    }


                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        paused = true;
                        gameObject.transform.Find("Paused").GetComponent<Canvas>().gameObject.SetActive(true);
                    }
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(0);
            }
        }
        
    }

    public void setPaused(bool p)
    {
        paused = p;
    }

    public bool getPaused()
    {
        return paused;
    }

    public void FinGamePlay()
    {
        gameObject.transform.Find("FinGameplay").GetComponentInChildren<Canvas>().gameObject.SetActive(true);
        gameObject.transform.Find("FinGameplay/Panel/Puntos").GetComponent<Text>().text = pto + " ptos";
        gameObject.transform.Find("HUD").GetComponentInChildren<Canvas>().gameObject.SetActive(false);
        fin = true;
        paused = true;

    }

    public void Continuar()
    {
        gameObject.transform.Find("Continuar").GetComponent<Canvas>().gameObject.SetActive(true);
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
