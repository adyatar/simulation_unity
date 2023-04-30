using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag_rot : MonoBehaviour
{

    float rotationspd = 5f;
    Vector2 upDown;
    Vector2 leftRight;
    Rigidbody r;
    public float mouseSensitivity = 2f;
    public static bool selected = false;
    private Transform selectedObject;
    public void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                if (objectHit != null)
                {
                    selectedObject = objectHit;
                    Debug.Log("9stooo");
                    Debug.Log(hit.transform.name);
                    selectedObject = objectHit;
                    Debug.Log("mn l object" + objectHit.transform.name);
                   r = selectedObject.GetComponent<Rigidbody>();
                }
            }
        }
        // r = GetComponent<Rigidbody>();

        //click droit et gauche
        if (selectedObject != null)
        {
            if (this.transform.name == selectedObject.transform.name)
            {

                if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
                {
                        if (Collision.enter == true)
                        {
                         rotation();
                        }
                }
                if (Input.GetMouseButton(1) && !Input.GetMouseButton(0))
                {
                     r.useGravity = false;
                    y();
                }
                   if (!Input.GetMouseButton(1) && !Input.GetMouseButton(0))
                   {
                    r.useGravity = true;
                 }


                if (!Input.GetMouseButton(1) && Input.GetMouseButton(0))
                {
                    xz();
                }
            }
        } 
    }
    public void y()
    {
        upDown.y = selectedObject.transform.position.y;
        upDown.y += Input.GetAxis("Mouse Y") / 30;
        selectedObject.transform.position = new Vector3(selectedObject.transform.position.x, upDown.y, selectedObject.transform.position.z);
        Debug.Log("click droit : y");
    }
    public void xz()
    {
        leftRight.x = selectedObject.transform.position.x;
        leftRight.y = selectedObject.transform.position.z;
        leftRight.x -= Input.GetAxis("Mouse X") / 30;
        leftRight.y -= Input.GetAxis("Mouse Y") / 30;
        selectedObject.transform.position = new Vector3(leftRight.x, selectedObject.transform.position.y, leftRight.y);

        Debug.Log("click gauche : x & z");
    }
    public void rotation()
    {
        float xaxis = Input.GetAxis("Mouse X") * rotationspd;
        float yaxis = Input.GetAxis("Mouse Y") * rotationspd;
        selectedObject.transform.Rotate(Vector3.down, xaxis);
        selectedObject.transform.Rotate(Vector3.right, yaxis);
        Debug.Log("Rotation : x & y");
    }
}
