using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 15f;
    public float destroyTime = 10f;
    
  
    void Start()
    {
        Invoke("DestroyObject", destroyTime);
    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
     transform.Translate(Vector3.forward*speed*Time.deltaTime);  
        
        
    }
}
