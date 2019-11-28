using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionPasillos : MonoBehaviour
{
    public float vel;
    public Pasillo[] pasillos;
    GameObject plane;
    public Vector3 dim;
    float espacio;

    // Start is called before the first frame update

    void Start()
    {
        plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        dim = pasillos[0].GetComponent<Renderer>().bounds.size;
        espacio = dim.z;
        
        for(int i = 0; i < pasillos.Length; i++)
        {
            if (i > 0)
            {
                Vector3 pos = pasillos[i - 1].transform.position;
                pos.z += espacio;
                pasillos[i].transform.position = pos;
            }
        }

        Vector3 planePos = plane.transform.position;
        planePos.z= pasillos[pasillos.Length - 1].transform.position.z;
        plane.transform.position = planePos;
        plane.transform.Rotate(new Vector3(0, -90, -90));
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < pasillos.Length; i++)
        {
            Vector3 pos = pasillos[i].transform.position;
            pos.z -= vel * Time.deltaTime;
            pasillos[i].transform.position=pos;
            if (pasillos[i].transform.position.z <= -espacio/2.0f)
            {
                colocarDetras(i);
            }
        }
    }
    void colocarDetras(int indx)
    {
        int aux = indx - 1;
        if (aux <0)
        {
            aux = pasillos.Length - 1;
        }
        Vector3 newPos = pasillos[aux].transform.position;
        newPos.z += espacio-0.2f;
        pasillos[indx].transform.position = newPos;
    }

    public Vector3 getPosSpawn()
    {
        return plane.transform.position;
    }

    public void setVel(float v)
    {
        vel = v;
    }
}
