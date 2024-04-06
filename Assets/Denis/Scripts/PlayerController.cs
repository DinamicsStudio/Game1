using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public float dashDistance;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));
        transform.LookAt(worldPosition);

        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.velocity = moveInput * speed;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.MovePosition(rb.position + transform.forward * dashDistance);
        }
    }
}
