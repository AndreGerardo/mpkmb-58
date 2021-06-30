using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Struct dari inventory ini untuk mempermudah unity editor, ignore saja dan lanjut ke bawah
    [System.Serializable]
    public struct ItemSlots {
        [SerializeField]
        private bool isFull;
        // Property di C#
        public bool IsFull
        {
            get { return isFull; }
            set { isFull = value; }
        }
        
        [SerializeField]
        private GameObject slot;
        public GameObject Slot
        {
            get { return slot; }
            set { slot = value; }
        }

        [SerializeField]
        private string itemName;
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
    }
    
    // Struct untuk representasi slot di inventory
    public ItemSlots[] itemSlots;    

    /// <summary>
    /// Hapus item dengan nama <paramref name="itemName"/>
    /// </summary>
    /// <returns>
    /// True jika item berhasil dihapus, false jika item tidak ditemukan.
    /// </returns>
    /// <param name="itemName"></param>
    public bool RemoveItem(string itemName)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if(itemSlots[i].ItemName == itemName){
                itemSlots[i].IsFull = false;
                itemSlots[i].ItemName = "";
                // Hapus UI pada slot tersebut
                foreach(Transform child in itemSlots[i].Slot.transform){
                    GameObject.Destroy(child.gameObject); 
                }
                Debug.Log($"Item {itemName} sukses dihapus!");
                return true;
            }
        }
        Debug.Log($"Item dengan nama {itemName} tidak ditemukan");
        return false;
    }

    /// <summary>
    /// Mengecek apakah kita mempunyai item dengan nama <paramref name="itemName"/>
    /// </summary>
    /// <param name="itemName"></param>
    /// <returns>
    /// true jika ada, 
    /// false jika tidak ada.
    /// </returns>
    public bool HasItem(string itemName){
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if(itemSlots[i].ItemName == itemName){
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Mencari index dari item dengan nama <paramref name="itemName"/>
    /// </summary>
    /// <param name="itemName"></param>
    /// <returns>int index dari item, -1 jika tidak ditemukan</returns>
    public int IndexOfItem(string itemName){
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if(itemSlots[i].ItemName == itemName){
                return i;
            }
        }
        return -1;
    }

    /// <summary>
    /// Trigger jika kita mengklik UI slot pada index <paramref name="slotIndex"/>
    /// </summary>
    /// <param name="slotIndex"></param>
    public void InteractWithItem(int slotIndex)
    {
        if(itemSlots[slotIndex].IsFull == true){
            string iName = itemSlots[slotIndex].ItemName;
            Debug.Log($"Click item dengan nama {iName}");
        }else{
            Debug.Log("Slot tersebut kosong");
        }
    }
}

