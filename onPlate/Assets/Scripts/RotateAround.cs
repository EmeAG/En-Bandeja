using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public GameObject rotateAroundPrefab;
    public Vector3 rotateAroundOffset;
    [Header("Grados/s")]
    public float rotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        CreateRotateAround();
        StartCoroutine(CheckPlateMovement());

    }
    private void CreateRotateAround()
    {
        Transform container = transform.parent;
        GameObject rotateAround = Instantiate<GameObject>(rotateAroundPrefab, container, false);
        this.transform.SetParent(rotateAround.transform);
        rotateAround.transform.SetParent(container);
        //Aplico el offset
        rotateAround.transform.localPosition += rotateAroundOffset;
        this.transform.localPosition -= rotateAroundOffset;
    }


    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator CheckPlateMovement()
    {
        do
        {
            float horiz = Input.GetAxis("Horizontal");
            if (horiz != 0.0f)
            {
                PlateRotation(horiz);
            }
            yield return null;
        } while (true);
    }

    public void PlateRotation(float dir)
    {
        this.transform.parent.RotateAround(this.transform.parent.localPosition, new Vector3(0, 0, dir).normalized, rotSpeed * Time.deltaTime);
    }

    public void PlateMovement()
    {

    }

}