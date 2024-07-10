using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject camera;

    public Camera mainCamera;

    public float newXPosition;
    public float newYPosition;
    public float newZPosition;

    public float speedVertical;

    public float moveSpeed = 0.1f;

    public Vector3 lastMousePos;
    private void Update()
    {
        PCController();
    }

    public void PCController()
    {
        UpDownCamPC();
        MoveCamPC();
    }

    private void UpDownCamPC()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            newYPosition -= speedVertical * Time.deltaTime;
            Debug.Log("¬верх");
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            newYPosition += speedVertical * Time.deltaTime;
            Debug.Log("¬низ");
        }
        else if (Input.GetAxis("Mouse ScrollWheel") == 0)
        {
            newYPosition = 0;
        }
        camera.transform.position += new Vector3(0f, newYPosition, 0f);
    }

    private void MoveCamPC()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 delta = mainCamera.ScreenToViewportPoint(Input.mousePosition - lastMousePos);
            camera.transform.position += new Vector3(-delta.x * moveSpeed, 0f, -delta.y * moveSpeed);
            lastMousePos = Input.mousePosition;
        }
    }
}
