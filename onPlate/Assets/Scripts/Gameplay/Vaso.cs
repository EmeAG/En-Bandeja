using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaso : MonoBehaviour
{
    public Vector3 pos;
    // Start is called before the first frame update
    private void Start()
    {
        pos = transform.localPosition;
    }

    private void Update()
    {
        if (!gameObject.transform.Find("/GestionGameplay").GetComponent<GestionGameplay>().getPaused())
        {
            GetComponent<Rigidbody>().isKinematic = false;
            pos = transform.localPosition;
            if (pos.z < -0.5f)
            {
                Destroy(gameObject);
                GetComponentInParent<Waiter>().updateVasos();
            }
        }
        else
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        Destroy(gameObject,1f);
        GetComponentInParent<Waiter>().updateVasos();
    }
}
