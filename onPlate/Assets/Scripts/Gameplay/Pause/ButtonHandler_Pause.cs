using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler_Pause : MonoBehaviour
{
    public void goMenu()
    {
        GetComponentInParent<Canvas>().gameObject.SetActive(false);
        GetComponentInParent<GestionGameplay>().GoMenu();
    }

    public void Continuar()
    {
        GetComponentInParent<Canvas>().gameObject.SetActive(false);
        GetComponentInParent<GestionGameplay>().Continuar();
    }
}
