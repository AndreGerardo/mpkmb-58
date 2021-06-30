using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contoh jika object butuh script khusus
// maka kita akan inherit dari Item
public class Book : Item
{
    // Book akan mengganti sprite jika mempunyai object pen di inventory
    bool hasBeenNoted = false;
    public Sprite notedBookSprite;
    // Overwrite fungsi takeitem milik item dengan menggunakan "override"
    public override void Interact(){
        if(inventory.HasItem("pen") && !hasBeenNoted){
            Debug.Log("Buku Telah Ditulis");
            hasBeenNoted = true;
            Tulis();
        } else if(!inventory.HasItem("pen")) {
            Debug.Log("Inventory tidak berisi object bernama 'pen'");
        } else{
            Debug.Log("Buku sudah dicatat");
        }
    }
    private void Tulis(){
        gameObject.GetComponent<SpriteRenderer>().sprite = notedBookSprite;
        inventory.RemoveItem("pen");
    }
}
