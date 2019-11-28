using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionGameplay : MonoBehaviour
{
    [SerializeField] float vel;
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<SpawnObstaculos>().setVel(vel);
        GetComponentInChildren<gestionPasillos>().setVel(vel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
