using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Client : MonoBehaviour
{
    //public GameObject[] productImages; // для облочка
    public GameObject orderBanner;
    public float leaveTime; //через сколько уйдет
    private GameObject[] sitTables; //ничего не надо указывать сдесь в инспекторe
    public float speed;
    public float stoppingDistanceForTable;
    public float stoppingDistanceForOrderPlace;
    private bool reachedTarget = false;
    private static bool isOrdered = false;
    private GameObject orderPos;
    private bool isColided;

    Collider colider;
    Rigidbody rb;

    private void Start()
    {
        ClientSpawner clientSpawner = FindAnyObjectByType<ClientSpawner>(); //find any так как вроде не будет больше такого obj
        sitTables = clientSpawner.tablesToSitForClient;
        orderPos = clientSpawner.orderPosToClient;
        colider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();

    }
    void Update()
    {
        if (isOrdered)
        {
            foreach (GameObject obj in sitTables)
            {
                if (obj.GetComponent<PlaceToSit>().isFree)
                {
                    if (!reachedTarget)
                    {
                        Vector3 direction = obj.transform.position - transform.position;
                        if (direction.magnitude <= stoppingDistanceForTable)
                        {
                            reachedTarget = true;
                            Debug.Log($"{obj}Is free");
                            obj.GetComponent<PlaceToSit>().isFree = false;
                            colider.isTrigger = true;
                            rb.isKinematic = true;
                            isOrdered = false;
                            obj.GetComponent<Collider>().isTrigger = true;
                            if (leaveTime <= 0)
                            {
                                Debug.Log("Client leave");
                                obj.GetComponent<PlaceToSit>().isFree = true;
                                Destroy(gameObject);
                                obj.GetComponent<Collider>().isTrigger = false;
                            }
                            leaveTime -= Time.deltaTime;
                        }
                        else
                        {
                            transform.Translate(direction.normalized * speed * Time.deltaTime);
                        }
                    }
                }
            }
        }
        if (!isOrdered)
        {
            if (orderPos.GetComponent<PlaceToSit>().isFree)
            {
                if (!reachedTarget)
                {
                    Vector3 direction = orderPos.transform.position - transform.position;
                    if (direction.magnitude <= stoppingDistanceForOrderPlace)
                    {
                        reachedTarget = true;
                        orderPos.GetComponent<PlaceToSit>().isFree = false;
                        colider.isTrigger = true;
                        rb.isKinematic = true;
                        isOrdered = false;
                    }
                    else
                    {
                        transform.Translate(direction.normalized * speed * Time.deltaTime);
                    }
                }
                
            }
            if (isColided && Input.GetKeyDown(KeyCode.E))
            {
                isColided = false;
                rb.isKinematic = false;
                colider.isTrigger = false;
                orderPos.GetComponent<PlaceToSit>().isFree = true;
                isOrdered = true;
                reachedTarget = false;
            }
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isColided = true;
            if(isOrdered) orderBanner.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isColided = false;
            if(isOrdered) orderBanner.SetActive(false);
        }
    }

}