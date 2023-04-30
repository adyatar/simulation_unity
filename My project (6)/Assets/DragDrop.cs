using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public float doubleClickTime = 0.3f;
    public float lastClickTime;
    Vector3 offset;
    public bool selected = false;
    public GameObject clicked;
    public bool hrek = false;
   
    private void Start()
    {
        hrek = false;
 
    
    }
    /*
     public Rigidbody rb;

    void Start()
    {
        // Disable gravity for the Rigidbody
        rb.useGravity = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            // Toggle the use of gravity for the Rigidbody
            rb.useGravity = !rb.useGravity;
        }
    }
     */

    private void Update()
    {
    
        //GameObject gris = GameObject.FindWithTag("gris");
        // Create a Ray from the mouse position.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Check if the Ray hit a Collider.
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
      /*  if (Physics.Raycast(ray, out hit))
        {
            // Get the GameObject that was hit.
           

            // Do something with the GameObject.   
        }*/

        if (Input.GetMouseButtonDown(0))
        {
            GameObject gris = hit.collider.gameObject;

            if (Time.time-lastClickTime<doubleClickTime)
            {
                if(selected==false)
                {
                    //desactiver gravity
                    Rigidbody rb = gris.GetComponent<Rigidbody>();
                    rb.useGravity = false;
                   
                    gris.transform.position = new Vector3(gris.transform.position.x, 0.989f, transform.position.z);
                    //   transform.position = new Vector3(0.953f, 1.2f, -1.808f);
                    clicked = this.gameObject;
                    Debug.Log(clicked.tag);
                    hrek = true;
                   
                    selected = true;
                }
                else {
                    Rigidbody rb = gris.GetComponent<Rigidbody>();
                    rb.useGravity = true;
                    selected = false;
                    // transform.position = new Vector3(0.953f, 0.898f, -1.808f);
                    hrek = false;
                 
                    gris.transform.position = new Vector3(gris.transform.position.x, 0.889f, gris.transform.position.z);
                }
                
            }
            else
            {
                lastClickTime = Time.time;
            }
        }
    }
    void OnMouseDown()
    {
        
            Debug.Log(hrek);if(hrek==true)
        offset = transform.position - MouseWorldPosition();
    }
    void OnMouseDrag()
    {
        
            Debug.Log(hrek);if (hrek == true)
            transform.position = MouseWorldPosition() + offset;
    }
    Vector3 MouseWorldPosition()
    {
        var mouseScreenpos = Input.mousePosition;
        mouseScreenpos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenpos);
    }
}
