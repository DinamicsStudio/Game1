using System.Runtime.CompilerServices;
using UnityEngine;

public class Client : MonoBehaviour
{
    //public GameObject[] productImages; // для облочка
    [SerializeField] private GameObject orderBanner;
    [SerializeField] private float leaveTime; //через сколько уйдет
    private SitTables _sitTables;
    [SerializeField] private float speed;
    private bool isOrdered = false;
    [SerializeField] private Transform _orderPos;
    private bool _usable;
    private float _isOrdering = 1;
    public int _tableNumber, _firstway = 1, _secondway = 0;
    private bool _isEat = false;
    DialogueSimple dialogueSystem;


    private void Start()
    {
        _sitTables = GameObject.FindGameObjectWithTag("EatTables").GetComponent<SitTables>();
        _orderPos = GameObject.FindGameObjectWithTag("OrderPos").GetComponent<Transform>();
        dialogueSystem = FindAnyObjectByType<DialogueSimple>();

    }

    void Update()
    {

        if (isOrdered == false && _isEat == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _orderPos.position, speed * Time.deltaTime * _isOrdering);
            if (Vector3.Distance(transform.position, _orderPos.position) <= 0.2f) _isOrdering = 0;
            if (Input.GetKeyDown(KeyCode.E) && _usable && _isOrdering == 0)
            {
                dialogueSystem.StartDialogue();
            }
            if (dialogueSystem.isEnded == true)
            {
                isOrdered = true;
                orderBanner.SetActive(true);
                dialogueSystem.isEnded = false;
            }
        }
        if (isOrdered && _isEat == false)
        {
            //Debug.Log(Vector3.Distance(transform.position, _sitTables.WayToTable[_tableNumber * 2+1].position));
            //Debug.Log(_secondway);
            transform.position = Vector3.MoveTowards(transform.position, _sitTables.WayToTable[_tableNumber * 2].position, speed * Time.deltaTime * _firstway);
            if (Vector3.Distance(transform.position, _sitTables.WayToTable[_tableNumber * 2].position) <= 0.6f) { _secondway = 1; _firstway = 0; }
            transform.position = Vector3.MoveTowards(transform.position, _sitTables.WayToTable[_tableNumber * 2 + 1].position, speed * Time.deltaTime * _secondway);
            if (Vector3.Distance(transform.position, _sitTables.WayToTable[(_tableNumber * 2) + 1].position) <= 0.6f) { _secondway = 0; _firstway = 0; }
            if (_secondway + _firstway == 0) { _isEat = true; } //orderBanner.SetActive(false);

        }
        //Debug.Log(isOrdered); 
        //Debug.Log(_isEat);
        

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Player>()!=null)
        {
            _usable = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            _usable = false;
        }
    }

    public void GetNumberOfTable(int num)
    {
        _tableNumber = num;
    }
}