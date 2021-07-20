using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [System.Serializable]
    public struct ActiveItem {
        [SerializeField]
        private bool hasActiveItem;
        public bool HasActiveItem {
            get { return hasActiveItem; }
            set { hasActiveItem = value; }
        }

        [SerializeField]
        private int itemActiveIndex;
        public int ItemActiveIndex {
            get { return itemActiveIndex; }
            set { itemActiveIndex = value; }
        }
    }

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
    public ActiveItem activeItem;

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
                activeItem.HasActiveItem = false;
                itemSlots[i].Slot.GetComponent<Image>().color = new Color32(255,255,255,255);

                itemSlots[i].IsFull = false;
                itemSlots[i].ItemName = "";
                // Hapus UI pada slot tersebut
                foreach(Transform child in itemSlots[i].Slot.transform){
                    GameObject.Destroy(child.gameObject); 
                }
                RapihkanItem(i);
                Debug.Log($"Item {itemName} sukses dihapus!");
                return true;
            }
        }
        Debug.Log($"Item dengan nama {itemName} tidak ditemukan");
        return false;
    }

    private void RapihkanItem(int i){
        if (i == itemSlots.Length-1 || !itemSlots[i+1].IsFull){
            return;
        } else {
            Transform child = itemSlots[i+1].Slot.transform.GetChild(0);
            child.gameObject.GetComponent<Slot>().ID--;
            child.SetParent(itemSlots[i].Slot.transform, false);
            child = itemSlots[i].Slot.transform;
            itemSlots[i].IsFull = true;
            itemSlots[i+1].IsFull = false;
            RapihkanItem(i+1);
        }
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
    /// Mengecek apakah kita sedang menggunakan item dengan nama <paramref name="itemName"/>
    /// </summary>
    /// <param name="itemName"></param>
    /// <returns>
    /// true jika iya, 
    /// false jika tidak.
    /// </returns>
    public bool CheckActiveItem(string itemName){
        if (itemSlots[activeItem.ItemActiveIndex].ItemName == itemName && activeItem.HasActiveItem){
            return true;
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
            
            if (!activeItem.HasActiveItem) {
                itemSlots[slotIndex].Slot.GetComponent<Image>().color = new Color32(255,255,0,255);
                activeItem.HasActiveItem = true;
                activeItem.ItemActiveIndex = slotIndex;
            } else {
                itemSlots[activeItem.ItemActiveIndex].Slot.GetComponent<Image>().color = new Color32(255,255,255,255);
                if (activeItem.ItemActiveIndex == slotIndex) {
                    activeItem.HasActiveItem = false;
                } else {
                    itemSlots[slotIndex].Slot.GetComponent<Image>().color = new Color32(255,255,0,255);
                    activeItem.ItemActiveIndex = slotIndex;
                }
            }

        }else{
            Debug.Log("Slot tersebut kosong");
        }
    }
}

