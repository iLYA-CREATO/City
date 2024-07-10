using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class StatusConstruction : MonoBehaviour
{
    public GameObject selectedConstruction;

    public GameObject panelStatusConstruction;

    RaycastHit hit;
    public LayerMask layerMask;
    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Info();
        }
    }
    public void Info()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, layerMask) && selectedConstruction == null)
        {
            Debug.Log("Hit an object: " + hit.collider.gameObject.name);
            if (hit.collider.tag == "Construction")
            {
                selectedConstruction = hit.collider.gameObject;
                OpenInterfaceObject(true);
            }
        }
        else if (selectedConstruction != null)
        {
            selectedConstruction = null;
            OpenInterfaceObject(false);
        }
    }

    // Основные методы информации выбраного объекта
    public void OpenInterfaceObject(bool activ)
    {
        panelStatusConstruction.SetActive(activ);
    }
}


