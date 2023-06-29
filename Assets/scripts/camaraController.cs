using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraController : MonoBehaviour
{   
    public GameObject characterControler;
    
    void Update()
    {
        transform.position = new Vector3(characterControler.transform.position.x, transform.position.y, transform.position.z);
    }
}
