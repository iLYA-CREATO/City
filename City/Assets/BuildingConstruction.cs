using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuildingConstruction : MonoBehaviour
{
    [SerializeField] private GameObject aCreateConstruction;
    private Transform CreateCatolog; // Выбор места создания

    [SerializeField] private GameObject aPlanCreate;

    public void Update()
    {
        // Костыля для стройки
        if (Input.GetKeyUp(KeyCode.Q) && aPlanCreate == null)
        {
            aPlanCreate = Instantiate(aCreateConstruction, CreateCatolog);
        }

        // Сама стройка
        if (aPlanCreate == null)
        {
            
        }
        else
        {
            Creator();
        }
    }

    public void Creator()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 intersectionPoint = hit.point;

            aPlanCreate.transform.position = new Vector3(intersectionPoint.x, 0f, intersectionPoint.z);
            // Do something with the object that was hit
            if (Input.GetMouseButtonDown(0))
            {
                aPlanCreate = null;
            }
            else if (Input.GetMouseButtonDown(1))
            {
                Destroy(aPlanCreate);

            }
        }
    }
}
