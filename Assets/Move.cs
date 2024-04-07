using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 15f;
    public float delay = 10f;



    void Start()
    {
        StartCoroutine(DestroyAfterDelay(delay));
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
     transform.Translate(Vector3.forward*speed*Time.deltaTime);  
        
        
    }
}
