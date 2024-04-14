using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject ImageInInventory;
    [SerializeField] private int _iD;
    [SerializeField] private int _maxInStack;

    [SerializeField] private Inventory _inventory;
    private bool _usable;

    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null )
        {
            _usable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _usable = false;
    }

    private void Update()
    {
        if(_usable && Input.GetKeyDown(KeyCode.E))
        {
            PickUping(_maxInStack,_iD,_inventory,ImageInInventory,true);
        }
    }
    
    public void PickUping(int maxInStack,int iD,Inventory inventory,GameObject imageInInventory, bool del)
    {
        for (int i = 0; i < _inventory._slots.Length; i++)
        {
            if ((inventory.ItemID[i] == iD && inventory.SlotStack[i] > inventory.ObjCountInSlot[i]))
            {
                inventory.ItemID[i] = iD;
                inventory.SlotStack[i] = maxInStack;
                inventory.ObjCountInSlot[i]++;
                //Instantiate(ImageInInventory, _inventory._slots[i].transform);
                if(del)Destroy(gameObject);
                Debug.Log(11);
                break;

            }
            else if (inventory.ItemID[i] == -1)
            {
                inventory.ItemID[i] = iD;
                inventory.SlotStack[i] = maxInStack;
                inventory.ObjCountInSlot[i]++;
                Instantiate(imageInInventory, inventory._slots[i].transform);
                if(del)Destroy(gameObject);
                break;
            }
        }
    }
}
