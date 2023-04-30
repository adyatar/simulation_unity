using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabeRotation : MonoBehaviour
{
    float rotationspd = 1f;

    private void OnMouseDrag()
    {
        if(Input.GetMouseButton(1))
        {
           
            if (Collision.enter == true)
            { 
                Debug.Log("right click");
                float xaxis = Input.GetAxis("Mouse X") * rotationspd;
                float yaxis = Input.GetAxis("Mouse Y") * rotationspd;
                transform.Rotate(Vector3.down, xaxis);
                transform.Rotate(Vector3.right, yaxis);
            }
        }
      
    }
}
