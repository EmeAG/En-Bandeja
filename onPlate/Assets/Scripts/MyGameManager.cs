using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{
    #region Singleton
    private static MyGameManager gameManager = null;
    public static MyGameManager Instance_
    {
        get
        {
            return gameManager;
        }
    }

#endregion
    public SpawnManager mySpawnManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = this;
        Debug.Log("start de game manager");
        mySpawnManager.Start();
    }

}
