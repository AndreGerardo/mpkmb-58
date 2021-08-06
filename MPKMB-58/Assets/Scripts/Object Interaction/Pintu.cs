using UnityEngine.SceneManagement;
using UnityEngine;

public class Pintu : Item
{
    // Overwrite fungsi takeitem milik item dengan menggunakan "override"
    public override void Interact(){
        if(inventory.HasItem("key")){
            if (inventory.CheckActiveItem("key"))
            {
                gameObject.GetComponent<DialogueActivator>().UpdateDialogueObject(null);
                NextLevel();
            } else {
                Debug.Log("Aku harus menggunakan item key!");
            }
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

}
