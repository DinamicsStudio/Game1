using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    public GameObject player;
    private Transform tr;
    public float range;

    private void Start()
    {
        tr = player.GetComponent<Transform>();
    }
    private void Update()
    {
        Vector3 posi = new Vector3(tr.position.x, 10f, tr.position.z+range);
        transform.position = posi;
    }
}
