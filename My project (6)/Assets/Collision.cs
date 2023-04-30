using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject per;
    static public bool enter = false;

    public void OnTriggerEnter(Collider other)
    {

        if(other.tag=="Player")
        {
               
           GameObject cam=other.transform.GetChild(1).gameObject;
            Debug.Log(cam.name);
            
            cam.transform.localPosition = new Vector3(-0.29f, 0.36f, 0.82f);
            cam.transform.localRotation = Quaternion.Euler(51, 0, 0);
            other.transform.localRotation = Quaternion.Euler(0, 180, 0);

            enter = true;
            Transform perto = per.transform.GetComponent<Transform>();
            perto.localPosition= new Vector3(1.157869f, 1.111139f, -1.036644f);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
           
            enter = false;
            GameObject cam = other.transform.GetChild(1).gameObject;

            cam.transform.localPosition = new Vector3(0,0.685f, 0);
        }
    }
}
