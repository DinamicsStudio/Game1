using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 15f;

    
  
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
     transform.Translate(Vector3.forward*speed*Time.deltaTime);  
        
        
    }
}
