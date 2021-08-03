using UnityEngine;
using UnityEngine.SceneManagement;

//taro di main camera
public class SceneManagement : MonoBehaviour
{
    //pindah scene
    public void MoveScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //pindah ke scene selanjutnya
    }
}
