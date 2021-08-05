using UnityEngine.SceneManagement;
using UnityEngine;

public class Pintu : Item
{
    // Overwrite fungsi takeitem milik item dengan menggunakan "override"
    public override void Interact(){
        if(inventory.HasItem("key")){
            if (inventory.CheckActiveItem("key")){
                GetComponent<SceneManagement>().NextScene();
            } else {
                Debug.Log("Aku harus menggunakan item key!");
            }
        }
    }

}
