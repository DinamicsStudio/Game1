using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public float speed;
    public Camera cam;
    private Rigidbody rb;
    public float dashDistance;
    public Vector3 mousePos;
    public bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        /*mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 LookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(LookDir.x, LookDir.y) * Mathf.Rad2Deg;
        Quaternion.LookRotation(LookDir);*/

        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveInput.Normalize();
        rb.velocity = moveInput * speed;
        if (moveInput != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveInput); // ��������� ������� ������� � ������� ��������
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 15f * Time.deltaTime); // ������ ������������ �������� � ������� �������� ��������
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.MovePosition(rb.position + transform.forward * dashDistance);
        }
        
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded==true)
        {
            rb.AddForce(transform.up*1000,ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("floor") == true)
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("floor") == true)
        {
            isGrounded = false;
        }
    }
}

