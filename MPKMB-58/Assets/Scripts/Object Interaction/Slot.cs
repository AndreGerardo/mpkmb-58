using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField]
    private int id;
    public int ID
    {
        get { return id; }
        set { id = value; }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }
    /// <summary>
    /// Panggil ketika kita ingin interaksi dengan item ini
    /// </summary>
    public void Interact(){
        Debug.Log("ItemCheck");
        inventory.InteractWithItem(id);
    }
}
