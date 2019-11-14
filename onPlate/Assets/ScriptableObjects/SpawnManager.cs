using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnManager")]
public class SpawnManager : ScriptableObject
{
    public float worldSpeed;
    public float timeToSpawn;
    RespawnObstaculos spawner;
    public GameObject playerRef;
    public bool spawnObjects;
    Camera myCamera;

    public void Start()
    {
        Debug.Log("start method from SpawnManager");
        myCamera = Camera.main;
        spawner = RespawnObstaculos.Instance_;
        playerRef = GameObject.Find("player");

        Debug.Log("respawnObstaculos vale: " + RespawnObstaculos.Instance_);
        spawner.startSpawn(timeToSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Foo()
    {
        Debug.Log("Foo");
    }
}
