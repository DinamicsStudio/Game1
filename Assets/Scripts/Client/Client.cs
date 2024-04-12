using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Client : MonoBehaviour
{
    //public GameObject[] productImages; // для облочка
    public GameObject orderBanner;
    public float leaveTime; //через сколько уйдет
    public GameObject[] sitTables; 
    public float speed;
    public float stoppingDistance;
    private bool reachedTarget = false;

    Collider colider;
    Rigidbody rb;

    private void Start()
    {
        ClientSpawner clientSpawner = FindAnyObjectByType<ClientSpawner>(); //find any так как вроде не будет больше такого obj
        sitTables = clientSpawner.tablesToSitForClient;
        colider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();

    }
    void Update()
    {
        leaveTime -= Time.deltaTime;
        foreach(GameObject obj in sitTables)
        {
            if (obj.GetComponent<PlaceToSit>().isFree)
            {
                if (!reachedTarget)
                {
                    Vector3 direction = obj.transform.position - transform.position;
                    if (direction.magnitude <= stoppingDistance)
                    {
                        reachedTarget = true;
                        Debug.Log($"{obj}Is free");
                        obj.GetComponent<PlaceToSit>().isFree = false;
                        colider.isTrigger = true;
                        rb.isKinematic = true;
                        obj.GetComponent<Collider>().isTrigger = true;
                        if(leaveTime <= 0)
                        {
                            Debug.Log("Client leave");
                            obj.GetComponent<PlaceToSit>().isFree = true;
                            Destroy(gameObject);
                            obj.GetComponent<Collider>().isTrigger = false;
                        }
                    }
                    else
                    {
                        transform.Translate(direction.normalized * speed * Time.deltaTime);
                    }
                }
            }
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            orderBanner.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            orderBanner.SetActive(false);
        }
    }


}
