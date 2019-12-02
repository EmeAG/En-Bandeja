using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstaculos : MonoBehaviour
{
    [SerializeField] Obstaculo[] obstaculos;
    [SerializeField] int tamPasillos;
    [SerializeField] float vel;
    float offset,timeStart, auxTime, timeSpawn;
    float posObstaculos, posibilidadHueco;
    // Start is called before the first frame update
    void Start()
    {
        timeSpawn = 3.5f;
        timeStart = -1;
        auxTime = -1;
        posibilidadHueco = 50.0f;
        posObstaculos = 50;
        offset = 0.2f;
        for(int i = 0; i < obstaculos.Length; i++)
        {
            obstaculos[i].setVel(vel);
        }

        crearFila((int)(Random.Range(0.0f, tamPasillos) - 3.5f), -3.5f, 3.5f, 18.3191f);
        crearFila((int)(Random.Range(0.0f, tamPasillos) - 3.5f), -3.5f, 3.5f, 28.85141f);
        crearFila((int)(Random.Range(0.0f, tamPasillos) - 3.5f), -3.5f, 3.5f, 39.36765f);
    }

    // Update is called once per frame
    void Update()
    {
        Spawner();
    }

    public List<Obstaculo> crearFila(float posHueco, float posIn, float posFin, float posObstaculos)
    {
        List<Obstaculo> obs = new List<Obstaculo>();
        Obstaculo o;
        float auxPos = posIn;
        int auxIndx = -1;
        while (auxPos <= posHueco - 0.7f)
        {
            auxIndx = elegirObstaculo(auxPos, posHueco - 0.7f);
            if (auxIndx >= 0)
            {
                o = Instantiate(obstaculos[auxIndx], new Vector3(auxPos + (obstaculos[auxIndx].getAncho() / 2.0f), obstaculos[auxIndx].getAlto(), posObstaculos), obstaculos[auxIndx].transform.rotation);
                obs.Add(o);
                auxPos += obstaculos[auxIndx].getAncho()+offset;
            }
            else
            {
                auxPos += 1;
            }

        }
        auxPos = posHueco + 0.7f;
        while (auxPos <= posFin)
        {
            auxIndx = elegirObstaculo(auxPos, posFin);
            if (auxIndx >= 0)
            {
                o = Instantiate(obstaculos[auxIndx], new Vector3(auxPos + (obstaculos[auxIndx].getAncho() / 2.0f), obstaculos[auxIndx].getAlto(), posObstaculos), obstaculos[auxIndx].transform.rotation);
                obs.Add(o);
                auxPos += obstaculos[auxIndx].getAncho()+offset;
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
        if (hayObjeto >= posibilidadHueco)
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

    void Spawner()
    {
        if (!gameObject.transform.Find("/GestionGameplay").GetComponent<GestionGameplay>().getPaused())
        {
            if (timeStart ==-1)
            {
                timeStart = Time.time;
            }
            else if (timeStart == -2)
            {
                timeStart = Time.time - auxTime;
            }
            if (Time.time - timeStart >= timeSpawn)
            {
                crearFila((int)(Random.Range(0.0f, tamPasillos) - 3.5f), -3.5f, 3.5f, posObstaculos);
                timeStart = Time.time;
            }
        }
        else
        {
            if (timeStart >= 0)
            {
                auxTime = Time.time - timeStart;
                timeStart = -2;
            }
        }
    }

    IEnumerator Spawner2()
    {
        while (!gameObject.transform.Find("/GestionGameplay").GetComponent<GestionGameplay>().getPaused())
        {
            
            crearFila((int)(Random.Range(0.0f,tamPasillos)-3.5f), -3.5f, 3.5f, posObstaculos);
            yield return new WaitForSeconds(3.5f);
        }          
    }

    public void setVel(float v)
    {
        vel = v;
        for(int i = 0; i < obstaculos.Length; i++)
        {
            obstaculos[i].setVel(v);
        }
    }
}
