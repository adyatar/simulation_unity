using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xyz : MonoBehaviour
{
    // Start is called before the first frame update
   public float speed = 1f;

   /* void Update()
    {
        if (Input.GetMouseButton(1))
        { 
            // Rotate the object around its x and y axes
            float yaw = speed * Input.GetAxis("Mouse X");
        float pitch = speed * Input.GetAxis("Mouse Y");
        transform.Rotate(pitch, yaw, 0.0f);

        // Move the object along the z-axis
        float z = speed * Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(0.0f, 0.0f, z);
        }

    }*/
    void OnMouseDrag()
    {
        float x = Input.GetAxis("Mouse X") * speed;
        float y = Input.GetAxis("Mouse Y") * speed;
        transform.position = new Vector3(x, y, 0);
    }
}
