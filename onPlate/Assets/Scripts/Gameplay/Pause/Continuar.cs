using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Continuar : MonoBehaviour
{
    float startTime;
    int t;
    // Start is called before the first frame update
    void Start()
    {
        startTime = -1;
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<Canvas>().gameObject.active)
        {
            gameObject.transform.Find("Panel/Text").GetComponent<Text>().text = ""+(3 - t);
            if (startTime < 0)
            {
                startTime = Time.time;
            }
            else
            {
                if (Time.time - startTime >= 1f)
                {
                    startTime = Time.time;
                    t++;
                    if (t == 3)
                    {
                        gameObject.transform.Find("/GestionGameplay").GetComponent<GestionGameplay>().setPaused(false);
                        GetComponent<Canvas>().gameObject.SetActive(false);
                        t = 0;
                        startTime = -1;
                    }
                }
            }
        }
    }
}
