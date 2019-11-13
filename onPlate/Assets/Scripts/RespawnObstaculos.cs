using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObstaculos : MonoBehaviour
{
    [SerializeField] Obstaculo[] obstaculos;
    [SerializeField] float tamPasillo, vel;
    float posAnt;
    List<Obstaculo> obsSig;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < obstaculos.Length; i++)
        {
            obstaculos[i].setVel(vel);
        }
        obsSig = new List<Obstaculo>();
        posAnt = tamPasillo / 2;

        obsSig = new List<Obstaculo>();
        obsSig = crearFila(0, -4.5f, 4.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    List<Obstaculo> crearFila(float posHueco,float posIn, float posFin) 
    {
        List<Obstaculo> obs = new List<Obstaculo>();
        Obstaculo o;
        float auxPos = posIn;
        int auxIndx = -1;
        while (auxPos<= posHueco - 0.5f)
        {
            auxIndx = elegirObstaculo(auxPos, posHueco - 0.5f);
            if (auxIndx >= 0)
            {
                o = Instantiate(obstaculos[auxIndx], new Vector3(auxPos + (obstaculos[auxIndx].getAncho() / 2), 0, 0), Quaternion.identity);
                obs.Add(o);
                auxPos += obstaculos[auxIndx].getAncho();
            }
            else
            {
                auxPos += 1;
            }

        }
        auxPos = posHueco + 0.5f;
        while (auxPos <= posFin)
        {
            auxIndx = elegirObstaculo(auxPos, posFin);
            if (auxIndx >= 0)
            {
                obs.Add(Instantiate(obstaculos[auxIndx], new Vector3(auxPos + (obstaculos[auxIndx].getAncho() / 2), 0, 0), Quaternion.identity));
                auxPos += obstaculos[auxIndx].getAncho();
            }
            else
            {
                auxPos += 1;
            }
        }
        return obs;
    }
    int elegirObstaculo(float posIn, float posFin)
    {
        float hayObjeto = Random.Range(0.0f, 100.0f);
        if (hayObjeto >= 0.0f)
        {
            List<int> aux = new List<int>();

            for (int i = 0; i < obstaculos.Length; i++)
            {
                if (obstaculos[i].getAncho() <= posFin - posIn)
                {
                    aux.Add(i);
                }
            }

            int objSeleccionado = (int)Random.Range(0.0f, aux.Count);
            foreach (int a in aux)
            {
                if (a == objSeleccionado) return a;
            }
            return -1;
        }
        else
        {
            return -1;
        }
    }
        
}
