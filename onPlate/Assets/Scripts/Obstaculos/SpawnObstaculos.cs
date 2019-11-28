using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstaculos : MonoBehaviour
{
    [SerializeField] Obstaculo[] obstaculos;
    [SerializeField] int tamPasillos;
    [SerializeField] float vel;
    float offset;
    List<Obstaculo> obsSig;
    float posObstaculos, posibilidadHueco;
    // Start is called before the first frame update
    void Start()
    {
        posibilidadHueco = 50.0f;
        StartCoroutine(Spawner());
        posObstaculos = 50;
        offset = 0.2f;
        for(int i = 0; i < obstaculos.Length; i++)
        {
            obstaculos[i].setVel(vel);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<Obstaculo> crearFila(float posHueco, float posIn, float posFin)
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
                obs.Add(Instantiate(obstaculos[auxIndx], new Vector3(auxPos + (obstaculos[auxIndx].getAncho() / 2.0f), obstaculos[auxIndx].getAlto(), posObstaculos),obstaculos[auxIndx].transform.rotation));
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

    IEnumerator Spawner()
    {
        while (true)
        {
            
            crearFila((int)(Random.Range(0.0f,tamPasillos)-3.5f), -3.5f, 3.5f);
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
